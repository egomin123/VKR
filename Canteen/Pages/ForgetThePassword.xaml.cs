using Canteen.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для ForgetThePassword.xaml
    /// </summary>
    public partial class ForgetThePassword : Page
    {
        public ForgetThePassword()
        {
            InitializeComponent();
            Random random = new Random();
            vov = random.Next();
            Code.Visibility = Visibility.Hidden;
            TextCode.Visibility = Visibility.Hidden;
        }
        int vov = 0;
        int equal = 0;
        string UserEmail;

        private void SendAndRecovery(object sender, RoutedEventArgs e)
        {
            User users = new ConnectToDB().GetUsersByEmail(Email.Text);
            if (equal == 0)
            {

                if (Email.Text == users.Email)
                {
                    SendButton.Content = "Продолжить";
                    equal = 1;
                    Code.Visibility = Visibility.Visible;
                    TextCode.Visibility = Visibility.Visible;

                    UserEmail = Email.Text;

                    string login = "adm1nomsystem453@mail.ru";
                    string pasword = "QAaUuNXve9zPQSuv2ncm";

                    // отправитель - устанавливаем адрес и отображаемое в письме имя
                    MailAddress from = new MailAddress(login, "Код авторизации");
                    // кому отправляем
                    MailAddress to = new MailAddress(Email.Text);
                    // создаем объект сообщения
                    MailMessage m = new MailMessage(from, to);
                    // тема письма
                    m.Subject = "Восстановление пароля";
                    // текст письма
                    m.Body = $"<h2>Ваш код восстановления пароля: {vov}</h2>";
                    // письмо представляет код html
                    m.IsBodyHtml = true;
                    // адрес smtp-сервера и порт, с которого будем отправлять письмо
                    string str = "";
                    if (login.Contains("@gmail.com")) str = "smtp.gmail.com";
                    else if (login.Contains("@mail.ru")) str = "smtp.mail.ru";
                    SmtpClient smtp = new SmtpClient(str, 587);
                    // логин и пароль
                    smtp.Credentials = new NetworkCredential(login, pasword);
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                    //открытие ввода кода
                }
                else
                {
                    MessageBox.Show("Введена неверная почта");
                }



            }
            else if (equal == 1)
            {
                try
                {
                    if (Convert.ToInt32(Code.Text) == vov)
                    {
                        MessageBox.Show("Код верен");
                        NavigationService.Navigate(new ChangePassword(UserEmail));
                    }
                    else
                    {
                        MessageBox.Show("Введён неверный код");
                    }
                }
                catch
                {
                    MessageBox.Show("Введён неверный код");
                }
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        // Возможность записи только цифр
        private void JustNumbers(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890".IndexOf(e.Text) < 0;
        }
    }
}
