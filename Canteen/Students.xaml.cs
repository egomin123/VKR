using Canteen.Classes;
using Canteen.Pages;
using IronXL;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Canteen
{
    /// <summary>
    /// Логика взаимодействия для Students.xaml
    /// </summary>
    public partial class Students : Page
    {
        User MainUser;
        public Students(User user)
        {
            InitializeComponent();
            MainUser = user;
            LoginBlock.Header = MainUser.Login;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WriteExel();
        }

        List<Student> students;
        public void filldata()
        {


            students = new ConnectToDB().GetStudent();
            MetricsDataGrid.ItemsSource = students;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            filldata();
        }

        public void WriteExel()
        {
            string Path = (Directory.GetCurrentDirectory() + "\\Список студентов.xlsx");
            WorkBook workBook = WorkBook.Load(Path);
            WorkSheet workSheet = workBook.DefaultWorkSheet;

            int NomerKoloncki = 2;
            workSheet[$"A{1}"].Value = "Код студента";
            workSheet[$"B{1}"].Value = "Фамилия";
            workSheet[$"C{1}"].Value = "Имя";
            workSheet[$"D{1}"].Value = "Отчество";
            workSheet[$"E{1}"].Value = "Дата рождения";
            workSheet[$"F{1}"].Value = "Номер телефона";
            workSheet[$"G{1}"].Value = "Почта";
            workSheet[$"H{1}"].Value = "Серия паспорта";
            workSheet[$"I{1}"].Value = "Номер паспорта";
            workSheet[$"J{1}"].Value = "Аттестат";
            workSheet[$"K{1}"].Value = "Номер группы";
            foreach (Student student in students)
            {
                workSheet[$"A{NomerKoloncki}"].Value = student.ID_User;
                workSheet[$"B{NomerKoloncki}"].Value = student.SecondName;
                workSheet[$"C{NomerKoloncki}"].Value = student.FirstName;
                workSheet[$"D{NomerKoloncki}"].Value = student.Patronymic;
                workSheet[$"E{NomerKoloncki}"].Value = student.DateOfBirth;
                workSheet[$"F{NomerKoloncki}"].Value = student.PhoneNumber;
                workSheet[$"G{NomerKoloncki}"].Value = student.Email;
                workSheet[$"H{NomerKoloncki}"].Value = student.SeriaPassport;
                workSheet[$"I{NomerKoloncki}"].Value = student.NumberPasport;
                workSheet[$"J{NomerKoloncki}"].Value = student.Attestat;
                workSheet[$"K{NomerKoloncki}"].Value = student.GroupNumber;
                NomerKoloncki++;
            }
            // Save Changes
            workBook.SaveAs(Path);
            MessageBox.Show("Список студентов сохранён в папку - " + Path);

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HowMuchGroups(MainUser));
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
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

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(MainUser));
        }
    }
}
