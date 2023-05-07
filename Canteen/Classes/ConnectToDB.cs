using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Canteen.Classes
{
    // Класс подключения к Базе Данных
    public class ConnectToDB
    {
        // Строка подключения
        public string ConnectionString { get; set; } = @"Persist Security Info=False;User ID=Last;Password=123123;Initial Catalog=Delfin;Data Source=LAPTOP-DOAF05I7";

        public User GetUsersByLoginForButton(string UserLogin)
        {
            string command = "USE Canteen " + $"select* from Users WHERE Login = '{UserLogin}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                User user = new User();
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    user.ID_User = reader.GetInt32(0);
                    user.Login = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.Email = reader.GetString(3);
                    user.FirstName = reader.GetString(4);
                    user.SecondName = reader.GetString(5);
                    user.Patronymic = reader.GetString(6);
                    user.Role_ID = reader.GetInt32(7);
                }
                reader.Close();
                conn.Close();
                return user;
            }
        }

        public Abiturient GetAbiturientByID(int ID)
        {
            string command = "USE Canteen " + $"select* from Abiturient WHERE ID_Abiturient = {ID}"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                Abiturient abiturient = new Abiturient();
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    abiturient.ID_User = reader.GetInt32(0);
                    abiturient.SecondName = reader.GetString(1); 
                    abiturient.FirstName = reader.GetString(2); 
                    abiturient.Patronymic = reader.GetString(3); 
                    abiturient.DateOfBirth = reader.GetDateTime(4); 
                    abiturient.PhoneNumber = reader.GetString(5); 
                    abiturient.Email = reader.GetString(6); 
                    abiturient.SeriaPassport = reader.GetInt32(7); 
                    abiturient.NumberPasport = reader.GetInt32(8); 
                    abiturient.Attestat = reader.GetString(9); 
                    abiturient.FirstDirectionBall = reader.GetInt32(10); 
                    abiturient.SecondDirectionBall = reader.GetInt32(11); 
                    abiturient.ThiredDerictionBall = reader.GetInt32(12); 
                    abiturient.ID_FirstDirection = reader.GetInt32(13);
                    abiturient.ID_SecondDirection = reader.GetInt32(14); 
                    abiturient.ID_ThiredDeriction = reader.GetInt32(15); 
                }
                reader.Close();
                conn.Close();
                return abiturient;
            }
        }

        public int GetIDAbiturientByLoginForButton(string Email, string PhoneNumber)
        {
            string command = "USE Canteen " + $"select* from Abiturient WHERE Email = '{Email}' AND PhoneNumber = '{PhoneNumber}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            int ID = 0;
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                Abiturient abiturient = new Abiturient();
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    abiturient.ID_User = reader.GetInt32(0);
                    ID = abiturient.ID_User;
                }
                reader.Close();
                conn.Close();
                return ID;
            }
        }

        public int GetDirectionsIDFromCB(string DirectionStrng)
        {
            string command = "USE Canteen " + $"select* from Directions WHERE Direction = '{DirectionStrng}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            int ID = 0;
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    ID = reader.GetInt32(0);
                }
                reader.Close();
                conn.Close();
                return ID;
            }
        }
        

        public List<User> GetUsersByLogin(string UserLogin)
        {
            try
            {
                string command = "USE Canteen " + $"select* from Users WHERE Login = '{UserLogin}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
                List<User> users = new List<User>();
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User();
                        user.ID_User = reader.GetInt32(0);
                        user.Login = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.Email = reader.GetString(3);
                        user.FirstName = reader.GetString(4);
                        user.SecondName = reader.GetString(5);
                        user.Patronymic = reader.GetString(6);
                        user.Role_ID = reader.GetInt32(7);
                        switch (user.Role_ID)
                        {
                            case 1:
                                user.Role = "Администратор";
                                break;

                        }
                        users.Add(user);
                    }
                    reader.Close();
                    conn.Close();
                    return users;
                }
            }
            catch
            {
                List<User> users = new List<User>();
                return users;
            }
        }


        public List<string> GetRolesForCB()
        {
            string command = "USE Canteen " + "select* from Roles";
            List<string> roels = new List<string>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Roles role = new Roles();
                    role.Role = reader.GetString(1);
                    roels.Add(role.Role);
                }
                reader.Close();
                conn.Close();
                return roels;
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                string command = "USE Canteen " + $"select* from Users "; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
                List<User> users = new List<User>();
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User();
                        user.ID_User = reader.GetInt32(0);
                        user.Login = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.Email = reader.GetString(3);
                        user.FirstName = reader.GetString(4);
                        user.SecondName = reader.GetString(5);
                        user.Patronymic = reader.GetString(6);
                        user.Role_ID = reader.GetInt32(7);
                        switch (user.Role_ID)
                        {
                            case 1:
                                user.Role = "Администратор";
                                break;
                            case 2:
                                user.Role = "Сотрудник отдела приёмной комиссии";
                                break;
                            case 1003:
                                user.Role = "Инжинер тестирвония";
                                break;

                        }
                        users.Add(user);
                    }
                    reader.Close();
                    conn.Close();
                    return users;
                }
            }
            catch
            {
                List<User> users = new List<User>();
                return users;
            }
        }
        public int GetRoleByName (String name)
        {
            int ID_Role = 0;
            string command = "Use Canteen " + $"select *from Roles Where Role = '{name}'";
            using (System.Data.SqlClient.SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Roles role = new Roles();
                    ID_Role = reader.GetInt32(0);
                }
                reader.Close();
                conn.Close();
                return ID_Role;
            }
        }

        public List<User> GetHidenUser(string Name)
        {
            try
            {
                string command = "USE Canteen " + $"select* from Users WHERE Login = '{Name}' OR Email = '{Name}' OR FirstName = '{Name}' OR SecondName = '{Name}' OR Patronymic = '{Name}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
                List<User> users = new List<User>();
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User();
                        user.ID_User = reader.GetInt32(0);
                        user.Login = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.Email = reader.GetString(3);
                        user.FirstName = reader.GetString(4);
                        user.SecondName = reader.GetString(5);
                        user.Patronymic = reader.GetString(6);
                        user.Role_ID = reader.GetInt32(7);
                        switch (user.Role_ID)
                        {
                            case 1:
                                user.Role = "Администратор";
                                break;
                            case 2:
                                user.Role = "Сотрудник отдела приёмной комиссии";
                                break;
                            case 1003:
                                user.Role = "Инжинер тестирвония";
                                break;

                        }
                        users.Add(user);
                    }
                    reader.Close();
                    conn.Close();
                    return users;
                }
            }
            catch
            {
                List<User> users = new List<User>();
                return users;
            }
        }



        public List<Student> StudentsOnGroup(double HowMuchGroup)
        {
            //Проверка коммита
            int AddStudent = 0; // скольким студентам дали группу
            int equal = 0;
            
            List<Student> StudentsWithoutGroup = GetStudent(); // студенты,в БД которых буду менять
            double howmuchStudents = new ConnectToDB().HowMuchStudents(); // Количество студентов в БД
            double qwe = howmuchStudents / HowMuchGroup; // количество студентов в одной группе
            int ewq = 0; // сколько студентов уже добавил в эту группу
            int IDStudent = 1;
            int Group = 1;
            var isNumeric = int.TryParse(Convert.ToString(ewq), out int n);

            if (isNumeric == true)
            {
                equal = 0;// если студенты нормально делятся по группам, без остатка, то всё хорошо
            }
            else
            {
                equal = 1; // если студенты делятся не поровну в группах, то делаю переменную для "гуляющего" студента
            }
            while(AddStudent < howmuchStudents)
            {
                int ff = 0;
                if (ewq < qwe) // если студентов в группе не хватает, то добавляю туда ещё одного
                {
                    string command = "USE Canteen " + $"EXEC [dbo].EditStudentGroup '{Group}', {IDStudent}";
                    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        SqlCommand command2 = new SqlCommand(command, conn);
                        command2.ExecuteScalar();
                        conn.Close();
                    }
                    IDStudent++;
                    AddStudent++;
                    ewq++;
                }
                else if (equal == 1 && ff ==0)
                {

                    string command = "USE Canteen " + $"EXEC [dbo].EditStudentGroup '{Group}', {IDStudent}";
                    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        SqlCommand command2 = new SqlCommand(command, conn);
                        command2.ExecuteScalar();
                        conn.Close();
                    }
                    IDStudent++;
                    AddStudent++;
                    ff = 1;
                    ewq++;
                }
                else
                {
                    Group++;
                    ff = 0;
                    ewq = 0;
                }


               
                
                
            }

            List<Student> studeents = new ConnectToDB().GetStudent(); // таблица, которую я выведу в Xaml
            return studeents;

        }
        
        public List<string> GroupForCB()
        {
            List<Student> AllStudents = GetStudent();
            List<String> AllGroup = new List<string>();

            string command = "USE Canteen " + $"select* from Students";
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while ( reader.Read())
                {
                    Group group = new Group();
                    group.GroupNumber = reader.GetString(10);
                    
                    if(AllGroup.Contains(group.GroupNumber))// если в AllGroup есть уже такая группа, то ничего не делает
                    {
                       
                    }
                    else {
                        AllGroup.Add(group.GroupNumber);
                    }
                    

                }
            }
            return AllGroup;
        }

        public List<Student> GetHidenStudent(string HidenAbiturient)
        {
            string command = "USE Canteen " + $"select* from Students WHERE SecondName = '{HidenAbiturient}' or FirstName = '{HidenAbiturient}' or Patronymic = '{HidenAbiturient}' or Email = '{HidenAbiturient}' or PhoneNumber = '{HidenAbiturient}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            List<Student> user = new List<Student>();

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {

                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Student abiturient = new Student();
                    abiturient.ID_User = reader.GetInt32(0);
                    abiturient.SecondName = reader.GetString(1);
                    abiturient.FirstName = reader.GetString(2);
                    abiturient.Patronymic = reader.GetString(3);
                    abiturient.DateOfBirth = reader.GetDateTime(4);
                    abiturient.PhoneNumber = reader.GetString(5);
                    abiturient.Email = reader.GetString(6);
                    abiturient.SeriaPassport = reader.GetInt32(7);
                    abiturient.NumberPasport = reader.GetInt32(8);
                    abiturient.Attestat = reader.GetString(9);
                    abiturient.GroupNumber = reader.GetString(10);



                    user.Add(abiturient);
                }
                reader.Close();
                conn.Close();
                return user;

            }
        }

        public List<Test> GetHidenTest(string HidenTest)
        {
            string command = "USE Canteen " + $"select* from Tests WHERE TestName = '{HidenTest}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            List<Test> tests = new List<Test>();

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {

                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Test test = new Test();
                    test.ID_Test = reader.GetInt32(0);
                    test.TestName = reader.GetString(1);
                    test.Difficulity = reader.GetInt32(2);
                    tests.Add(test);
                }
                reader.Close();
                conn.Close();
                return tests;

            }
        }

        public List<Abiturient> GetHidenAbiturient(string HidenAbiturient)
        {
            string command = "USE Canteen " + $"select* from Abiturient WHERE SecondName = '{HidenAbiturient}' or FirstName = '{HidenAbiturient}' or PhoneNumber = '{HidenAbiturient}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            List<Abiturient> user = new List<Abiturient>();

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
               
                    conn.Open();
                    SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                    while (reader.Read())
                    {
                        Abiturient abiturient = new Abiturient();
                        abiturient.ID_User = reader.GetInt32(0);
                        abiturient.SecondName = reader.GetString(1);
                        abiturient.FirstName = reader.GetString(2);
                        abiturient.Patronymic = reader.GetString(3);
                        abiturient.DateOfBirth = reader.GetDateTime(4);
                        abiturient.PhoneNumber = reader.GetString(5);
                        abiturient.Email = reader.GetString(6);
                        abiturient.SeriaPassport = reader.GetInt32(7);
                        abiturient.NumberPasport = reader.GetInt32(8);
                        abiturient.Attestat = reader.GetString(9);
                        abiturient.FirstDirectionBall = reader.GetInt32(10);
                        abiturient.SecondDirectionBall = reader.GetInt32(11);
                        abiturient.ThiredDerictionBall = reader.GetInt32(12);
                        abiturient.ID_FirstDirection = reader.GetInt32(13);
                        abiturient.ID_SecondDirection = reader.GetInt32(14);
                        abiturient.ID_ThiredDeriction = reader.GetInt32(15);
                        user.Add(abiturient);
                    }
                    reader.Close();
                    conn.Close();
                    return user;
                
            }
        }

        public void AddAbiturients(List<Abiturient> abiturients)
        {

            foreach (Abiturient abiturient in abiturients)
            {
                string command = "USE Canteen " + $"EXEC [dbo].AddAbiturients '{abiturient.SecondName}','{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}', '{abiturient.PhoneNumber}', '{abiturient.Email}', '{abiturient.SeriaPassport}', '{abiturient.NumberPasport}', '{abiturient.Attestat}'";
               
                    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        SqlCommand command1 = new SqlCommand(command, conn);
                        command1.ExecuteScalar();
                        conn.Close();
                    }
                
            }
            
        
        }
        public void AddStudentsFromAbiturients(List<Abiturient> abiturients, int equal)
        {
            int qwe = 0;
            foreach (Abiturient abiturient in abiturients)
            {
                if (qwe < equal)
                {
                    string command = "USE Canteen " + $"EXEC [dbo].AddStudentsFromAbiturients '{abiturient.SecondName}','{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}', '{abiturient.PhoneNumber}', '{abiturient.Email}', '{abiturient.SeriaPassport}', '{abiturient.NumberPasport}', '{abiturient.Attestat}','0'";

                    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        SqlCommand command1 = new SqlCommand(command, conn);
                        command1.ExecuteScalar();
                        conn.Close();
                    }
                    string command3 = "USE Canteen " + $"EXEC [dbo].DeleteAbiturient '{abiturient.ID_User}'";

                    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        SqlCommand command1 = new SqlCommand(command3, conn);
                        command1.ExecuteScalar();
                        conn.Close();
                    }
                    qwe++;
                }
                else break;

            }


        }
        public void DeleteUser (int ID_User)
        {
            String Command = "Use Canteen " + $"EXEC [dbo].DeleteUser {ID_User}";
            using(System.Data.SqlClient.SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(Command, conn);
                command1.ExecuteScalar();
                conn.Close();
            }
        }

        public void DeleteTest (int ID_Test)
        {
            string command = "USE Canteen " + $"EXEC [dbo].DeleteTest {ID_Test}";

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(command, conn);
                command1.ExecuteScalar();
                conn.Close();
            }
            List<Question> DeletedQuestions = GetListQuestionByID(ID_Test);
            int NumberQuestion = DeletedQuestions.Count();
            int HowMuchQuestionDelete = 0;
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                while (HowMuchQuestionDelete != NumberQuestion)
                {
                    Question question = GetQuestionByID(ID_Test, 1);
                    string command3 = "USE Canteen " + $"EXEC [dbo].DeleteQuestion {question.ID_Question}";
                    conn.Open();
                    SqlCommand command1 = new SqlCommand(command3, conn);
                    command1.ExecuteScalar();
                    conn.Close();
                    HowMuchQuestionDelete++;
                }
            }
        }

        public void ClearAbiturient()
        {

            
                string command = "USE Canteen " + "TRUNCATE TABLE Abiturient";
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand command1 = new SqlCommand(command, conn);
                    command1.ExecuteScalar();
                    conn.Close();
                }
           
        }
        public void ClearStudents()
        {


            string command = "USE Canteen " + "TRUNCATE TABLE Students";
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(command, conn);
                command1.ExecuteScalar();
                conn.Close();
            }

        }
        

        public List<Direction> GetDirections()
        {
            string command = "USE Canteen " + "select* from Directions";
            List<Direction> directions = new List<Direction>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Direction direction = new Direction();
                    direction.ID_Direction = reader.GetInt32(0);
                    direction.DirectionName = reader.GetString(1);
                    direction.NumberOfPeople = reader.GetInt32(2);


                    directions.Add(direction);
                }
                reader.Close();
                conn.Close();
                return directions;
            }
        }




        public List<string> GetDirectionsForCB()
        {
            string command = "USE Canteen " + "select* from Directions";
            List<string> directions = new List<string>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Direction direction = new Direction();
                    direction.DirectionName = reader.GetString(1);
                    directions.Add(direction.DirectionName);
                }
                reader.Close();
                conn.Close();
                return directions;
            }
        }

        public List<Abiturient> GetAbiturient()
        {
            string command = "USE Canteen " + "select* from Abiturient";
            List<Abiturient> abiturients = new List<Abiturient>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Abiturient abiturient = new Abiturient();
                    abiturient.ID_User = reader.GetInt32(0);
                    abiturient.SecondName = reader.GetString(1);
                    abiturient.FirstName = reader.GetString(2);
                    abiturient.Patronymic = reader.GetString(3);
                    abiturient.DateOfBirth = reader.GetDateTime(4);
                    abiturient.PhoneNumber = reader.GetString(5);
                    abiturient.Email = reader.GetString(6);
                    abiturient.SeriaPassport = reader.GetInt32(7);
                    abiturient.NumberPasport = reader.GetInt32(8);
                    abiturient.Attestat = reader.GetString(9);
                    abiturient.FirstDirectionBall = reader.GetInt32(10);
                    abiturient.SecondDirectionBall = reader.GetInt32(11);
                    abiturient.ThiredDerictionBall = reader.GetInt32(12);
                    abiturient.ID_FirstDirection = reader.GetInt32(13);
                    abiturient.ID_SecondDirection = reader.GetInt32(14);
                    abiturient.ID_ThiredDeriction = reader.GetInt32(15);


                    abiturients.Add(abiturient);
                }
                reader.Close();
                conn.Close();
                return abiturients;
            }
        }


        
        public List<Student> GetStudentWithGroup( string group)
        {
            string command = "USE Canteen " + $"select* from Students WHERE GroupNumber = '{group}'";
            List<Student> abiturients = new List<Student>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Student abiturient = new Student();
                    abiturient.ID_User = reader.GetInt32(0);
                    abiturient.SecondName = reader.GetString(1);
                    abiturient.FirstName = reader.GetString(2);
                    abiturient.Patronymic = reader.GetString(3);
                    abiturient.DateOfBirth = reader.GetDateTime(4);
                    abiturient.PhoneNumber = reader.GetString(5);
                    abiturient.Email = reader.GetString(6);
                    abiturient.SeriaPassport = reader.GetInt32(7);
                    abiturient.NumberPasport = reader.GetInt32(8);
                    abiturient.Attestat = reader.GetString(9);
                    abiturient.GroupNumber = reader.GetString(10);

                    abiturients.Add(abiturient);
                }
                reader.Close();
                conn.Close();
                return abiturients;
            }
        }


        public List<Student> GetStudent()
        {
            string command = "USE Canteen " + "select* from Students";
            List<Student> abiturients = new List<Student>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Student abiturient = new Student();
                    abiturient.ID_User = reader.GetInt32(0);
                    abiturient.SecondName = reader.GetString(1);
                    abiturient.FirstName = reader.GetString(2);
                    abiturient.Patronymic = reader.GetString(3);
                    abiturient.DateOfBirth = reader.GetDateTime(4);
                    abiturient.PhoneNumber = reader.GetString(5);
                    abiturient.Email = reader.GetString(6);
                    abiturient.SeriaPassport = reader.GetInt32(7);
                    abiturient.NumberPasport = reader.GetInt32(8);
                    abiturient.Attestat = reader.GetString(9);
                    abiturient.GroupNumber = reader.GetString(10);

                    abiturients.Add(abiturient);
                }
                reader.Close();
                conn.Close();
                return abiturients;
            }
        }
        public User GetUsersByEmail(string UserEmail)
        {
            string command = "USE Canteen " + $"select* from Users WHERE Email = '{UserEmail}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                User user = new User();
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    user.ID_User = reader.GetInt32(0);
                    user.Login = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.Email = reader.GetString(3);
                    user.FirstName = reader.GetString(4);
                    user.SecondName = reader.GetString(5);
                    user.Patronymic = reader.GetString(6);
                    user.Role_ID = reader.GetInt32(7);
                }
                reader.Close();
                conn.Close();
                return user;
            }
        }



        public void AddUser(User user)
        {
            if (CheckIfLoginIsNew(user.Login))
            {
                if (CheckIfEmailIsNew(user.Email))
                {
                    string command = "USE Canteen " + $"EXEC [dbo].AddUser '{user.Login}','{user.Password}', '{user.Email}', '{user.FirstName}', '{user.SecondName}', '{user.Patronymic}', '{user.Role_ID}'";
                    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        SqlCommand command1 = new SqlCommand(command, conn);
                        command1.ExecuteScalar();
                        conn.Close();
                    }
                    MessageBox.Show("Успешная регистрация");
                }
                else
                {
                    MessageBox.Show("Пользователь с такой почтой уже существует");
                }
            }
            else
            {

                MessageBox.Show("Пользователь с таким логином уже существует");
            }
        }
        
        public void EditUser(User user)
        {

            string command = "USE Canteen " + $"EXEC [dbo].EditUser '{user.Login}','{user.Password}', '{user.Email}', '{user.FirstName}', '{user.SecondName}', '{user.Patronymic}', '{user.Role_ID}', {user.ID_User}";
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(command, conn);
                command1.ExecuteScalar();
                conn.Close();
            }

        }

        
        public void EditAbiturientAttestat(int ID_Abiturient, string  Attestat)
        {
            Abiturient abiturient = GetAbiturientByID(ID_Abiturient);
            string command = "USE Canteen " + $"EXEC [dbo].EditAbiturient '{abiturient.SecondName}','{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}', '{abiturient.PhoneNumber}', '{abiturient.Email}', {abiturient.SeriaPassport}, {abiturient.NumberPasport}, '{Attestat}', {abiturient.FirstDirectionBall}, {abiturient.SecondDirectionBall}, {abiturient.ThiredDerictionBall}, {abiturient.ID_FirstDirection}, {abiturient.ID_SecondDirection}, {abiturient.ID_ThiredDeriction}, {abiturient.ID_User}";
           
           
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(command, conn);
                command1.ExecuteScalar();
                conn.Close();
            }

        }



        public void EditAbiturient(Abiturient abiturient, int CompletedTest, int NumberTrueAnswer)
        {
            string command = "";
            if (CompletedTest == 1)
            {
                command = "USE Canteen " + $"EXEC [dbo].EditAbiturient '{abiturient.SecondName}','{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}', '{abiturient.PhoneNumber}', '{abiturient.Email}', {abiturient.SeriaPassport}, {abiturient.NumberPasport}, '{abiturient.Attestat}', {NumberTrueAnswer}, {abiturient.SecondDirectionBall}, {abiturient.ThiredDerictionBall}, {abiturient.ID_FirstDirection}, {abiturient.ID_SecondDirection}, {abiturient.ID_ThiredDeriction}, {abiturient.ID_User}";
            }
            else if (CompletedTest == 2)
            {
                command = "USE Canteen " + $"EXEC [dbo].EditAbiturient '{abiturient.SecondName}','{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}', '{abiturient.PhoneNumber}', '{abiturient.Email}', {abiturient.SeriaPassport}, {abiturient.NumberPasport}, '{abiturient.Attestat}', {abiturient.FirstDirectionBall}, {NumberTrueAnswer}, {abiturient.ThiredDerictionBall}, {abiturient.ID_FirstDirection}, {abiturient.ID_SecondDirection}, {abiturient.ID_ThiredDeriction}, {abiturient.ID_User}";
            }
            else if (CompletedTest == 3)
            {
                command = "USE Canteen " + $"EXEC [dbo].EditAbiturient '{abiturient.SecondName}','{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}', '{abiturient.PhoneNumber}', '{abiturient.Email}', {abiturient.SeriaPassport}, {abiturient.NumberPasport}, '{abiturient.Attestat}', {abiturient.FirstDirectionBall}, {abiturient.SecondDirectionBall}, {NumberTrueAnswer}, {abiturient.ID_FirstDirection}, {abiturient.ID_SecondDirection}, {abiturient.ID_ThiredDeriction}, {abiturient.ID_User}";
            }
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(command, conn);
                command1.ExecuteScalar();
                conn.Close();
            }

        }

        public void UpdateTest(int ID_Test, int Difficuluty)
        {
            Test test = GetTestsByID(ID_Test);

            string command = "USE Canteen " + $"EXEC [dbo].UpdateTest '{test.TestName}',{Difficuluty}, {ID_Test}";
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(command, conn);
                command1.ExecuteScalar();
                conn.Close();
            }

        }


        public bool CheckIfLoginIsNew(string login)
        {
            string command = "USE Canteen " + $"select* from Users WHERE Login = '{login}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            List<User> users = new List<User>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.ID_User = reader.GetInt32(0);
                    users.Add(user);
                }
                reader.Close();
                conn.Close();
            }
            if (users.Count != 0)
                return false;
            else
                return true;
        }

       public int HowMuchStudents()
        {
            string command = "USE Canteen " + $"select* from Students"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            int equal = 0;
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    equal++;
                }
                reader.Close();
                conn.Close();
            }
            return equal;
        }

        public int HowMuchAbiturients()
        {
            string command = "USE Canteen " + $"select* from Abiturient"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            int equal = 0;
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    equal++;
                }
                reader.Close();
                conn.Close();
            }
            return equal;
        }


        public int HowMuchQuestion(int ID_Test)
        {
            string command = "USE Canteen " + $"select* from Questions WHERE TestNumber = '{ID_Test}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            int equal = 0;
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    equal++;
                }
                reader.Close();
                conn.Close();
            }
            return equal;
        }

        public bool CheckIfEmailIsNew(string email)
        {
            string command = "USE Canteen " + $"select* from Users WHERE Email = '{email}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            List<User> users = new List<User>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.ID_User = reader.GetInt32(0);
                    users.Add(user);
                }
                reader.Close();
                conn.Close();
            }
            if (users.Count != 0)
                return false;
            else
                return true;
        }

        public List<Question> GetQuestion(int equal)
        {
            string command = "USE Canteen " + $"select* from Questions Where TestNumber = {equal}";
            List<Question> questions = new List<Question>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Question question = new Question();
                    question.ID_Question = reader.GetInt32(0);
                    question.QuestionString = reader.GetString(1);
                    question.A = reader.GetString(2);
                    question.B = reader.GetString(3);
                    question.C = reader.GetString(4);
                    question.D = reader.GetString(5);
                    question.Answer = reader.GetString(6);
                    question.IDTest = reader.GetInt32(7);
                    question.QuestionType = reader.GetInt32(8);

                    switch (question.QuestionType)
                    {
                        case 0:
                            question.QuestionTypeString = "Выбор правильного ответа";
                            break;
                        case 1:
                            question.QuestionTypeString = "Выбор нескольких ответов";
                            break;
                        case 2:
                            question.QuestionTypeString = "Вписать ответ";
                            break;
                    }

                    questions.Add(question);
                }
                reader.Close();
                conn.Close();
                return questions;
            }
        }

        public List<Question> GetQuestionByName(string Name)
        {
            string command = "USE Canteen " + $"select* from Questions Where Question = '{Name}'";
            List<Question> questions = new List<Question>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Question question = new Question();
                    question.ID_Question = reader.GetInt32(0);
                    question.QuestionString = reader.GetString(1);
                    question.A = reader.GetString(2);
                    question.B = reader.GetString(3);
                    question.C = reader.GetString(4);
                    question.D = reader.GetString(5);
                    question.Answer = reader.GetString(6);
                    question.IDTest = reader.GetInt32(7);
                    question.QuestionType = reader.GetInt32(8);

                    switch (question.QuestionType)
                    {
                        case 0:
                            question.QuestionTypeString = "Выбор правильного ответа";
                            break;
                        case 1:
                            question.QuestionTypeString = "Выбор нескольких ответов";
                            break;
                        case 2:
                            question.QuestionTypeString = "Вписать ответ";
                            break;
                    }

                    questions.Add(question);
                }
                reader.Close();
                conn.Close();
                return questions;
            }
        }

        public List<Question> GetAllQuestion()
        {
            string command = "USE Canteen " + $"select* from Questions";
            List<Question> questions = new List<Question>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Question question = new Question();
                    question.ID_Question = reader.GetInt32(0);
                    question.QuestionString = reader.GetString(1);
                    question.A = reader.GetString(2);
                    question.B = reader.GetString(3);
                    question.C = reader.GetString(4);
                    question.D = reader.GetString(5);
                    question.Answer = reader.GetString(6);
                    question.IDTest = reader.GetInt32(7);
                    question.QuestionType = reader.GetInt32(8);

                    switch (question.QuestionType)
                    {
                        case 0:
                            question.QuestionTypeString = "Выбор правильного ответа";
                            break;
                        case 1:
                            question.QuestionTypeString = "Выбор нескольких ответов";
                            break;
                        case 2:
                            question.QuestionTypeString = "Вписать ответ";
                            break;
                    }

                    questions.Add(question);
                }
                reader.Close();
                conn.Close();
                return questions;
            }
        }


        public Question GetQuestionByID(int ID_Test, int QuestionNumber)
        {
            Question question = new Question();
            int TryToRead = 0;
            string command = "Use Canteen " + $"Select *from Questions WHERE TestNumber = {ID_Test}";
            using (System.Data.SqlClient.SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while(reader.Read() && TryToRead != QuestionNumber)
                {
                    
                        question.ID_Question = reader.GetInt32(0);
                        question.QuestionString = reader.GetString(1);
                        question.A = reader.GetString(2);
                        question.B = reader.GetString(3);
                        question.C = reader.GetString(4);
                        question.D = reader.GetString(5);
                        question.Answer = reader.GetString(6);
                        question.IDTest = reader.GetInt32(7);
                        question.QuestionType = reader.GetInt32(8);

                        switch (question.QuestionType)
                        {
                            case 0:
                                question.QuestionTypeString = "Выбор правильного ответа";
                                break;
                            case 1:
                                question.QuestionTypeString = "Выбор нескольких ответов";
                                break;
                            case 2:
                                question.QuestionTypeString = "Вписать ответ";
                                break;
                        }
                    
                    TryToRead++;
                }
                reader.Close();
                conn.Close();
                return question;
            }
        }



        public List<Question> GetListQuestionByID(int ID_Test)
        {

            List<Question> questions = new List<Question>();
            string command = "Use Canteen " + $"Select *from Questions WHERE TestNumber = {ID_Test}";
            using (System.Data.SqlClient.SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read() )
                {
                    Question question = new Question();
                    question.ID_Question = reader.GetInt32(0);
                    question.QuestionString = reader.GetString(1);
                    question.A = reader.GetString(2);
                    question.B = reader.GetString(3);
                    question.C = reader.GetString(4);
                    question.D = reader.GetString(5);
                    question.Answer = reader.GetString(6);
                    question.IDTest = reader.GetInt32(7);
                    question.QuestionType = reader.GetInt32(8);

                    switch (question.QuestionType)
                    {
                        case 0:
                            question.QuestionTypeString = "Выбор правильного ответа";
                            break;
                        case 1:
                            question.QuestionTypeString = "Выбор нескольких ответов";
                            break;
                        case 2:
                            question.QuestionTypeString = "Вписать ответ";
                            break;
                    }

                    questions.Add(question);
                }
                reader.Close();
                conn.Close();
                return questions;
            }
        }



        public string GetTestName(int ID_Test)
        {
            string command = "USE Canteen " + $"select* from Tests Where ID_Test = {ID_Test}";
            string TestName ="";
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                {
                    while (reader.Read())
                    {
                        Test test = new Test();
                        test.TestName = reader.GetString(1);
                        TestName = test.TestName;
                    }
                }
                 
                reader.Close();
                conn.Close();
                
            }
            return TestName;
        }


        public string GetDirectionName(int ID_Direction)
        {
            string command = "USE Canteen " + $"select* from Directions Where ID_Direction = {ID_Direction}";
            string DirectionName = "";
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                {
                    while (reader.Read())
                    {
                        Direction direction = new Direction();
                        direction.DirectionName = reader.GetString(1);
                        DirectionName = direction.DirectionName;
                    }
                }

                reader.Close();
                conn.Close();

            }
            return DirectionName;
        }

        public void AddTest(List<Question> questions, string testName)
        {
           

            string command = "USE Canteen " + $"EXEC [dbo].AddTest '{testName}', 0";
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(command, conn);
                command1.ExecuteScalar();
                conn.Close();
            }




            Test test = new Test();


            string command3 = "USE Canteen " + $"select* from Tests WHERE TestName = '{testName}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command3, conn).ExecuteReader();
                while (reader.Read())
                {
                    
                    test.ID_Test = reader.GetInt32(0);
                }
                reader.Close();
                conn.Close();
            }



            foreach (Question question in questions)
            {
                string command2 = "USE Canteen " + $"EXEC [dbo].AddQuestion '{question.QuestionString}','{question.A}', '{question.B}', '{question.C}', '{question.D}', '{question.Answer}', '{test.ID_Test}', '{question.QuestionType}'";

                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand command1 = new SqlCommand(command2, conn);
                    command1.ExecuteScalar();
                    conn.Close();
                }

            }


        }



        public List<Test> GetTests()
        {
            string command = "USE Canteen " + "select* from Tests";
            List<Test> tests = new List<Test>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Test test = new Test();
                    test.ID_Test = reader.GetInt32(0);
                    test.TestName = reader.GetString(1);
                    test.Difficulity = reader.GetInt32(2);
                    test.Direction = new ConnectToDB().GetDirection(test.Difficulity);
                    int Equel = HowMuchQuestion(test.ID_Test);
                    test.NumberOfQuestion = Equel;
                    tests.Add(test);
                }
                reader.Close();
                conn.Close();
                return tests;
            }
        }





        public List<Test> GetTestsFromAbiturient(int ID_Direction)
        {
            string command = "USE Canteen " + $"select* from Tests WHERE Difficulty = {ID_Direction}" ;
            List<Test> tests = new List<Test>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Test test = new Test();
                    test.ID_Test = reader.GetInt32(0);
                    test.TestName = reader.GetString(1);
                    test.Difficulity = reader.GetInt32(2);
                    test.Direction = new ConnectToDB().GetDirection(test.Difficulity);
                    int Equel = HowMuchQuestion(test.ID_Test);
                    test.NumberOfQuestion = Equel;
                    tests.Add(test);
                }
                reader.Close();
                conn.Close();
                return tests;
            }
        }


        public string GetDirection(int ID_Direction)
        {
            string command = "USE Canteen " + $"select* from Directions WHERE ID_Direction = {ID_Direction}";
            string direction ="";
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {

                    direction = reader.GetString(1);
                }
                reader.Close();
                conn.Close();
                return direction;
            }
        }

        public Test GetTestsByID( int ID_Test)
        {
            string command = "USE Canteen " + $"select* from Tests WHERE ID_Test = {ID_Test}";
            Test test = new Test();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    test.ID_Test = reader.GetInt32(0);
                    test.TestName = reader.GetString(1);
                    test.Difficulity = reader.GetInt32(2);
                    int Equel = HowMuchQuestion(test.ID_Test);
                    test.NumberOfQuestion = Equel;
                }
                reader.Close();
                conn.Close();
                return test;
            }
        }


        public void AddDirection(Direction direction)
        {
            string command = "USE Canteen " + $"EXEC [dbo].[addDirection] '{direction.DirectionName}', {direction.NumberOfPeople}"; 
            using ( System.Data.SqlClient.SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(command,conn);
                command1.ExecuteScalar();
                conn.Close();
            }
        }

        public void AddAbiturient(Abiturient abiturient)
        {
            string command = "USE Canteen " + $"EXEC [dbo].[AddAbiturient] '{abiturient.SecondName}', '{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}', '{abiturient.PhoneNumber}', '{abiturient.Email}', {abiturient.SeriaPassport}, {abiturient.NumberPasport}, '{abiturient.Attestat}', {abiturient.FirstDirectionBall}, {abiturient.SecondDirectionBall}, {abiturient.ThiredDerictionBall},  {abiturient.ID_FirstDirection}, {abiturient.ID_SecondDirection}, {abiturient.ID_ThiredDeriction}";
            using (System.Data.SqlClient.SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(command, conn);
                command1.ExecuteScalar();
                conn.Close();
            }
        }


        public void EditDirection(Direction direction)
        {
            string command = "USE Canteen " + $"EXEC [dbo].[editDirection] '{direction.DirectionName}', {direction.NumberOfPeople}, {direction.ID_Direction}";
            using (System.Data.SqlClient.SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(command, conn);
                command1.ExecuteScalar();
                conn.Close();
            }
        }


        public void DeleteDirection(int ID_Direction)
        {
            string command = "USE Canteen " + $"EXEC [dbo].[deleteDirection] {ID_Direction}";
            using (System.Data.SqlClient.SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(command, conn);
                command1.ExecuteScalar();
                conn.Close();
            }
        }

    }
}
