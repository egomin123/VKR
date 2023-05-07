using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Classes
{
    public class Question
    {
        public int ID_Question { get; set; }
        public string QuestionString { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string Answer{ get; set; }
        public int IDTest { get; set; }
        public int QuestionType { get; set; }
        public string QuestionTypeString { get; set; }
    }
}
