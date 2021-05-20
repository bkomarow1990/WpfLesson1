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
        bool isHaveComaSecond = false;
        int index_two = -1;
        bool isHaveOperation = false;
        bool[] minuses = new bool[2];
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
            history.Text = resTxtBlock.Text;
            string res = (new DataTable().Compute((resTxtBlock.Text).Replace(',', '.'), null)).ToString();
            if (res == "∞")
            {
                MessageBox.Show("Can`t div to null");
                return;
            }
            resTxtBlock.Text = res;
            
            isHaveOperation = false;
            isHaveComa = false;
            minuses[0] = false;
            minuses[1] = false;
            if (resTxtBlock.Text[0] == '-')
            {
                minuses[0] = true;
            }
        }

        private void btnNum_Click(object sender, RoutedEventArgs e)
        {
            char num = ((sender as Button).Content as string)[0];
            if (isFirstNull())
            {

                this.resTxtBlock.Text = num.ToString();
                return;
            }
            this.resTxtBlock.Text += num;
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
                if (resTxtBlock.Text == "-")
                {
                    minuses[0] = false;
                    minuses[1] = false;
                }
                resTxtBlock.Text = "0";
                return;
            }
            char symb = resTxtBlock.Text[resTxtBlock.Text.Length - 1];
            if (isHaveOperation)
            {
                if (symb == ',')
                {
                    isHaveComaSecond = false;
                }
                
            }
            else
            {
                if (symb == ',')
                {
                    isHaveComa = false;
                }
            }
            if (isOperationChar(symb) && isHaveOperation)
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
            index_two = resTxtBlock.Text.Length - 1;
        }
        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            if (isHaveOperation)
            {
                return;
            }

            resTxtBlock.Text += '/';
            isHaveOperation = true;
            index_two = resTxtBlock.Text.Length - 1;
        }

        private void btnComa_Click(object sender, RoutedEventArgs e)
        {

            char res = resTxtBlock.Text[resTxtBlock.Text.Length - 1];
            if (res == '0' || isOperationChar(res) )
            {
                return;
            }
            if (isHaveComa && isHaveOperation)
            {
                if (isHaveComaSecond)
                {
                    return;
                }
                this.isHaveComaSecond = true;
                resTxtBlock.Text += ',';
                return;
            }
            resTxtBlock.Text += ',';
            isHaveComa = true;
        }

        private void btnCLear_Click(object sender, RoutedEventArgs e)
        {
            isHaveOperation = false;
            isHaveComa = false;
            isHaveComaSecond = false;
            minuses[0] = false;
            minuses[1] = false;
            resTxtBlock.Text = "0";
        }

        private void btnChangeSymb_Click(object sender, RoutedEventArgs e)
        {
            if (isHaveOperation)
            {
                if (minuses[1])
                {
                    resTxtBlock.Text = resTxtBlock.Text.Remove(index_two + 1,1);
                    minuses[1] = false;
                    return;
                }
                resTxtBlock.Text = resTxtBlock.Text.Insert(index_two+1,"-");
                minuses[1] = true;
                return;
            }
            if (resTxtBlock.Text == "0")
            {
                return;
            }
            if (minuses[0])
            {
                resTxtBlock.Text = resTxtBlock.Text.Remove(0,1);
                minuses[0] = false;
                return;
            }
            resTxtBlock.Text = resTxtBlock.Text.Insert(0, "-");
            minuses[0] = true;
        }
    }
}
