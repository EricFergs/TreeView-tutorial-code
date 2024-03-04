
using PropertyChanged;
using System.ComponentModel;

namespace TreeView
{

    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        ///  The event that is fired when any child property changes it's values 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
