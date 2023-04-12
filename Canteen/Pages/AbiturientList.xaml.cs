using Canteen.Classes;
using IronXL;
using Microsoft.Win32;
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
using IronXL;

namespace Canteen.Pages
{
    /// <summary>
    /// Логика взаимодействия для AbiturientList.xaml
    /// </summary>
    public partial class AbiturientList : Page
    {
        User MainUser;
        public AbiturientList(User user)
        {
            InitializeComponent();
            MainUser = user;
            LoginBlock.Header = MainUser.Login;
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

                usersnNew.Sort(delegate (Abiturient c1, Abiturient c2) { return c1.Attestat.CompareTo(c2.Attestat); });
                usersnNew.Reverse();
                MetricsDataGrid.ItemsSource = usersnNew;
                new ConnectToDB().AddAbiturients(usersnNew);

            }
        }
        List<Abiturient> abiturient = new List<Abiturient>();
        List<Abiturient> abiturients = new List<Abiturient>();
        List<Abiturient> usersnNew;

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string HidenAbiturient = Hide.Text;
                if (HidenAbiturient == "" || HidenAbiturient == null )
                    abiturient = new ConnectToDB().GetAbiturient();
                else
                    abiturient = new ConnectToDB().GetHidenAbiturient(HidenAbiturient);
                MetricsDataGrid.ItemsSource = abiturient;
            }
            catch { }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(MainUser));
        }
    }
}
