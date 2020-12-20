using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.Model
{
    public class BasketElement : INotifyPropertyChanged
    {
        private int part;
        private int quantity;
        private decimal price;
        private string name;
        public BasketElement(DataRow row)
        {
            part = (int)row["Part_Id"];           
            price = (decimal)row["Price"];
            name = (string)row["Name"];
            quantity = 1;
        }
        public int Part_Id { get { return part; } set {
                part = value;
                OnPropertyChanged("Part_Id");
            }
        }
        public int Quantity { get { return quantity; } set {
                quantity = value;
                OnPropertyChanged("Quantity");
            }
        }
        public decimal Price { get { return price; } set {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public string Name { get { return name; } set {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public override bool Equals(object obj)
        {
            BasketElement o = (BasketElement)obj;
            if (Part_Id == o.Part_Id && Quantity == o.Quantity && Price == o.Price)
                return true;
            return false;
        }
    }
}
