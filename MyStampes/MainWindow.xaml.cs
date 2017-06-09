﻿using Microsoft.Win32;
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
using MahApps.Metro.Controls;

namespace MyStampes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
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
    }

}
