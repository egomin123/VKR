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
    /// Логика взаимодействия для StartTestPage.xaml
    /// </summary>
    public partial class StartTestPage : Page
    {
        User MainUser;
        int NumberCompletedTests = 0;
        AbiturientSPO MainAbiturient;
        int ID_FirstDirection = 0;
        int ID_SecondDirection = 0;
        int ID_ThiredDirection = 0;
        public StartTestPage(User user, AbiturientSPO abiturient, int FirstDirection, int SecondDirection, int ThiredDirection, int CompletedTest)
        {
            InitializeComponent();
            NumberCompletedTests = CompletedTest;
            MainUser = user;
            MainAbiturient = abiturient;
            ID_FirstDirection = FirstDirection;
            ID_SecondDirection = SecondDirection;
            ID_ThiredDirection = ThiredDirection;
            switch (NumberCompletedTests)
            {
                case 0:
                    tests = new ConnectToDB().GetTestsFromAbiturient(ID_FirstDirection);
                    TBlock.Text = "Выберите тест по специальности " + new ConnectToDB().GetDirectionName(ID_FirstDirection);
                    break;
                case 1:
                    tests = new ConnectToDB().GetTestsFromAbiturient(ID_SecondDirection);
                    TBlock.Text = "Выберите тест по специальности " + new ConnectToDB().GetDirectionName(ID_SecondDirection);
                    break;
                case 2:
                    tests = new ConnectToDB().GetTestsFromAbiturient(ID_ThiredDirection);
                    TBlock.Text = "Выберите тест по специальности " + new ConnectToDB().GetDirectionName(ID_ThiredDirection);
                    break;
                case 3:
                    tests = new ConnectToDB().GetTestsFromAbiturient(ID_ThiredDirection);
                    TBlock.Text = "Все тесты пройдены, ожидайте результатов";
                    MetricsDataGrid.Margin = new Thickness(1000, 1000, 0, 0);
                    Start.Margin = new Thickness(1000, 1000, 0, 0);
                    break;
               
            }
            MetricsDataGrid.ItemsSource = tests;
           

            
        }

        
        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TesterPage(MainUser));
        }

        List<Test> tests = new List<Test>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int ID_Test = 0;
            ID_Test = tests[MetricsDataGrid.SelectedIndex].ID_Test;
            string TestName = new ConnectToDB().GetTestName(ID_Test);
            NavigationService.Navigate(new AbiturientTestPage(MainUser, ID_Test, MainAbiturient, TestName , ID_FirstDirection, ID_SecondDirection, ID_ThiredDirection, NumberCompletedTests));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
