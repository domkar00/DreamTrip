using System;
using System.Windows.Input;
using DreamTrip.Desktop.Enums;

namespace DreamTrip.Desktop.Commands
{
    public class CommonCommand : ICommand
    {
        private readonly Action<Object> _action;
        public CommonCommand(Action<Object> action)
        {
            this._action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
        }

        public event EventHandler CanExecuteChanged;
    }
}
