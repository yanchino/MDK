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

namespace Пз25_26._4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AttendanceManager attendanceManager;
        public ObservableCollection<Event> events {get; set;}
        public class Event
        {
            public string Name {get; set;}
            public DateTime DateTime {get; set;}
            public Event(string name, DateTime dateTime)
            {
                Name = name;
                DateTime = dateTime;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            attendanceManager = AttendanceManager.Instance;
            events = new ObservableCollection<Event>();
            eventListBox.ItemsSource = events;
        }
        public sealed class AttendanceManager
        {
            private static readonly Lazy<AttendanceManager> instance = new Lazy<AttendanceManager>(() => new AttendanceManager());
            public static AttendanceManager Instance => instance.Value;
            private Dictionary<Event, List<string>> attendanceList;
            private AttendanceManager()
            {
                attendanceList = new Dictionary<Event, List<string>>();
            }
            public void AddVisitor(Event theEvent, string visitorName)
            {
                if (!attendanceList.ContainsKey(theEvent))
                {
                    attendanceList[theEvent] = new List<string>();
                }
                attendanceList[theEvent].Add(visitorName);
            }
            public void MarkAttendance(Event theEvent, string visitorName)
            {
                if (attendanceList.ContainsKey(theEvent))
                {
                    attendanceList[theEvent].Remove(visitorName);
                }
            }
            public void GenerateReport(Event theEvent)
            {
                if (attendanceList.ContainsKey(theEvent))
                {
                    MessageBox.Show($"Отчёт: {theEvent.Name}");
                    foreach (var visitor in attendanceList[theEvent])
                    {
                        MessageBox.Show(visitor);
                    }
                }
            }
        }
        private void MarkAttendance_Click_1(object sender, RoutedEventArgs e)
        {
            if (eventListBox.SelectedItem is Event selectedEvent)
            {
                string visitorName = "Иванов Иван Иванович";
                attendanceManager.AddVisitor(selectedEvent, visitorName);
            }
        }
        private void GenerateReport_Click_1(object sender, RoutedEventArgs e)
        {
            if (eventListBox.SelectedItem is Event selectedEvent)
            {
                attendanceManager.GenerateReport(selectedEvent);
            }
        }
        private void AddVisitor_Click_1(object sender, RoutedEventArgs e)
        {
            Event newEvent = new Event("Новый посетитель", DateTime.Now);
            events.Add(newEvent);
            eventListBox.ItemsSource = null;
            eventListBox.ItemsSource = events;
        }
        
        private void Clear_Click_1(object sender, RoutedEventArgs e)
        {
            eventListBox.Items.Clear();            
        }
    }
}
