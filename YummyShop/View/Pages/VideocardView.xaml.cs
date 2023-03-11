using System.Windows.Controls;
using YummyShop.Model.DataBaseTableModel;
using YummyShop.View.WindowViewDetalisProduct;
using YummyShop.ViewModel.WindowViewDetalisProduct;

namespace YummyShop.View.Pages {
    public partial class VideocardView : Page
    {
        public static ListBox? VideocardListView;
        public VideocardView()
        {
            InitializeComponent();
            VideocardListView = ListBoxItemsSourceName;
        }

        private void GridName_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            Videocards? videocards = ((Grid)sender).DataContext as Videocards;
            VideocardWindowDetalis windowDetalis = new(videocards);
            windowDetalis.ShowDialog();
        }
    }
}
