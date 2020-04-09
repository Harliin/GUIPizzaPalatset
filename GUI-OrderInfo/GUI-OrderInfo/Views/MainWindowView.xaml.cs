using GUI_OrderInfo.ViewModels;
using ReactiveUI;
using System;
using System.Reactive.Disposables;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace GUI_OrderInfo.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : ReactiveWindow<MainWindowViewModels>
    {
        #region Constructor
        public MainWindowView()
        {
            this.ViewModel = new MainWindowViewModels(this);

            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, ongoing => ongoing.OngoingOrders,
                    o => o.txbOngoing.ItemsSource).DisposeWith(disposables);

                this.OneWayBind(ViewModel, complete => complete.CompleteOrder,
                    c => c.txbComplete.ItemsSource).DisposeWith(disposables);

            });

        }
        #endregion

        //[DllImport("user32.dll")]
        //static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        //[DllImport("user32.dll")]
        //static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        //const uint MF_BYCOMMAND = 0x00000000;
        //const uint MF_GRAYED = 0x00000001;
        //const uint MF_ENABLED = 0x00000000;

        //const uint SC_CLOSE = 0xF060;

        //const int WM_SHOWWINDOW = 0x00000018;
        //const int WM_CLOSE = 0x10;

        //protected override void OnSourceInitialized(EventArgs e)
        //{
        //    base.OnSourceInitialized(e);

        //    HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;

        //    if (hwndSource != null)
        //    {
        //        hwndSource.AddHook(new HwndSourceHook(this.hwndSourceHook));
        //    }
        //}


        //IntPtr hwndSourceHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        //{
        //    if (msg == WM_SHOWWINDOW)
        //    {
        //        IntPtr hMenu = GetSystemMenu(hwnd, false);
        //        if (hMenu != IntPtr.Zero)
        //        {
        //            EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND | MF_GRAYED);
        //        }
        //    }
        //    else if (msg == WM_CLOSE)
        //    {
        //        handled = true;
        //    }
        //    return IntPtr.Zero;
        //}
    }
}
