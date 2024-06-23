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

namespace Пз27_28._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {    
        public MainWindow()
        {
            InitializeComponent();
            DataContext = contacts;
        }
        private ContactList<Contact> contacts = new ContactList<Contact>();
        public class Contact
        {
            public string Name {get; set;}
            public string SurName {get; set;}
            public string Number {get; set;}
            public string Email {get; set;}
            public override string ToString()
            {
                return $"{Name} {SurName} {Number} {Email}";
            }
        }
        public class ContactList<T>
        {
            public ObservableCollection<T> Contacts {get; set;}
            public ContactList()
            {
                Contacts = new ObservableCollection<T>();
            }
            public void AddContact(T contact)
            {
                Contacts.Add(contact);
            }
            public void DeleteContact(T contact)
            {
                Contacts.Remove(contact);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                SurName = surnameTextBox.Text,
                Number = numberTextBox.Text,
                Email = EmailTextBox.Text
            };
            contacts.AddContact(contact);
            nameTextBox.Text = "";
            surnameTextBox.Text = "";
            numberTextBox.Text = "";
            EmailTextBox.Text = "";
        }
    }
}
