using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Classes
{
    public class Property
    {
        public string Increment { get; set; }

        private string name;
        public string Name
        {
            get
            {
                return Increment + " " + name;
            }
            set
            {
                name = value;
            }
        }


        public string GetNameWithoutIncrement
        {
            get
            {
                return name;
            }
        }
    }
}

