using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

namespace FirstTryCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        long firstNumber;
        long lastNumber;
        long result;
        char operatingChar;

        bool nextNumber = true;
        public MainWindow()
        {
            InitializeComponent();
        }

   
        private void InputDigit(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Content.ToString();

            if (nextNumber)
            {
                display.Text = "";
                nextNumber = false;
            }

            display.Text += content;

        }
        private void Plus(object sender, RoutedEventArgs e)
        {

            Operation('+');

        }

        private void Minus(object sender, RoutedEventArgs e)
        {
            Operation('-');

        }
        private void Multiply(object sender, RoutedEventArgs e)
        {

            Operation('*');

        }
        private void Divide(object sender, RoutedEventArgs e)
        {

            Operation('/');

        }
        private void Operation(char mathSign)
        {
            long parsedNumber = Int32.Parse(display.Text);

            if (operatingChar != mathSign)
            {

                lastNumber = parsedNumber;
                operatingChar = mathSign;
                nextNumber = true;

                display.Text = "0";
                lastNumberBox.Text = $"{lastNumber} {operatingChar}";

            }
            else
            {
                operatingChar = mathSign;
                firstNumber = parsedNumber;
                nextNumber = true;

                
                lastNumberBox.Text = $"{lastNumber} {operatingChar}";

                switch (operatingChar)
                {
                    case '+':

                        result = firstNumber + lastNumber;

                        break;

                    case '-':

                        result = lastNumber - firstNumber;
                        break;

                    case '*':

                        result = firstNumber * lastNumber;

                        break;

                    case '/':
                        result = lastNumber / firstNumber;

                        break;
                }

                
                lastNumber = result;

                display.Text = result.ToString();
            }
        }
        private void Equation(object sender, RoutedEventArgs e)
        {
            long parsedNumber = Int32.Parse(display.Text);

            switch (operatingChar)
            {
                case '+':

                    Plus(parsedNumber, e);

                    operatingChar = '=';
                    result = firstNumber + lastNumber;

                    lastNumberBox.Text += $" {firstNumber} {operatingChar}";

                    break;
                
                case '-':
                    
                    Minus(parsedNumber, e);

                    operatingChar = '=';

                    lastNumberBox.Text += $" {firstNumber} {operatingChar}";

                    break; 
                
                case '*':
                    
                    Multiply(parsedNumber, e);

                    operatingChar = '=';

                    lastNumberBox.Text += $" {firstNumber} {operatingChar}";
                    break; 
                
                case '/':
                    
                    Divide(parsedNumber, e);

                    operatingChar = '=';

                    lastNumberBox.Text += $" {firstNumber} {operatingChar}";
                    break;
            }

        }
        private void DeleteDigit(object sender, RoutedEventArgs e)
        {

            if (display.Text.Length == 1)
            {
                display.Text = "0";

            }
            else
            {

                display.Text = display.Text.Remove(display.Text.Length - 1);

            }

        }
        private void Del_All(object sender, RoutedEventArgs e)
        {

            display.Text = "0";
            lastNumberBox.Text = "";
            firstNumber = 0;
            lastNumber = 0;
            result = 0;
            operatingChar = ' ';

        }





    }
}


