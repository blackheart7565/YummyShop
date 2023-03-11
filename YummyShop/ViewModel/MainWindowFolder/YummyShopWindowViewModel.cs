using System.Runtime.InteropServices;
using System;
using System.Windows;
using YummyShop.Model.Base;
using YummyShop.Model.YummyCommands;
using YummyShop.View;
using YummyShop.View.Pages;
using System.Windows.Interop;
using YummyShop.Model.ControlWindow;

namespace YummyShop.ViewModel.MainWindowFolder {
    public class YummyShopWindowViewModel : PropertyChangedBase {
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public byte[]? ImageEllipse { get; set; } = MainAuthorizationWindow.Images;
        public string? Username { get; set; } = MainAuthorizationWindow.Username;

        // Поля для взаемодействия с окном
        private RelayCommandT<Window>? _moveWindowShopCommand;
        private RelayCommandT<Window>? _buttonMaximizateWindowShopCommand;
        private RelayCommandT<Window>? _buttonMinimizateWindowShopCommand;
        private RelayCommandT<Window>? _buttonCloseWindowShopCommand;

        // Поля для открытия страниц
        private RelayCommandT<Window>? _buttonShoppingBaskedCommand;
        private RelayCommandT<Window>? _buttonShowPageVideocardCatalogCommand;

        #region All Commands

        #region Взаемодествие с окном

        /// <summary>
        /// Перемещение окна
        /// </summary>
        public RelayCommandT<Window>? MoveWindowShopCommand {
            get {
                return _moveWindowShopCommand ??= new RelayCommandT<Window>(sender => {
                    //sender.DragMove();
                    WindowInteropHelper helper = new WindowInteropHelper(sender);
                    SendMessage(helper.Handle, 161, 2, 0);
                });
            }
        }
        /// <summary>
        /// Закрытие окна
        /// </summary>
        public RelayCommandT<Window>? ButtonCloseWindowShopCommand {
            get {
                return _buttonCloseWindowShopCommand ??= new RelayCommandT<Window>(sender => {
                    TheControlWindow.Exit(sender);
                });
            }
        }
        /// <summary>
        /// Разкрытие окна на весь экран
        /// </summary>
        public RelayCommandT<Window>? ButtonMaximizateWindowShopCommand {
            get {
                return _buttonMaximizateWindowShopCommand ??= new RelayCommandT<Window>(sender => {
                    TheControlWindow.DoMaximize(sender);
                });
            }
        }
        /// <summary>
        /// Свертывание окна 
        /// </summary>
        public RelayCommandT<Window>? ButtonMinimizateWindowShopCommand {
            get {
                return _buttonMinimizateWindowShopCommand ??= new RelayCommandT<Window>(sender => {
                    TheControlWindow.Minimize(sender);
                });
            }
        }

        #endregion

        #region Открытие страниц

        /// <summary>
        /// Корзина товаров
        /// </summary>
        public RelayCommandT<Window>? ButtonShoppingBaskedCommand {
            get {
                return _buttonShoppingBaskedCommand ??= new RelayCommandT<Window>(sender => {
                    if (sender is YummyShopWindow win)
                        win.ShopFramePage.Content = new Home();
                });
            }
        }
        /// <summary>
        /// Открытие каталога Videocard
        /// </summary>
        public RelayCommandT<Window>? ButtonShowPageVideocardCatalogCommand {
            get {
                return _buttonShowPageVideocardCatalogCommand ??= new RelayCommandT<Window>(sender => {
                    if (sender is YummyShopWindow win)
                        win.ShopFramePage.Content = new VideocardView();
                });
            }
        }

        #endregion

        #endregion
    }
}
