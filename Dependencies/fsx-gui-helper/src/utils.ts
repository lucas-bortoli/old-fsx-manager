import { Entry } from '@lucas-bortoli/libdiscord-fs'
import * as fsp from 'fs/promises'
import * as fs from 'fs'

const REMOTE_PATH_WITH_DRIVE_REGEXP = /^(.*[^\/])::(\/.*)$/m
const REMOTE_PATH_WITHOUT_DRIVE_REGEXP = /^(\/.*)$/
interface ParsedRemotePath { driveId: string, remotePath: string }

export default abstract class Utils {
    public static naturalSort(entries: [string, Entry][]): [string, Entry][] {
        return entries.sort((a, b) => {
            return (a[1].type + a[0]).localeCompare((b[1].type + b[0]), undefined, {numeric: true, sensitivity: 'base'})
        })
    }

    /**
     * Returns a Promise that resolves after a specified amount of time.
     */
    public static Wait = (ms: number): Promise<void> => {
        return new Promise(resolve => {
            setTimeout(resolve, ms)
        })
    }

    /**
     * Checks if a file exists in the filesystem.
     * @param path Path to file
     * @returns true if the file exists and is readable.
     */
    public static async fsp_fileExists(path: string): Promise<boolean> {
        try {
            await fsp.access(path, fs.constants.F_OK)
            return true
        } catch (error) {
            return false
        }
    }

    /**
     * Checks if a given path is remote. Remote paths start with "driveName::/"
     */
    public static isValidRemotePath(p: string): boolean {
        if (process.env.FSX_DRIVE)
            return !!p.match(REMOTE_PATH_WITHOUT_DRIVE_REGEXP)

        return !!p.match(REMOTE_PATH_WITH_DRIVE_REGEXP)
    }

    public static parseRemotePath(p: string): ParsedRemotePath {
        if (process.env.FSX_DRIVE) {
            const match = p.match(REMOTE_PATH_WITHOUT_DRIVE_REGEXP)
            return { driveId: process.env.FSX_DRIVE, remotePath: match[1].replaceAll('+', ' ') }
        }
    
        const match = p.match(REMOTE_PATH_WITH_DRIVE_REGEXP)
        return { driveId: match[1], remotePath: match[2].replaceAll('+', ' ') }
    }
}