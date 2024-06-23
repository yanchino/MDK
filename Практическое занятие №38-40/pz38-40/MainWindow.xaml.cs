using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

namespace Пз_38_40
{
    public partial class MainWindow : Window
    {
        string DecimalSeparator => CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
        decimal FirstValue {get; set;}
        decimal? SecondValue {get; set;}
        IOperation CurrentOperation;
        public MainWindow()
        {
            InitializeComponent();
            btnPoint.Content = DecimalSeparator;
            btnSum.Tag = new Sum();
            btnSubtraction.Tag = new Subtraction();
            btnDivision.Tag = new Division();
            btnMultiplication.Tag = new Multiplication();
        }
        private void regularButtonClick(object sender, RoutedEventArgs e) => SendToInput(((Button)sender).Content.ToString());
        private void SendToInput(string content)
        {
            if (txtInput.Text == "0")
                txtInput.Text = "";

            txtInput.Text = $"{txtInput.Text}{content}";
        }
        private void btnPoint_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput.Text.Contains(this.DecimalSeparator))
                return;

            regularButtonClick(sender, e);
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //чтобы 0 не сбрасывался
            if (txtInput.Text == "0")
                return;

            txtInput.Text = txtInput.Text.Substring(0, txtInput.Text.Length - 1);
            if (txtInput.Text == "")
                txtInput.Text = "0";
        }
        private void operationButton_Click(object sender, RoutedEventArgs e)
        {
            //если текущая операция не равна нулю, значит первое значение уже есть
            if (CurrentOperation == null)
                FirstValue = Convert.ToDecimal(txtInput.Text);

            CurrentOperation = (IOperation)((Button)sender).Tag;
            SecondValue = null;
            txtInput.Text = "";
        }
        private void Window_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            switch (e.Text)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    SendToInput(e.Text);
                    break;

                case "*":
                    btnMultiplication.PerformClick();
                    break;

                case "-":
                    btnSubtraction.PerformClick();
                    break;

                case "+":
                    btnSum.PerformClick();
                    break;

                case "/":
                    btnDivision.PerformClick();
                    break;

                case "=":
                    btnEquals.PerformClick();
                    break;

                default:
                    if (e.Text == DecimalSeparator)
                        btnPoint.PerformClick();
                    else if (e.Text[0] == (char)8)
                        btnBack.PerformClick();
                    else if (e.Text[0] == (char)13)
                        btnEquals.PerformClick();

                    break;
            }
            //предотвращает нажатие на кнопку
            btnEquals.Focus();
        }
        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentOperation == null)
                return;

            if (txtInput.Text == "")
                return;

            //для многократного нажатия на =, обновляя результат
            decimal num2 = SecondValue ?? Convert.ToDecimal(txtInput.Text);
            try
            {
                txtInput.Text = (FirstValue = CurrentOperation.DoOperation(FirstValue, (decimal)(SecondValue = num2))).ToString();
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Нельзя делить на ноль!", "Ошибка!");
                btnClearAll.PerformClick();
            }
        }
        private void btnClearEntry_Click(object sender, RoutedEventArgs e) => txtInput.Text = "0";
        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        {
            FirstValue = 0;
            CurrentOperation = null;
            txtInput.Text = "0";
        }
    }
}
