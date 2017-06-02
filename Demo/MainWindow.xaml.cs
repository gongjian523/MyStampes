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

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private View1 view1 = new View1();
        private View2 view2 = new View2();

        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Navigate(view1);
        }

        private void EnterView1(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(view1);
        }

        private void EnterView2(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(view2);
        }
        
    }
}
