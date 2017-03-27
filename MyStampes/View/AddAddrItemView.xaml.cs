using MyStampes.SQLiteHerlper;
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
using System.Windows.Shapes;

namespace MyStampes.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddAddrItemView : Window
    {
        private AddressItem newAddr;
        private AddressItem oldAddr; 

        public AddAddrItemView(AddressItem addr = null)
        {
            InitializeComponent();

            newAddr = new AddressItem();
            
            
            if(addr == null)
            {
                AddAddrItemBtn.Visibility = Visibility.Visible;
                EditAddrItemBtn.Visibility = Visibility.Collapsed;  
            }
            else
            {
                
                oldAddr = addr;
                newAddr = addr;

                AddAddrItemBtn.Visibility = Visibility.Collapsed;
                EditAddrItemBtn.Visibility = Visibility.Visible;  
            }

            DataContext = newAddr;
        }

        public void AddAddrItem(object sender, RoutedEventArgs e)
        {
            SQLiteHelper.Instance.InsertNewAddressItem(newAddr);
            this.Close();
        }

        public void EidtAddrItem(object sender, RoutedEventArgs e)
        {
            SQLiteHelper.Instance.UpdateAddressItem(newAddr);
            this.Close();
        }



        //private void Init(bool bCanBeEdit)
        //{
        //    NameTB.IsEnabled = bCanBeEdit;
        //    TelNumTb.IsEnabled = bCanBeEdit;
        //    LocTB.IsEnabled = bCanBeEdit;
        //    AddrCodTB.IsEnabled = bCanBeEdit;
        //    AddrTB.IsEnabled = bCanBeEdit;
        //    Info1TitTB.IsEnabled = bCanBeEdit;
        //    Info1TB.IsEnabled = bCanBeEdit;
        //    Info2TitTB.IsEnabled = bCanBeEdit;
        //    Info2TB.IsEnabled = bCanBeEdit;
        //    Info3TitTB.IsEnabled = bCanBeEdit;
        //    Info3TB.IsEnabled = bCanBeEdit;
        //    Info4TitTB.IsEnabled = bCanBeEdit;
        //    Info4TB.IsEnabled = bCanBeEdit;
        //}
    }
}
