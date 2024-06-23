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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Data.OleDb;

namespace Пз_38
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {     
        public MainWindow()
        {
            InitializeComponent();

            OleDbConnection connect = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=Database.mdb;");
            connect.Open();

            OleDbCommand command = new OleDbCommand("Select * From Shop", connect);
            DataGrid.ItemsSource = command.ExecuteReader();

        }
     
    }
}
