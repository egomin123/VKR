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
        public string ConnectionString { get; set; } = @"Persist Security Info=False;User ID=Last1;Password=123456;Initial Catalog=Delfin;Data Source=LAPTOP-DOAF05I7";

        public void DoCommand(string request)
        {
           
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(request, conn);
                        cmd.ExecuteScalar();
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                  //  MessageBox.Show($"Ошибка: " + ex);
                }
           
        }


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


        public void AddQuestion(Question question)
        {
            int NumberTest = 0;
            string Command = "USE Canteen " + $"EXEC [dbo].AddQuestion '{question.QuestionString}','{question.A}','{question.B}','{question.C}','{question.D}','{question.Answer}','{NumberTest}','{question.QuestionType}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand Command1 = new SqlCommand(Command, conn);
                Command1.ExecuteScalar();
                conn.Close();
            }
        }

        public AbiturientSPO GetAbiturientSPOByID(int ID)
        {
            string command = "USE Canteen " + $"select* from AbiturientSPO WHERE ID_Abiturient = {ID}"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                AbiturientSPO abiturient = new AbiturientSPO();
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    abiturient.ID_Abiturient = reader.GetInt32(0);
                    abiturient.SecondName = reader.GetString(1); 
                    abiturient.FirstName = reader.GetString(2); 
                    abiturient.Patronymic = reader.GetString(3); 
                    abiturient.DateOfBirth = reader.GetDateTime(4);
                    abiturient.Email = reader.GetString(5);
                    abiturient.PhoneNumber = reader.GetString(6); 
                    abiturient.SeriesPasport = reader.GetInt32(7); 
                    abiturient.NumberPasport = reader.GetInt32(8); 
                    abiturient.FirstDirectionBall = reader.GetInt32(9); 
                    abiturient.SecondDirectionBall = reader.GetInt32(10); 
                    abiturient.ThiredDerictionBall = reader.GetInt32(11); 
                    abiturient.ID_FirstDirection = reader.GetInt32(12);
                    abiturient.ID_SecondDirection = reader.GetInt32(13); 
                    abiturient.ID_ThiredDeriction = reader.GetInt32(14); 
                }
                reader.Close();
                conn.Close();
                return abiturient;
            }
        }
        public Abiturient11 GetAbiturient11ByID(int ID)
        {
            string command = "USE Canteen " + $"select* from Abiturient11 WHERE ID_Abiturient = {ID}"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                Abiturient11 abiturient = new Abiturient11();
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    abiturient.ID_Abiturient = reader.GetInt32(0);
                    abiturient.SecondName = reader.GetString(1);
                    abiturient.FirstName = reader.GetString(2);
                    abiturient.Patronymic = reader.GetString(3);
                    abiturient.DateOfBirth = reader.GetDateTime(4);
                    abiturient.Email = reader.GetString(5);
                    abiturient.PhoneNumber = reader.GetString(6);
                    abiturient.SeriesPasport = reader.GetInt32(7);
                    abiturient.NumberPasport = reader.GetInt32(8);
                    abiturient.EGE = reader.GetString(9);
                    abiturient.ID_FirstDirection = reader.GetInt32(10);
                    abiturient.ID_SecondDirection = reader.GetInt32(11);
                    abiturient.ID_ThiredDeriction = reader.GetInt32(12);
                }
                reader.Close();
                conn.Close();
                return abiturient;
            }
        }
        public int GetIDAbiturientSPOByLoginForButton(string Email, string PhoneNumber)
        {
            string command = "USE Canteen " + $"select* from AbiturientSPO WHERE Email = '{Email}' AND PhoneNumber = '{PhoneNumber}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            int ID = 0;
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                AbiturientSPO abiturient = new AbiturientSPO();
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    abiturient.ID_Abiturient = reader.GetInt32(0);
                    ID = abiturient.ID_Abiturient;
                }
                reader.Close();
                conn.Close();
                return ID;
            }
        }


        public int GetIDAbiturient11ByLoginForButton(string Email, string PhoneNumber)
        {
            string command = "USE Canteen " + $"select* from Abiturient11 WHERE Email = '{Email}' AND PhoneNumber = '{PhoneNumber}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            int ID = 0;
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                Abiturient11 abiturient = new Abiturient11();
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    abiturient.ID_Abiturient = reader.GetInt32(0);
                    ID = abiturient.ID_Abiturient;
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


        public int GetGroupName()
        {
            int GroupInt = 1;
            string Group = "Группа " + GroupInt;
            
            while (true)
            {
                int Test = 0;
                string Command = "Use Canteen " + $"Select *from students WHERE GroupNumber = '{Group}'";
                using (System.Data.SqlClient.SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlDataReader reader = new SqlCommand(Command, conn).ExecuteReader();
                    while (reader.Read())
                    {
                        Test++;
                    }
                    if (Test != 0)
                    {
                        GroupInt++;
                        Group =  "Группа " + GroupInt;
                    }
                    else
                    {
                        
                        break;
                    }
                }
            }
            return GroupInt;
        }
        public List<Student> StudentsOnGroup(int HowMuchGroup, int ID_Direction)
        {
            int AddStudent = 0; // скольким студентам дали группу
            int equal = 0;
            int CreatedGroups = 0;
            List<Student> StudentsWithoutGroup = GetStudentByDirectionID(ID_Direction); // список студентов, которым буду выдавать группу
            int howmuchStudents = new ConnectToDB().HowMuchStudentsWithDirectionID(ID_Direction); // Их кКоличество в БД
            int HowStudentsNeedInGroup = howmuchStudents / HowMuchGroup; // Сколько человек должно быть в группе

            int ewq = HowStudentsNeedInGroup * HowMuchGroup;
            if (ewq != howmuchStudents) HowStudentsNeedInGroup++;
            int Group = GetGroupName(); // свободный номер группы


            
            foreach (Student sudents in StudentsWithoutGroup) // у меня есть список из 10 студентов, нужно дать им 3 группы
            {
                if (HowStudentsNeedInGroup > 0 && AddStudent < howmuchStudents) // 2 > 0 && 0 < 9
                {
                    string command = "USE Canteen " + $"EXEC [dbo].EditStudentGroup 'Группа {Group}', {sudents.ID_User}";
                    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        SqlCommand command2 = new SqlCommand(command, conn);
                        command2.ExecuteScalar();
                        conn.Close();
                    }
                    HowStudentsNeedInGroup--;
                    AddStudent++;
                }
                else
                {
                    HowStudentsNeedInGroup = howmuchStudents / HowMuchGroup;
                    CreatedGroups++;
                    howmuchStudents = new ConnectToDB().HowMuchStudentsWithDirectionID(ID_Direction);
                    if (CreatedGroups != HowMuchGroup)
                    {
                        Group = GetGroupName();
                    }
                    if ( AddStudent < howmuchStudents)
                    {
                        string command = "USE Canteen " + $"EXEC [dbo].EditStudentGroup 'Группа {Group}', {sudents.ID_User}";
                        using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                        {
                            conn.Open();
                            SqlCommand command2 = new SqlCommand(command, conn);
                            command2.ExecuteScalar();
                            conn.Close();
                        }
                        HowStudentsNeedInGroup--;
                        AddStudent++;
                    }
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
            List<Student> students = new List<Student>();

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {

                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.ID_User = reader.GetInt32(0);
                    student.SecondName = reader.GetString(1);
                    student.FirstName = reader.GetString(2);
                    student.Patronymic = reader.GetString(3);
                    student.DateOfBirth = reader.GetDateTime(4);
                    student.PhoneNumber = reader.GetString(5);
                    student.Email = reader.GetString(6);
                    student.SeriaPassport = reader.GetInt32(7);
                    student.NumberPasport = reader.GetInt32(8);
                    student.ID_Direction = reader.GetInt32(9);
                    student.GroupNumber = reader.GetString(10);



                    students.Add(student);
                }
                reader.Close();
                conn.Close();
                return students;

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

        public List<Abiturient11> GetHidenAbiturient11(string HidenAbiturient)
        {
            string command = "USE Canteen " + $"select* from Abiturient11 WHERE SecondName = '{HidenAbiturient}' or FirstName = '{HidenAbiturient}' or PhoneNumber = '{HidenAbiturient}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            List<Abiturient11> user = new List<Abiturient11>();

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
               
                    conn.Open();
                    SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                    while (reader.Read())
                    {
                        Abiturient11 abiturient = new Abiturient11();
                    abiturient.ID_Abiturient = reader.GetInt32(0);
                    abiturient.SecondName = reader.GetString(1);
                    abiturient.FirstName = reader.GetString(2);
                    abiturient.Patronymic = reader.GetString(3);
                    abiturient.DateOfBirth = reader.GetDateTime(4);
                    abiturient.Email = reader.GetString(5);
                    abiturient.PhoneNumber = reader.GetString(6);
                    abiturient.SeriesPasport = reader.GetInt32(7);
                    abiturient.NumberPasport = reader.GetInt32(8);
                    abiturient.EGE = reader.GetString(9);
                    abiturient.ID_FirstDirection = reader.GetInt32(10);
                    abiturient.ID_SecondDirection = reader.GetInt32(11);
                    abiturient.ID_ThiredDeriction = reader.GetInt32(12);
                    user.Add(abiturient);
                    }
                    reader.Close();
                    conn.Close();
                    return user;
                
            }
        }


        public List<AbiturientSPO> GetHidenAbiturientSPO(string HidenAbiturient)
        {
            string command = "USE Canteen " + $"select* from AbiturientSPO WHERE SecondName = '{HidenAbiturient}' or FirstName = '{HidenAbiturient}' or PhoneNumber = '{HidenAbiturient}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            List<AbiturientSPO> user = new List<AbiturientSPO>();

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {

                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    AbiturientSPO abiturient = new AbiturientSPO();
                    abiturient.ID_Abiturient = reader.GetInt32(0);
                    abiturient.SecondName = reader.GetString(1);
                    abiturient.FirstName = reader.GetString(2);
                    abiturient.Patronymic = reader.GetString(3);
                    abiturient.DateOfBirth = reader.GetDateTime(4);
                    abiturient.Email = reader.GetString(5);
                    abiturient.PhoneNumber = reader.GetString(6);
                    abiturient.SeriesPasport = reader.GetInt32(7);
                    abiturient.NumberPasport = reader.GetInt32(8);
                    abiturient.FirstDirectionBall = reader.GetInt32(9);
                    abiturient.SecondDirectionBall = reader.GetInt32(10);
                    abiturient.ThiredDerictionBall = reader.GetInt32(11);
                    abiturient.ID_FirstDirection = reader.GetInt32(12);
                    abiturient.ID_SecondDirection = reader.GetInt32(13);
                    abiturient.ID_ThiredDeriction = reader.GetInt32(14);
                    user.Add(abiturient);
                }
                reader.Close();
                conn.Close();
                return user;

            }
        }


        public void AddAbiturients11(List<Abiturient11> abiturients)
        {

            foreach (Abiturient11 abiturient in abiturients)
            {
                string command = "USE Canteen " + $"EXEC [dbo].AddAbiturient11 '{abiturient.SecondName}','{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}','{abiturient.Email}', '{abiturient.PhoneNumber}', '{abiturient.SeriesPasport}', '{abiturient.NumberPasport}', '{abiturient.EGE}', '{abiturient.ID_FirstDirection}', '{abiturient.ID_SecondDirection}', '{abiturient.ID_ThiredDeriction}'";
               
                    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        SqlCommand command1 = new SqlCommand(command, conn);
                        command1.ExecuteScalar();
                        conn.Close();
                    }
                
            }
            
        
        }

        public void AddAbiturientsSPO(List<AbiturientSPO> abiturients)
        {

            foreach (AbiturientSPO abiturient in abiturients)
            {
                string command = "USE Canteen " + $"EXEC [dbo].AddAbiturient11 '{abiturient.SecondName}','{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}','{abiturient.PhoneNumber}','{abiturient.Email}', '{abiturient.SeriesPasport}' '{abiturient.NumberPasport}', '{abiturient.FirstDirectionBall}','{abiturient.SecondDirectionBall}','{abiturient.ThiredDerictionBall}', '{abiturient.ID_FirstDirection}', '{abiturient.ID_SecondDirection}', '{abiturient.ID_ThiredDeriction}'";

                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand command1 = new SqlCommand(command, conn);
                    command1.ExecuteScalar();
                    conn.Close();
                }

            }
        }



        public void AddStudentsFromAbiturients(List<Abiturient11> abiturients11, List<AbiturientSPO> abiturientsSPO, int ID_Direction, int equal)
        {
            string NumberGroup = "Не распред"; // записывается в переменную группы студента
            int NumberStudentsCanBeAccepted = GetHowStudentsCanBeInGroupByID(ID_Direction) - GetHowMuchStudentInGroup(ID_Direction); // сколько человек ещё можно принять на направление          
            int HowMuchStudentAreAccepted = 0; // колличество принятых студентов
            try
            {
                try 
                {
                    NumberStudentsCanBeAccepted = NumberStudentsCanBeAccepted / 2; // сколько человек будем брать из каждого списка абитуриентов
                }
                catch
                {
                    NumberStudentsCanBeAccepted++;
                    NumberStudentsCanBeAccepted = NumberStudentsCanBeAccepted / 2;
                }
            }
            catch
            {
                NumberStudentsCanBeAccepted++;
                NumberStudentsCanBeAccepted = NumberStudentsCanBeAccepted / 2;
            }
            int Nedded11 = 0; // 10
            int NeddedSPO = 0; 
            try
            {
                // equeal = 9
                Nedded11 = equal / 2;
                Nedded11 += Nedded11;
                if (Nedded11 == equal)
                {
                    Nedded11 = Nedded11/2;
                    NeddedSPO = Nedded11;
                }
                else
                {
                    string broke = "qweqw";
                    int Broke1 = Convert.ToInt32(broke);
                }
                
            }
            catch
            {
               
                equal++;
                Nedded11 = equal / 2;
                NeddedSPO = Nedded11 - 1;
            }
            int NumberAbiturients11CanAccepted = NumberStudentsCanBeAccepted; // сколько человек максимум возьмём из списка абитуриентов11
            int NumberAbiturientsSPOCanAccepted = NumberStudentsCanBeAccepted; // сколько человек максимум возьмём из списка абитуриентовСПО
            while (Nedded11 > 0 || NeddedSPO > 0)
            {
                foreach (Abiturient11 abiturient in abiturients11)
                {
                    if (Nedded11 != 0 && NumberAbiturients11CanAccepted > 0)
                    {
                        string command = "USE Canteen " + $"EXEC [dbo].AddStudentsFromAbiturients '{abiturient.SecondName}', '{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}', '{abiturient.PhoneNumber}', '{abiturient.Email}', {abiturient.SeriesPasport}, {abiturient.NumberPasport}, {ID_Direction}, '{NumberGroup}'";
                        using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                        {
                            conn.Open();
                            SqlCommand command1 = new SqlCommand(command, conn);
                            command1.ExecuteScalar();
                            conn.Close();
                        }
                        string command3 = "USE Canteen " + $"EXEC [dbo].DeleteAbiturient11 '{abiturient.ID_Abiturient}'";

                        using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                        {
                            conn.Open();
                            SqlCommand command1 = new SqlCommand(command3, conn);
                            command1.ExecuteScalar();
                            conn.Close();
                        }
                        NumberAbiturients11CanAccepted--;
                        Nedded11--;
                    }
                    else break;
                }

                foreach (AbiturientSPO abiturient in abiturientsSPO)
                {
                    if (NeddedSPO != 0 && NumberAbiturientsSPOCanAccepted > 0)
                    {
                        string command = "USE Canteen " + $"EXEC [dbo].AddStudentsFromAbiturients '{abiturient.SecondName}', '{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}', '{abiturient.PhoneNumber}', '{abiturient.Email}', {abiturient.SeriesPasport}, {abiturient.NumberPasport}, {ID_Direction}, '{NumberGroup}'";
                        using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                        {
                            conn.Open();
                            SqlCommand command1 = new SqlCommand(command, conn);
                            command1.ExecuteScalar();
                            conn.Close();
                        }
                        string command3 = "USE Canteen " + $"EXEC [dbo].DeleteAbiturientSPO '{abiturient.ID_Abiturient}'";

                        using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                        {
                            conn.Open();
                            SqlCommand command1 = new SqlCommand(command3, conn);
                            command1.ExecuteScalar();
                            conn.Close();
                        }
                        NumberAbiturientsSPOCanAccepted--;
                        NeddedSPO--;
                    }
                    else break;
                }

                if (NeddedSPO > 0)
                {
                    Nedded11 += NeddedSPO;
                    NeddedSPO = 0;
                }
                else if (Nedded11 > 0)
                {
                    NeddedSPO += Nedded11;
                    Nedded11 = 0;
                }

                abiturients11 = GetAbiturient11FromAccepted(ID_Direction);
                abiturients11.Sort(delegate (Abiturient11 c1, Abiturient11 c2) { return c1.EGE.CompareTo(c2.EGE); });
                abiturients11.Reverse();

                abiturientsSPO = GetAbiturientSPOFromAccepted(ID_Direction);
                abiturientsSPO.Sort(delegate (AbiturientSPO c1, AbiturientSPO c2) { return c1.SummBall.CompareTo(c2.SummBall); });
                abiturientsSPO.Reverse();


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

        public void ClearAbiturient11()
        {

            
                string command = "USE Canteen " + "TRUNCATE TABLE Abiturient11";
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand command1 = new SqlCommand(command, conn);
                    command1.ExecuteScalar();
                    conn.Close();
                }
           
        }

        public void ClearAbiturientSPO()
        {


            string command = "USE Canteen " + "TRUNCATE TABLE AbiturientSPO";
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

        public List<Abiturient11> GetAbiturient11()
        {
            string command = "USE Canteen " + "select* from Abiturient11";
            List<Abiturient11> abiturients = new List<Abiturient11>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Abiturient11 abiturient = new Abiturient11();
                    abiturient.ID_Abiturient = reader.GetInt32(0);
                    abiturient.SecondName = reader.GetString(1);
                    abiturient.FirstName = reader.GetString(2);
                    abiturient.Patronymic = reader.GetString(3);
                    abiturient.DateOfBirth = reader.GetDateTime(4);
                    abiturient.Email = reader.GetString(5);
                    abiturient.PhoneNumber = reader.GetString(6);
                    abiturient.SeriesPasport = reader.GetInt32(7);
                    abiturient.NumberPasport = reader.GetInt32(8);
                    abiturient.EGE = reader.GetString(9);
                    abiturient.ID_FirstDirection = reader.GetInt32(10);
                    abiturient.ID_SecondDirection = reader.GetInt32(11);
                    abiturient.ID_ThiredDeriction = reader.GetInt32(12);

                    abiturient.FirstDirection = GetDirectionName(abiturient.ID_FirstDirection);
                    abiturient.SecondDirection = GetDirectionName(abiturient.ID_SecondDirection);
                    abiturient.ThiredDeriction = GetDirectionName(abiturient.ID_ThiredDeriction);



                    abiturients.Add(abiturient);
                }
                reader.Close();
                conn.Close();
                return abiturients;
            }
        }
        public List<AbiturientSPO> GetAbiturientSPO()
        {
            string command = "USE Canteen " + "select* from AbiturientSPO";
            List<AbiturientSPO> abiturients = new List<AbiturientSPO>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    AbiturientSPO abiturient = new AbiturientSPO();
                    abiturient.ID_Abiturient = reader.GetInt32(0);
                    abiturient.SecondName = reader.GetString(1);
                    abiturient.FirstName = reader.GetString(2);
                    abiturient.Patronymic = reader.GetString(3);
                    abiturient.DateOfBirth = reader.GetDateTime(4);
                    abiturient.Email = reader.GetString(5);
                    abiturient.PhoneNumber = reader.GetString(6);
                    abiturient.SeriesPasport = reader.GetInt32(7);
                    abiturient.NumberPasport = reader.GetInt32(8);
                    abiturient.FirstDirectionBall = reader.GetInt32(9);
                    abiturient.SecondDirectionBall = reader.GetInt32(10);
                    abiturient.ThiredDerictionBall = reader.GetInt32(11);
                    abiturient.ID_FirstDirection = reader.GetInt32(12);
                    abiturient.ID_SecondDirection = reader.GetInt32(13);
                    abiturient.ID_ThiredDeriction = reader.GetInt32(14);

                    abiturient.FirstDirection = GetDirectionName(abiturient.ID_FirstDirection);
                    abiturient.SecondDirection = GetDirectionName(abiturient.ID_SecondDirection);
                    abiturient.ThiredDeriction = GetDirectionName(abiturient.ID_ThiredDeriction);

                    abiturient.SummBall = abiturient.FirstDirectionBall + abiturient.SecondDirectionBall + abiturient.ThiredDerictionBall;

                    abiturients.Add(abiturient);
                }
                reader.Close();
                conn.Close();
                return abiturients;
            }
        }

        public List<Abiturient11> GetAbiturient11FromAccepted(int ID_Direction)
        {
            string command = "USE Canteen " + $"select* from Abiturient11 WHERE ID_FirstDirection = {ID_Direction} or ID_SecondDirection = {ID_Direction} or ID_ThiredDirection = {ID_Direction}";
            List<Abiturient11> abiturients = new List<Abiturient11>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Abiturient11 abiturient = new Abiturient11();
                    abiturient.ID_Abiturient = reader.GetInt32(0);
                    abiturient.SecondName = reader.GetString(1);
                    abiturient.FirstName = reader.GetString(2);
                    abiturient.Patronymic = reader.GetString(3);
                    abiturient.DateOfBirth = reader.GetDateTime(4);
                    abiturient.Email = reader.GetString(5);
                    abiturient.PhoneNumber = reader.GetString(6);
                    abiturient.SeriesPasport = reader.GetInt32(7);
                    abiturient.NumberPasport = reader.GetInt32(8);
                    abiturient.EGE = reader.GetString(9);
                    abiturient.ID_FirstDirection = reader.GetInt32(10);
                    abiturient.ID_SecondDirection = reader.GetInt32(11);
                    abiturient.ID_ThiredDeriction = reader.GetInt32(12);

                    abiturient.FirstDirection = GetDirectionName(abiturient.ID_FirstDirection);
                    abiturient.SecondDirection = GetDirectionName(abiturient.ID_SecondDirection);
                    abiturient.ThiredDeriction = GetDirectionName(abiturient.ID_ThiredDeriction);



                    abiturients.Add(abiturient);
                }
                reader.Close();
                conn.Close();
                return abiturients;
            }
        }

        public List<AbiturientSPO> GetAbiturientSPOFromAccepted(int ID_Direction)
        {
            string command = "USE Canteen " + $"select* from AbiturientSPO WHERE ID_FirstDirection = {ID_Direction} or ID_SecondDirection = {ID_Direction} or ID_ThiredDirection = {ID_Direction}";
            List<AbiturientSPO> abiturients = new List<AbiturientSPO>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    AbiturientSPO abiturient = new AbiturientSPO();
                    abiturient.ID_Abiturient = reader.GetInt32(0);
                    abiturient.SecondName = reader.GetString(1);
                    abiturient.FirstName = reader.GetString(2);
                    abiturient.Patronymic = reader.GetString(3);
                    abiturient.DateOfBirth = reader.GetDateTime(4);
                    abiturient.Email = reader.GetString(5);
                    abiturient.PhoneNumber = reader.GetString(6);
                    abiturient.SeriesPasport = reader.GetInt32(7);
                    abiturient.NumberPasport = reader.GetInt32(8);
                    abiturient.FirstDirectionBall = reader.GetInt32(9);
                    abiturient.SecondDirectionBall = reader.GetInt32(10);
                    abiturient.ThiredDerictionBall = reader.GetInt32(11);
                    abiturient.ID_FirstDirection = reader.GetInt32(12);
                    abiturient.ID_SecondDirection = reader.GetInt32(13);
                    abiturient.ID_ThiredDeriction = reader.GetInt32(14);

                    abiturient.FirstDirection = GetDirectionName(abiturient.ID_FirstDirection);
                    abiturient.SecondDirection = GetDirectionName(abiturient.ID_SecondDirection);
                    abiturient.ThiredDeriction = GetDirectionName(abiturient.ID_ThiredDeriction);

                    if (abiturient.ID_FirstDirection == ID_Direction) abiturient.SummBall = abiturient.FirstDirectionBall;
                    else if (abiturient.ID_SecondDirection == ID_Direction) abiturient.SummBall = abiturient.SecondDirectionBall;
                    else if (abiturient.ID_ThiredDeriction == ID_Direction) abiturient.SummBall = abiturient.ThiredDerictionBall;

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
            List<Student> students = new List<Student>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.ID_User = reader.GetInt32(0);
                    student.SecondName = reader.GetString(1);
                    student.FirstName = reader.GetString(2);
                    student.Patronymic = reader.GetString(3);
                    student.DateOfBirth = reader.GetDateTime(4);
                    student.PhoneNumber = reader.GetString(5);
                    student.Email = reader.GetString(6);
                    student.SeriaPassport = reader.GetInt32(7);
                    student.NumberPasport = reader.GetInt32(8);
                    student.ID_Direction = reader.GetInt32(9);
                    student.GroupNumber = reader.GetString(10);

                    students.Add(student);
                }
                reader.Close();
                conn.Close();
                return students;
            }
        }


        public List<Student> GetStudent()
        {
            string command = "USE Canteen " + "select* from Students";
            List<Student> students = new List<Student>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.ID_User = reader.GetInt32(0);
                    student.SecondName = reader.GetString(1);
                    student.FirstName = reader.GetString(2);
                    student.Patronymic = reader.GetString(3);
                    student.DateOfBirth = reader.GetDateTime(4);
                    student.PhoneNumber = reader.GetString(5);
                    student.Email = reader.GetString(6);
                    student.SeriaPassport = reader.GetInt32(7);
                    student.NumberPasport = reader.GetInt32(8);
                    student.ID_Direction = reader.GetInt32(9);
                    student.GroupNumber = reader.GetString(10);

                    students.Add(student);
                }
                reader.Close();
                conn.Close();
                return students;
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

        
        public void EditAbiturientEGE(int ID_Abiturient, string  EGE)
        {
            Abiturient11 abiturient = GetAbiturient11ByID(ID_Abiturient);
            string command = "USE Canteen " + $"EXEC [dbo].EditAbiturient11 '{abiturient.SecondName}','{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}',  '{abiturient.Email}','{abiturient.PhoneNumber}', {abiturient.SeriesPasport}, {abiturient.NumberPasport}, '{EGE}', {abiturient.ID_FirstDirection}, {abiturient.ID_SecondDirection}, {abiturient.ID_ThiredDeriction}, {abiturient.ID_Abiturient}";
           
           
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(command, conn);
                command1.ExecuteScalar();
                conn.Close();
            }

        }



        public void EditAbiturientSPO(AbiturientSPO abiturient, int CompletedTest, int NumberTrueAnswer)
        {
            string command = "";
            if (CompletedTest == 1)
            {
                command = "USE Canteen " + $"EXEC [dbo].EditAbiturientSPO '{abiturient.SecondName}','{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}', '{abiturient.Email}', '{abiturient.PhoneNumber}', {abiturient.SeriesPasport}, {abiturient.NumberPasport}, {NumberTrueAnswer}, {abiturient.SecondDirectionBall}, {abiturient.ThiredDerictionBall}, {abiturient.ID_FirstDirection}, {abiturient.ID_SecondDirection}, {abiturient.ID_ThiredDeriction}, {abiturient.ID_Abiturient}";
            }
            else if (CompletedTest == 2)
            {
                command = "USE Canteen " + $"EXEC [dbo].EditAbiturientSPO'{abiturient.SecondName}','{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}', '{abiturient.Email}', '{abiturient.PhoneNumber}', {abiturient.SeriesPasport}, {abiturient.NumberPasport}, {abiturient.FirstDirectionBall}, {NumberTrueAnswer}, {abiturient.ThiredDerictionBall}, {abiturient.ID_FirstDirection}, {abiturient.ID_SecondDirection}, {abiturient.ID_ThiredDeriction}, {abiturient.ID_Abiturient}";
            }
            else if (CompletedTest == 3)
            {
                command = "USE Canteen " + $"EXEC [dbo].EditAbiturientSPO '{abiturient.SecondName}','{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}',  '{abiturient.Email}', '{abiturient.PhoneNumber}', {abiturient.SeriesPasport}, {abiturient.NumberPasport}, {abiturient.FirstDirectionBall}, {abiturient.SecondDirectionBall}, {NumberTrueAnswer}, {abiturient.ID_FirstDirection}, {abiturient.ID_SecondDirection}, {abiturient.ID_ThiredDeriction}, {abiturient.ID_Abiturient}";
            }
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(command, conn);
                command1.ExecuteScalar();
                conn.Close();
            }

        }


        public void EditAbiturient11(Abiturient11 abiturient)
        {
            string command = "USE Canteen " + $"EXEC [dbo].EditAbiturient11 '{abiturient.SecondName}','{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}',  '{abiturient.Email}', '{abiturient.PhoneNumber}', {abiturient.SeriesPasport}, {abiturient.NumberPasport}, '{abiturient.EGE}', {abiturient.ID_FirstDirection}, {abiturient.ID_SecondDirection}, {abiturient.ID_ThiredDeriction}, {abiturient.ID_Abiturient}";


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



        public int HowMuchAbiturientsWithDirectionID(int ID_Direction)
        {
            int equal = 0;
            string command = "USE Canteen " + $"select* from Abiturient11 Where ID_FirstDirection = {ID_Direction} or ID_SecondDirection = {ID_Direction} or ID_ThiredDirection = {ID_Direction}"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            
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


            string command3 = "USE Canteen " + $"select* from AbiturientSPO Where ID_FirstDirection = {ID_Direction} or ID_SecondDirection = {ID_Direction} or ID_ThiredDirection = {ID_Direction}"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command3, conn).ExecuteReader();
                while (reader.Read())
                {
                    equal++;
                }
                reader.Close();
                conn.Close();
            }
            return equal;
        }


        public int HowMuchStudentsWithDirectionID(int ID_Direction)
        {
            string command = "USE Canteen " + $"select* from Students Where ID_Direction = {ID_Direction}"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
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
            int equal = 0;
            string command = "USE Canteen " + $"select* from Abiturient11"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
           
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
            command = "USE Canteen " + $"select* from AbiturientSPO"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'

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
        public List<Student> GetStudentByDirectionID(int ID_Direction)
        {
            List<Student> students = new List<Student>();
            string command = "Use Canteen " + $"Select *from Students WHERE ID_Direction = {ID_Direction}";
            using (System.Data.SqlClient.SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.ID_User = reader.GetInt32(0);
                    student.SecondName = reader.GetString(1);
                    student.FirstName = reader.GetString(2);
                    student.Patronymic = reader.GetString(3);
                    student.DateOfBirth = reader.GetDateTime(4);
                    student.Email = reader.GetString(5);
                    student.PhoneNumber = reader.GetString(6);
                    student.SeriaPassport = reader.GetInt32(7);
                    student.NumberPasport = reader.GetInt32(8);
                    student.ID_Direction = reader.GetInt32(9);
                    student.GroupNumber = reader.GetString(10);
                    students.Add(student);

                }
                reader.Close();
                conn.Close();
                return students;
            }
        }


        public int GetHowMuchStudentInGroup(int ID_Direction)
        {
            int number = 0;
            string command = "Use Canteen " + $"Select *from Students WHERE ID_Direction = {ID_Direction}";
            using (System.Data.SqlClient.SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read() )
                {

                    number++;
                }
                reader.Close();
                conn.Close();
                return number;
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

            int ID_Test = 0;
            string command3 = "USE Canteen " + $"select* from Tests WHERE TestName = '{testName}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command3, conn).ExecuteReader();
                while (reader.Read())
                {

                    ID_Test = reader.GetInt32(0);
                    
                }
                reader.Close();
                conn.Close();
            }


            String Command4 = "use Canteen " + $"select *from Questions WHERE TestNumber = 0";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(Command4, conn).ExecuteReader();
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
                    question.IDTest = ID_Test;
                    question.QuestionType = reader.GetInt32(8);
                    EditQuestion(question);
                }
            }
            


        }

        public void DeleteEmptyQuestion()
        {
            String Command4 = "use Canteen " + $"select *from Questions WHERE TestNumber = 0";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(Command4, conn).ExecuteReader();
                while (reader.Read())
                {
                
                    int ID = reader.GetInt32(0);
                    DeleteQuestion(ID);
                }
            }
        }
        public void DeleteQuestion(int ID)
        {
            String Command = "use Canteen " + $"EXEC [dbo].DeleteQuestion {ID}";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand Command1 = new SqlCommand(Command, conn);
                Command1.ExecuteScalar();
                conn.Close();
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
        public int GetHowStudentsCanBeInGroupByID(int ID_Direction)
        {
            int number = 0;
            string command = "USE Canteen " + $"select* from Directions WHERE ID_Direction = {ID_Direction}";
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    number = reader.GetInt32(2);
                }
                reader.Close();
                conn.Close();
                return number;
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

        public void AddAbiturientSPO(AbiturientSPO abiturient)
        {
            string command = "USE Canteen " + $"EXEC [dbo].[AddAbiturientSPO] '{abiturient.SecondName}', '{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}', '{abiturient.Email}', '{abiturient.PhoneNumber}',  {abiturient.SeriesPasport}, {abiturient.NumberPasport}, {abiturient.FirstDirectionBall}, {abiturient.SecondDirectionBall}, {abiturient.ThiredDerictionBall},  {abiturient.ID_FirstDirection}, {abiturient.ID_SecondDirection}, {abiturient.ID_ThiredDeriction}";
            using (System.Data.SqlClient.SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(command, conn);
                command1.ExecuteScalar();
                conn.Close();
            }
        }

        public void AddAbiturient11(Abiturient11 abiturient)
        {
            string command = "USE Canteen " + $"EXEC [dbo].[AddAbiturient11] '{abiturient.SecondName}', '{abiturient.FirstName}', '{abiturient.Patronymic}', '{abiturient.DateOfBirth}', '{abiturient.Email}', '{abiturient.PhoneNumber}',  {abiturient.SeriesPasport}, {abiturient.NumberPasport}, '{abiturient.EGE}',  {abiturient.ID_FirstDirection}, {abiturient.ID_SecondDirection}, {abiturient.ID_ThiredDeriction}";
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
        public void EditQuestion(Question question)
        {
            string command = "USE Canteen " + $"EXEC [dbo].EditQuestion '{question.QuestionString}','{question.A}','{question.B}','{question.C}','{question.D}','{question.Answer}','{question.IDTest}','{question.QuestionType}', {question.ID_Question}"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
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
