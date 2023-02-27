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

namespace FirstTryCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        long digits;
        long counter;
        char operatingChar;
        public MainWindow()
        {
            InitializeComponent();
        }

   
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Content.ToString();


            if (display.Text == "0")
            {
                display.Text = "";
            }

            display.Text += content;

        }        
        
        private void DeleteDigit(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Content.ToString();

            if (display.Text.Length == 1)
            {
                display.Text = "0";

            }
            else
            {
            
                display.Text = display.Text.Remove(display.Text.Length -1);

            }

        }        
        
        private void Del_All(object sender, RoutedEventArgs e)
        {


            display.Text = "0";
            counter = 0;
            digits = 0;

        }

        private void Plus(object sender, RoutedEventArgs e)
        {
            long parsedNumber = Int32.Parse(display.Text);

            operatingChar = '+';
            display.Text = "0";

            counter += parsedNumber;


        }       
        
        private void Minus(object sender, RoutedEventArgs e)
        {
            long parsedNumber = Int32.Parse(display.Text);

            operatingChar = '-';
            display.Text = "0";

            digits = parsedNumber;

            counter -= (counter - digits);


        }        
        
        private void Multiply(object sender, RoutedEventArgs e)
        {
            long parsedNumber = Int32.Parse(display.Text);

            operatingChar = '*';
            display.Text = "0";

            digits = parsedNumber;
            counter += (counter * digits);


        }

        private void Equation(object sender, RoutedEventArgs e)
        {
            long parsedNumber = Int32.Parse(display.Text);

            if (operatingChar == '+')
            {
                long calculation = counter + parsedNumber;
                display.Text = calculation.ToString();
            
            }
            else if (operatingChar == '-')
            {
                long calculation = counter - parsedNumber;
                display.Text = calculation.ToString();
            }
            else if (operatingChar == '/')
            {
                long calculation = counter / parsedNumber;
                display.Text = calculation.ToString();
            }
            else if (operatingChar == '*')
            {
                long calculation = counter * parsedNumber;
                display.Text = calculation.ToString();
            }

        }    
        

    }
}


