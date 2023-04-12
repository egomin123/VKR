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
            Abiturients = new ConnectToDB().HowMuchAbiturients();
            HowMushStesentsText.Text = ("Количество абитуриентов: " + Convert.ToString(Abiturients));
        }

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
                int equal = Convert.ToInt32(HowMuchAbiturientBox.Text);
                if (equal > Abiturients)
                {
                    MessageBox.Show("Количество вписаных абитуриентов больше, чем имеется");
                }
                else
                {
                    List<Abiturient> Entered_Abiturients = new ConnectToDB().GetAbiturient();
                    new ConnectToDB().AddStudentsFromAbiturients(Entered_Abiturients, equal);
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
    }
}
