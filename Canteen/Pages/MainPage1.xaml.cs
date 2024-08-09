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
            }
        }       
    }
}
