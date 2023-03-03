using System.Windows;
using YummyShop.Model.Commands;

namespace YummyShop.ViewModel.MainWindowFolder {
    public class MainNavigationWindow {
        private RelayCommandT<Window>? _moveWindowCommand;
        private RelayCommandT<Window>? _windowMinimizateCommand;
        private RelayCommand? _windowCloseCommand;

        #region All Commands

        /// <summary>
        /// Команда для перемещения окна
        /// </summary>
        public RelayCommandT<Window> MoveWindowCommand =>
            _moveWindowCommand ??= new RelayCommandT<Window>(sender => { sender.DragMove(); });
        /// <summary>
        /// Команда для скрытия и раскрытия окна
        /// </summary>
        public RelayCommandT<Window> WindowMinimizateCommand =>
            _windowMinimizateCommand ??= new RelayCommandT<Window>(sender => {
                sender.WindowState = WindowState.Minimized;
            });
        /// <summary>
        /// Команда для закрытия всех оконых потоков 
        /// </summary>
        public RelayCommand WindowCloseCommand =>
            _windowCloseCommand ??= new RelayCommand(sender => {
                System.Windows.Application.Current.Shutdown();
            });


        #endregion

    }
}
