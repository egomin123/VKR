using Canteen.Classes;
using Canteen.Pages;
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

namespace Canteen
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        User MainUser;
        public AdminPage(User user)
        {
            InitializeComponent();
            MainUser = user;
            TextTextText.Text = "Панель Администратора";
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void View_Tests(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TestList(MainUser));
        }

        private void Go_To_Abiturient_List(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AbiturientListFromAdmin(MainUser));
        }

        private void Go_to_Question_List(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new QuestionListForAdminPage(MainUser));
        }

        private void Go_To_User_List(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UsersListForAdmin(MainUser));
        }
    }
}
