
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mime;
using System.Windows.Input;

namespace TreeView
{ 
    /// <summary>
    /// a viewmodel for each folder or drive(directory) 
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {

        #region public properties
        public DirectoryItemType Type { get; set; }
        public string FullPath { get; set; }

        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }

        public bool isExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                if (value == true)
                    Expand();
                else
                    this.ClearChildren();
            }
        }

        #endregion

        #region Public Commands

        public ICommand ExpandCommand { get; set; }

        #endregion

        #region Construction 

        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            this.ExpandCommand = new RelayCommand(Expand);

            this.FullPath = fullPath;
            this.Type = type;

            this.ClearChildren();
        }

        #endregion

        #region Helper Methods
        private void ClearChildren()
        {
            this.Children = new ObservableCollection<DirectoryItemViewModel>();

            if (this.Type != DirectoryItemType.File)
            {
                this.Children.Add(null);
            }
        }
        #endregion
        private void Expand()
        {
            if (this.Type == DirectoryItemType.File) {
                return;
            }
            this.Children = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure.GetDirectoryContents(this.FullPath).Select(content => new DirectoryItemViewModel(content.FullPath,content.Type)));
        }
    }
}
