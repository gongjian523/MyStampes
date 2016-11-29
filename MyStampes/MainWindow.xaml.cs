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

namespace MyStampes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Export_Log(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "数据库(*.db)|*.db|Excel(*.xlsx)|*.xlsx"; // Filter files by extension

            if(ofd.ShowDialog() == true)
            {
                Debug.Print("OPEN xlsx or db");
                LoadExcleFile();
            }
        }

        private void LoadExcleFile()
        {
            throw new NotImplementedException();
        }

        private void Save_Log(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "数据库(*.db)|*.db"; // Filter files by extension

            if (sfd.ShowDialog() == true)
            {
                Debug.Print("Save as DB");
                SaveLogToDB();
            }
        }

        private void SaveLogToDB()
        {
            throw new NotImplementedException();
        }
    }
}
