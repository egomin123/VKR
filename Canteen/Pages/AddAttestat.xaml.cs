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
    /// Логика взаимодействия для AddAttestat.xaml
    /// </summary>
    public partial class AddAttestat : Page
    {
        User MainUser;
        public AddAttestat(User user)
        {
            InitializeComponent();
            MainUser = user;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(MainUser));
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MetricsDataGrid.ItemsSource = abiturients;
        }

        List<Abiturient11> abiturients = new ConnectToDB().GetAbiturient11();
            

        private void HideButton(object sender, RoutedEventArgs e)
        {

            if (Hide.Text == "") MetricsDataGrid.ItemsSource = abiturients;
            else MetricsDataGrid.ItemsSource = new ConnectToDB().GetHidenAbiturient11(Hide.Text);
            }

        private void Edit_Attestat(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AttestatTB.Text == "" || AttestatTB.Text == null) MessageBox.Show("Введите баллы ЕГЭ");
                else
                {
                    int ID_Abiturient = abiturients[MetricsDataGrid.SelectedIndex].ID_Abiturient;
                    new ConnectToDB().EditAbiturientEGE(ID_Abiturient, AttestatTB.Text);
                    abiturients = new ConnectToDB().GetAbiturient11();
                    MetricsDataGrid.ItemsSource = abiturients;
                }
            }
            catch { MessageBox.Show("Выберите абитуриента"); } 
            
        }
    }
}
