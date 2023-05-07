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
    /// Логика взаимодействия для DirectionListPage.xaml
    /// </summary>
    public partial class DirectionListPage : Page
    {
        User MainUser;
        public DirectionListPage(User user)
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

        

        private void JustNumbers(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890".IndexOf(e.Text) < 0;
        }

        List<Direction> directions = new ConnectToDB().GetDirections();

        private void Add_Direction(object sender, RoutedEventArgs e)
        {
            try { 
            Direction direction = new Direction();
            direction.DirectionName = DirectionNameTB.Text;
            direction.NumberOfPeople = Convert.ToInt32(NumberOfPeopleTB.Text);
            new ConnectToDB().AddDirection(direction);
            FillData();
            }
            catch { }
        }

       

        private void Edit_Direction(object sender, RoutedEventArgs e)
        {
            try { 
            Direction direction = new Direction();
            direction.ID_Direction = directions[MetricsDataGrid.SelectedIndex].ID_Direction;
            direction.DirectionName = DirectionNameTB.Text;
            direction.NumberOfPeople = Convert.ToInt32(NumberOfPeopleTB.Text);
            new ConnectToDB().EditDirection(direction);
            FillData();
            }
            catch { }
        }

        private void Delete_Direction(object sender, RoutedEventArgs e)
        {
            try
            {


                int ID_Direction = 0;
                ID_Direction = directions[MetricsDataGrid.SelectedIndex].ID_Direction;
                new ConnectToDB().DeleteDirection(ID_Direction);
                FillData();
            }
            catch { }
        }
        
        public void FillData()
        {
            directions = new ConnectToDB().GetDirections();
            MetricsDataGrid.ItemsSource = directions;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillData();
        }
    }
}
