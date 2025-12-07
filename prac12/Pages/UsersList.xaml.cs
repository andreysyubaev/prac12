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
    /// Логика взаимодействия для UsersList.xaml
    /// </summary>
    public partial class UsersList : Page
    {
        public UsersService service { get; set; } = new();
        public User? user { get; set; } = null;
        public InterestGroup current { get; set; }
        public UsersList()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Edit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Выберите элемент из списка!");
                return;
            }
            NavigationService.Navigate(new UserPage(user));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserPage());
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }
            if (MessageBox.Show(
                "Вы действительно хотите удалить запись?", 
                "Удалить?",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes
                )
            {
                service.Remove(user);
            }
        }

        private void Roles_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RoleList());
        }

        private void Groups_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InterestGroupPage());
        }

        private void Join_Click(object sender, RoutedEventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Выберите элемент из списка!");
                return;
            }
            NavigationService.Navigate(new RegInterestGroup(user));
        }
    }
}
