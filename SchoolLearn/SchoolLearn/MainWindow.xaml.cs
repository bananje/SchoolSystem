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

namespace SchoolLearn
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool adminMode = false;
        public MainWindow()
        {
            InitializeComponent();
            lvServices.ItemsSource = App.DataBase.Services.ToList();
        }

        private void btnAdminMode_Click(object sender, RoutedEventArgs e)
        {
            Windows.AdminWindow adminWindow = new Windows.AdminWindow();
            adminWindow.ShowDialog();

            if(adminMode == true)
            {
                rowAdmin.MaxHeight = 40;
            }
        }

        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddEditServiceWindow addEditServiceWindow = new Windows.AddEditServiceWindow(null);
            addEditServiceWindow.Title = "Добавление услуги";
            addEditServiceWindow.ShowDialog();
            lvServices.ItemsSource = App.DataBase.Services.ToList();
        }

        private void btnRegistrateClient_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция в разработке");
        }

        private void btnLookMeets_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция в разработке");
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (adminMode == false)
            {
                MessageBox.Show("Войдите в режим администратора для доступа к данной функции!");
                return;
            }
            Windows.AddEditServiceWindow addEditServiceWindow = new Windows.AddEditServiceWindow((sender as Button).DataContext as Entities.Service);
            addEditServiceWindow.Title = "Изменение услуги";
            addEditServiceWindow.ShowDialog();
            lvServices.ItemsSource = App.DataBase.Services.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (adminMode == false)
            {
                MessageBox.Show("Войдите в режим администратора для доступа к данной функции!");
                return;
            }
            if(MessageBox.Show($"Вы уверены, что хотите удалить данную услугу", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    App.DataBase.Services.Remove((sender as Button).DataContext as Entities.Service);
                    App.DataBase.SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    lvServices.ItemsSource = App.DataBase.Services.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
