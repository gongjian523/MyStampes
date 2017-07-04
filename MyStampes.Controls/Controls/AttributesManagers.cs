using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyStampes.Controls.Controls
{
    public class AttributesManagers:DependencyObject
    {

        public static string GetNormalPic(DependencyObject obj)
        {
            return (string)obj.GetValue(NormalPicProperty);
        }

        public static void SetNormalPic(DependencyObject obj, string value)
        {
            obj.SetValue(NormalPicProperty, value);
        }

        public static DependencyProperty NormalPicProperty =
            DependencyProperty.RegisterAttached("NormalPic", typeof(string), typeof(AttributesManagers), new PropertyMetadata(""));



        public static string GetMouseOnPic(DependencyObject obj)
        {
            return (string)obj.GetValue(MouseOnPicProperty);
        }

        public static void SetMouseOnPic(DependencyObject obj, string value)
        {
            obj.SetValue(MouseOnPicProperty, value);
        }

        public static DependencyProperty MouseOnPicProperty =
            DependencyProperty.RegisterAttached("MouseOnPic", typeof(string), typeof(AttributesManagers), new PropertyMetadata(""));


    }
}
