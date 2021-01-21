using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace PrimeNumbers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int Secs { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        static bool IsPrime(int n)
        {
            if (n > 1)
            {
                return Enumerable.Range(1, n).Where(x => n % x == 0)
                                 .SequenceEqual(new[] { 1, n });
            }

            return false;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            tbContains.IsEnabled = false;
            ContainCheck(tbContains.Text);
        }
        public void ContainCheck(string x)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            bool first = true;
            for (int i = 0; i < 10000; i++)
            {
                if (IsPrime(i) && i.ToString().Contains(x))
                {
                    if (first)
                    {
                        Tb1.Text = i.ToString();
                        first = false;
                    }
                    else
                    {
                        Tb1.Text += $", {i}";
                    }
                }  
            }
            if (Tb1.Text == "")
            {
                Tb1.Text = "NIC";
            }
            stopWatch.Stop();
            tbTime1.Text = stopWatch.Elapsed.ToString(@"ss\:fff");
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            tbContains.IsEnabled = true;
            Tb1.Text = "";
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            tbMin.IsEnabled = false;
            tbMax.IsEnabled = false;
            InRange(tbMin.Text,tbMax.Text);
        }

        private void InRange(string min, string max)
        {
            bool first = true;
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                for (int i = int.Parse(min); i < int.Parse(max); i++)
                {
                    if (IsPrime(i))
                    {
                        if (first)
                        {
                            Tb2.Text = i.ToString();
                            first = false;
                        }
                        else
                        {
                            Tb2.Text += $", {i}";
                        }
                    }
                }
                if (Tb2.Text == "")
                {
                    Tb2.Text = "NIC";
                }
                stopWatch.Start();
                tbTime2.Text = stopWatch.Elapsed.ToString(@"ss\:fff");
            }
            catch (FormatException)
            {
                MessageBox.Show("Zadejte minimální i maximální hodnotu");
            }

        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            tbMin.IsEnabled = true;
            tbMax.IsEnabled = true;
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            RepeatCheck(tbContains.Text);
        }

        private void RepeatCheck(string x)
        {
            bool first = true;
            for (int i = 0; i < 1000; i++)
            {
                if (IsPrime(i))
                {
                    if (true)
                    {
                        if (first)
                        {
                            Tb1.Text = i.ToString();
                            first = false;
                        }
                        else
                        {
                            Tb1.Text += $", {i}";
                        }
                    }

                }
            }
        }

        private void CheckBox_Unchecked_2(object sender, RoutedEventArgs e)
        {
        }


    }
}
