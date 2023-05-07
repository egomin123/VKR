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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }
        //Функция входа в систему 
        private void Enter(object sender, RoutedEventArgs e)
        {
            bool secondEqual = true;
            int SecondEqual = 0;
            List<User> users = new ConnectToDB().GetUsersByLogin(Login.Text);
            int equal = 0;
            if (Login.Text == "" || Password.Password == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                foreach (User user in users)
                {
                    if (Login.Text == user.Login)
                    {
                        equal = 1;


                        if (user.Password == new EncryptAndDecryptClass().Shifrovka(Password.Password, "Aboba"))
                        {

                            User users1 = new ConnectToDB().GetUsersByLoginForButton(Login.Text);
                            // Post post = new FastConnection().GetPostByID(personal_Card.Post_ID)[0];
                            int Rolll = 0;
                            SecondEqual = 1;
                            //Успешная авторизация
                            secondEqual = false;

                            if (users1.Role_ID == 1)
                            {

                                NavigationService.Navigate(new AdminPage(user));
                            }
                            else if (users1.Role_ID == 2)
                            {
                                NavigationService.Navigate(new MainPage(user));
                            }
                            else if (users1.Role_ID == 1003)
                            {
                                NavigationService.Navigate(new TesterPage(user));
                            }
                        }
                        else if (secondEqual == true && SecondEqual != 1)
                        {
                            MessageBox.Show("Неверный пароль");
                            SecondEqual = 1;
                        }
                    }


                }
                if (equal == 0)
                {
                    MessageBox.Show("Такого пользователя нет");
                }
            }
        }

        private void ForgetThePassword(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ForgetThePassword());
        }

        private void Registrarion(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registrarion());
        }

       
    }
}
