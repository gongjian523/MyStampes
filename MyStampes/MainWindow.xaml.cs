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

namespace MyStampes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private LogView logView = new LogView();
        private AddrBookView addrBookView = new AddrBookView();

        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Navigate(logView);
        }

        private void EnterLog(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(logView);
        }

        private void EnterAddrBook(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(addrBookView);
        }
    }

}
