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
    /// Логика взаимодействия для ViewTest.xaml
    /// </summary>
    public partial class ViewTest : Page
    {
        User MainUser;
        int ID_Test = 0;
        public ViewTest(User user, int equal, string testname)
        {
            InitializeComponent();
            MainUser = user;
            ID_Test = equal;
            questions = new ConnectToDB().GetQuestion(equal);
            TestsLV.ItemsSource = questions;
            TestName.Content = testname;
        }
        List<Question> questions;
        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TestList(MainUser));
        }
        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
