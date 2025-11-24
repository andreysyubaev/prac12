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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private UsersService _service = new();
        public User _user = new();
        bool isEdit = false;
        public UserPage(User? _editUser = null)
        {
            InitializeComponent();
            if (_editUser != null)
            {
                _user = _editUser;
                isEdit = true;
            }
            DataContext = _user;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_user.Password != ConfirmPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            if (isEdit)
                _service.Commit();
            else
                _service.Add(_user);
            NavigationService.GoBack();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
