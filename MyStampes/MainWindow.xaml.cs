using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyStampes.AddrBook;
using MyStampes.Log;
using System.Windows.Interop;
using System.Windows.Forms;
using System.Drawing;

namespace MyStampes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private LogListView logListView = new LogListView();
        private AddrBookView addrBookView = new AddrBookView();

        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Navigate(logListView);
        }

        private void EnterLogList(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(logListView);
        }

        private void EnterAddrBook(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(addrBookView);
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MaximizedWindow(object sender, RoutedEventArgs e)
        {
            //if (this.WindowState == WindowState.Maximized)
            //    this.WindowState = WindowState.Normal;
            //else if (this.WindowState == WindowState.Normal)


            var handle = new WindowInteropHelper(this).Handle;

            Screen screen = Screen.FromHandle(handle);

            this.MaxWidth = screen.Bounds.Width;
            this.MaxHeight = screen.Bounds.Height;
            this.WindowState = WindowState.Maximized;

            RestoreDownBtn.Visibility = System.Windows.Visibility.Visible;
            MaximizedBtn.Visibility = System.Windows.Visibility.Hidden;
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
             this.WindowState = WindowState.Minimized;
        }

        private void RestoreDownWindow(object sender, RoutedEventArgs e)
        {
            //if (this.WindowState == WindowState.Minimized)
            //    this.WindowState = WindowState.Normal;
            //else if (this.WindowState == WindowState.Normal)
            this.WindowState = WindowState.Normal;

            MaximizedBtn.Visibility = System.Windows.Visibility.Visible;
            RestoreDownBtn.Visibility = System.Windows.Visibility.Hidden;
        }

        private void DragMove(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
                this.WindowState = System.Windows.WindowState.Normal;

            this.DragMove();
        }


    }

}
