using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Пз_38_40
{
    public interface IOperation
    {
        decimal DoOperation(decimal num1, decimal num2);
    }
    public class Sum : IOperation//сложение
    {
        public decimal DoOperation(decimal num1, decimal num2) => num1 + num2;
    }
    public class Subtraction : IOperation//вычитание
    {
        public decimal DoOperation(decimal num1, decimal num2) => num1 - num2;
    }
    public class Division : IOperation//деление
    {
        public decimal DoOperation(decimal num1, decimal num2) => num1 / num2;
    }
    public class Multiplication : IOperation//умножение
    {
        public decimal DoOperation(decimal num1, decimal num2) => num1 * num2;
    }
}
