using YummyShop.Model.DataBaseTableModel.Interface;

namespace YummyShop.Model.DataBaseTableModel {
    public class Products : IСharacteristicProduct {
        public int Id { get; set; }
        public byte[]? Image { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
