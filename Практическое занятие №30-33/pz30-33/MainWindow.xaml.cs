using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Пз_30_33
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog FileOpen = new OpenFileDialog();
            FileOpen.Filter = "Текстовые файлы (*.txt)|*.txt";
            if (FileOpen.ShowDialog() == true)
            {
                Redactor.Text = File.ReadAllText(FileOpen.FileName);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog FileSave = new SaveFileDialog();
            FileSave.Filter = "Текстовые файлы (*.txt)|*.txt";
            if (FileSave.ShowDialog() == true)
            {
                File.WriteAllText(FileSave.FileName, Redactor.Text);
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Redactor.Text = string.Empty;
        }
    }
}
