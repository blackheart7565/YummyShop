namespace YummyShop.Model.DataBaseTableModel.Interface {
    interface IVideocard
    {  
        /// <summary>
        /// Графический чип
        /// </summary>
        public string? GraphicsChip { get; set; }
        /// <summary>
        /// Частота памяти
        /// </summary>
        public string? MemoryFrequency { get; set; }
        /// <summary>
        /// Объем памяти
        /// </summary>
        public string? Memory { get; set; }
        /// <summary>
        /// Разрядность шины памяти
        /// </summary>
        public string? MemoryBusWidth { get; set; }
        /// <summary>
        /// Максимально поддерживаемое разрешение
        /// </summary>
        public string? MaximumSupportedResolution { get; set; }
        /// <summary>
        /// Размеры
        /// </summary>
        public string? Dimensions { get; set; }
        /// <summary>
        /// Разъемы
        /// </summary>
        public string? Connectors { get; set; }
    }
}
