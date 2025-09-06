using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppCalculator
{
    public partial class MainWindow : Window
    {
        private List<string> calculationHistory = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private double CalculateExpression(double x)
        {
            try
            {
                // e^x - x - 2 + (1 + x)^x
                double part1 = Math.Exp(x);          // e^x
                double part2 = -x - 2;               // -x - 2
                double part3 = Math.Pow(1 + x, x);   // (1 + x)^x

                return part1 + part2 + part3;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ошибка вычисления для x = {x}: {ex.Message}");
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (double.TryParse(txtX.Text, out double x))
                {
                    double result = CalculateExpression(x);
                    string calculation = $"f({x}) = e^{x} - {x} - 2 + (1 + {x})^{x} = {result:F6}";

                    txtResult.Text = result.ToString("F6");
                    calculationHistory.Add(calculation);
                    lstHistory.Items.Add(calculation);
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректное числовое значение для x.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}