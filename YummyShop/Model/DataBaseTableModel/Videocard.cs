using YummyShop.Model.DataBaseTableModel.Interface;

namespace YummyShop.Model.DataBaseTableModel {
    public class Videocards : IVideocard, IСharacteristicProduct {
        public int Id { get; set; }
        public byte[]? Image { get; set; }
        public string? GraphicsChip { get; set; }
        public string? MemoryFrequency { get; set; }
        public string? Memory { get; set; }
        public string? MemoryBusWidth { get; set; }
        public string? MaximumSupportedResolution { get; set; }
        public string? Dimensions { get; set; }
        public string? Connectors { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
