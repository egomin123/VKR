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
    /// Логика взаимодействия для TesterPage.xaml
    /// </summary>
    public partial class TesterPage : Page
    {
        User MainUser;
        public TesterPage(User user)
        {
            InitializeComponent();
            MainUser = user;
            new ConnectToDB().DeleteEmptyQuestion();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoginBlock.Header = MainUser.Login;
            TextTextText.Text = "Окно инженера тестирования";
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

       

        private void Go_To_Test_List(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TestList(MainUser));
        }

        private void Add_Test_Page(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateTestPage(MainUser));
        }

        private void Read_The_Results(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ResultsTestsPage(MainUser));
        }

        private void MyProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Profile(MainUser));
        }

        private void Stast_Test_Page(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new InputAbiturientInfoPage(MainUser));

        }

        
    }
}
