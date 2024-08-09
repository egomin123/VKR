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
    /// Логика взаимодействия для HowMuchGroups.xaml
    /// </summary>
    public partial class HowMuchGroups : Page
    {
        User MainUser;
        int students = 0;
        public HowMuchGroups(User user)
        {
            InitializeComponent();
            MainUser = user;
            LoginBlock.Header = user.Login;
            
            DirectionCB.ItemsSource = Directions;
        }

        List<String> Directions = new ConnectToDB().GetDirectionsForCB();
        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        private void JustNumbers(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890".IndexOf(e.Text) < 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int ID_Direction = new ConnectToDB().GetDirectionsIDFromCB(DirectionCB.Text);
            double equal =  students/ Convert.ToInt32(HowMuchGroupBox.Text);
            if (equal < 2)
                MessageBox.Show("слишком много групп");
            else
            {
                new ConnectToDB().StudentsOnGroup(Convert.ToInt32(HowMuchGroupBox.Text), ID_Direction);
                NavigationService.Navigate(new StudentsWithGroup(MainUser, Convert.ToInt32(HowMuchGroupBox.Text)));
            }
;
        }

        private void Back(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new MainPage(MainUser));
        }

        private void DirectionCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ID_Direction = new ConnectToDB().GetDirectionsIDFromCB(Convert.ToString(DirectionCB.SelectedValue));
            students = new ConnectToDB().HowMuchStudentsWithDirectionID(ID_Direction);
            HowMushStesentsText.Text = ("Количество студентов: " + Convert.ToString(students));
        }
    }
}
