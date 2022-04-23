using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsxGUI
{
    internal static class Utils
    {
        // Returns the human-readable file size for an arbitrary, 64-bit file size 
        // The default format is "0.### XB", e.g. "4.2 KB" or "1.434 GB"
        public static string GetBytesReadable(long size)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = size;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            return string.Format("{0:0.##} {1}", len, sizes[order]).Replace(",", ".");
        }

        public static char[] FORBIDDEN_NAME_CHARACTERS = { '/', '\\', '*', '?', ':', '"', '<', '>', '|' };
        public static bool isValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            if (string.Equals(name, "..")) return false;
            if (string.Equals(name, ".")) return false;

            foreach (var forbiddenChar in FORBIDDEN_NAME_CHARACTERS)
            {
                if (name.Contains(forbiddenChar)) return false;
            }
            return true;
        }

        public static string elapsedTime(DateTime start)
        {
            var delta = DateTime.UtcNow - start;

            return $"{delta.Hours.ToString("00")}h{delta.Minutes.ToString("00")}m{delta.Seconds.ToString("00")}s";
        }

        public static string plural(int count, string unit)
        {
            var suffix = count != 1 ? "s" : "";
            return $"{count} {unit}{suffix}";
        }

        public static string fsxJoinAndResolvePath(string path, params string[] segmentsToAdd)
        {
            while (path.StartsWith('/')) path = path.Substring(1);

            var segmentList = path.Split('/').ToList();

            foreach (var segment in segmentsToAdd)
            {
                foreach (var subseg in segment.Split('/'))
                {
                    if (string.Equals(subseg, ".."))
                    {
                        segmentList = segmentList.SkipLast(1).ToList();
                    }
                    else if (subseg.Length < 1 || string.Equals(subseg, "."))
                    {
                        // noop
                    }
                    else
                    {
                        // Append segment
                        segmentList.Add(subseg);
                    }
                }
            }

            return "/" + string.Join("/", segmentList.Where(x => !string.IsNullOrEmpty(x)));
        }
        public static IEnumerable<string> EnumerateFilesRecursive(string path)
        {
            foreach (var file in Directory.EnumerateFiles(path))
            {
                yield return file;
            }

            foreach (var subDir in Directory.EnumerateDirectories(path))
            {
                foreach (var subFile in EnumerateFilesRecursive(subDir))
                {
                    yield return subFile;
                }
            }
        }

        public static void LoadFileIcon(string name, ImageList smallImageList, ImageList largeImageList)
        {
            var ext = Path.GetExtension(name);

            if (smallImageList.Images.ContainsKey(ext))
                return;

            Icon smallIcon = Etier.IconHelper.IconReader.GetFileIcon(name, Etier.IconHelper.IconReader.IconSize.Small, false);
            Icon largeIcon = Etier.IconHelper.IconReader.GetFileIcon(name, Etier.IconHelper.IconReader.IconSize.Large, false);

            using (Bitmap bm = smallIcon.ToBitmap())
            {
                bm.MakeTransparent(Color.Transparent);
                smallIcon.Dispose();
                smallImageList.Images.Add(ext, bm);
            }

            using (Bitmap bm = largeIcon.ToBitmap())
            {
                bm.MakeTransparent(Color.Transparent);
                largeIcon.Dispose();
                largeImageList.Images.Add(ext, bm);
            }
        }

        public static void LoadFolderIcon(ImageList smallImageList, ImageList largeImageList)
        {
            if (smallImageList.Images.ContainsKey("<folder>"))
                return;

            Icon smallIcon = Etier.IconHelper.IconReader.GetFolderIcon(Etier.IconHelper.IconReader.IconSize.Small, Etier.IconHelper.IconReader.FolderType.Closed);
            Icon largeIcon = Etier.IconHelper.IconReader.GetFolderIcon(Etier.IconHelper.IconReader.IconSize.Large, Etier.IconHelper.IconReader.FolderType.Closed);

            using (Bitmap bm = smallIcon.ToBitmap())
            {
                bm.MakeTransparent(Color.Transparent);
                smallIcon.Dispose();
                smallImageList.Images.Add("<folder>", bm);
            }

            using (Bitmap bm = largeIcon.ToBitmap())
            {
                bm.MakeTransparent(Color.Transparent);
                largeIcon.Dispose();
                largeImageList.Images.Add("<folder>", bm);
            }
        }

        public static void OpenWindowsExplorer(string path)
        {
            Process.Start("explorer.exe", path);
        }
    }
}
