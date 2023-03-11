using System.Windows;

namespace YummyShop.Model.ControlWindow {
    /// <summary>
    /// Статический класс для работы с окном
    /// <code>
    /// -Закрыть окно
    /// -Сввернуть окно
    /// -Развернуть окно 
    /// -Полный экран окна
    /// </code>
    /// </summary>
    static class TheControlWindow {
        static bool _isMax = false;
        static bool _isFull = false;
        static Point old_loc, default_loc;
        static Size old_size, default_size;

        public static void SetInitial(Window win) {
            old_size = new Size(win.Width, win.Height);
            old_loc = new Point(win.Top, win.Left);
            default_loc = new Point(win.Width, win.Height);
            default_size = new Size(win.Top, win.Left);
        }

        #region Методы для работы с окном
        /// <summary>
        /// Развернуть экран
        /// </summary>
        /// <param name="win"></param>
        public static void DoMaximize(Window win) {
            if (_isMax == false) {
                old_size = new Size(win.Width, win.Height);
                old_loc = new Point(win.Top, win.Left);
                Maximize(win);
                _isMax = true;
                _isFull = false;
            }
            else {
                win.Top = old_loc.Y;
                win.Left = old_loc.X;
                win.Width = old_size.Width;
                win.Height = old_size.Height;
                _isMax = false;
                _isFull = false;
            }
        }
        /// <summary>
        /// Полный экран
        /// </summary>
        /// <param name="win"></param>
        public static void DoFullScrean(Window win) {
            if (_isMax == false) {
                old_size = new Size(win.Width, win.Height);
                old_loc = new Point(win.Top, win.Left);
                FullScrean(win);
                _isMax = false;
                _isFull = true;
            }
            else {
                win.Top = old_loc.Y;
                win.Left = old_loc.X;
                win.Width = old_size.Width;
                win.Height = old_size.Height;
                _isMax = false;
                _isFull = false;
            }
        }
        /// <summary>
        /// Свернуть экран
        /// </summary>
        /// <param name="win"></param>
        public static void Minimize(Window win) {
            win.WindowState = WindowState.Minimized;

        }
        /// <summary>
        /// Закрыть все поточные окна
        /// </summary>
        /// <param name="win"></param>
        public static void Exit() {
            Application.Current.Shutdown();
        }
        /// <summary>
        /// Закрыть определёное окно
        /// </summary>
        /// <param name="win"></param>
        public static void Exit(Window win) {
            win.Close();
        }

        #endregion

        #region Вспомогательные методы
        static void FullScrean(Window win) {
            if (win.WindowState == WindowState.Normal) {
                win.WindowState = WindowState.Maximized;
            }
            else {
                win.WindowState = WindowState.Normal;
            }
        }
        static void Maximize(Window win) {
            double x = SystemParameters.WorkArea.Width;
            double y = SystemParameters.WorkArea.Height;
            win.WindowState = WindowState.Normal;
            win.Top = 0;
            win.Left = 0;
            win.Width = x;
            win.Height = y;
        }
        #endregion
    }
}
