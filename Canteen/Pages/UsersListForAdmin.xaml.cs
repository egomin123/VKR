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
    /// Логика взаимодействия для UsersListForAdmin.xaml
    /// </summary>
    public partial class UsersListForAdmin : Page
    {
        User MainUser;
        public UsersListForAdmin(User user)
        {
            InitializeComponent();
            MainUser = user;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage(MainUser));
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        List<User> users = new ConnectToDB().GetUsers();
        List<string> roles = new ConnectToDB().GetRolesForCB();
        private void HideButton(object sender, RoutedEventArgs e)
        {
            if(Hide.Text == "") MetricsDataGrid.ItemsSource = users = new ConnectToDB().GetUsers();
            else MetricsDataGrid.ItemsSource =  new ConnectToDB().GetHidenUser(Hide.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MetricsDataGrid.ItemsSource = users;
            RoleCB.ItemsSource = roles;
        }

        private void Delete_User_Click(object sender, RoutedEventArgs e)
        {
            int ID_User = users[MetricsDataGrid.SelectedIndex].ID_User;
            new ConnectToDB().DeleteUser(ID_User);
        }

        private void Edit_User_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.ID_User = users[MetricsDataGrid.SelectedIndex].ID_User;
            user.SecondName = SecondNameTB.Text;
            user.FirstName = FirstNameTB.Text;
            user.Patronymic = PatronymicTB.Text;
            user.Login = users[MetricsDataGrid.SelectedIndex].Login;
            user.Email = users[MetricsDataGrid.SelectedIndex].Email;
            user.Role_ID = new ConnectToDB().GetRoleByName(RoleCB.Text);
            user.Password = users[MetricsDataGrid.SelectedIndex].Password;
            new ConnectToDB().EditUser(user);
            MetricsDataGrid.ItemsSource = new ConnectToDB().GetUsers();
            
        }
    }
}
