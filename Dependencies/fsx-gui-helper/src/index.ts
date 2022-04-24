import * as fsp from 'fs/promises'
import * as fs from 'fs'
import * as path from 'path'
import * as pathp from 'path/posix'
import FileSystem, { Directory, Entry, File } from '@lucas-bortoli/libdiscord-fs'
import Utils from './utils.js'
import * as http from 'http'

const EncodeURLPointer = (link) => {
    return link
        .replace('https://cdn.discordapp.com/attachments/', '')
        .replace('/entry', '')
        .replaceAll('/', '.')
        .split('')
        .reverse()
        .join('')
}

let fileSystem: FileSystem = null;

/**
 * Initializes a filesystem object.
 * @param drivePath What drive id to use for the filesystem
 */
const openFileSystem = async (): Promise<FileSystem> => {
    if (fileSystem)
        return fileSystem;

    const libfs = new FileSystem(process.env.DISCORD_WEBHOOK)

    fileSystem = libfs
    
    let dataFile = path.resolve(process.env.FSX_DRIVE)

    // If file doesn't exist, proceed with an empty filesystem
    if (!await Utils.fsp_fileExists(dataFile)) {
        console.log('Filesystem doesn\'t exist, proceeding with an empty drive. Given path: ' + dataFile)
        return libfs
    }

    const fileStream = fs.createReadStream(dataFile)
    await libfs.loadDataFromStream(fileStream)

    console.log('Loaded filesystem from disk.')

    return libfs
}

const saveFileSystem = async (fsx: FileSystem): Promise<void> => {
    const fileStream = fs.createWriteStream(process.env.FSX_DRIVE)
    await fsx.writeDataToStream(fileStream)
}

