using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Пз_38_40
{
    public static class Method
    {
        public static void PerformClick(this Button btn) => btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));//нажатие на кнопки +, -, *, /
    }
}
