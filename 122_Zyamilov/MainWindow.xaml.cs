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

namespace _122_Zyamilov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(InputX.Text))
                {
                    MessageBox.Show("Введите значение x!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!double.TryParse(InputX.Text, out double x))
                {
                    MessageBox.Show("Некорректное значение x! Введите число.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(InputY.Text))
                {
                    MessageBox.Show("Введите значение y!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!double.TryParse(InputX.Text, out double y))
                {
                    MessageBox.Show("Некорректное значение y! Введите число.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                double f_x = 0;
                if (RadioSh.IsChecked == true)
                {
                    f_x = Math.Sinh(x);
                }
                else if (RadioSquare.IsChecked == true) { 
                    f_x = Math.Pow(x, 2);
                }
                else if (RadioExp.IsChecked == true)
                {
                    f_x = Math.Exp(x);
                }

                double d;

                if (x > y)
                {
                    d = Math.Pow(f_x-y, 3) + Math.Atan(f_x);
                }
                else if (y > x)
                {
                    d = Math.Pow(y - f_x, 3) + Math.Atan(f_x);
                }
                else
                {
                    d = Math.Pow(y + f_x, 3) + 0.5;
                }

                ResultBox.Text = d.ToString("F2");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           



        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputX.Clear();
            InputY.Clear();
            RadioSh.IsChecked = true;
            ResultBox.Clear();
        }
    }
}
