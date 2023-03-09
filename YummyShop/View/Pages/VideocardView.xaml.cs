using System.Windows.Controls;
using YummyShop.View.WindowViewDetalisProduct;

namespace YummyShop.View.Pages {
    /// <summary>
    /// Interaction logic for VideocardView.xaml
    /// </summary>
    public partial class VideocardView : Page
    {
        public static ListBox? VideocardListView;
        public VideocardView()
        {
            InitializeComponent();
            VideocardListView = ListBoxItemsSourceName;
        }
    }
}
