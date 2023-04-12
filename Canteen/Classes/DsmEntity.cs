using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Canteen.Classes
{
    public class DsmEntity
    {
        public string Object { get; set; }
        private string status;
        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                if (value != null)
                {
                    status = value;
                }
                else
                    MessageBox.Show("Статус может иметь только значения ?+-0, а получил значение: '" + value.ToString() + "'", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
    }
}

