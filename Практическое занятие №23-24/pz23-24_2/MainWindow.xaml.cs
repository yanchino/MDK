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
using System.Collections.ObjectModel;

namespace Пз23_24._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        public MainWindow()
        {
            InitializeComponent();
            DataContext = tasks;
        }
        private TaskList<Task> tasks = new TaskList<Task>();
        public class Task
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Deadline { get; set; }
            public bool IsCompleted { get; set; }
            public override string ToString()
            {
                return $"{Title} {Description} {Deadline} {IsCompleted}";
            }
        }
        public class TaskList<T>
        {
            public ObservableCollection<T> Tasks { get; private set; }
            public TaskList()
            {
                Tasks = new ObservableCollection<T>();
            }
            public void AddTask(T task)
            {
                Tasks.Add(task);
            }
            public void RemoveTask(T task)
            {
                Tasks.Remove(task);
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task()
            {
                Title = Zadacha.Text,
                Description = Opisanie.Text,
                Deadline = DateTime.Now,
                IsCompleted = true,
            };
            tasks.AddTask(task);
            Zadacha.Text = "";
            Opisanie.Text = "";
            MessageBox.Show($"Добавлено задач: {tasks.Tasks.Count}");
        }
    }
}
