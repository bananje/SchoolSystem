using SchoolLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SchoolLearn.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditServiceWindow.xaml
    /// </summary>
    public partial class AddEditServiceWindow : Window
    {
        private Service _currentService = new Service();
        public AddEditServiceWindow(Service selectedService)
        {
            InitializeComponent();
            if (selectedService != null)
                _currentService = selectedService;
            DataContext = _currentService;
        }

        private void btnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция в разработке");
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentService.Title))
                errors.AppendLine("Введите название!");
            if (string.IsNullOrWhiteSpace(_currentService.Cost.ToString()))
                errors.AppendLine("Введите цену!");
            if (string.IsNullOrWhiteSpace(_currentService.DurationInSeconds.ToString()))
                errors.AppendLine("Введите длительность!");
            if(!Regex.IsMatch(tbCost.Text, @"[0-9]") || _currentService.Cost <= 0)
                errors.AppendLine("Цена должна быть положительным числом!");
            
            if (!Regex.IsMatch(tbDuration.Text, @"[0-9]") || _currentService.DurationInSeconds <= 0)
                errors.AppendLine("Длительность должна быть положительным числом!");
            if (string.IsNullOrWhiteSpace(tbDiscount.Text) == false)
            {
                if (!Regex.IsMatch(tbDiscount.Text, @"[0-9 ,.]") || _currentService.Discount <= 0)
                    errors.AppendLine("Скидка должна быть положительным числом!");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentService.ID == 0)
                App.DataBase.Services.Add(_currentService);

            try
            {
                App.DataBase.SaveChanges();
                MessageBox.Show("Данные сохранены!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
