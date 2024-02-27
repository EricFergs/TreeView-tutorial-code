
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
