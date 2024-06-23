using System;
using System.Collections.Generic;
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

namespace Пз_29._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
    public class RelayCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;
        public RelayCommand(Action Execute, Func<bool> CanExecute = null)
        {
            execute = Execute;
            canExecute = CanExecute;
        }
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public bool CanExecute(object parameter) => canExecute == null || canExecute();
        public void Execute(object parameter) => execute();
    }
    public class CurrencyConverter
    {
        private Dictionary<string, double> exchangeRates = new Dictionary<string, double>()
        {
            {"USD",0.90},
            {"EUR",0.98}
        };
        public double ConvertCurrency(double amount, string fromCurrency, string toCurrency)
        {
            if (exchangeRates.ContainsKey(fromCurrency) && exchangeRates.ContainsKey(toCurrency))
            {
                double rate = exchangeRates[toCurrency] / exchangeRates[fromCurrency];
                return amount * rate;
            }
            else
            {
                return 0;
            }
        }
    }
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private CurrencyConverter currencyConverter;
        public MainViewModel()
        {
            currencyConverter = new CurrencyConverter();
            Currencies = new List<string> { "USD", "EUR" };
            FromCurrency = Currencies.FirstOrDefault();
            ToCurrency = Currencies.FirstOrDefault();
        }
        private List<string> currencies;
        public List<string> Currencies
        {
            get {return currencies;}
            set
            {
                currencies = value;
                OnPropertyChanged(nameof(Currencies));
            }
        }
        private double amount;
        public double Amount
        {
            get {return amount;}
            set
            {
                amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
        private string fromCurrency;
        public string FromCurrency
        {
            get {return fromCurrency;}
            set
            {
                fromCurrency = value;
                OnPropertyChanged(nameof(FromCurrency));
            }
        }
        private string toCurrency;
        public string ToCurrency
        {
            get {return toCurrency;}
            set
            {
                toCurrency = value;
                OnPropertyChanged(nameof(ToCurrency));
            }
        }
        private double result;
        public double Result
        {
            get {return result;}
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }
        public ICommand ConvertCommand => new RelayCommand(Convert);
        private void Convert()
        {
            Result = currencyConverter.ConvertCurrency(Amount, FromCurrency, ToCurrency);
        }
    }
}
