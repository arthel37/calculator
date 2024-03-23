using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double currentValue = 0.0;
        double calculatedValue = 0.0;
        string op = "";
        string prevOp = "";
        bool beforeResult = true;
        bool isValueFirst = true;
        bool afterOp = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Operation(string op)
        {
            if (beforeResult)
            {
                if (textBox.Text != "")
                {
                    currentValue = Double.Parse(textBox.Text);
                }
                else
                {
                    currentValue = 0.0;
                }
            }

            if (op == "+")
            {
                calculatedValue += currentValue;
            }
            else if (op == "-")
            {
                calculatedValue -= currentValue;
            }
            else if (op == "*")
            {
                calculatedValue *= currentValue;
            }
            else if (op == "/")
            {
                calculatedValue /= currentValue;
            }
            afterOp = true;
        }

        private void ValueClick(object sender, RoutedEventArgs e)
        {
            if (!beforeResult)
            {
                textBox.Text = "";
                isValueFirst = true;
                beforeResult = true;
            }

            if(afterOp)
            {
                textBox.Text = "";
                afterOp = false;
                if (op == "-")
                {
                    textBox.Text += "-";
                    op = prevOp;
                }
            }

            Button clickedButton = (Button)sender;
            textBox.Text += clickedButton.Content;
        }

        private void OperationClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            op = (string)clickedButton.Content;
            if (afterOp & op == "-")
            {
                return;
            }
            if (!beforeResult)
            {
                isValueFirst = false;
            }
            else if (isValueFirst)
            {
                Operation("+");
                isValueFirst = false;
            }
            else
            {
                Operation(op);
            }
            textBox.Text = calculatedValue.ToString();
            beforeResult = true;
            prevOp = op;
        }

        private void BackspaceClick(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length > 0)
            {
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
            }
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
            currentValue = 0;
            calculatedValue = 0;
            beforeResult = true;
            isValueFirst = true;
            afterOp = false;
        }

        private void ResultClick(object sender, RoutedEventArgs e)
        {
            Operation(op);
            textBox.Text = calculatedValue.ToString();
            beforeResult = false;
        }
    }
}