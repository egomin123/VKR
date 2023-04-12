using Canteen.Classes;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        User MainUser;
        int euqeel = 1;
        public MainPage(User user)
        {
            InitializeComponent();
            MainUser = user;
            LoginBlock.Header = MainUser.Login;
            TextTextText.Text = "Приём абитуриентов";
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(path1);
            bitmapImage.EndInit();
            ImagePhoto.Source = bitmapImage;
        }

        private void MyProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Profile(MainUser));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();
        }


        
        private void timerTick(object sender, EventArgs e)
        {
            euqeel++;
            SelectImage();
        }
        string path1 = Directory.GetCurrentDirectory() + "\\Priem.jpg";
        string path2 = Directory.GetCurrentDirectory() + "\\OnGroup.jpg";

        public void SelectImage()
        {
            if (euqeel == 1)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(path1);
                bitmapImage.EndInit();
                ImagePhoto.Source = bitmapImage;
                TextTextText.Text = "Приём абитуриентов";
                PhotoNumberText.Text = "1/2";
            }
            else if (euqeel == 2)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(path2);
                bitmapImage.EndInit();
                ImagePhoto.Source = bitmapImage;

                TextTextText.Text = "Распределение студентов по группам";
                PhotoNumberText.Text = "2/2";
            }
            else if (euqeel == 3)
            {
                euqeel = 0;
            }
            
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        private void MyMoney_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackImage(object sender, RoutedEventArgs e)
        {
            euqeel--;
            if (euqeel <= 0)
            {
                euqeel = 1;
            }
            
            SelectImage();
        }

        private void NextImage(object sender, RoutedEventArgs e)
        {
            if (euqeel == 2)
            {
                euqeel = 0;
            }
            euqeel++;
            SelectImage();
        }

        private void Go_To_Page(object sender, RoutedEventArgs e)
        {
            switch (euqeel)
            {
                case 1:
                    //NavigationService.Navigate(new BookATable(MainUser));
                    NavigationService.Navigate(new HowMuchGetAbiturientsOnStudentPage(MainUser));
                    break;
                case 2:
                    NavigationService.Navigate(new HowMuchGroups(MainUser));
                    break;
            }
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
    }
}
