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
    /// Логика взаимодействия для TestList.xaml
    /// </summary>
    public partial class TestList : Page
    {
        User MainUser;
        public TestList(User user)
        {
            InitializeComponent();
            MainUser = user;
            LoginBlock.Header = MainUser.Login;
            if (MainUser.Role_ID == 1)
            {
                Button1.Content = "Удалить тест";
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button2.Visibility = Visibility.Hidden;
                Button3.Visibility = Visibility.Hidden;
            }
            else
            {
                Button1.Content = "Загрузить тест из Excel";
                Button2.IsEnabled = true;
                Button3.IsEnabled = true;
                Button2.Visibility = Visibility.Visible;
                Button3.Visibility = Visibility.Visible;
            }
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            if (MainUser.Role_ID == 1) NavigationService.Navigate(new AdminPage(MainUser));
            else NavigationService.Navigate(new TesterPage(MainUser));
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
        List<Test> tests = new ConnectToDB().GetTests();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MetricsDataGrid.ItemsSource = tests;
            DirectionCB.ItemsSource = Directions;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateTestPage(MainUser));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int ID_Test = 0;
            ID_Test = tests[MetricsDataGrid.SelectedIndex].ID_Test;
            string TestName = new ConnectToDB().GetTestName(ID_Test);
            NavigationService.Navigate(new ViewTest(MainUser, ID_Test, TestName));

        }

        List<String> Directions = new ConnectToDB().GetDirectionsForCB();
        private void Set_Difficuluty_Click(object sender, RoutedEventArgs e)
        {
            int ID_Test = 0;
            ID_Test = tests[MetricsDataGrid.SelectedIndex].ID_Test;
            int ID_Direction = new ConnectToDB().GetDirectionsIDFromCB(DirectionCB.Text);
            new ConnectToDB().UpdateTest(ID_Test, ID_Direction);
            tests = new ConnectToDB().GetTests();
            MetricsDataGrid.ItemsSource = tests;
        }

   

        private void HideButton(object sender, RoutedEventArgs e)
        {
            if (Hide.Text == "") MetricsDataGrid.ItemsSource = new ConnectToDB().GetTests();
            else MetricsDataGrid.ItemsSource = new ConnectToDB().GetHidenTest(Hide.Text);

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (MainUser.Role_ID == 1)
            {
                int ID_Test = tests[MetricsDataGrid.SelectedIndex].ID_Test;
                new ConnectToDB().DeleteTest(ID_Test);
                MessageBox.Show("Тест удалён");
                NavigationService.Navigate(new AdminPage(MainUser));
            }
        }
    }
}
