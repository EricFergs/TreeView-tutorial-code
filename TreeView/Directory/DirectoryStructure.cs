
using System.IO;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Linq;

namespace TreeView
{
    public static class DirectoryStructure
    {

        public static List<DirectoryItem> GetLogicalDrives()
        {
             return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive}).ToList();
             
        }

        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {

            var items = new List<DirectoryItem>();
            

            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder}));
            }
            catch { }



            

           

            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                    items.AddRange(fs.Select(f => new DirectoryItem {FullPath = f, Type = DirectoryItemType.File}));
            }
            catch
            {

            }
            
            return items;
        }
        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;
            var normalizedPath = path.Replace('/', '\\');

            var lastIndex = normalizedPath.LastIndexOf('\\');

            if (lastIndex <= 0)
                return path;

            return path.Substring(lastIndex + 1);
        }
    }
}
