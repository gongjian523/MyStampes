using MyStampes.SQLiteHerlper;
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
using System.Windows.Shapes;

namespace MyStampes.View
{

    public class Seller
    {
        public int Id  { get; set;} 
        public string Brief { get; set; }
    }

    /// <summary>
    /// Interaction logic for AddLogItemView.xaml
    /// </summary>
    public partial class AddLogItemView : Window
    {
        private LogItem newLog;
        private LogItem oldLog;

        public AddLogItemView(LogItem log = null )
        {
            InitializeComponent();

            newLog = new LogItem();
            oldLog = new LogItem();

            if (log != null)
            {
                oldLog = log;
                newLog = log;


                TitleTB.Text = "编辑日志";
                AddLogItemBtn.Visibility = Visibility.Collapsed;
                EditLogItemBtn.Visibility = Visibility.Visible;
            }
            else
            {
                TitleTB.Text = "新增日志";
                AddLogItemBtn.Visibility = Visibility.Visible;
                EditLogItemBtn.Visibility = Visibility.Collapsed;
            }
            

            this.DataContext = log;

            List<AddressItem> addrList = SQLiteHelper.Instance.GetAllAddress();
            addrList.ForEach(addr => {
                _sellerList.Add(new Seller { Id = addr.Id, Brief = addr.Name });
            });


            SellerCB.ItemsSource = SellerList;
            SellerCB.SelectedValuePath = "Id";
            SellerCB.DisplayMemberPath = "Brief";
        }


        //private Seller _selectSeller;
        //public Seller SelectSeller
        //{
        //    get
        //    {
        //        return _selectSeller;
        //    }
        //    set
        //    {
        //        _selectSeller = value;
        //        if (this.PropertyChanged != null)
        //            PropertyChanged(this, new PropertyChangedEventArgs("SelectSeller"));
        //    }
        //}


        private ObservableCollection<Seller> _sellerList = new ObservableCollection<Seller>();
        public ObservableCollection<Seller> SellerList
        {
            get
            {
                return _sellerList;
            }
        }


        private void AddLogItem(object sender, RoutedEventArgs e)
        {


            newLog.SellerId = Convert.ToInt32(SellerCB.SelectedValue);
            newLog.SellerInfo = SellerList.FirstOrDefault(sell => sell.Id == newLog.SellerId).Brief;

            SQLiteHelper.Instance.InsertNewLogItem(newLog);
            this.Close();
        }


        private void EditLogItem(object sender, RoutedEventArgs e)
        {

        }
    }
}
