using Canteen.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для Registrarion.xaml
    /// </summary>
    public partial class Registrarion : Page
    {
        public Registrarion()
        {
            InitializeComponent();
            Random random = new Random();
            vov = random.Next();
            Code.Visibility = Visibility.Hidden;
            TextCode.Visibility = Visibility.Hidden;
            Code.IsEnabled = false;
            TextCode.IsEnabled = false;
        }
        string UserEmail;
        int vov = 0;
        int qwe = 0;
        private void Registrate(object sender, RoutedEventArgs e)
        {
            User users = new ConnectToDB().GetUsersByEmail(Email.Text);
            User user = new User();




            if ((Login.Text == "" && Login.Text != null) || (Password.Text == "" && Password.Text != null)
                || (Email.Text == "" && Email.Text != null) || (FirstName.Text == "" && FirstName.Text != null) || (SecondName.Text == "" && SecondName.Text != null))
            {
                MessageBox.Show("Заполниете все поля");
            }
            else
            {
                if (AcceptedPersonalInfoCB.IsChecked == true)
                {
                    try
                    {
                        if (new ConnectToDB().CheckIfLoginIsNew(Login.Text))
                        {
                            if (new ConnectToDB().CheckIfEmailIsNew(Email.Text))
                            {
                                if (IsValidEmail(Email.Text))
                                {

                                    if (checkPassword(Password.Text))
                                    {
                                        if (qwe == 0)// сообщение
                                        {

                                            Code.Visibility = Visibility.Visible;
                                            TextCode.Visibility = Visibility.Visible;
                                            Code.IsEnabled = true;
                                            TextCode.IsEnabled = true;

                                            UserEmail = Email.Text;

                                            string login = "adm1nomsystem453@mail.ru";
                                            string pasword = "QAaUuNXve9zPQSuv2ncm";

                                            // отправитель - устанавливаем адрес и отображаемое в письме имя
                                            MailAddress from = new MailAddress(login, "Код регистрации");
                                            // кому отправляем
                                            MailAddress to = new MailAddress(Email.Text);
                                            // создаем объект сообщения
                                            MailMessage m = new MailMessage(from, to);
                                            // тема письма
                                            m.Subject = "Регистрация пользователя";
                                            // текст письма
                                            m.Body = $"<h2>Ваш код для создания пользователя: {vov}</h2>";
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
                                            qwe = 1;
                                        }
                                        else if (qwe == 1)
                                        {
                                            if (Code.Text == Convert.ToString(vov))
                                            {
                                                user.Login = Login.Text;
                                                user.Password = new EncryptAndDecryptClass().Shifrovka(Password.Text, "Aboba");
                                                user.SecondName = SecondName.Text;
                                                user.FirstName = FirstName.Text;
                                                user.Patronymic = Patronymic.Text;
                                                user.Email = Email.Text;
                                                user.Role_ID = 1004;
                                                new ConnectToDB().AddUser(user);
                                                qwe = 0;
                                                NavigationService.Navigate(new Authorization());
                                            }
                                            else
                                            {
                                                MessageBox.Show("Введён неверный код");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Введён слабый пароль");
                                    }


                                }
                                else
                                {
                                    MessageBox.Show("Введена неккоректная почта");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Пользователь с такой почтой уже существует");
                            }
                        }

                        else
                        { MessageBox.Show("Пользователь с таким логином уже существует"); }
                    }
                    catch (Exception exception) { MessageBox.Show("Что-то пошлно не так. " + exception); }
                }
                else MessageBox.Show("Подтвердите согласие на обработку персональных данных");
            
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        // Проверка силы пароля
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


        // Проверка корректности Почты
        public bool IsValidEmail(string email)
        {

            string pattern = @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(.[-.a-zA-Z0-9]+)*.
(com|edu|info|gov|int|mil|net|org|ru|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$";
            Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
            bool valid = false;
            if (string.IsNullOrWhiteSpace(email))
            {
                valid = false;
            }
            else
            {
                valid = check.IsMatch(email);
            }
            return valid;
        }

        private void OnluLetter(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int i))
            {
                e.Handled = true;
            }
        }

        private void JustNumbers(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890".IndexOf(e.Text) < 0;
        }

       

      
     

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new ConnectToDB().ClearAbiturient11();
            new ConnectToDB().ClearAbiturientSPO();
            new ConnectToDB().ClearStudents();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new ConnectToDB().ClearAbiturientSPO();
            new ConnectToDB().ClearAbiturient11();
            new ConnectToDB().ClearStudents();
        }

       
    }
}
