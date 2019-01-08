using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using DreamTrip.Desktop.Enums;

namespace DreamTrip.Desktop.ViewModels
{
    public abstract class ViewBaseModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }

    public interface IListen { }
    public interface IListen<T> : IListen
    {
        void Handle(T obj);
    }

    public class EventAggregator
    {
        private List<IListen> subscribers = new List<IListen>();

        public void Subscribe(IListen model)
        {
            this.subscribers.Add(model);
        }

        public void Unsubscribe(IListen model)
        {
            this.subscribers.Remove(model);
        }

        public void Publish<T>(T message)
        {
            foreach (var item in this.subscribers.OfType<IListen<T>>())
            {
                item.Handle(message);
            }
        }
    }

    public class SecondaryViewModel : ViewBaseModel, IListen<AvailableViews>
    {
        protected AvailableViews viewType;
        protected EventAggregator eventAggregator { get; }

        public SecondaryViewModel(EventAggregator eventAggregator, AvailableViews viewType)
        {
            this.viewType = viewType;
            this.eventAggregator = eventAggregator;
        }

        public void Handle(AvailableViews obj)
        {
        }

        public void Signal()
        {
            if (eventAggregator != null)
            {
                eventAggregator.Publish(viewType);
            }
        }



    }

    #region ChangeViewCommand
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
            Console.WriteLine();
        }

        public event EventHandler CanExecuteChanged;
    }
    #endregion

    #region ParameterlessActionCommand
    public class ParameterlessActionCommand : ICommand
    {
        private readonly Action _action;
        public ParameterlessActionCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged;
    }
    #endregion
}
