﻿using MyStampes.View;
using MyStampes.ViewModel;
using System;
using System.Collections.Generic;
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

namespace MyStampes.AddrBook
{
    /// <summary>
    /// Interaction logic for AddrBookView.xaml
    /// </summary>
    public partial class AddrBookView : UserControl
    {
        public AddrBookView()
        {
            InitializeComponent();
            DataContext = this;

            _addrList = SQLiteHerlper.SQLiteHelper.Instance.GetAllAddress();
        }

        private List<AddressItem> _addrList = new List<AddressItem>();
        public List<AddressItem> AddrList
        {
            get
            {
                return _addrList;
            }
        }

        private void AddAddrItem(object sender, RoutedEventArgs e)
        {
            AddAddrItemView addAddr = new AddAddrItemView();
            addAddr.Owner = Application.Current.MainWindow;
            addAddr.ShowDialog(); 
        }

        
    }
}