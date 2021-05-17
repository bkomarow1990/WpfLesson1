using System;
using System.Collections.Generic;
using System.Data;
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

namespace CalcClasswork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isHaveComa = false;
        int index_two = -1;
        bool isHaveOperation = false;
        public MainWindow()
        {
            InitializeComponent();
            MyInit();
        }
        private void MyInit()
        {
            resTxtBlock.Text = "0";
        }
        private bool isFirstNull() {
            return resTxtBlock.Text[0] == '0';
        }
        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            
            if (resTxtBlock.Text.Length <= 0 || resTxtBlock.Text[0] == '0')
            {
                return;
            }
            if (index_two != -1 && resTxtBlock.Text[index_two] == '0')
            {
                return;
            }
            this.resTxtBlock.Text += '0';
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            if (isOperationChar(resTxtBlock.Text[resTxtBlock.Text.Length - 1]))
            {
                return;
            }
            resTxtBlock.Text = (new DataTable().Compute(resTxtBlock.Text, null)).ToString();
            isHaveOperation = false;
            isHaveComa = false;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (isFirstNull())
            {
                this.resTxtBlock.Text = "1";
                return;
            }
            this.resTxtBlock.Text += '1';
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (isFirstNull())
            {
                this.resTxtBlock.Text = "2";
                return;
            }
            this.resTxtBlock.Text += '2';
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            if (isFirstNull())
            {
                this.resTxtBlock.Text = "3";
                return;
            }
            this.resTxtBlock.Text += '3';
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (isFirstNull())
            {
                this.resTxtBlock.Text = "4";
                return;
            }
            this.resTxtBlock.Text += '4';
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            if (isFirstNull())
            {
                this.resTxtBlock.Text = "5";
                return;
            }
            this.resTxtBlock.Text += '5';
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            if (isFirstNull())
            {
                this.resTxtBlock.Text = "6";
                return;
            }
            this.resTxtBlock.Text += '6';
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if (isFirstNull())
            {
                this.resTxtBlock.Text = "7";
                return;
            }
            this.resTxtBlock.Text += '7';
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            if (isFirstNull())
            {
                this.resTxtBlock.Text = "8";
                return;
            }
            this.resTxtBlock.Text += '8';
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            if (isFirstNull())
            {
                this.resTxtBlock.Text = "8";
                return;
            }
            this.resTxtBlock.Text += '9';
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (isHaveOperation)
            {
                return;
            }
            resTxtBlock.Text += '+';
            isHaveOperation = true;
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (isHaveOperation)
            {
                return;
            }

            resTxtBlock.Text += '-';
            isHaveOperation = true;
        }
        private bool isOperationChar(char symb)
        {
            char[] operations = new char[4] { '+', '-', '*', '/' };
            foreach (char item in operations)
            {
                if (symb == item)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnClearOne_Click(object sender, RoutedEventArgs e)
        {
            if (resTxtBlock.Text.Length == 0)
            {
                return;
            }
            if (resTxtBlock.Text.Length == 1)
            {
                resTxtBlock.Text = "0";
                return;
            }
            if (isOperationChar(resTxtBlock.Text[resTxtBlock.Text.Length - 1]))
            {
                isHaveOperation = false;
            }
            
            resTxtBlock.Text = resTxtBlock.Text.Remove(resTxtBlock.Text.Length - 1, 1);

        }

        private void btnMult_Click(object sender, RoutedEventArgs e)
        {
            if (isHaveOperation)
            {
                return;
            }

            resTxtBlock.Text += '*';
            isHaveOperation = true;
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            if (isHaveOperation)
            {
                return;
            }

            resTxtBlock.Text += '/';
            isHaveOperation = true;
        }

        private void btnComa_Click(object sender, RoutedEventArgs e)
        {

            char res = resTxtBlock.Text[resTxtBlock.Text.Length - 1];
            if (res == '0' || isOperationChar(res) || isHaveComa)
            {
                return;
            }
            resTxtBlock.Text += '.';
            isHaveComa = true;
        }

        private void btnCLear_Click(object sender, RoutedEventArgs e)
        {
            isHaveOperation = false;
            isHaveComa = false;
            resTxtBlock.Text = "0";
        }
    }
}
