using System.Windows;
using YummyShop.Model.Base;
using YummyShop.Model.Commands;

namespace YummyShop.ViewModel.MainWindowFolder {
    public class YummyShopWindowViewModel : PropertyChangedBase {
        public byte[]? ImageEllipse { get; set; } = MainAuthorizationWindow.Images;
        public string? Username { get; set; } = MainAuthorizationWindow.Username;

        private RelayCommandT<Window>? _moveWindowShopCommand;
        private RelayCommandT<Window>? _buttonMaximizateWindowShopCommand;
        private RelayCommandT<Window>? _buttonMinimizateWindowShopCommand;
        private RelayCommandT<Window>? _buttonCloseWindowShopCommand;

        #region All Commands

        /// <summary>
        /// Перемещение окна
        /// </summary>
        public RelayCommandT<Window>? MoveWindowShopCommand {
            get {
                return _moveWindowShopCommand ??= new RelayCommandT<Window>(sender => {
                    sender.DragMove();
                });
            }
        }
        /// <summary>
        /// Закрытие окна
        /// </summary>
        public RelayCommandT<Window>? ButtonCloseWindowShopCommand {
            get {
                return _buttonCloseWindowShopCommand ??= new RelayCommandT<Window>(sender => {
                    sender.Close();
                });
            }
        }
        /// <summary>
        /// Разкрытие окна на весь экран
        /// </summary>
        public RelayCommandT<Window>? ButtonMaximizateWindowShopCommand {
            get {
                return _buttonMaximizateWindowShopCommand ??= new RelayCommandT<Window>(sender => {

                });
            }
        }
        /// <summary>
        /// Свертывание окна 
        /// </summary>
        public RelayCommandT<Window>? ButtonMinimizateWindowShopCommand {
            get {
                return _buttonMinimizateWindowShopCommand ??= new RelayCommandT<Window>(sender => {
                    sender.WindowState = WindowState.Minimized;
                });
            }
        }

        #endregion
    }
}
