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
            MetricsDataGridSPO.Margin = new Thickness(1000, 1000, 0, 0);
            MetricsDataGrid11.ItemsSource = new ConnectToDB().GetAbiturient11();
        }


        


        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
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
                Abiturient11 abiturientAdd = new Abiturient11();
                WriteExel(fileName);
                usersnNew = ReadExel(fileName);


                new ConnectToDB().ClearAbiturient11();

                usersnNew.Sort(delegate (Abiturient11 c1, Abiturient11 c2) { return c1.EGE.CompareTo(c2.EGE); });
                usersnNew.Reverse();
                MetricsDataGrid11.ItemsSource = usersnNew;
                new ConnectToDB().AddAbiturients11(usersnNew);

            }
        }
        List<Abiturient11> abiturient = new List<Abiturient11>();
        List<Abiturient11> abiturients = new List<Abiturient11>();
        List<Abiturient11> usersnNew;

        public List<Abiturient11> ReadExel(string Path)
        {
            //создаю лист для вывода данных так сказать
            List<Abiturient11> abiturientsNew = new List<Abiturient11>();

            WorkBook workBook = WorkBook.Load(Path);
            WorkSheet workSheet = workBook.WorkSheets.First();



            for (int i = 2; i < 10000; i++)
            {
                Abiturient11 thisuser = new Abiturient11();

                thisuser.SecondName = workSheet[$"B{i}"].StringValue;
                if (thisuser.SecondName == null)
                    break;
                thisuser.ID_Abiturient = workSheet[$"A{i}"].Int32Value;
                thisuser.FirstName = workSheet[$"C{i}"].StringValue;
                thisuser.Patronymic = workSheet[$"D{i}"].StringValue;
                thisuser.DateOfBirth = Convert.ToDateTime(workSheet[$"E{i}"].StringValue);
                thisuser.Email = workSheet[$"F{i}"].StringValue;
                thisuser.PhoneNumber = workSheet[$"G{i}"].StringValue;
                thisuser.SeriesPasport = workSheet[$"H{i}"].Int32Value;
                thisuser.NumberPasport = workSheet[$"I{i}"].Int32Value;
                thisuser.EGE = workSheet[$"J{i}"].StringValue;
                thisuser.ID_FirstDirection = workSheet[$"K{i}"].Int32Value;
                thisuser.ID_SecondDirection = workSheet[$"L{i}"].Int32Value;
                thisuser.ID_ThiredDeriction = workSheet[$"M{i}"].Int32Value;
                abiturientsNew.Add(thisuser);




            }

            return abiturientsNew;


        }


        public void WriteExel(string Path)
        {

            WorkBook workBook = WorkBook.Load(Path);
            WorkSheet workSheet = workBook.DefaultWorkSheet;

            int NomerKoloncki = 2;
            foreach (Abiturient11 abiturient in abiturients)
            {
                workSheet[$"A{NomerKoloncki}"].Value = abiturient.ID_Abiturient;
                workSheet[$"B{NomerKoloncki}"].Value = abiturient.SecondName;
                workSheet[$"C{NomerKoloncki}"].Value = abiturient.FirstName;
                workSheet[$"D{NomerKoloncki}"].Value = abiturient.Patronymic;
                workSheet[$"E{NomerKoloncki}"].Value = abiturient.DateOfBirth;
                workSheet[$"F{NomerKoloncki}"].Value = abiturient.PhoneNumber;
                workSheet[$"G{NomerKoloncki}"].Value = abiturient.Email;
                workSheet[$"H{NomerKoloncki}"].Value = abiturient.SeriesPasport;
                workSheet[$"I{NomerKoloncki}"].Value = abiturient.NumberPasport;
                workSheet[$"J{NomerKoloncki}"].Value = abiturient.EGE;
                workSheet[$"K{NomerKoloncki}"].Value = abiturient.ID_FirstDirection;
                workSheet[$"L{NomerKoloncki}"].Value = abiturient.ID_SecondDirection;
                workSheet[$"M{NomerKoloncki}"].Value = abiturient.ID_ThiredDeriction;
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
                if (HidenAbiturient == "" || HidenAbiturient == null  && SelectedAbiturientsListCB.SelectedIndex == 0)
                    MetricsDataGrid11.ItemsSource = new ConnectToDB().GetHidenAbiturient11(HidenAbiturient);
                else if (HidenAbiturient == "" || HidenAbiturient == null && SelectedAbiturientsListCB.SelectedIndex == 1)
                    MetricsDataGridSPO.ItemsSource = new ConnectToDB().GetHidenAbiturientSPO(HidenAbiturient);
                
                
            }
            catch { }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(MainUser));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedAbiturientsListCB.SelectedIndex == 0)
            {
                ButtonLoad.Margin = new Thickness(104.2, 45, 0, 0);
                MetricsDataGridSPO.Margin = new Thickness(1000, 1000, 0, 0);
                MetricsDataGrid11.Margin = new Thickness(3, 85, 6.6, 17.4);
                MetricsDataGrid11.ItemsSource = new ConnectToDB().GetAbiturient11();
            }
            else if (SelectedAbiturientsListCB.SelectedIndex == 1)
            {
                ButtonLoad.Margin = new Thickness(1000, 1000, 0, 0);
                MetricsDataGrid11.Margin = new Thickness(1000, 1000, 0, 0);
                MetricsDataGridSPO.Margin = new Thickness(3, 85, 6.6, 17.4);
                MetricsDataGridSPO.ItemsSource = new ConnectToDB().GetAbiturientSPO();
            }
        }
    }
}
