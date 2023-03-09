using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using YummyShop.Model.Base;
using YummyShop.Model.Data;
using YummyShop.Model.DataBaseTableModel;
using YummyShop.Model.YummyCommands;
using YummyShop.View.AddProductWindow;
using YummyShop.View.WindowViewDetalisProduct;

namespace YummyShop.ViewModel.Pages {
    public class VideocardViewModel : PropertyChangedBase {

        private RelayCommandT<Page>? _openWindowAddToVideocardCommand;
        private RelayCommandT<Page>? _doubleClockToShowWindowDetalisCommand;

        #region PROPERTY

        /// <summary>
        /// Получение всех данных из таблицы "Videocards"
        /// </summary>
        public static List<Videocards>? VideocardsCollectionDB {
            get => new ApplicationContextDB().Videocards.ToList();
        }

        #endregion

        #region All Command

        /// <summary>
        /// Открытие окна добавление товара в таблицу Videocard
        /// </summary>
        public RelayCommandT<Page> OpenWindowAddToVideocardCommand {
            get => _openWindowAddToVideocardCommand ??= new RelayCommandT<Page>(sender => {
                var win = new AddToVideocardWindow();
                win.ShowDialog();
            });
        }


        public RelayCommandT<Page> DoubleClockToShowWindowDetalisCommand {
            get {
                return _doubleClockToShowWindowDetalisCommand ??= new RelayCommandT<Page>(sender => {
                    VideocardWindowDetalis windowDetalis = new();
                    windowDetalis.ShowDialog();
                });
            }
        }


        #endregion
    }
}
