using System.Windows;
using YummyShop.Model.Base;
using YummyShop.Model.YummyCommands;

namespace YummyShop.ViewModel.AddProductWindow {
    public class AddToVideocardWindowViewModel : PropertyChangedBase {

        private RelayCommandT<Window>? _closeWindowAddToVideocard;

        #region All Command

        /// <summary>
        /// Закрытие окна
        /// </summary>
        public RelayCommandT<Window> CloseWindowAddToVideocard {
            get => _closeWindowAddToVideocard ??= new RelayCommandT<Window>(sender => sender.Close());
        }

        #endregion
    }
}
