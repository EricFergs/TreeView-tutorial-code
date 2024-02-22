﻿using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace TreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var drive in Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem()
                {
                    Header = drive,
                    Tag = drive,
                };
                

                item.Items.Add(null);

                item.Expanded += Folder_Expanded;

                FolderView.Items.Add(item);
            }
        }

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {

            #region Inital Checks
            var item = (TreeViewItem)sender;
            if(item.Items.Count != 1 || item.Items[0] != null)
            {
                return;
            }
            item.Items.Clear();

            var fullPath = (string)item.Tag;

            #endregion

            #region Get Folders

            var directories = new List<string>();

            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    directories.AddRange(dirs);
            }
            catch
            {

            }
            directories.ForEach(directoryPath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(directoryPath),
                    Tag = directoryPath,
                };

                subItem.Items.Add(null);
                subItem.Expanded += Folder_Expanded;


                //Add this item to the parent
                item.Items.Add(subItem);
            });

            #endregion

            #region Get Files 

            var files = new List<string>();

            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                   files.AddRange(fs);
            }
            catch
            {

            }
            files.ForEach(filePath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(filePath),
                    Tag = filePath,
                };

                //Add this item to the parent
                item.Items.Add(subItem);
            });

            #endregion
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
