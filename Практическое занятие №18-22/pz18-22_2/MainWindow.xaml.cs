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
        public interface Car
        {
            string Model {get; set;}
        }
        public interface Sedan
        {
           int Name {get; set;}
           int Color {get; set;}

        }
        public interface SUV
        {
            bool Name {get; set;}
            int Color  {get ; set;}
        }
        public interface ToyotaSedan
        {
            bool mileage {get; set;}//probeg
            int Age {get; set;}
        }
        public interface HondaSedan
        {
            bool mileage { get; set; }//probeg
            int Age { get; set; }

        }
        public interface ToyotaSUV
        {
            bool mileage { get; set; }//probeg
            int Age { get; set; }
        }
        public interface HondaSUV
        {
            bool mileage { get; set; }//probeg
            int Age { get; set; }
        }
    }    
}
