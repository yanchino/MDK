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

namespace Пз27_28._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public User NewUser {get; set;}
        public MainWindow()
        {
            InitializeComponent();
            NewUser = new User();
            DataContext = NewUser;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newUser = NewUser;
            newUser.userName = name.Text;
            newUser.Poshta = poshta.Text;
            newUser.Parol = parol.Password;
            NewUser = newUser;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string userData = $"Имя: {NewUser.userName}\nEmail: {NewUser.Poshta}\nПароль: Недоступен";
            MessageBox.Show(userData, "Данные");
        }
    }
    public class User
    {
        public string userName {get; set;}
        public string Parol {get; set;}
        public string Poshta {get; set;}
    }
}
