using System;
using System.Windows.Input;

namespace MCInstall.Commands
{
    public class ActionCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<Object> _predicate;

        public ActionCommand(Action<Object> action) : this(action, null) { }

        public ActionCommand(Action<Object> action, Predicate<Object> predicate) => (_action, _predicate) = (action ?? throw new ArgumentNullException(nameof(action), @"You must specify an Action<T>."), predicate);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            var result = _predicate?.Invoke(parameter);
            return !result.HasValue || result.Value;
        }

        public void Execute() => Execute(null);

        public void Execute(object parameter) => _action?.Invoke(parameter);
    }
}
