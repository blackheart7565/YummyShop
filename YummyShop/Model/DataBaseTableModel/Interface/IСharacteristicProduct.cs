namespace YummyShop.Model.DataBaseTableModel.Interface {
    /// <summary>
    /// Характеристика продукта
    /// </summary>
    interface IСharacteristicProduct {
        /// <summary>
        /// Изображение
        /// </summary>
        public byte[]? Image { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int Count { get; set; }
    }
}
