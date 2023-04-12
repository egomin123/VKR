using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Classes
{
    // Конструктор модели пользвователя
    public class User
    {
        public int ID_User { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public int Role_ID { get; set; }
        public string Role { get; set; }

        public User()
        {

        }
        public User(string login, int role_ID, int id_User, string email)
        {
            Login = login;
            Role_ID = role_ID;
            ID_User = id_User;
            Email = email;

        }
    }
}
