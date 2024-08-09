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
    /// Логика взаимодействия для HowMuchGetAbiturientsOnStudentPage.xaml
    /// </summary>
    public partial class HowMuchGetAbiturientsOnStudentPage : Page
    {
        int Abiturients = 1;
        User MainUser;
        public HowMuchGetAbiturientsOnStudentPage(User user)
        {
            InitializeComponent();
            MainUser = user;
            LoginBlock.Header = user.Login;
            DirectionCB.ItemsSource = directions;
        }
        List<string> directions = new ConnectToDB().GetDirectionsForCB();

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        private void JustNumbers(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890".IndexOf(e.Text) < 0;
        }

        private void Start_Selection(object sender, RoutedEventArgs e)
        {
            try
            {
                int ID_Direction = new ConnectToDB().GetDirectionsIDFromCB(DirectionCB.Text);
                int equal = Convert.ToInt32(HowMuchAbiturientBox.Text);
                if (equal > Abiturients)
                {
                    MessageBox.Show("Количество вписаных абитуриентов больше, чем имеется");
                }
                else
                {
                    List<Abiturient11> abiturients11 = new ConnectToDB().GetAbiturient11FromAccepted(ID_Direction);
                    abiturients11.Sort(delegate (Abiturient11 c1, Abiturient11 c2) { return c1.EGE.CompareTo(c2.EGE); });
                    abiturients11.Reverse();

                    List<AbiturientSPO> abiturientsSPO = new ConnectToDB().GetAbiturientSPOFromAccepted(ID_Direction);
                    abiturientsSPO.Sort(delegate (AbiturientSPO c1, AbiturientSPO c2) { return c1.SummBall.CompareTo(c2.SummBall); });
                    abiturientsSPO.Reverse();

                    new ConnectToDB().AddStudentsFromAbiturients(abiturients11, abiturientsSPO, ID_Direction, Convert.ToInt32(HowMuchAbiturientBox.Text));
                    NavigationService.Navigate(new Students(MainUser));
                }
            }
            catch {
                MessageBox.Show("Введите корректное число");
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(MainUser));
        }

        private void DirectionCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ID_Direction = new ConnectToDB().GetDirectionsIDFromCB(Convert.ToString(DirectionCB.SelectedValue));
            Abiturients = new ConnectToDB().HowMuchAbiturientsWithDirectionID(ID_Direction);
            HowMushStesentsText.Text = ("Направление выбрало: " + Convert.ToString(Abiturients) + " абитуриентов");
        }
    }
}
