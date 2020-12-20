using AutoParts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoParts.ViewModel 
{
    class ResponsesViewModel 
    {
        private DBManager manager;
       
        
        public ObservableCollection<Response> Responses { get; set; }

        public ResponsesViewModel(int part_id)
        {
            manager = new DBManager();
            Responses = new ObservableCollection<Response>();
            DataTable dt = manager.GetReviews(part_id).Tables[0];
            
            foreach(DataRow row in dt.Rows)
            {
                Responses.Add(new Response(row));
            }
           
        }

        public double AVG
        {
            get
            {
                return (double)Responses.Sum(x => x.Rate) / Responses.Count;
            }
        }
       
    }
}
