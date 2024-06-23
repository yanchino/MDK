using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Пз25_26._3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Task> tasks = new ObservableCollection<Task>();
        public MainWindow()
        {
            InitializeComponent();
            taskListBox.ItemsSource = tasks;
        }
        public abstract class TaskCreator
        {
            public abstract Task CreateTask();
        }
        public class HomeworkTaskCreator : TaskCreator
        {
            public override Task CreateTask()
            {
                return new HomeworkTask();
            }
        }
        public class WorkTaskCreator : TaskCreator
        {
            public override Task CreateTask()
            {
                return new WorkTask();
            }
        }
        public class Task
        {
            public string Title {get; set;}
            public string Description {get; set;}
            public DateTime Deadline {get; set;}
            public bool IsComplete {get; set;}
        }
        public class HomeworkTask : Task
        {
            public string Clear {get; set;}
        }
        public class WorkTask : Task
        {
            public string Work {get; set;}
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var homeworkTaskCreator = new HomeworkTaskCreator();
            var newHomeworkTask = homeworkTaskCreator.CreateTask();
            tasks.Add(newHomeworkTask);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var workTaskCreator = new WorkTaskCreator();
            var newWorkTask = workTaskCreator.CreateTask();
            tasks.Add(newWorkTask);
        }
    }
}
