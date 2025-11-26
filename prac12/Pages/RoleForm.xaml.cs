using prac12.Data;
using prac12.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prac12.Pages
{
    /// <summary>
    /// Логика взаимодействия для RoleForm.xaml
    /// </summary>
    public partial class RoleForm : Page
    {
        Role _role = new();
        RolesService service = new();
        bool IsEdit = false;
        public RoleForm(Role? role = null)
        {
            InitializeComponent();

            if (role != null)
            {
                service.LoadRelation(role, "Users");
                _role = role;
                IsEdit = true;
            }
            DataContext = _role;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (IsEdit)
                service.Commit();
            else
                service.Add(_role);
            Back_Click(sender, e);
        }
    }
}
