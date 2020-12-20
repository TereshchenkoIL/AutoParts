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
    class Response : INotifyPropertyChanged
    {
        private string name;
        private int id;
        private int part;
        private string date;
        private double rate;
        private string text;

        public Response(DataRow row)
        {
            var d = (DateTime)row["Create_Date"];
            name = (string)row["Name"];
            id = (int)row["Response_Id"];
            part = (int)row["Part_Id"];
            date = d.Day.ToString() + "." + d.Month.ToString() + "." + d.Year.ToString();
            rate = (double)row["Rate"];
            text = (string)row["Text"];

        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public int Part
        {
            get
            {
                return part;
            }
            set
            {
                part = value;
                OnPropertyChanged("Part");
            }
        }
        public string Date
        {
            get
            {
                return date;
            }
           
        }

        public double Rate
        {
            get
            {
                return rate;
            }
            set
            {
                rate = value;
                OnPropertyChanged("Rate");
            }
        }
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged("Text");
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
