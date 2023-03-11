using System.Windows;
using YummyShop.Model.DataBaseTableModel;
using YummyShop.ViewModel.WindowViewDetalisProduct;

namespace YummyShop.View.WindowViewDetalisProduct {
    public partial class VideocardWindowDetalis : Window
    {
        public VideocardWindowDetalis(Videocards? videocards)
        {
            InitializeComponent();
            DataContext = new WindowViewDetalisProductVM(videocards);
        }
    }
}
