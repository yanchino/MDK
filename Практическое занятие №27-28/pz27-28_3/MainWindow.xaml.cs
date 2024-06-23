using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Пз27_28._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> 
    public partial class MainWindow : Window
    {
        private ObservableCollection<Task> tasks = new ObservableCollection<Task>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Task = tasks;
        }
        public ObservableCollection<Task> Task
        {
            get {return tasks;}
            set
            {
                tasks = value;
                OnPropertyChanged(nameof(Task));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Task newTask = new Task()
            {
                Name = NameTextBox.Text,
                Description = DescriptionTextBox.Text,
                Date = DatePicker.SelectedDate ?? DateTime.Now,
            };
            tasks.Add(newTask);
            OnPropertyChanged(nameof(Task));
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TasksDataGrid.SelectedItem is Task selectedTask)
            {
                tasks.Remove(selectedTask);
                OnPropertyChanged(nameof(Task));
            }
            else
            {
                MessageBox.Show("Выберите строку!","Внимание!");
            }
        }
    }
    public class Task : INotifyPropertyChanged
    {
        private string name;
        private string description;
        private DateTime date;
        public string Name
        {
            get {return name;}
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Description
        {
            get {return description;}
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public DateTime Date
        {
            get {return date;}
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
