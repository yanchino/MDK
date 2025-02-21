﻿using System;
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
        public class Car
        {
            public string Model { get; set; }
        }
        public class Sedan : Car
        {
            public string Color {get; set;}
            public string PrintInfo()
            {
                return $"Седан модели {Model}, цвет:{Color}";
            }

        }
        public class SUV : Car
        {
            public string Color { get; set; }
            public string PrintInfo()
            {
                return $"Спорткар модели {Model}, цвет:{Color}";
            }
        }
        public class ToyotaSedan : Sedan
        {
            public string PrintInfo()
            {
                return base.PrintInfo() + "Это тойта";
            }
            
        }
        public class HondaSedan : Sedan
        {
            public string PrintInfo()
            {
                return base.PrintInfo() + "This is Hond";
            }

        }
        public class ToyotaSUV : SUV
        {
            public string PrintInfo()
            {
                return base.PrintInfo() + "Это тойта";
            }
        }
        public class collector : SUV
        {
            public string PrintInfo()
            {
                return base.PrintInfo() + "This is Hond";
            }
        }
    }    
}
