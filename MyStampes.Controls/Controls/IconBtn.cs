using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyStampes.Controls.Controls
{
    public class IconBtn : Button
    {
        //public IconBtn()
        //{
        //}

        public string NomalPic
        {
            get { return (string)GetValue(NomalPicProperty); }
            set { SetValue(NomalPicProperty, value); }
        }

        public static readonly DependencyProperty NomalPicProperty =
            DependencyProperty.Register("NomalPic", typeof(string), typeof(IconBtn), new PropertyMetadata(""));


        public string MouseOnPic
        {
            get { return (string)GetValue(MouseOnPicProperty); }
            set { SetValue(MouseOnPicProperty, value); }
        }

        public static readonly DependencyProperty MouseOnPicProperty =
            DependencyProperty.Register("MouseOnPic", typeof(string), typeof(IconBtn), new PropertyMetadata(""));

    }
}
