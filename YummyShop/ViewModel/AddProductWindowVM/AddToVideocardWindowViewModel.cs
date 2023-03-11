using System.IO;
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

        // Взаемодействие с окном
        private RelayCommandT<Window>? _closeWindowAddToVideocard;
        private RelayCommandT<Window>? _moveWindowAddToVideocard;

        // Действие с Базой Данных
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

        #region Взаемодействие с окном

        /// <summary>
        /// Закрытие окна
        /// </summary>
        public RelayCommandT<Window> CloseWindowAddToVideocard {
            get => _closeWindowAddToVideocard ??= new RelayCommandT<Window>(sender => sender.Close());
        }
        /// <summary>
        /// Перемещение окна
        /// </summary>
        public RelayCommandT<Window> MoveWindowAddToVideocard {
            get => _moveWindowAddToVideocard ??= new RelayCommandT<Window>(sender => sender.DragMove());
        }

        #endregion

        #region Действие с Базой Данных

        /// <summary>
        /// Добаление товара в таблицу "Videocard"
        /// </summary>
        public RelayCommand AddProductToTableVideocard => _addProductToTableVideocard ??= new RelayCommand(sender => {
            using (ApplicationContextDB contextDB = new()) {
                AddToVideocardWindow? win = sender as AddToVideocardWindow;
                if (ImageByte != null &&
                string.IsNullOrEmpty(win.GraphicsChipName.Text) &&
                string.IsNullOrEmpty(win.MemoryFrequencyName.Text) &&
                string.IsNullOrEmpty(win.MemoryName.Text) &&
                string.IsNullOrEmpty(win.MemoryBusWidthName.Text) &&
                string.IsNullOrEmpty(win.MaximumSupportedResolutionName.Text) &&
                string.IsNullOrEmpty(win.DimensionsName.Text) &&
                string.IsNullOrEmpty(win.DimensionsName.Text) &&
                string.IsNullOrEmpty(win.ConnectorsName.Text) &&
                string.IsNullOrEmpty(win.CountName.Text) &&
                string.IsNullOrEmpty(win.PriceName.Text)
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
                    win.Close();
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

        #endregion
    }
}
