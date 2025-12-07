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
    /// Логика взаимодействия для InterestGroupForm.xaml
    /// </summary>
    public partial class InterestGroupForm : Page
    {
        InterestGroup _interestGroup = new();
        InterestGroupService service = new();
        bool IsEdit = false;
        public InterestGroupForm(InterestGroup? interestGroup = null)
        {
            InitializeComponent();

            if (interestGroup != null)
            {
                _interestGroup = interestGroup;
                IsEdit = true;
            }
            DataContext = _interestGroup;
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
                service.Add(_interestGroup);
            Back_Click(sender, e);
        }
    }
}
