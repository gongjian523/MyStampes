using MyStampes.SQLiteHerlper;
using MyStampes.View;
using MyStampes.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

            InitData();
        }

        private ObservableCollection<AddressItem> _addrList = new ObservableCollection<AddressItem>();
        public ObservableCollection<AddressItem> AddrList
        {
            get
            {
                return _addrList;
            }
            set 
            {
                _addrList = value;
            }
        }

        private void AddAddrItem(object sender, RoutedEventArgs e)
        {
            AddAddrItemView addAddr = new AddAddrItemView();
            addAddr.Owner = Application.Current.MainWindow;
            addAddr.ShowDialog(); 
        }


        private void EidtAddrItem(object sender, RoutedEventArgs e)
        {
            AddressItem adr = (AddressItem)((Button)sender).Tag;
            AddAddrItemView addAddr = new AddAddrItemView(adr);
            addAddr.Owner = Application.Current.MainWindow;
            addAddr.ShowDialog(); 
        }


        private void DelAddrItem(object sender, RoutedEventArgs e)
        {
            AddressItem adr = (AddressItem)((Button)sender).Tag;

            SQLiteHelper.Instance.DeleteAddressItem(adr.Id);

            InitData();
        }

        private void InitData()
        {
            AddrList.Clear();

            List<AddressItem> addrs = SQLiteHerlper.SQLiteHelper.Instance.GetAllAddress();

            addrs.ForEach(addr => AddrList.Add(addr));    
        }
    }
}
