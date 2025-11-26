using prac12.Data;
using prac12.Models;
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

namespace prac12.Pages
{
    /// <summary>
    /// Логика взаимодействия для RoleList.xaml
    /// </summary>
    public partial class RoleList : Page
    {
        public RolesService service { get; set; } = new();
        public Role? current { get; set; } = null;
        public RoleList()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RoleForm());
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                if (MessageBox.Show(
                    "Вы действительно хотите удалить роль?",
                    "Удалить роль?",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    service.Remove(current);
            }
            else
            {
                MessageBox.Show(
                    "Выберите роль для удаления",
                    "Выберите роль",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void Edit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (current != null)
            {
                NavigationService.Navigate(new RoleForm(current));
            }
            else
            {
                MessageBox.Show("Выберите роль");
            }
        }
    }
}
