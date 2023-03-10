using System.Collections.ObjectModel;
using System.Windows;
using YummyShop.Model.Base;
using YummyShop.Model.DataBaseTableModel;
using YummyShop.Model.YummyCommands;

namespace YummyShop.ViewModel.Pages {
    public class HomeViewModel : PropertyChangedBase
    {
        public ObservableCollection<Products> ProductsCollection { get; set; } =
            new ObservableCollection<Products>() {
                new Products()
                {
                    Count = 5,
                    Price = 32545,
                },
                new Products()
                {
                    Count = 2,
                    Price = 546,
                }
            };

        private RelayCommandT<Window> _showToHomeProductsCommand;
        public RelayCommandT<Window> ShowToHomeProductsCommand
        {
            get
            {
                return _showToHomeProductsCommand ??= new RelayCommandT<Window>(sender =>
                {

                });
            }
        }


    }
}
