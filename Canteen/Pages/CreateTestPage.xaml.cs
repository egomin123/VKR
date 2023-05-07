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
    /// Логика взаимодействия для CreateTestPage.xaml
    /// </summary>
    public partial class CreateTestPage : Page
    {
        User MainUser;
        public CreateTestPage(User user)
        {
            InitializeComponent();
            MainUser = user;
            SelectedQuestionsL.Margin = new Thickness(1000, 1000, 0, 0);
            ATB.Margin = new Thickness(1000, 1000, 0, 0);
            BTB.Margin = new Thickness(1000, 1000, 0, 0);
            CTB.Margin = new Thickness(1000, 1000, 0, 0);
            DTB.Margin = new Thickness(1000, 1000, 0, 0);

            AL.Margin = new Thickness(1000, 1000, 0, 0);
            BL.Margin = new Thickness(1000, 1000, 0, 0);
            CL.Margin = new Thickness(1000, 1000, 0, 0);
            DL.Margin = new Thickness(1000, 1000, 0, 0);

            AnswerL.Margin = new Thickness(1000, 1000, 0, 0);
            AnswerCB.Margin = new Thickness(1000, 1000, 0, 0);

            ACB.Margin = new Thickness(1000, 1000, 0, 0);
            BCB.Margin = new Thickness(1000, 1000, 0, 0);
            CCB.Margin = new Thickness(1000, 1000, 0, 0);
            DCB.Margin = new Thickness(1000, 1000, 0, 0);

            ATBSelect.Margin = new Thickness(1000, 1000, 0, 0);
            BTBSelect.Margin = new Thickness(1000, 1000, 0, 0);
            CTBSelect.Margin = new Thickness(1000, 1000, 0, 0);
            DTBSelect.Margin = new Thickness(1000, 1000, 0, 0); 
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TestList(MainUser));
        }
        List<Question> questions = new List<Question>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Question New_Question = new Question();
            New_Question.QuestionString = QuestionTB.Text;
            if (TypeOfQuestionCB.SelectedIndex == 0)
            {
                
                New_Question.A = ATB.Text;
                New_Question.B = BTB.Text;
                New_Question.C = CTB.Text;
                New_Question.D = DTB.Text;
                New_Question.Answer = AnswerCB.Text;
                New_Question.QuestionType = 0;
                New_Question.QuestionTypeString = "Выбор правильного ответа";
            }
            else if (TypeOfQuestionCB.SelectedIndex == 1)
            {
                string asnwer = "";
                New_Question.A = ATBSelect.Text;
                New_Question.B = BTBSelect.Text;
                New_Question.C = CTBSelect.Text;
                New_Question.D = DTBSelect.Text;
                if(ACB.IsChecked == true)
                    asnwer += "А";
                if (BCB.IsChecked == true)
                    asnwer += "Б";
                if (CCB.IsChecked == true)
                    asnwer += "В";
                if (DCB.IsChecked == true)
                    asnwer += "Г";
                New_Question.Answer = asnwer;
                New_Question.QuestionType = 1;
                New_Question.QuestionTypeString = "Выбор нескольких ответов";

            }
            else if (TypeOfQuestionCB.SelectedIndex == 2)
            {
                New_Question.A = "-";
                New_Question.B = "-";
                New_Question.C = "-";
                New_Question.D = "-";
                New_Question.Answer = ATB.Text;
                New_Question.QuestionType = 2;
                New_Question.QuestionTypeString = "Вписать ответ";
            }
            questions.Add(New_Question);
            ClearUeqstions();
            MetricsDataGrid.Items.Add(New_Question);

        }

        public void ClearUeqstions()
        {
            QuestionTB.Text = "";
            ATB.Text = "";
            BTB.Text = "";
            CTB.Text = "";
            DTB.Text = "";


            ACB.IsChecked = false;
            BCB.IsChecked = false;
            CCB.IsChecked = false;
            DCB.IsChecked = false;

            ATBSelect.Text = "";
            BTBSelect.Text = "";
            CTBSelect.Text = "";
            DTBSelect.Text = "";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new ConnectToDB().AddTest(questions, TestName.Text);
        }

        private void TypeOfQuestionCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeOfQuestionCB.SelectedIndex == 0)
            {
                SelectedQuestionsL.Margin = new Thickness(35, 210, 0, 0);
                SelectedQuestionsL.Content = "Варианты Ответов";
                ATB.Margin = new Thickness(61, 249, 0, 0);
                BTB.Margin = new Thickness(61, 288, 0, 0);
                CTB.Margin = new Thickness(61, 324, 0, 0);
                DTB.Margin = new Thickness(61, 3.4, 0, 0);

                AL.Margin = new Thickness(35, 245, 0, 0);
                BL.Margin = new Thickness(35, 283, 0, 0);
                CL.Margin = new Thickness(35, 320, 0, 0);
                DL.Margin = new Thickness(35, 359, 0, 0);

                AnswerL.Margin = new Thickness(35, 39.867, 0, 0);
                AnswerCB.Margin = new Thickness(235, 41.867, 0, 0);

                ACB.Margin = new Thickness(1000, 1000, 0, 0);
                BCB.Margin = new Thickness(1000, 1000, 0, 0);
                CCB.Margin = new Thickness(1000, 1000, 0, 0);
                DCB.Margin = new Thickness(1000, 1000, 0, 0);

                ATBSelect.Margin = new Thickness(1000, 1000, 0, 0);
                BTBSelect.Margin = new Thickness(1000, 1000, 0, 0);
                CTBSelect.Margin = new Thickness(1000, 1000, 0, 0);
                DTBSelect.Margin = new Thickness(1000, 1000, 0, 0);
            }
            else if (TypeOfQuestionCB.SelectedIndex == 1)
            {
                SelectedQuestionsL.Margin = new Thickness(35, 210, 0, 0);
                SelectedQuestionsL.Content = "Варианты Ответов";
                ATB.Margin = new Thickness(1000, 1000, 0, 0);
                BTB.Margin = new Thickness(1000, 1000, 0, 0);
                CTB.Margin = new Thickness(1000, 1000, 0, 0);
                DTB.Margin = new Thickness(1000, 1000, 0, 0);

                AL.Margin = new Thickness(35, 245, 0, 0);
                BL.Margin = new Thickness(35, 283, 0, 0);
                CL.Margin = new Thickness(35, 320, 0, 0);
                DL.Margin = new Thickness(35, 359, 0, 0);

                AnswerL.Margin = new Thickness(1000, 1000, 0, 0);
                AnswerCB.Margin = new Thickness(1000, 1000, 0, 0);

                ACB.Margin = new Thickness(73, 259, 0, 0);
                BCB.Margin = new Thickness(73, 298, 0, 0);
                CCB.Margin = new Thickness(73, 334, 0, 0);
                DCB.Margin = new Thickness(73, 3.4, 0, 0);

                ATBSelect.Margin = new Thickness(95, 249, 0, 0);
                BTBSelect.Margin = new Thickness(95, 288, 0, 0);
                CTBSelect.Margin = new Thickness(95, 324, 0, 0);
                DTBSelect.Margin = new Thickness(95, 3.4, 0, 0);
            }
            else if (TypeOfQuestionCB.SelectedIndex == 2)
            {
                SelectedQuestionsL.Margin = new Thickness(35, 210, 0, 0);
                SelectedQuestionsL.Content = "Впишите ответ";
                ATB.Margin = new Thickness(61, 249, 0, 0);
                BTB.Margin = new Thickness(1000, 1000, 0, 0);
                CTB.Margin = new Thickness(1000, 1000, 0, 0);
                DTB.Margin = new Thickness(1000, 1000, 0, 0);

                AL.Margin = new Thickness(1000, 1000, 0, 0);
                BL.Margin = new Thickness(1000, 1000, 0, 0);
                CL.Margin = new Thickness(1000, 1000, 0, 0);
                DL.Margin = new Thickness(1000, 1000, 0, 0);

                AnswerL.Margin = new Thickness(1000, 1000, 0, 0);
                AnswerCB.Margin = new Thickness(1000, 1000, 0, 0);

                ACB.Margin = new Thickness(1000, 1000, 0, 0);
                BCB.Margin = new Thickness(1000, 1000, 0, 0);
                CCB.Margin = new Thickness(1000, 1000, 0, 0);
                DCB.Margin = new Thickness(1000, 1000, 0, 0);

                ATBSelect.Margin = new Thickness(1000, 1000, 0, 0);
                BTBSelect.Margin = new Thickness(1000, 1000, 0, 0);
                CTBSelect.Margin = new Thickness(1000, 1000, 0, 0);
                DTBSelect.Margin = new Thickness(1000, 1000, 0, 0);
            }
        }
    }
}
