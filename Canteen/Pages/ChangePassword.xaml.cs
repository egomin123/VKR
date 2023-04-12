using Canteen.Classes;
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

namespace Canteen.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Page
    {
        public ChangePassword(string Email)
        {
            InitializeComponent();
            UserEmail = Email;
        }
        string UserEmail;

        private void EditPassword(object sender, RoutedEventArgs e)
        {
            User users = new ConnectToDB().GetUsersByEmail(UserEmail);
            User user = new User();




            if (Password.Text == "" || NewPassword.Text == "")
            {
                MessageBox.Show("Заполниете все поля");
            }
            else
            {


                if (Password.Text == NewPassword.Text)
                {
                    if (checkPassword(Password.Text))
                    {
                        if (users.Password != new EncryptAndDecryptClass().Shifrovka(Password.Text, "Aboba"))
                        {
                            try
                            {
                                users.Password = new EncryptAndDecryptClass().Shifrovka(Password.Text, "Aboba");
                                new ConnectToDB().EditUser(users);
                                MessageBox.Show("Пароль изменён");
                                NavigationService.Navigate(new Authorization());
                            }
                            catch
                            {
                                MessageBox.Show("Ошибка смены пароля");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Введён старый пароль");
                        }
                    }
                    else MessageBox.Show("Введён слабый пароль");
                }
                else
                {
                    MessageBox.Show("Пароли не одинаковы");
                }



            }
        }

        public bool checkPassword(string slovo)
        {
            bool result;
            int newball = 0;
            if (slovo.Length >= 6)
                newball++;
            Regex bukva4 = new Regex(@"[A-Z]");
            if (bukva4.IsMatch(slovo))
                newball++;
            Regex bukva3 = new Regex(@"[a-z]");
            if (bukva3.IsMatch(slovo))
                newball++;
            Regex bukva2 = new Regex(@"[0-9]");
            if (bukva2.IsMatch(slovo))
                newball++;
            Regex bukva1 = new Regex(@"\W");
            if (bukva1.IsMatch(slovo))
                newball++;
            if (newball != 5)
                result = false;
            else
                result = true;
            return result;
        }


        private void Cancel(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
    }
}
