using Canteen.Classes;
using Canteen.Pages;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        private void Reserv(object sender, RoutedEventArgs e)
        {
            string path = "C:\\Backup";    
            var t = new Thread(() => MaidCopy(path));
            t.Start();
        }


        private void UseCopy(object path)
        {
            bool Finished = false;
            string command = "";
            try
            {
                command = $@"USE master ALTER DATABASE [Canteen] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE [Canteen] FROM DISK = '{path.ToString()}' with file = 1; ALTER DATABASE [Canteen] SET MULTI_USER;";
                new ConnectToDB().DoCommand(command);
                Finished = true;
            }
            catch
            {
                command = "use master ALTER DATABASE [Canteen] SET MULTI_USER";
                new ConnectToDB().DoCommand(command);
            }
            if (Finished == true)
            {
                command = "use master ALTER DATABASE [Canteen] SET MULTI_USER";
                new ConnectToDB().DoCommand(command);
                Application.Current.Dispatcher.Invoke(() =>
                {
                   MessageBox.Show("Восстановление завершено");
                    
                });

            }
            else
            {
                command = "use master ALTER DATABASE [Canteen] SET MULTI_USER";
                new ConnectToDB().DoCommand(command);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("Ошибка восстановления");
                });

            }

        }



        private void MaidCopy(object folder)
        {
            string res = folder.ToString();
            string path = Convert.ToString(res) + @"\Backup.bak";
            string command = $@"BACKUP DATABASE [Canteen] TO DISK = '{path}'";
            new ConnectToDB().DoCommand(command);
            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageBox.Show("Файл создан по пути " + path);
            });

        }
        private void Vosstanow(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Data Base File (*.bak)|*.bak";
           
                if ( openFileDialog.ShowDialog() == true)
            {
                if (!String.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    var t = new Thread(() => UseCopy(openFileDialog.FileName));
                    t.Start();
                }
           
            }
        }
    }
}
