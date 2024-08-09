using Aspose.Cells;
using Canteen.Classes;
using IronXL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для Groups.xaml
    /// </summary>
    public partial class Groups : Page
    {
        User MainUser;
        List<Student> students = new List<Student>();
        public Groups(User user)
        {
            InitializeComponent();
            MainUser = user;
            GroupCB.Text = "1";
            LoginBlock.Header = user.Login;
            GroupCB.ItemsSource = new ConnectToDB().GroupForCB();
            students = new ConnectToDB().GetStudentWithGroup("1");
            MetricsDataGrid.ItemsSource = students;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(MainUser));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Path = (Directory.GetCurrentDirectory() + "\\" + Convert.ToString(GroupCB.Text) + ".xlsx");
            try
            {
                
                WorkBook workBook = WorkBook.Load(Path); 
                workBook.SaveAs(Path);
                WorkSheet workSheet = workBook.DefaultWorkSheet;
                int NomerKoloncki = 3;
                workSheet[$"A{1}"].Value = "" + Convert.ToString(GroupCB.SelectedValue);
                workSheet[$"A{2}"].Value = "Фамилия";
                workSheet[$"B{2}"].Value = "Имя";
                workSheet[$"C{2}"].Value = "Отчество";
                workSheet[$"D{2}"].Value = "Дата рождения";
                workSheet[$"E{2}"].Value = "Номер телефона";
                workSheet[$"F{2}"].Value = "Почта";
                workSheet[$"G{2}"].Value = "Серия паспорта";
                workSheet[$"H{2}"].Value = "Номер паспорта";
                workSheet[$"I{2}"].Value = "Код направления";
                workSheet[$"J{2}"].Value = "Номер группы";
                foreach (Student student in students)
                {
                    workSheet[$"A{NomerKoloncki}"].Value = student.SecondName;
                    workSheet[$"B{NomerKoloncki}"].Value = student.FirstName;
                    workSheet[$"C{NomerKoloncki}"].Value = student.Patronymic;
                    workSheet[$"D{NomerKoloncki}"].Value = student.DateOfBirth;
                    workSheet[$"E{NomerKoloncki}"].Value = student.PhoneNumber;
                    workSheet[$"F{NomerKoloncki}"].Value = student.Email;
                    workSheet[$"G{NomerKoloncki}"].Value = student.SeriaPassport;
                    workSheet[$"H{NomerKoloncki}"].Value = student.NumberPasport;
                    workSheet[$"I{NomerKoloncki}"].Value = student.ID_Direction;
                    workSheet[$"J{NomerKoloncki}"].Value = student.GroupNumber;
                    NomerKoloncki++;
                }
                // Save Changes
               
                workBook.SaveAs(Path);
                MessageBox.Show("Список студентов сохранён в папку - " + Path);
            }
            catch ( Exception qwe)
            {
                
                MessageBox.Show("Файл создан по пути. " + Path + ". Ошибка " + qwe);
            }
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {

        }

       

        private void GroupCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string group = Convert.ToString(GroupCB.SelectedValue);
            students = new ConnectToDB().GetStudentWithGroup(group);
            MetricsDataGrid.ItemsSource = students;
        }
        List<Student> student;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string group = Convert.ToString(GroupCB.SelectedValue);
            try
            {
                string HidenStudent = Hide.Text;
                if (HidenStudent == "")
                {
                    if (group == "") group = "1";
                    student = new ConnectToDB().GetStudentWithGroup(group);
                }
                else
                    student = new ConnectToDB().GetHidenStudent(HidenStudent);
                MetricsDataGrid.ItemsSource = student;
            }
            catch { }
        }
    }
}
