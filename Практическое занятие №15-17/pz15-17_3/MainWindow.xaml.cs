using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Пз15_17._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Person Bob { get; set; } = new Person("Bob", 6);
        public Person Tom { get; set; } = new Person("Tom", 29);
        public Person Jimmy { get; set; } = new Person("Jiimmy", 78);
        public Animal Cat { get; set; } = new Animal("Cat", "Tony");
        public Animal Dog { get; set; } = new Animal("Dog", "Monica");
        public Animal Tiger { get; set; } = new Animal("Tiger", "NoName");
        public Plant Clover { get; set; } = new Plant("Clover", "Kashka");
        public Plant Chamaenerion { get; set; } = new Plant("Chamaenerion", "Ivan-Chai");
        public Plant Asphodelaceae { get; set; } = new Plant("Asphodelaceae", "Stoletnik");
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public void UpdateAge(int newAge)
        {
            Age = newAge;
        }
        public string GetInfo()
        {
            return $"Класс1: {Name} ({Age})";
        }

        public string GetInfo(bool includeAge)
        {
            if (includeAge)
            {
                return $"Имя: {Name}, Номер: {Age}";
            }
            else
            {
                return $"Номер: {Age}";
            }
        }

    }
    public class Animal
    {
        public string Species { get; set; }
        public string Name { get; set; }

        public Animal(string species, string name)
        {
            Species = species;
            Name = name;
        }
        public string GetInfo()
        {
            return $"Класс2: {Species}, Цвет: ({Name})";
        }
        public void ChangeName(string newName)
        {
            Name = newName;
        }

        public string GetInfo(bool includeName)
        {
            if (includeName)
            {
                return $"Имя: {Species}, Цвет: {Name}";
            }
            else
            {
                return $"Имя: {Species}";
            }
        }


    }
        public class Plant
        {
            public string ScientificName { get; set; }
            public string CommonName { get; set; }

            public Plant(string scientificname, string commonname)
            {
                ScientificName = scientificname;
                CommonName = commonname;
            }
            public void UpdateCommonName(string newCommonName)
            {
                CommonName = newCommonName;
            }
            public string GetInfo()
            {
                return $"Класс3: ({ScientificName}, {CommonName})";
            }

            public string GetInfo(bool includeCommonName)
            {
                if (includeCommonName)
                {
                    return $"X: {ScientificName}, Y: {CommonName}";
                }
                else
                {
                    return $"Научное название: {ScientificName}";
                }
            }


        }
    }

