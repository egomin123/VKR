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
    /// Логика взаимодействия для StudentsWithGroup.xaml
    /// </summary>
    public partial class StudentsWithGroup : Page
    {
        User MainUser;
        double GroupEqual = 0;
        public StudentsWithGroup(User user, double equal)
        {
            InitializeComponent();
            MainUser = user;
            LoginBlock.Header = MainUser.Login;
            GroupEqual = equal;
            int students = new ConnectToDB().HowMuchStudents();
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {

        }
        List<Student> students;
        public void filldata()
        {


            students = new ConnectToDB().GetStudent();
            MetricsDataGrid.ItemsSource = students;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            filldata();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(MainUser));
        }

        List<Student> student = new List<Student>();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string HidenStudent = Hide.Text;
                if (HidenStudent == "")
                    student = new ConnectToDB().GetStudent();
                else
                    student = new ConnectToDB().GetHidenStudent(HidenStudent);
                MetricsDataGrid.ItemsSource = student;
            }
            catch { }
        }
    }
}
