using Canteen.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
using ClosedXML.Excel;
using Aspose.Cells;
using System.Collections.ObjectModel;
using System.IO;
using IronXL;

namespace Canteen.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage1.xaml
    /// </summary>
    public partial class MainPage1 : Page
    {
        User MainUser;
        int euqeel = 1;
        public MainPage1(User user)
        {
            InitializeComponent();
            
            MainUser = user;
            LoginBlock.Header = MainUser.Login;
        }

        private void MyProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            filldata();
        }



        

      

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        public void filldata()
        {


            abiturient = new ConnectToDB().GetAbiturient();
            MetricsDataGrid.ItemsSource = abiturient;
        }

        List<Abiturient> abiturient = new List<Abiturient>();
        Abiturient abiturient1 = new Abiturient();
        List<Abiturient> abiturients = new List<Abiturient>();
        List<Abiturient> usersnNew;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "*.xls;*.xlsx";
            dlg.Filter = "Microsoft Excel (*.xls*)|*.xls*";
            if (dlg.ShowDialog() == true)
            {
                int ID = 0;
              
                string fileName = dlg.FileName;
                Abiturient abiturientAdd = new Abiturient();
                WriteExel(fileName);
                usersnNew = ReadExel(fileName);

               
                new ConnectToDB().ClearAbiturient();

                usersnNew.Sort(delegate(Abiturient c1, Abiturient c2) { return c1.Attestat.CompareTo(c2.Attestat); });
                usersnNew.Reverse();
                MetricsDataGrid.ItemsSource = usersnNew;
                new ConnectToDB().AddAbiturients(usersnNew);
               
            }

        }


       



        public List<Abiturient> ReadExel(string Path)
        {
            //создаю лист для вывода данных так сказать
            List<Abiturient> abiturientsNew = new List<Abiturient>();

            WorkBook workBook = WorkBook.Load(Path);
            WorkSheet workSheet = workBook.WorkSheets.First();



            for (int i = 2; i < 10000; i++)
            {
                Abiturient thisuser = new Abiturient();
               
                thisuser.SecondName = workSheet[$"B{i}"].StringValue;
                if (thisuser.SecondName == null)
                    break;
                thisuser.ID_User = workSheet[$"A{i}"].Int32Value;
                thisuser.FirstName = workSheet[$"C{i}"].StringValue;
                thisuser.Patronymic = workSheet[$"D{i}"].StringValue;
                thisuser.DateOfBirth = Convert.ToDateTime(workSheet[$"E{i}"].StringValue);
                thisuser.PhoneNumber = workSheet[$"F{i}"].StringValue;
                thisuser.Email = workSheet[$"G{i}"].StringValue;
                thisuser.SeriaPassport = workSheet[$"H{i}"].Int32Value;
                thisuser.NumberPasport = workSheet[$"I{i}"].Int32Value;
                thisuser.Attestat = workSheet[$"J{i}"].StringValue;
                abiturientsNew.Add(thisuser);

               


            }

            return abiturientsNew;


        }

        public void WriteExel(string Path)
        {

            WorkBook workBook = WorkBook.Load(Path);
            WorkSheet workSheet = workBook.DefaultWorkSheet;

            int NomerKoloncki = 2;
            foreach (Abiturient abiturient in abiturients)
            {
                workSheet[$"A{NomerKoloncki}"].Value = abiturient.ID_User;
                workSheet[$"B{NomerKoloncki}"].Value = abiturient.SecondName;
                workSheet[$"C{NomerKoloncki}"].Value = abiturient.FirstName;
                workSheet[$"D{NomerKoloncki}"].Value = abiturient.Patronymic;
                workSheet[$"E{NomerKoloncki}"].Value = abiturient.DateOfBirth;
                workSheet[$"F{NomerKoloncki}"].Value = abiturient.PhoneNumber;
                workSheet[$"G{NomerKoloncki}"].Value = abiturient.Email;
                workSheet[$"H{NomerKoloncki}"].Value = abiturient.SeriaPassport;
                workSheet[$"I{NomerKoloncki}"].Value = abiturient.NumberPasport;
                workSheet[$"J{NomerKoloncki}"].Value = abiturient.Attestat;
                NomerKoloncki++;
            }
            // Save Changes
            workBook.SaveAs(Path);

        }



        private void MyMoney_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Raspred(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HowMuchGetAbiturientsOnStudentPage(MainUser));
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(MainUser));
        }
    }
}
