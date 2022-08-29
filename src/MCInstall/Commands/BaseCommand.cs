using System;

namespace MCInstall.Commands
{
    public class BaseCommand : IBaseCommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<object> _predicate;
        private event EventHandler _canExecuteChanged;

        public BaseCommand(Action<object> action, Predicate<object> predicate = null)
        {
            (_action, _predicate) = (
                action ?? throw new ArgumentNullException(nameof(action), @"You must specify an Action<T>."),
                predicate);
        }

        public event EventHandler CanExecuteChanged
        {
            add => _canExecuteChanged += value;
            remove => _canExecuteChanged -= value;
        }

        public void RaiseCanExecuteChanged() => _canExecuteChanged?.Invoke(this, EventArgs.Empty);


        public bool CanExecute(object parameter)
        {
            return _predicate?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke(parameter);
        }
    }
}