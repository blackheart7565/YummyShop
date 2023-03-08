using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using YummyShop.Model.Base;
using YummyShop.Model.Data;
using YummyShop.Model.DataBaseTableModel;
using YummyShop.Model.YummyCommands;
using YummyShop.View;
using YummyShop.View.AddProductWindow;

namespace YummyShop.ViewModel.Pages {
    public class VideocardViewModel : PropertyChangedBase {

        private RelayCommandT<Page>? _openWindowAddToVideocardCommand;

        #region PROPERTY

        /// <summary>
        /// Получение всех данных из таблицы "Videocards"
        /// </summary>
        public List<Videocards>? VideocardsCollectionDB => new ApplicationContextDB().Videocards.ToList();

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

        #endregion
    }
}
