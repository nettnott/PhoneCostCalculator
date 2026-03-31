using System;
using System.Windows;
using System.Windows.Controls;

namespace PhoneCostCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cboDayOfWeek.SelectedIndex = 0;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            txtError.Text = "";
            txtResult.Text = "";

            // Проверка длительности
            if (!int.TryParse(txtDuration.Text, out int duration) || duration <= 0)
            {
                txtError.Text = "Введите корректную длительность (целое число больше 0).";
                return;
            }

            // Проверка цены
            if (!double.TryParse(txtPrice.Text, out double price) || price <= 0)
            {
                txtError.Text = "Введите корректную цену (число больше 0).";
                return;
            }

            // Получение дня недели
            string dayOfWeek = (cboDayOfWeek.SelectedItem as ComboBoxItem)?.Content?.ToString();
            if (string.IsNullOrEmpty(dayOfWeek))
            {
                txtError.Text = "Выберите день недели.";
                return;
            }

            double result = CostCalculator.Calculate(duration, price, dayOfWeek);
            txtResult.Text = result.ToString("F2");
        }
    }
}
