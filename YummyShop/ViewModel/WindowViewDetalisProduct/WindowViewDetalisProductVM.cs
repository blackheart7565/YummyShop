using System.Windows;
using YummyShop.Model.Base;
using YummyShop.Model.DataBaseTableModel;
using YummyShop.Model.YummyCommands;

namespace YummyShop.ViewModel.WindowViewDetalisProduct {
    public class WindowViewDetalisProductVM : PropertyChangedBase {
        public Videocards Videocards { get; set; } = new Videocards();

        #region Конструктор
        public WindowViewDetalisProductVM(Videocards? videocards) {
            if (videocards != null)
                Videocards = videocards;
        }

        #endregion

        #region All Commands

        /// <summary>
        /// Перемещение окна
        /// </summary>
        private RelayCommandT<Window>? _moveWindowCommand;
        public RelayCommandT<Window> MoveWindowCommand {
            get {
                return _moveWindowCommand ??= new RelayCommandT<Window>(sender => {
                    sender.DragMove();
                });
            }
        }

        /// <summary>
        /// Закрытие окна
        /// </summary>
        private RelayCommandT<Window>? _closeWindowCommand;
        public RelayCommandT<Window> CloseWindowCommand {
            get {
                return _closeWindowCommand ??= new RelayCommandT<Window>(sender => {
                    sender.Close();
                });
            }
        }

        #endregion
    }
}
