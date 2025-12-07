using prac12.Data;
using prac12.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для RegInterestGroup.xaml
    /// </summary>
    public partial class RegInterestGroup : Page
    {
        public User user { get; set; }
        public UserInterestGroup userInterestGroup { get; set; } = new();
        public InterestGroupService interestGroupService { get; set; } = new();
        public RegInterestGroup(User _user)
        {
            InitializeComponent();
            user = _user;
            DataContext = this;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Join_Click(object sender, RoutedEventArgs e)
        {
            var selectedGroup = GroupListView.SelectedItem as InterestGroup;

            if (selectedGroup == null)
            {
                MessageBox.Show("Пожалуйста, выберите группу из списка!");
                return;
            }

            interestGroupService.AddUserToGroup(user, userInterestGroup, selectedGroup);

            MessageBox.Show($"Пользователь добавлен в группу {selectedGroup.Title}!");
            Back_Click(sender, e);
        }
    }
}
