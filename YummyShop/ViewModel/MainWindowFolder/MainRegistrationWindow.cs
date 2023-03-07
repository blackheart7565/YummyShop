using System.IO;
using System.Windows;
using System.Windows.Forms;
using YummyShop.Model.Base;
using YummyShop.Model.Data;
using YummyShop.Model.DataBaseTableModel;
using YummyShop.Model.YummyCommands;
using YummyShop.View;

namespace YummyShop.ViewModel.MainWindowFolder {
    public class MainRegistrationWindow : PropertyChangedBase {
        private RelayCommandT<Window>? _moveWindowCommand;
        private RelayCommandT<Window>? _windowMinimizateCommand;
        private RelayCommandT<Window>? _windowCloseCommand;
        private RelayCommandT<Window>? _buttonWindowRegisterCommand;

        private RelayCommand? _inputImageCommand;

        private byte[]? _imageByte;

        #region Property

        public byte[]? ImageByte {
            get => _imageByte;
            set => SetField(ref _imageByte, value, nameof(ImageByte));
        }

        #endregion

        #region All Command

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
        public RelayCommandT<Window> WindowCloseCommand =>
            _windowCloseCommand ??= new RelayCommandT<Window>(sender => {
                sender.Close();
            });
        /// <summary>
        /// Регистрация пользователя в Базе Данных
        /// </summary>
        public RelayCommandT<Window>? ButtonWindowRegisterCommand {
            get {
                return _buttonWindowRegisterCommand ??= new RelayCommandT<Window>(sender => {
                    RegistrationWindow win = ((RegistrationWindow)sender);
                    using (ApplicationContextDB contextDb = new ApplicationContextDB()) {
                        contextDb.Users.Add(new Users() {
                            Image = ImageByte,
                            FirstName = win.TextBoxFirstName.Text,
                            LastName = win.TextBoxLastName.Text,
                            Username = win.TextBoxUsername.Text,
                            Password = win.TextBoxPassword.Text,
                            Email = win.TextBoxEmmail.Text,
                            Phone = win.TextBoxPhone.Text,
                        });
                        contextDb.SaveChanges();
                        win.Close();
                    };
                });
            }
        }
        /// <summary>
        /// Загрузка картинки в БД
        /// </summary>
        public RelayCommand? InputImageCommand {
            get {
                return _inputImageCommand ??= new RelayCommand(sender => {
                    using (var fileDialog = new OpenFileDialog()) {
                        if (fileDialog.ShowDialog() == DialogResult.OK) {
                            using (FileStream fileStream = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read)) {
                                using (BinaryReader binaryReader = new BinaryReader(fileStream)) {
                                    ImageByte = binaryReader.ReadBytes((int)fileStream.Length);
                                }
                            }
                        }
                    }
                });
            }
        }

        #endregion
    }
}
