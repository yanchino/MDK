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

namespace Пз25_26._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IStudentFactory _factory;
        public MainWindow()
        {
            InitializeComponent();
            _factory = new StudentFactory();
            StudentTypeComboBox.SelectedIndex = 0;
        }
        private void ShowStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var studentType = (StudentType)StudentTypeComboBox.SelectedIndex;
            var student = _factory.CreateStudent(studentType);
            DataContext = student;
        }
        public class Student
        {
            public string Name {get; set;}
            public int Age {get; set;}
        }
        public interface IStudentFactory
        {
            Student CreateStudent(StudentType type);
        }
        public enum StudentType
        {
            SchoolStudent,
            UniversityStudent
        }
        public class SchoolStudent : Student
        {
            public SchoolStudent()
            {
                Name = "John";
                Age = 16;
                Grade = 10;
            }
            public int Grade {get; set;}
        }
        public class UniversityStudent : Student
        {
            public UniversityStudent()
            {
                Name = "Alice";
                Age = 20;
                Major = "Computer Science";
            }
            public string Major {get; set;}
        }
        public class StudentFactory : IStudentFactory
        {
            public Student CreateStudent(StudentType type)
            {
                switch (type)
                {
                    case StudentType.SchoolStudent:
                        return new SchoolStudent();
                    case StudentType.UniversityStudent:
                        return new UniversityStudent();
                    default:
                        throw new ArgumentException("Неизвестный тип студентов");
                }
            }
        }
    }
}
