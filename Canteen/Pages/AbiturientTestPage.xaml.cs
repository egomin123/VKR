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
    /// Логика взаимодействия для AbiturientTestPage.xaml
    /// </summary>
    public partial class AbiturientTestPage : Page
    {
        User MainUser;
        Abiturient MainAbiturient;
        int QuestionNumber = 0;
        int ID_Test = 0;
        int ID_FirstDirection = 0;
        int ID_SecondDirection = 0;
        int ID_ThiredDirection = 0;
        int NumberTrueAnswer = 0;
        int NumberOfQuestionOnTest = 0;
        int NumberCompletedTests = 0;


        public AbiturientTestPage(User user, int IDTest, Abiturient abiturient, string Testname, int IDFirstDirection, int IDSecondDirection, int IDThiredDirection, int NumberCompletedTests1)
        {
            InitializeComponent();
            NumberCompletedTests = NumberCompletedTests1;
            MainUser = user;
            MainAbiturient = abiturient;
            TestNameL.Content = Testname;
            ID_Test = IDTest;
            ID_FirstDirection = IDFirstDirection;
            ID_SecondDirection = IDSecondDirection;
            ID_ThiredDirection = IDThiredDirection;
            NumberOfQuestionOnTest = new ConnectToDB().HowMuchQuestion(ID_Test);

        }

        
        Question question = new Question();
        public void NextQuestion()
        {

            if (QuestionNumber != NumberOfQuestionOnTest)
            {
                QuestionNumber++;
                question = new ConnectToDB().GetQuestionByID(ID_Test, QuestionNumber);
                QuestionTB.Content = question.QuestionString;
                if (question.QuestionType == 0) // выбор правильного ответа
                {
                    SelectedQuestionsL.Content = "выбор правильного ответа";
                    ATB.Margin = new Thickness(41, 210, 0, 0);
                    BTB.Margin = new Thickness(41, 250, 0, 0);
                    CTB.Margin = new Thickness(41, 290, 0, 0);
                    DTB.Margin = new Thickness(41, 330, 0, 0);

                    AL.Margin = new Thickness(16, 207, 0, 0);
                    BL.Margin = new Thickness(16, 245, 0, 0);
                    CL.Margin = new Thickness(16, 282, 0, 0);
                    DL.Margin = new Thickness(16, 321, 0, 0);

                    AnswerL.Margin = new Thickness(16, 0.4, 0, 0);
                    AnswerCB.Margin = new Thickness(217, 3.4, 0, 0);

                    ACB.Margin = new Thickness(1000, 1000, 0, 0);
                    BCB.Margin = new Thickness(1000, 1000, 0, 0);
                    CCB.Margin = new Thickness(1000, 1000, 0, 0);
                    DCB.Margin = new Thickness(1000, 1000, 0, 0);

                    ATBSelect.Margin = new Thickness(1000, 1000, 0, 0);
                    BTBSelect.Margin = new Thickness(1000, 1000, 0, 0);
                    CTBSelect.Margin = new Thickness(1000, 1000, 0, 0);
                    DTBSelect.Margin = new Thickness(1000, 1000, 0, 0);
                    ATBQ.Margin = new Thickness(1000, 1000, 0, 0);



                    ATB.Content = question.A;
                    BTB.Content = question.B;
                    CTB.Content = question.C;
                    DTB.Content = question.D;
                    AnswerCB.Text = "";
                }
                else if (question.QuestionType == 1) // выбор нескольких ответов
                {
                    SelectedQuestionsL.Content = "выберите от 1 до 4 ответов";
                    ATB.Margin = new Thickness(1000, 1000, 0, 0);
                    BTB.Margin = new Thickness(1000, 1000, 0, 0);
                    CTB.Margin = new Thickness(1000, 1000, 0, 0);
                    DTB.Margin = new Thickness(1000, 1000, 0, 0);

                    AL.Margin = new Thickness(16, 207, 0, 0);
                    BL.Margin = new Thickness(16, 245, 0, 0);
                    CL.Margin = new Thickness(16, 282, 0, 0);
                    DL.Margin = new Thickness(16, 321, 0, 0);

                    AnswerL.Margin = new Thickness(1000, 1000, 0, 0);
                    AnswerCB.Margin = new Thickness(1000, 1000, 0, 0);

                    ACB.Margin = new Thickness(54, 220, 0, 0);
                    BCB.Margin = new Thickness(54, 260, 0, 0);
                    CCB.Margin = new Thickness(54, 300, 0, 0);
                    DCB.Margin = new Thickness(54, 340, 0, 0);

                    ATBSelect.Margin = new Thickness(76, 210, 0, 0);
                    BTBSelect.Margin = new Thickness(76, 250, 0, 0);
                    CTBSelect.Margin = new Thickness(76, 290, 0, 0);
                    DTBSelect.Margin = new Thickness(76, 330, 0, 0);
                    ATBQ.Margin = new Thickness(1000, 1000, 0, 0);


                    ACB.IsChecked = false;
                    BCB.IsChecked = false;
                    CCB.IsChecked = false;
                    DCB.IsChecked = false;
                    ATBSelect.Content = question.A;
                    BTBSelect.Content = question.B;
                    CTBSelect.Content = question.C;
                    DTBSelect.Content = question.D;

                }
                else if (question.QuestionType == 2) // вписать правильный ответ
                {
                    SelectedQuestionsL.Content = "Впишите правильный ответ";
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


                    ATBQ.Margin = new Thickness(41, 210, 0, 0);

                    ATBQ.Text = "";
                }
            }
            else
            {
                int Score = 0;
                int NumberUqestions = new ConnectToDB().HowMuchQuestion(ID_Test);
                decimal Score1 = Convert.ToDecimal(NumberTrueAnswer) / Convert.ToDecimal(NumberUqestions) *100;
                if (Score1 < 50) Score = 2;
                if (Score1 >= 50) Score = 3;
                if (Score1 >= 70) Score = 4;
                if (Score1 >= 90) Score = 5;
                NumberCompletedTests++;
                MainAbiturient = new ConnectToDB().GetAbiturientByID(MainAbiturient.ID_User);
                new ConnectToDB().EditAbiturient(MainAbiturient, NumberCompletedTests, Score);
               
                MessageBox.Show("Вы ответили - " + NumberTrueAnswer + " верно из " + NumberOfQuestionOnTest);
                NavigationService.Navigate(new StartTestPage(MainUser, MainAbiturient, ID_FirstDirection, ID_SecondDirection, ID_ThiredDirection, NumberCompletedTests));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if ( question.QuestionType == 0)
            {
                if (AnswerCB.Text == question.Answer) NumberTrueAnswer++;
            } 
            else if (question.QuestionType == 1)
            {
                string answer = "";
                if (ACB.IsChecked == true) answer += "А";
                if (BCB.IsChecked == true) answer += "Б";
                if (CCB.IsChecked == true) answer += "В";
                if (DCB.IsChecked == true) answer += "Г";
                if (answer == question.Answer) NumberTrueAnswer++;
            }
            else if (question.QuestionType == 2)
            {
                if (ATBQ.Text == question.Answer) NumberTrueAnswer++;
            }
            NextQuestion();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NextQuestion();
        }
    }
}
