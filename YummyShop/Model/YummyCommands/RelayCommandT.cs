using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YummyShop.Model.YummyCommands {
    public class RelayCommandT<T> : ICommand {
        private readonly Action<T>? _executeAction;
        private readonly Func<T, bool>? _canExecuteAction;

        public RelayCommandT(Action<T> executeAction, Func<T, bool>? canExecuteAction = null) {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        public event EventHandler? CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        
        public bool CanExecute(object? parameter) {
            return parameter != null && (_canExecuteAction?.Invoke((T)parameter) ?? true);
        }

        public void Execute(object? parameter) {
            if (parameter != null) _executeAction?.Invoke((T)parameter);
        }
    }
}
