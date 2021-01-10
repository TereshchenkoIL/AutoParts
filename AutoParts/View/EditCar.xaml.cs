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
    /// Логика взаимодействия для EditCar.xaml
    /// </summary>
    public partial class EditCar : Window
    {
        private int Car_Id;
        private string type;
        public EditCar()
        {
            InitializeComponent();
            manager = new DBManager();
            TypeBox.ItemsSource = manager.Select("SELECT DISTINCT Type FROM Cars").Tables[0].DefaultView;
            TypeBox.DisplayMemberPath = "Type";
            TypeBox.SelectedValuePath = "Type";
            Edit = false;
        }
        public EditCar(int car_id)
        {
            InitializeComponent();
            manager = new DBManager();
            Car_Id = car_id;
            DataRow row = manager.Select($"SELECT * FROM Cars WHERE Car_Id = {Car_Id}").Tables[0].Rows[0];
            Mark = (string)row["Mark"];
            Model = (string)row["Model"];
            Year = ((int)row["Year"]).ToString();
            var types = manager.Select("SELECT DISTINCT Type FROM Cars").Tables[0];
            TypeBox.ItemsSource = types.DefaultView;
            TypeBox.DisplayMemberPath = "Type";
            TypeBox.SelectedValuePath = "Type";
            int index = types.AsEnumerable().Select((car, i) => new { car, i }).First(car => (string)car.car["Type"] == (string)row["Type"]).i;
            TypeBox.SelectedIndex = index;
            Edit = true;
            type = (string)row["Type"];
        }

        public string Mark
        {
            get
            {
                return (string)GetValue(MarkProperty);
            }
            set
            {
                SetValue(MarkProperty, value);
            }
        }
        public string Model
        {
            get
            {
                return (string)GetValue(ModelProperty);
            }
            set
            {
                SetValue(ModelProperty, value);
            }
        }
        public string Year
        {
            get
            {
                return (string)GetValue(YearProperty);
            }
            set
            {
                SetValue(YearProperty, value);
            }
        }

        public string Type { get; set; }

      
        private DBManager manager;
        private bool Edit;
        public static readonly DependencyProperty MarkProperty =
            DependencyProperty.Register("Mark", typeof(string), typeof(EditCar), new PropertyMetadata("test"));
        public static readonly DependencyProperty ModelProperty =
           DependencyProperty.Register("Model", typeof(string), typeof(EditCar), new PropertyMetadata("test"));
        public static readonly DependencyProperty YearProperty =
         DependencyProperty.Register("Year", typeof(string), typeof(EditCar), new PropertyMetadata("test"));


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Edit)
                manager.Update_Car(Car_Id, Mark, Model, type, int.Parse(Year));
            else
                manager.Add_Car(Mark, Model, type, int.Parse(Year));
            MessageBox.Show("Операцію виконано успішно");
            Close();

        }

        private void TypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            type = (string)TypeBox.SelectedValue;
        }
    }
}
