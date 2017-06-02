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

                dateDP.SelectedDate = newLog.Date;
                SellerCB.SelectedValue = newLog.SellerId;

                AddLogItemBtn.Visibility = Visibility.Collapsed;
                EditLogItemBtn.Visibility = Visibility.Visible;
            }
            else
            {
                TitleTB.Text = "新增日志";

                AddLogItemBtn.Visibility = Visibility.Visible;
                EditLogItemBtn.Visibility = Visibility.Collapsed;
            }

            this.DataContext = newLog;

            List<AddressItem> addrList = SQLiteHelper.Instance.GetAllAddress();
            addrList.ForEach(addr =>
            {
                _sellerList.Add(new Seller { Id = addr.Id, Brief = addr.Name });
            });


            SellerCB.ItemsSource = SellerList;
            SellerCB.SelectedValuePath = "Id";
            SellerCB.DisplayMemberPath = "Brief";
        }

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
            if (!IsInfoValid())
                return;

            SQLiteHelper.Instance.InsertNewLogItem(newLog);
            this.Close();
        }


        private void EditLogItem(object sender, RoutedEventArgs e)
        {
            if (!IsInfoValid())
                return;

            SQLiteHelper.Instance.UpdateLogItem(newLog);
            this.Close();
        }


        private bool IsInfoValid()
        {
            string dateStr = Convert.ToDateTime(dateDP.SelectedDate).ToString();

            if (dateStr == "0001/1/1 0:00:00")
            {
                WarningTB.Text = "请选择日期！";
                return false;
            }

            if (string.IsNullOrEmpty(newLog.Info) || string.IsNullOrWhiteSpace(newLog.Info))
            {
                WarningTB.Text = "请填写简介！";
                return false;
            }

            newLog.Date = Convert.ToDateTime(dateDP.SelectedDate);

            if (SellerCB.SelectedValue != null)
            {
                newLog.SellerId = Convert.ToInt32(SellerCB.SelectedValue);
                newLog.SellerInfo = SellerList.FirstOrDefault(sell => sell.Id == newLog.SellerId).Brief;
            }

            return true;
        }

    }
}
