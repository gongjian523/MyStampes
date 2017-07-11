using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyStampes.Controls.Controls
{
    public class IconBtn : Button
    {

        public string NormalPic
        {
            get { return (string)GetValue(NormalPicProperty); }
            set { SetValue(NormalPicProperty, value); }
        }

        public static readonly DependencyProperty NormalPicProperty =
            DependencyProperty.Register("NormalPic", typeof(string), typeof(IconBtn), new PropertyMetadata(""));


        public string MouseOnPic
        {
            get { return (string)GetValue(MouseOnPicProperty); }
            set { SetValue(MouseOnPicProperty, value); }
        }

        public static readonly DependencyProperty MouseOnPicProperty =
            DependencyProperty.Register("MouseOnPic", typeof(string), typeof(IconBtn), new PropertyMetadata(""));



        public Canvas IconCanvas
        {
            get { return (Canvas)GetValue(IconCanvasProperty); }
            set { SetValue(IconCanvasProperty, value); }
        }

        public static readonly DependencyProperty IconCanvasProperty =
            DependencyProperty.Register("IconCanvas", typeof(Canvas), typeof(IconBtn));


    }
}
