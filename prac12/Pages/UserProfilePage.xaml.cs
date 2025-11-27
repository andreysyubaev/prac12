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
    /// Логика взаимодействия для UserProfilePage.xaml
    /// </summary>
    public partial class UserProfilePage : Page
    {
        User _user = new();
        public UserProfilePage(User? user)
        {
            InitializeComponent();

            _user = user;
            DataContext = _user;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Phone.Text != string.Empty && Bio.Text == string.Empty)
                MessageBox.Show("Введите остальные поля или сотрите введенные");
            else if (Bio.Text != string.Empty && Phone.Text == string.Empty)
                MessageBox.Show("Введите остальные поля или сотрите введенные");
            else 
                NavigationService.GoBack();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Phone.Text = string.Empty;
            Birthday.Text = string.Empty;
            Bio.Text = string.Empty;
            NavigationService.GoBack();
        }

        private void SelectAvatar_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();

            openFileDialog.Title = "Выберите фото";
            openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    _user.UserProfile.AvatarUrl = openFileDialog.FileName;

                    var binding = ((Image)FindName("AvatarImage")).GetBindingExpression(Image.SourceProperty);
                    binding?.UpdateTarget();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при выборе файла");
                }
            }
        }
    }
}
