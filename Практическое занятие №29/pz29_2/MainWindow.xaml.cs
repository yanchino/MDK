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

namespace Пз29_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new TaskManagerViewModel();
        }
    }
    public class RelayCommand : ICommand
    {
        private Action execute;
        public event EventHandler CanExecuteChanged;
        public RelayCommand(Action Execute)
        {
            execute = Execute;
        }
        public bool CanExecute(object param)
        {
            return true;
        }
        public void Execute(object param)
        {
            execute();
        }
    }
    public class TaskManagerViewModel
    {
        public ObservableCollection<TaskItem> TaskItems {get; set;} = new ObservableCollection<TaskItem>();
        public RelayCommand AddTaskCommand {get; set;}
        public TaskManagerViewModel()
        {
            Title = "";
            Description = "";
            AddTaskCommand = new RelayCommand(AddNewTask);
        }
        public void AddNewTask()
        {
            AddTask(Title, Description);
        }
        public void AddTask(string title, string description)
        {
            TaskItem newTask = new TaskItem
            {
                Title = title,
                Description = description,
                IsCompleted = false
            };
            TaskItems.Add(newTask);
        }
        public void RemoveTask(TaskItem task)
        {
            TaskItems.Remove(task);
        }
        public void ToggleTaskCompleted(TaskItem task)
        {
            task.IsCompleted = !task.IsCompleted;
        }
        public string Title {get; set;}
        public string Description {get; set;}
    }
    public class TaskItem : INotifyPropertyChanged
    {
        private string title;
        public string Title
        {
            get {return title;}
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged("Задача");
                }
            }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Описание");
            }
        }
        private bool isCompleted;
        public bool IsCompleted
        {
            get {return isCompleted;}
            set
            {
                isCompleted = value;
                OnPropertyChanged("Выполнение");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
