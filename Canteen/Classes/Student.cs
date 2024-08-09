using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Classes
{
    public class Student
    {
        public int ID_User { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int SeriaPassport { get; set; }
        public int NumberPasport { get; set; }
        public int ID_Direction { get; set; }
        public string GroupNumber { get; set; }
    }
}
