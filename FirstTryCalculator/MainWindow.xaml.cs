using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
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
        double firstNumber;
        double lastNumber;
        double result;
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
        private void PlusMinus(object sender, RoutedEventArgs e)
        {
            
            if( display.Text.StartsWith("-"))
            {
                display.Text = display.Text.Remove(0, 1);

            }
            else
            {
                display.Text = display.Text.Insert(0, "-");

            }



        }
        private void Operation(char mathSign)
        {
            double parsedNumber = double.Parse(display.Text);
            
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

                
                lastNumberBox.Text = $"{lastNumber} {operatingChar}";
                lastNumber = result;

                display.Text = result.ToString();
            }
        }
        private void Equation(object sender, RoutedEventArgs e)
        {
            double parsedNumber = double.Parse(display.Text);

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
                nextNumber = true;


            }
            else
            {

                display.Text = display.Text.Remove(display.Text.Length - 1);

            }

        }
        private void ClearError(object sender, RoutedEventArgs e)
        {

            display.Text = "0";


        }
        private void Del_All(object sender, RoutedEventArgs e)
        {

            display.Text = "0";
            lastNumberBox.Text = "";
            firstNumber = 0;
            lastNumber = 0;
            result = 0;
            operatingChar = ' ';
            nextNumber = true;


        }    

        private void PressedNumKey(object sender, KeyEventArgs e)
        {
           int pressedKey =  e.Key.GetHashCode();

            if (nextNumber)
            {
                display.Text = "";
                nextNumber = false;
            }

            if (pressedKey > 33 && pressedKey < 44 || pressedKey > 73 && pressedKey < 84)
            {
            
                string nameOfKey = e.Key.ToString();

                display.Text += nameOfKey.Last().ToString();
            }
            


        }
    }
}

