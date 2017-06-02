using MyStampes.SQLiteHerlper;
using MyStampes.View;
using MyStampes.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MyStampes.Log
{
    /// <summary>
    /// Interaction logic for LogView.xaml
    /// </summary>
    public partial class LogListView : UserControl
    {
        public LogListView()
        {
            InitializeComponent();

            DataContext = this;

            InitData();
        }


        private ObservableCollection<LogItem> _logList = new ObservableCollection<LogItem>();
        public ObservableCollection<LogItem> LogList
        {
            get
            {
                return _logList;
            }
            set
            {
                _logList = value;
            }
        }


        private void AddLogItem(object sender, RoutedEventArgs e)
        {
            AddLogItemView addLog = new AddLogItemView();
            addLog.Owner = Application.Current.MainWindow;
            addLog.ShowDialog();
            InitData();
        }

        private void EidtLogItem(object sender, RoutedEventArgs e)
        {
            LogItem log = (LogItem)((Button)sender).Tag;
            AddLogItemView addLog = new AddLogItemView(log);
            addLog.Owner = Application.Current.MainWindow;
            addLog.ShowDialog();
            InitData();
        }


        private void DelLogItem(object sender, RoutedEventArgs e)
        {

            if (MessageBoxResult.Cancel == MessageBox.Show(Application.Current.MainWindow, "确认删除此条日志？", "警告", MessageBoxButton.OKCancel))
                return;

            LogItem log = (LogItem)((Button)sender).Tag;
            SQLiteHelper.Instance.DeleteLogItem(log.Id);
            InitData();
        }

        private void InitData()
        {
            LogList.Clear();

            List<LogItem> logs = SQLiteHerlper.SQLiteHelper.Instance.GetAllLog();

            logs.ForEach(log => LogList.Add(log));  
        }


    }
}
