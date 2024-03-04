

using System;
using System.Runtime.Remoting.Channels;
using System.Windows.Input;
using System.Windows.Navigation;

namespace TreeView
{
    public class RelayCommand : ICommand
    {

        #region private members
        private Action mAction;
        #endregion

        #region Public Event

        /// <summary>
        /// the event that's fired when the canexecute value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender,e) => { };

        #endregion

        //Constructor 
        public RelayCommand(Action action)
        {
            mAction = action;
        }
        //whether the object can execute or not. like a button that is clickable or not
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
