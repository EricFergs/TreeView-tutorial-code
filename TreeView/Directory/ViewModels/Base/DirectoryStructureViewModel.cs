
using System.Collections.ObjectModel;
using System.Linq;

namespace TreeView
{
    public class DirectoryStructureViewModel : BaseViewModel
    {

        #region public properties
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        #endregion

        public DirectoryStructureViewModel() {

            var children = DirectoryStructure.GetLogicalDrives();
            this.Items = new ObservableCollection<DirectoryItemViewModel>(children.Select(drive => new DirectoryItemViewModel(drive.FullPath,DirectoryItemType.Drive)));
        }
    }
}
