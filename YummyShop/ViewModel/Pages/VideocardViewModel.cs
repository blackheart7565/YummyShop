using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using YummyShop.Model.Base;
using YummyShop.Model.Data;
using YummyShop.Model.DataBaseTableModel;

namespace YummyShop.ViewModel.Pages {
    public class VideocardViewModel : PropertyChangedBase {
        private ApplicationContextDB contextDB = new();

        public ObservableCollection<Videocards> VideocardsCollection { get; set; } =
            new ObservableCollection<Videocards>() {
                new Videocards()
                {
                    GraphicsChip = "GeForce RTX 3060",
                    MemoryFrequency = "15000 МГц",
        Memory = "12 ГБ",
                    MemoryBusWidth = "192 бит",
                    MaximumSupportedResolution = "7680x4320",
                    Dimensions = "200 x 123 x 38 мм",
                    Connectors = "DisplayPort\r\nHDMI",
                    Price = 16299,
                    Count = 10,
                },
                new Videocards()
                {
                    GraphicsChip = "GeForce RTX 3060",
                    MemoryFrequency = "15000 МГц",
                    Memory = "12 ГБ",
                    MemoryBusWidth = "192 бит",
                    MaximumSupportedResolution = "7680x4320",
                    Dimensions = "200 x 123 x 38 мм",
                    Connectors = "DisplayPort\r\nHDMI",
                    Price = 16299,
                    Count = 10,
                },
                new Videocards()
                {
                    GraphicsChip = "GeForce RTX 3060",
                    MemoryFrequency = "15000 МГц",
                    Memory = "12 ГБ",
                    MemoryBusWidth = "192 бит",
                    MaximumSupportedResolution = "7680x4320",
                    Dimensions = "200 x 123 x 38 мм",
                    Connectors = "DisplayPort\r\nHDMI",
                    Price = 16299,
                    Count = 10,
                },
                new Videocards()
                {
                    GraphicsChip = "GeForce RTX 3060",
                    MemoryFrequency = "15000 МГц",
                    Memory = "12 ГБ",
                    MemoryBusWidth = "192 бит",
                    MaximumSupportedResolution = "7680x4320",
                    Dimensions = "200 x 123 x 38 мм",
                    Connectors = "DisplayPort\r\nHDMI",
                    Price = 16299,
                    Count = 10,
                },
                new Videocards()
                {
                    GraphicsChip = "GeForce RTX 3060",
                    MemoryFrequency = "15000 МГц",
                    Memory = "12 ГБ",
                    MemoryBusWidth = "192 бит",
                    MaximumSupportedResolution = "7680x4320",
                    Dimensions = "200 x 123 x 38 мм",
                    Connectors = "DisplayPort\r\nHDMI",
                    Price = 16299,
                    Count = 10,
                },
                new Videocards()
                {
                    GraphicsChip = "GeForce RTX 3060",
                    MemoryFrequency = "15000 МГц",
                    Memory = "12 ГБ",
                    MemoryBusWidth = "192 бит",
                    MaximumSupportedResolution = "7680x4320",
                    Dimensions = "200 x 123 x 38 мм",
                    Connectors = "DisplayPort\r\nHDMI",
                    Price = 16299,
                    Count = 10,
                },
                new Videocards()
                {
                    GraphicsChip = "GeForce RTX 3060",
                    MemoryFrequency = "15000 МГц",
                    Memory = "12 ГБ",
                    MemoryBusWidth = "192 бит",
                    MaximumSupportedResolution = "7680x4320",
                    Dimensions = "200 x 123 x 38 мм",
                    Connectors = "DisplayPort\r\nHDMI",
                    Price = 16299,
                    Count = 10,
                },
                new Videocards()
                {
                    GraphicsChip = "GeForce RTX 3060",
                    MemoryFrequency = "15000 МГц",
                    Memory = "12 ГБ",
                    MemoryBusWidth = "192 бит",
                    MaximumSupportedResolution = "7680x4320",
                    Dimensions = "200 x 123 x 38 мм",
                    Connectors = "DisplayPort\r\nHDMI",
                    Price = 16299,
                    Count = 10,
                },
                new Videocards()
                {
                    GraphicsChip = "GeForce RTX 3060",
                    MemoryFrequency = "15000 МГц",
                    Memory = "12 ГБ",
                    MemoryBusWidth = "192 бит",
                    MaximumSupportedResolution = "7680x4320",
                    Dimensions = "200 x 123 x 38 мм",
                    Connectors = "DisplayPort\r\nHDMI",
                    Price = 16299,
                    Count = 10,
                },
                new Videocards()
                {
                    GraphicsChip = "GeForce RTX 3060",
                    MemoryFrequency = "15000 МГц",
                    Memory = "12 ГБ",
                    MemoryBusWidth = "192 бит",
                    MaximumSupportedResolution = "7680x4320",
                    Dimensions = "200 x 123 x 38 мм",
                    Connectors = "DisplayPort\r\nHDMI",
                    Price = 16299,
                    Count = 10,
                }
            };


        public List<Videocards>? VideocardsCollectionDB => contextDB.Videocards.ToList();
    }
}
