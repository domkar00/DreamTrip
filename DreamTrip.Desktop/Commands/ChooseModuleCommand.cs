using System;
using System.Windows.Input;
using DreamTrip.Desktop.Enums;

namespace DreamTrip.Desktop.Commands
{
    public class ChooseModuleCommand : ICommand
    {
        private readonly Action<AvailableViews> _action;
        private readonly AvailableViews _view;
        public ChooseModuleCommand(Action<AvailableViews> action, AvailableViews view)
        {
            this._action = action;
            this._view = view;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(_view);
        }

        public event EventHandler CanExecuteChanged;
    }
}
