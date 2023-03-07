using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using YummyShop.Model.YummyCommands;
using YummyShop.Model.Data;
using YummyShop.Model.DataBaseTableModel;
using YummyShop.View;

namespace YummyShop.ViewModel.MainWindowFolder {
    public class MainAuthorizationWindow {
        private RelayCommandT<Window>? _moveWindowCommand;
        private RelayCommandT<Window>? _windowMinimizateCommand;
        public RelayCommandT<Window>? _showRegistrationInfoWindowCommand;
        private RelayCommandT<Window>? _authorizationAccountCommand;

        private RelayCommand? _windowCloseCommand;
        public static byte[]? Images { get; set; }
        public static string? Username{ get; set; }

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
                    try {
                        AuthorizationWindow win = ((AuthorizationWindow)sender);
                        var contextDb = new ApplicationContextDB();

                        string username = win.TextBoxLoginUsername.Text;
                        string password = win.TextBoxLoginPassword.Password;

                        // SQL_Latin1_General_CP1_CS_AS - Учитывает регистр Базы Данных
                        bool isLoginAccount = contextDb.Users.Any(x => EF.Functions.Collate(x.Username, "SQL_Latin1_General_CP1_CS_AS") == username &&
                                                                       EF.Functions.Collate(x.Password, "SQL_Latin1_General_CP1_CS_AS") == password ||
                                                                       EF.Functions.Collate(x.Email, "SQL_Latin1_General_CP1_CS_AS") == username &&
                                                                       EF.Functions.Collate(x.Password, "SQL_Latin1_General_CP1_CS_AS") == password);
                        if (isLoginAccount)
                        {
                            foreach (Users bytes in contextDb.Users.Where(x =>
                                         EF.Functions.Collate(x.Username, "SQL_Latin1_General_CP1_CS_AS") == username &&
                                         EF.Functions.Collate(x.Password, "SQL_Latin1_General_CP1_CS_AS") == password ||
                                         EF.Functions.Collate(x.Email, "SQL_Latin1_General_CP1_CS_AS") == username &&
                                         EF.Functions.Collate(x.Password, "SQL_Latin1_General_CP1_CS_AS") == password))
                            {
                                Images = bytes.Image;
                                Username = bytes.Username;
                            }

                            win.TextBoxLoginUsername.Text = "";
                            win.TextBoxLoginPassword.Password = "";
                            var winShop = new YummyShopWindow();
                            win.Hide();
                            winShop.ShowDialog();
                            win.Show();
                        }
                        else {
                            MessageBox.Show("Такого аккаунта не существует!\nПроверьте правильно ли указаные данные",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }

        #endregion
    }
}
