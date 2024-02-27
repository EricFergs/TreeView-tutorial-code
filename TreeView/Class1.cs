
using System.ComponentModel;
using System.Runtime.Remoting.Channels;

namespace TreeView
{
    public class Class1: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public string test { get; set; } = "My property";
        public override string ToString()
        {
            return "Hello World";
        }
    }
}
