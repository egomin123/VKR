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
    /// Логика взаимодействия для ResultsTestsPage.xaml
    /// </summary>
    public partial class ResultsTestsPage : Page
    {
        User MainUser;
        public ResultsTestsPage(User user)
        {
            InitializeComponent();
            MainUser = user;
        }

        private void HideButton(object sender, RoutedEventArgs e)
        {
            if (Hide.Text == "") MetricsDataGrid.ItemsSource = abiturients;
            else MetricsDataGrid.ItemsSource = new ConnectToDB().GetHidenTest(Hide.Text);

        }
        List<Abiturient> abiturients = new ConnectToDB().GetAbiturient();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MetricsDataGrid.ItemsSource = abiturients;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TesterPage(MainUser));
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
    }
}
