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
                TitleTB.Text = "增加联系人";

                AddAddrItemBtn.Visibility = Visibility.Visible;
                EditAddrItemBtn.Visibility = Visibility.Collapsed;  
            }
            else
            {
                TitleTB.Text = "编辑联系人";
                
                oldAddr = addr;
                newAddr = addr;

                AddAddrItemBtn.Visibility = Visibility.Collapsed;
                EditAddrItemBtn.Visibility = Visibility.Visible;  
            }

            DataContext = newAddr;
        }

        public void AddAddrItem(object sender, RoutedEventArgs e)
        {
            if (!IsInfoValid())
                return;

            SQLiteHelper.Instance.InsertNewAddressItem(newAddr);
            this.Close();
        }

        public void EidtAddrItem(object sender, RoutedEventArgs e)
        {
            if (!IsInfoValid())
                return;

            SQLiteHelper.Instance.UpdateAddressItem(newAddr);
            this.Close();
        }

        private bool IsInfoValid()
        {
            bool bNameValid = !((string.IsNullOrEmpty(newAddr.Name) || string.IsNullOrWhiteSpace(newAddr.Name)));
            bool bInfo1Valid = ! ((string.IsNullOrEmpty(newAddr.Info1) || string.IsNullOrWhiteSpace(newAddr.Info1)));
            bool bInfo1TtileValid = !((string.IsNullOrEmpty(newAddr.Info1Title) || string.IsNullOrWhiteSpace(newAddr.Info1Title)));

            if (bInfo1Valid != bInfo1TtileValid)
            {
                WarningTB.Text = "信息1必须填写完整";
                return false;
            }

            if (!bNameValid && !bInfo1Valid)
            {
                WarningTB.Text = "姓名和信息1不能全部为空";
                return false;
            }

            return true;
        }


    }
}
