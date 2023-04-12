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
        public List<Student> StudentsOnGroup(double HowMuchGroup)
        {
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



        public List<Abiturient> GetHidenAbiturient(string HidenAbiturient)
        {
            string command = "USE Canteen " + $"select* from Abiturient WHERE SecondName = '{HidenAbiturient}' or FirstName = '{HidenAbiturient}' or Patronymic = '{HidenAbiturient}' or Email = '{HidenAbiturient}' or PhoneNumber = '{HidenAbiturient}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
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

    }
}
