using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using YummyShop.Model.Base;
using YummyShop.Model.Data;
using YummyShop.Model.DataBaseTableModel;
using YummyShop.Model.YummyCommands;
using YummyShop.View.AddProductWindow;
using YummyShop.View.Pages;
using YummyShop.ViewModel.Pages;

namespace YummyShop.ViewModel.AddProductWindowVM {
    public class AddToVideocardWindowViewModel : PropertyChangedBase {

        private RelayCommandT<Window>? _closeWindowAddToVideocard;
        private RelayCommand? _addProductToTableVideocard;
        private RelayCommand? _inputImageCommand;

        private byte[]? _imageByte;

        #region Property

        public byte[]? ImageByte {
            get => _imageByte;
            set => SetField(ref _imageByte, value, nameof(ImageByte));
        }

        #endregion

        #region All Command

        /// <summary>
        /// Закрытие окна
        /// </summary>
        public RelayCommandT<Window> CloseWindowAddToVideocard {
            get => _closeWindowAddToVideocard ??= new RelayCommandT<Window>(sender => sender.Close());
        }
        /// <summary>
        /// Добаление товара в таблицу "Videocard"
        /// </summary>
        public RelayCommand AddProductToTableVideocard => _addProductToTableVideocard ??= new RelayCommand(sender => {
            using (ApplicationContextDB contextDB = new()) {
                AddToVideocardWindow? win = sender as AddToVideocardWindow;
                if (ImageByte != null &&
                    win.GraphicsChipName.Text != string.Empty &&
                    win.MemoryFrequencyName.Text != string.Empty &&
                    win.MemoryName.Text != string.Empty &&
                    win.MemoryBusWidthName.Text != string.Empty &&
                    win.MaximumSupportedResolutionName.Text != string.Empty &&
                    win.DimensionsName.Text != string.Empty &&
                    win.ConnectorsName.Text != string.Empty &&
                    win.ConnectorsName.Text != string.Empty &&
                    win.CountName.Text != string.Empty &&
                    win.PriceName.Text != string.Empty
                ) {
                    contextDB.Videocards.Add(new Videocards() {
                        Image = ImageByte,
                        GraphicsChip = win.GraphicsChipName.Text,
                        MemoryFrequency = win.MemoryFrequencyName.Text,
                        Memory = win.MemoryName.Text,
                        MemoryBusWidth = win.MemoryBusWidthName.Text,
                        MaximumSupportedResolution = win.MaximumSupportedResolutionName.Text,
                        Dimensions = win.DimensionsName.Text,
                        Connectors = win.ConnectorsName.Text,
                        Count = int.Parse(win.CountName.Text),
                        Price = double.Parse(win.PriceName.Text)
                    });
                    contextDB.SaveChangesAsync();
                    VideocardView.VideocardListView.ItemsSource = null;
                    VideocardView.VideocardListView.Items.Clear();
                    VideocardView.VideocardListView.ItemsSource = VideocardViewModel.VideocardsCollectionDB;
                }
                else {
                    System.Windows.MessageBox.Show("Не все поля заполнены");
                }
            }
        });
        /// <summary>
        /// Загрузка картинки в БД
        /// </summary>
        public RelayCommand? InputImageCommand {
            get {
                return _inputImageCommand ??= new RelayCommand(sender => {
                    using (var fileDialog = new OpenFileDialog()) {
                        if (fileDialog.ShowDialog() == DialogResult.OK) {
                            using (FileStream fileStream = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read)) {
                                using (BinaryReader binaryReader = new BinaryReader(fileStream)) {
                                    ImageByte = binaryReader.ReadBytes((int)fileStream.Length);
                                }
                            }
                        }
                    }
                });
            }
        }

        #endregion
    }
}
