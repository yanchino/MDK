using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Пз18_22._1
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
        static void Main(string[] args)
        {
            People people = new People();
            people.Search();
        }
    }    
    class People
    {
        private bool car;
        private bool working;
        private void CheckCar()
        {
            Console.WriteLine("Поиск машины");
            car = true;
            Console.WriteLine("Машина найдена");
        }
        private void Suitable()
        {
            if(!working)
            {
                Console.WriteLine("Не на ходу");
                CheckCar();
            }
            Console.WriteLine("Подготовка подходящих специальностей");
            car= true;
            Console.WriteLine("Надены предложения");
        }
        public void Search()
        {
            if(!car)
            {
                Console.WriteLine("Машины нет");
                Suitable();
            }
            Console.WriteLine("Машина найдена");
            car = false;
        }
    }
}
