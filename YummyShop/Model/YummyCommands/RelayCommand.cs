using System;
using System.Windows.Input;

namespace YummyShop.Model.YummyCommands {
    public class RelayCommand : ICommand {

        private readonly Action<object>? _executeAction;
        private readonly Func<object, bool>? _canExecuteAction;

        public RelayCommand(Action<object> executeAction, Func<object, bool>? canExecuteAction = null) {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        public event EventHandler? CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        

        public bool CanExecute(object? parameter)
        {
            return parameter != null && (_canExecuteAction?.Invoke(parameter) ?? true);
        }

        public void Execute(object? parameter)
        {
            if (parameter != null) _executeAction?.Invoke(parameter);
        }

    }
}