const server = http.createServer(async (req, res) => {
    const doError = (msg: string) => {
        console.error(msg)
        res.writeHead(400)
        res.end(msg)
    }

    const doResponse = (output: string[][]) => {
        console.log(output)
        res.writeHead(200)
        res.end(
            output.map(row => 
                row.map(cell => encodeURIComponent(cell)).join(',')
            ).join('\n')
        )
    }

    console.log(`${req.method} ${req.url}`)

    if (!process.env.DISCORD_WEBHOOK)
        return doError('Environment variable DISCORD_WEBHOOK not set')

    let url: URL
    
    try {
        // Force it to be a valid URL
        // (req.url contains only the segment: /req?a=1&b=2...)
        url = new URL('http://0' + req.url)
    } catch(error) {
        return doError(error.toString())
    }

    const args: string[] = [ ...url.searchParams.getAll('arg') ]
    const argsWithoutFlags: string[] = args.filter(arg => !arg.startsWith('-'))

    // First argument will be the operation: upload/download/ls/rm/help...
    const operation = argsWithoutFlags[0]

    // The next two arguments will be the operands.
    const operand1 = argsWithoutFlags[1]
    const operand2 = argsWithoutFlags[2]

    if (!operation)
        return doError('No command given.')

    if (!'upload,download,cp,rm,mv,ls,save,get-headers,set-header,get-dir-tree,get-file-tree,exists,upload-entry'.split(',').includes(operation))
        return doError(`Invalid command: ${operation}`)
    
    if (operation === 'download') {
        // Validate remote path parameter
        if (!operand1)
            return doError('download: Missing parameters')

        if (!Utils.isValidRemotePath(operand1))
            return doError(`download: Invalid remote path ${operand1} (not in format driveId::/path/to/file)`)

        const { driveId, remotePath } = Utils.parseRemotePath(operand1)

        const fileSystem = await openFileSystem()
        const fileEntry = fileSystem.getEntry(remotePath)

        // Check if file exists before downloading it
        if (!fileEntry) {
            return doError(`File doesn't exist: ${driveId}::${remotePath}`)
        }

        // Can't download directories at once
        if (fileEntry.type === 'directory')
            return doError(`download: Invalid remote path ${operand1} (is a directory)`)

        const remoteFileStream = await fileSystem.createReadStream(remotePath)

        res.writeHead(200, {
            'Content-Length': fileEntry.size,
            'Content-Type': 'application/octet-stream'
        })

        remoteFileStream.pipe(res)
    }
    
    
    if (operation === 'upload') {
        // Validate remote path parameter
        if (!operand1)
            return doError('upload: Missing parameters')

        if (!Utils.isValidRemotePath(operand1))
            return doError(`upload: Invalid remote path ${operand1} (not in format driveId::/path/to/file)`)

        const { driveId, remotePath } = Utils.parseRemotePath(operand1)

        // Can't upload a file with to a directory path
        if (remotePath.endsWith('/'))
            return doError(`upload: Invalid remote path ${operand1} (is a directory)`)

        const customProps: Partial<File> = {}
        const propComment = args.find(arg => arg.startsWith('--comment='))

        if (propComment)
            customProps.comment = propComment.replace('--comment=', '')

        const fileSystem = await openFileSystem()
        const remoteFileStream = await fileSystem.createWriteStream(remotePath, true, customProps)

        req.pipe(remoteFileStream);

        remoteFileStream.once('finish', async () => {
            await Utils.Wait(1000);
            doResponse([])
        })

        return
    }
    
    
    if (operation === 'mv') {
        // Validate remote path parameter
        if (!operand1 || !operand2)
            return doError('mv: Missing parameters')
    
        if (!Utils.isValidRemotePath(operand1))
            return doError(`mv: Invalid remote path ${operand1} (not in format driveId::/path/to/file)`)
        if (!Utils.isValidRemotePath(operand2))
            return doError(`mv: Invalid remote path ${operand2} (not in format driveId::/path/to/file)`)
    
        const pathFrom = Utils.parseRemotePath(operand1)
        const pathTo = Utils.parseRemotePath(operand2)

        if (pathFrom.driveId !== pathTo.driveId)
            return doError (`mv: Unsupported cross-drive move operation (${pathFrom.driveId} -> ${pathTo.driveId})`)

        const fileSystem = await openFileSystem()

        if (!fileSystem.exists(pathFrom.remotePath))
            return doError(`mv: Source path not found (${pathFrom.driveId}::${pathFrom.remotePath})`)

        fileSystem.mv(pathFrom.remotePath, pathTo.remotePath)
        doResponse([])
    }
    
    
    if (operation === 'rm') {
        // Validate remote path parameter
        if (!operand1)
            return doError('rm: Missing parameters')

        if (!Utils.isValidRemotePath(operand1))
            return doError(`rm: Invalid remote path ${operand1} (not in format driveId::/path/to/file)`)
        
        const target = Utils.parseRemotePath(operand1)
        const fileSystem = await openFileSystem()

        if (!await fileSystem.exists(target.remotePath))
            return doError(`rm: Path not found (${target.driveId}::${target.remotePath})`)

        fileSystem.rm(target.remotePath)
        doResponse([])
    }
    
    
    if (operation === 'cp') {
        // Validate remote path parameter
        if (!operand1 || !operand2)
            return doError('cp: Missing parameters')

        if (!Utils.isValidRemotePath(operand1))
            return doError(`cp: Invalid remote path ${operand1} (not in format driveId::/path/to/file)`)
        if (!Utils.isValidRemotePath(operand2))
            return doError(`mv: Invalid remote path ${operand2} (not in format driveId::/path/to/file)`)
    
        const pathFrom = Utils.parseRemotePath(operand1)
        const pathTo = Utils.parseRemotePath(operand2)

        if (pathFrom.driveId !== pathTo.driveId)
            return doError(`cp: Unsupported cross-drive copy operation (${pathFrom.driveId} -> ${pathTo.driveId})`)

        const fileSystem = await openFileSystem()

        if (!fileSystem.exists(pathFrom.remotePath))
            return doError(`cp: Path not found (${pathFrom.driveId}::${pathFrom.remotePath})`)

        fileSystem.cp(pathFrom.remotePath, pathTo.remotePath)
        doResponse([])
    }

    if (operation === 'ls') {
        // Validate remote path parameter
        if (!operand1)
            return doError('ls: No operand')
        
        if (!Utils.isValidRemotePath(operand1))
            return doError(`ls: Invalid remote path ${operand1} (not in format driveId::/path/to/file)`)

        const path = Utils.parseRemotePath(operand1)
        const fileSystem = await openFileSystem()

        const target = fileSystem.getEntry(path.remotePath)

        if (!target)
            return doResponse([])

        if (target.type !== 'directory')
            return doError(`ls: Not a directory (${path.driveId}::${path.remotePath})`)

        const response: string[][] = []

        for (const [ name, child ] of Utils.naturalSort(Object.entries(target.items))) {
            if (child.type === 'directory') {
                const howManySubitems: number = Object.values(child.items).length
                response.push([ name, child.type, howManySubitems.toString() ])
            } else {
                response.push([ name, child.type, child.size.toString(), child.ctime.toString(), child.comment ])
            }
        }

        doResponse(response)
    }

    if (operation === 'get-dir-tree') {
        // Validate remote path parameter
        if (!operand1)
            return doError('get-dir-tree: No operand')
        
        if (!Utils.isValidRemotePath(operand1))
            return doError(`get-dir-tree: Invalid remote root path ${operand1} (not in format driveId::/path/to/file)`)

        const { remotePath } = Utils.parseRemotePath(operand1)
        const fileSystem = await openFileSystem()

        const root = fileSystem.getEntry(remotePath)

        if (!root)
            return doResponse([])

        if (root.type !== 'directory')
            return doError(`get-dir-tree: Not a directory (${remotePath})`)

        const response: string[][] = []

        type dir = [ string, number ];
        const getDirTree = (root: Directory, _prevPath?: string): dir[] => {
            _prevPath = _prevPath || '/'

            let paths: dir[] = [];
         
            for (const [ name, entry ] of Object.entries(root.items)) {
                if (entry.type === 'directory') {
                    let dir = entry as Directory
                    let thisPath = pathp.join(_prevPath, name)

                    paths.push([ thisPath, Object.values(dir.items).length ]);
                    paths.push(...getDirTree(dir, thisPath))
                }
            }

            return paths;
        }

        for (const dir of getDirTree(root, remotePath))
            response.push(dir.map(e => e.toString()))

        doResponse(response)
    }

    if (operation === "get-file-tree") {
        const { remotePath } = Utils.parseRemotePath(operand1)
        const fileSystem = await openFileSystem()
        const root = fileSystem.getEntry(remotePath)

        if (!root)
            return doResponse([])

        if (root.type !== 'directory')
            return doError(`get-file-tree: Not a directory (${remotePath})`)

        const response: string[][] = []

        await fileSystem.walkDirectory(root, async (fileEntry, filePath) => {
            response.push([ filePath.substring(1), fileEntry.size.toString() ])
        })

        doResponse(response)
    }

    if (operation === 'exists') {
        // Validate remote path parameter
        if (!operand1)
                return doError('download: Missing parameters')

        if (!Utils.isValidRemotePath(operand1))
            return doError(`download: Invalid remote path ${operand1} (not in format driveId::/path/to/file)`)

        const { driveId, remotePath } = Utils.parseRemotePath(operand1)

        const fileSystem = await openFileSystem()
        const fileEntry = fileSystem.getEntry(remotePath)

        // Check if file exists
        if (fileEntry) {
            return doResponse([[ "true" ]])
        } else {
            return doResponse([[ "false" ]])
        }
    }

    if (operation === "get-headers") {
        const fileSystem = await openFileSystem()

        const response: string[][] = []

        for (const [ key, value ] of fileSystem.header.entries()) {
            response.push([ key, value ]);
        }

        doResponse(response)
    }

    if (operation === "set-header") {
        if (!operand1 || !operand2)
            return doError('set-header: No operands')
        
        const key = operand1;
        const value = operand2;

        const fileSystem = await openFileSystem()

        fileSystem.header.set(key, value)

        doResponse([])
    }

    if (operation === "upload-entry") {
        const fileSystem = await openFileSystem()

        if (argsWithoutFlags.length <= 3)
            return doError("upload-entry: Not enough arguments")

        const uploadName = argsWithoutFlags[1]
        const uploadDesc = argsWithoutFlags[2]

        const entryUploadData: { entryName: string, entry: Entry }[] = []

        for (const entryPath of argsWithoutFlags.slice(3)) {
            const entry = fileSystem.getEntry(entryPath)

            if (!entry)
                return console.warn(`upload-entry: Entry ${entryPath} doesn't exist.`)

            entryUploadData.push({
                entryName: pathp.basename(entryPath), 
                entry: fileSystem.getEntry(entryPath)
            })
        }

        const shareLink = await fileSystem.uploadFileEntry(entryUploadData, { name: uploadName, description: uploadDesc, uploadDate: Date.now().toString() })

        doResponse([[ EncodeURLPointer(shareLink) ]])
    }
    
    if (operation === 'save') {
        const fileSystem = await openFileSystem()
        await saveFileSystem(fileSystem)
        doResponse([])
    }
})

server.listen(parseInt(process.env.PORT) || 38639, 'localhost')

console.log(`Listening on localhost:${parseInt(process.env.PORT) || 38639}`)