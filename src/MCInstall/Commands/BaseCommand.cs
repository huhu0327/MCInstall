using System;
using System.Windows.Input;

namespace MCInstall.Commands
{
    public class BaseCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<object> _predicate;

        public BaseCommand(Action<object> action, Predicate<object> predicate = null)
        {
            (_action, _predicate) = (
                action ?? throw new ArgumentNullException(nameof(action), @"You must specify an Action<T>."),
                predicate);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

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