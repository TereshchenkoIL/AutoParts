using AutoParts.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutoParts.View
{
    /// <summary>
    /// Логика взаимодействия для ResponseViewWindow.xaml
    /// </summary>
    public partial class ResponseViewWindow : Window
    {
        public ResponseViewWindow()
        {
         
            InitializeComponent();
            var resp = new ResponsesViewModel(1);
            DataContext = resp;
        }
        public ResponseViewWindow(int part)
        {
            
            InitializeComponent();
            var resp = new ResponsesViewModel(part);
            DataContext = resp ;
            List.ItemsSource = resp.Responses;
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

       
    }
}
