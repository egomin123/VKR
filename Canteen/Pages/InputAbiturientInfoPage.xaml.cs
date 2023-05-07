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
    /// Логика взаимодействия для InputAbiturientInfoPage.xaml
    /// </summary>
    public partial class InputAbiturientInfoPage : Page
    {
        User MainUser;
        public InputAbiturientInfoPage(User user)
        {
            InitializeComponent();
            MainUser = user;
        }

        private void Registrate(object sender, RoutedEventArgs e)
        {
            Abiturient abiturient = new Abiturient();
            abiturient.SecondName = SecondNameTB.Text;
            abiturient.FirstName = FirstNameTB.Text;
            abiturient.Patronymic = PatronymicTB.Text;
            abiturient.DateOfBirth = DateOfBitrhDP.DisplayDate;
            abiturient.PhoneNumber = TelephoneNumberTB.Text;
            abiturient.Email = EmainTB.Text;
            abiturient.NumberPasport = Convert.ToInt32(NumberPassportTB.Text);
            abiturient.SeriaPassport = Convert.ToInt32(SeriesPassportTB.Text);
            abiturient.Attestat = "0";
            abiturient.FirstDirectionBall = 0;
            abiturient.SecondDirectionBall = 0;
            abiturient.ThiredDerictionBall = 0;
            
            int ID_FirstDirection = new ConnectToDB().GetDirectionsIDFromCB(FirstDirection.Text);
            int ID_SecondDirection = new ConnectToDB().GetDirectionsIDFromCB(SecondDirecton.Text);
            int ID_ThiredDirection = new ConnectToDB().GetDirectionsIDFromCB(ThirdDirection.Text);
            abiturient.ID_FirstDirection = ID_FirstDirection;
            abiturient.ID_SecondDirection = ID_SecondDirection;
            abiturient.ID_ThiredDeriction = ID_ThiredDirection;
            new ConnectToDB().AddAbiturient(abiturient);
            int CompletedTest = 0;
            abiturient.ID_User = new ConnectToDB().GetIDAbiturientByLoginForButton(abiturient.Email, abiturient.PhoneNumber);
            NavigationService.Navigate(new StartTestPage(MainUser, abiturient, ID_FirstDirection, ID_SecondDirection, ID_ThiredDirection, CompletedTest));

                // 
        }


        private void OnluLetter(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int i))
            {
                e.Handled = true;
            }
        }
        
        private void JustNumbers(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890".IndexOf(e.Text) < 0;
        }
  
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> directions = new ConnectToDB().GetDirectionsForCB();
            FirstDirection.ItemsSource = directions;
            SecondDirecton.ItemsSource = directions;
            ThirdDirection.ItemsSource = directions;
        }
    }
}
