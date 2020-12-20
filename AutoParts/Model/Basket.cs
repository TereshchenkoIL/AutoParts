using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace AutoParts.Model
{
    public class Basket : INotifyPropertyChanged
    {
        private ObservableCollection<BasketElement> elements;
        public Basket(ObservableCollection<BasketElement> list)
        {
            elements = list;
        }
        public Basket()
        {
            elements = new ObservableCollection<BasketElement>();
        }
        public void Add(BasketElement el)
        {
            elements.Add(el);
        }
        public void Add(DataRow row)
        {
            elements.Add(new BasketElement(row));
        }
        public bool Remove(BasketElement el)
        {
            return elements.Remove(el);
        }
        public bool Remove(DataRow row)
        {
            return elements.Remove(new BasketElement(row));
        }
        
        public bool Contains(DataRow row)
        {
            return elements.Contains(new BasketElement(row));
        }
        public decimal SumTotal()
        {
            decimal sum = 0;
            foreach(var i in elements)
            {
                sum += i.Price * i.Quantity;
            }
            return sum;
        }
        public ObservableCollection<BasketElement> Elements
        {
            get
            {
                return elements;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
