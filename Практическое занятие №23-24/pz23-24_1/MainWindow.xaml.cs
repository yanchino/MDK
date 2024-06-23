using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace Пз23_24._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ContactList<Contact> contacts = new ContactList<Contact>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = contacts;

        }

        public class Contact
        {
            
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }

            public override string ToString()
            {
                return $"{FirstName} {LastName} {PhoneNumber} {Email}";
            }
        }

        public class ContactList<T>
        {
            public ObservableCollection<T> Contacts { get; private set; }

            public ContactList()
            {
                Contacts = new ObservableCollection<T>();
            }

            public void AddContact(T contact)
            {
                Contacts.Add(contact);
            }

            public void RemoveContact(T contact)
            {
                Contacts.Remove(contact);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text,
                Email = EmailTextBox.Text
            };

            contacts.AddContact(contact);

            // Очищаем текстовые поля после добавления контакта
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            PhoneNumberTextBox.Text = "";
            EmailTextBox.Text = "";
            MessageBox.Show($"Добавлено контактов: {contacts.Contacts.Count}");
        }
    }
}
