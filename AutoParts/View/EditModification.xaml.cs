using AutoParts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Логика взаимодействия для EditModification.xaml
    /// </summary>
    public partial class EditModification : Window
    {
        private bool Edit;
        private int Id;
        int car;
        int engine;
        public EditModification()
        {
            InitializeComponent();
            manager = new DBManager();
            Prepare();
    
        }
        public EditModification(int id)
        {
            InitializeComponent();
            manager = new DBManager();
            DataRow row = manager.Select("SELECT m.Modif_Id,  m.Name, M.Car_Id,m.Complect, M.Drive_type," +
                "CONCAT(e.Name,' ', e.Power, 'лс.  ', e.Volume, 'л. ') AS Engine," +
                " CONCAT(c.Mark,' ', c.Model, ' ',c.Year) AS Car, e.Engine_Id " +
                "FROM Engines e INNER JOIN Modifications m ON e.Engine_Id = M.Engine_Id " +
                $"INNER JOIN CARS c ON m.Car_Id = c.Car_Id WHERE m.Modif_Id = {id} ").Tables[0].Rows[0];
            Name = (string)row["Name"];
            Complect = (string)row["Complect"];
            Type = (string)row["Drive_Type"];
            Id = (int)row["Modif_Id"];
            car = (int)row["Car_Id"];
            engine = (int)row["Engine_Id"];
            Prepare();
           
            Edit = true;
        }

        public void Prepare()
        {
            string sql = "SELECT CONCAT(c.Mark,' ', c.Model, ' ',c.Year) AS Car, c.Car_Id FROM CARS c; ";

            DataTable table = manager.Select(sql).Tables[0];
            CarBox.ItemsSource = table.DefaultView;
            CarBox.DisplayMemberPath = "Car";
            CarBox.SelectedValuePath = "Car_Id";
            Show_Car(table);
            sql = "SELECT CONCAT(e.Name,' ', e.Power, 'лс.  ', e.Volume, 'л. ') AS Engine, e.Engine_Id FROM ENGINES E; ";
            table = manager.Select(sql).Tables[0];
            EngineBox.ItemsSource = table.DefaultView;
            EngineBox.DisplayMemberPath = "Engine";
            EngineBox.SelectedValuePath = "Engine_Id";
            Show_Engine(table);
        }
        public string Name
        {
            get
            {
                return (string)GetValue(NameProperty);
            }
            set
            {
                SetValue(NameProperty, value);
            }
        }
        public string Complect
        {
            get
            {
                return (string)GetValue(ComplectProperty);
            }
            set
            {
                SetValue(ComplectProperty, value);
            }
        }

       public string Type
        {
            get
            {
                return (string)GetValue(TypeProperty);
            }
            set
            {
                SetValue(TypeProperty, value);
            }
        }





        private DBManager manager;
       
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(EditModification), new PropertyMetadata("test"));
        public static readonly DependencyProperty ComplectProperty =
           DependencyProperty.Register("Complect", typeof(string), typeof(EditModification), new PropertyMetadata("test"));
        public static readonly DependencyProperty TypeProperty =
      DependencyProperty.Register("Type", typeof(string), typeof(EditModification), new PropertyMetadata("test"));


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Edit)
                manager.Update_Modification(Id, Name, Complect, Type, (int)CarBox.SelectedValue, (int)EngineBox.SelectedValue);
            else
                manager.Add_Modification(Name, Complect, Type, (int)CarBox.SelectedValue, (int)EngineBox.SelectedValue);
            MessageBox.Show("Операцію виконано успішно");
            Close();

        }
        private void Show_Car(DataTable cars)
        {
            int index = -1;
            for (int i = 0; i < cars.Rows.Count; i++)
            {
                if (cars.Rows[i].Field<int>("Car_Id") == car)
                    CarBox.SelectedIndex = i;
            }
        }
        private void Show_Engine(DataTable engines)
        {
            int index = -1;
            for (int i = 0; i < engines.Rows.Count; i++)
            {
                if (engines.Rows[i].Field<int>("Engine_Id") == engine)
                    EngineBox.SelectedIndex = i;
            }
        }
    }
}
