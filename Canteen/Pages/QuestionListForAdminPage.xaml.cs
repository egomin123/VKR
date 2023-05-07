using Canteen.Classes;
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

namespace Canteen.Pages
{
    /// <summary>
    /// Логика взаимодействия для QuestionListForAdminPage.xaml
    /// </summary>
    public partial class QuestionListForAdminPage : Page
    {
        User MainUser;
        public QuestionListForAdminPage(User user)
        {
            InitializeComponent();
            MainUser = user;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage(MainUser));
        }
        List<Question> questions;
        private void HideButton(object sender, RoutedEventArgs e)
        {
            if (Hide.Text == "") MetricsDataGrid.ItemsSource = questions;
            else MetricsDataGrid.ItemsSource = new ConnectToDB().GetQuestionByName(Hide.Text);
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            questions = new ConnectToDB().GetAllQuestion();
            MetricsDataGrid.ItemsSource = questions;
        }
    }
}
