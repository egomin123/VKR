using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Classes
{
    public static class Model
    {
        public static ObservableCollection<Property> Properties = new ObservableCollection<Property>(); // LBProperty
        public static ObservableCollection<DsmEntity> Entities = new ObservableCollection<DsmEntity>(); // DGCalculated
        public static StringBuilder Otchet = new StringBuilder();
        public static int XPos { get; set; }
        public static int XNeg { get; set; }
    }
}
