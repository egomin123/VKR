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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        User MainUser;
        public Profile(User user)
        {
            InitializeComponent();
            MainUser = user;
        }

        public void fillData()
        {
            FirstName.Text = MainUser.FirstName;
            SecondName.Text = MainUser.SecondName;
            Patronymic.Text = MainUser.Patronymic;
        }

        private void Go_To_Page1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AbiturientList(MainUser));
        }

        private void Go_To_Page2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Students(MainUser));
        }

        private void Go_To_Group(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Groups(MainUser));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fillData();
        }

        private void Registrate(object sender, RoutedEventArgs e)
        {
            int equel = 0;
            User NewUser = new User(MainUser.Login, MainUser.Role_ID, MainUser.ID_User, MainUser.Email);
            NewUser.FirstName = FirstName.Text;
            NewUser.SecondName = NewUser.FirstName = FirstName.Text;
            NewUser.Patronymic = Patronymic.Text;
            if (Password.Text == "" || Password.Text == null || String.IsNullOrWhiteSpace(Password.Text))
            
                NewUser.Password = MainUser.Password;
               
            
            else
                NewUser.Password = new EncryptAndDecryptClass().Shifrovka(Password.Text, "Aboba");
                new ConnectToDB().EditUser(NewUser);
            MessageBox.Show("Данные изменены");
            
        }

        private void OnluLetter(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int i))
            {
                e.Handled = true;
            }
        }


        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
    }
}
