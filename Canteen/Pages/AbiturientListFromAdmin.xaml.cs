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
    /// Логика взаимодействия для AbiturientListFromAdmin.xaml
    /// </summary>
    public partial class AbiturientListFromAdmin : Page
    {
        User MainUser;
        public AbiturientListFromAdmin(User user)
        {
            InitializeComponent();
            MainUser = user;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage(MainUser));
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        

        private void HideButton(object sender, RoutedEventArgs e)
        {
            string HidenAbiturient = Hide.Text;
            if (HidenAbiturient == "" || HidenAbiturient == null && SelectedAbiturientsListCB.SelectedIndex == 0)
                MetricsDataGrid11.ItemsSource = new ConnectToDB().GetHidenAbiturient11(HidenAbiturient);
            else if (HidenAbiturient == "" || HidenAbiturient == null && SelectedAbiturientsListCB.SelectedIndex == 1)
                MetricsDataGridSPO.ItemsSource = new ConnectToDB().GetHidenAbiturientSPO(HidenAbiturient);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedAbiturientsListCB.SelectedIndex == 0)
            {
                MetricsDataGridSPO.Margin = new Thickness(1000, 1000, 0, 0);
                MetricsDataGrid11.Margin = new Thickness(3, 73.8, 6.6, 17.4);
                MetricsDataGrid11.ItemsSource = new ConnectToDB().GetAbiturient11();
            }
            else if (SelectedAbiturientsListCB.SelectedIndex == 1)
            {
                MetricsDataGrid11.Margin = new Thickness(1000, 1000, 0, 0);
                MetricsDataGridSPO.Margin = new Thickness(3, 73.8, 6.6, 17.4);
                MetricsDataGridSPO.ItemsSource = new ConnectToDB().GetAbiturientSPO();
            }
        }
    }
}
