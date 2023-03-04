using System;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using YummyShop.Model.Commands;
using YummyShop.Model.Data;
using YummyShop.View;

namespace YummyShop.ViewModel.MainWindowFolder {
    public class MainNavigationWindow {
        private RelayCommandT<Window>? _moveWindowCommand;
        private RelayCommandT<Window>? _windowMinimizateCommand;
        private RelayCommand? _windowCloseCommand;
        public RelayCommandT<Window>? _showRegistrationInfoWindowCommand;
        private RelayCommandT<Window>? _authorizationAccountCommand;

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
        /// <summary>
        /// Открытие окна регистрации
        /// </summary>
        public RelayCommandT<Window> ShowRegistrationInfoWindowCommand {
            get {
                return _showRegistrationInfoWindowCommand ??= new RelayCommandT<Window>(sender => {
                    RegistrationWindow registrationWindow = new();
                    sender.Hide();
                    registrationWindow.ShowDialog();
                    sender.Show();
                });
            }
        }
        /// <summary>
        /// Авторизование акаунта
        /// </summary>
        public RelayCommandT<Window>? AuthorizationAccountCommand {
            get {
                return _authorizationAccountCommand ??= new RelayCommandT<Window>(sender => {
                    try
                    {
                        AuthorizationWindow win = ((AuthorizationWindow)sender);
                        var contextDb = new ApplicationContextDB();

                        bool isLoginAccount = contextDb.Users.Any(x => win.TextBoxLoginUsername.Text == x.Username &&
                                                                            win.TextBoxLoginPassword.Password == x.Password ||
                                                                            win.TextBoxLoginUsername.Text == x.Email &&
                                                                            win.TextBoxLoginPassword.Password == x.Password);
                        if (isLoginAccount)
                        {
                            win.TextBoxLoginUsername.Text = "";
                            win.TextBoxLoginPassword.Password = "";
                            YummyShopWindow winShop = new();
                            win.Hide();
                            winShop.ShowDialog();
                            win.Show();
                        }else
                        {
                            MessageBox.Show("Такого аккаунта не существует!\nПроверьте правильно ли указаные данные",
                                "Ошибка", 
                                MessageBoxButton.OK, 
                                MessageBoxImage.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }

        #endregion

    }
}
