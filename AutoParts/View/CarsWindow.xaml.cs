using AutoParts.Model;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для CarsWindow.xaml
    /// </summary>
    public partial class CarsWindow : Window
    {
        private DataTable table;
        private EnumerableRowCollection<DataRow> filtered;
        public bool IsFiltered;
        private bool ASC;
        private DBManager manager;
        string type = "";
        public CarsWindow()
        {
            InitializeComponent();
            manager = new DBManager();
            table = manager.Select("SELECT * FROM Cars").Tables[0];
            Grid.ItemsSource = table.DefaultView;
            TypeBox.ItemsSource = manager.Select("SELECT DISTINCT Type FROM Cars").Tables[0].DefaultView;
            TypeBox.DisplayMemberPath = "Type";
            TypeBox.SelectedValuePath = "Type";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return;
            var temp = table;
            if (IsFiltered) temp = filtered.CopyToDataTable();

            manager.Delete_Car((int)temp.Rows[index]["Car_Id"]);
            table = manager.Select("SELECT * FROM Cars").Tables[0];
            IsFiltered = false;
            Grid.ItemsSource = table.DefaultView;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            EditCar ed = new EditCar();
            ed.ShowDialog();
            table = manager.Select("SELECT * FROM Cars").Tables[0];
            IsFiltered = false;
            Grid.ItemsSource = table.DefaultView;
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return;
            var temp = table;
            if (IsFiltered) temp = filtered.CopyToDataTable();
           

            EditCar ed = new EditCar((int)temp.Rows[index]["Car_Id"]);
            ed.ShowDialog();
            table = manager.Select("SELECT * FROM Cars").Tables[0];
            IsFiltered = false;
            Grid.ItemsSource = table.DefaultView;
        }

      

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Grid.Items.Count; i++)
            {

                var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                if (row != null)
                    row.Background = Brushes.White;

            }
            DataTable temp;
            if (IsFiltered)
                temp = filtered.CopyToDataTable();
            else
                temp = ((DataView)Grid.ItemsSource).Table;


            if (AllFields.IsChecked == true)
            {
                Paint(temp, "Mark");
                Paint(temp, "Model");
                Paint(temp, "Type");
                int num = 0;
                bool isNumber = int.TryParse(SearchBox.Text, out num);
                if (!isNumber) return;

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    if (temp.Rows[i].Field<int>("Year").ToString().ToLower().Contains(SearchBox.Text.ToLower()))
                    {
                        var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                        row.Background = Brushes.Purple;
                    }
                }

            }
            else
            {

                if (ByMark.IsChecked == true)
                {
                    Paint(temp, "Mark");
                }
                if (ByModel.IsChecked == true)
                {
                    Paint(temp, "Model");
                }
                if (ByYear.IsChecked == true)
                {
                    int num;
                    bool isNumber = int.TryParse(SearchBox.Text, out num);
                    if (!isNumber) return;

                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        if (temp.Rows[i].Field<int>("Year").ToString().ToLower().Contains(SearchBox.Text.ToLower()))
                        {
                            var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                            row.Background = Brushes.Purple;
                        }
                    }
                }
                if (ByType.IsChecked == true)
                {
                    Paint(temp, "Type");
                }
            }
        }

        private void Filter_Button_Click(object sender, RoutedEventArgs e)
        {
            filtered = table.AsEnumerable();

            IsFiltered = true;

            if (MarkBox.Text != "" )         
                filtered = filtered.Where(x => x.Field<string>("Mark") == MarkBox.Text);
            if (YearBox.Text != "")
                filtered = filtered.Where(x => x.Field<int>("Year") == int.Parse(YearBox.Text));
            if (ModelBox.Text != "")
                filtered = filtered.Where(x => x.Field<string>("Model") == ModelBox.Text);
            if (Is_Type_Filtered.IsChecked == true && type != "")
                filtered = filtered.Where(x => x.Field<string>("Type") == type);
            if (filtered.Count() != 0)
                Grid.ItemsSource = filtered.CopyToDataTable().DefaultView;
            else
                MessageBox.Show("Відповідного авто не знайшлось");
        }

        private void Dsc_Click(object sender, RoutedEventArgs e)
        {
            ASC = false;
            Asc.BorderBrush = Brushes.Transparent;
            Dsc.BorderBrush = Brushes.Black;
        }

        private void ASC_Click(object sender, RoutedEventArgs e)
        {
            ASC = true;
            Asc.BorderBrush = Brushes.Black;
            Dsc.BorderBrush = Brushes.Transparent;
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string field = Sort.SelectedValue.ToString().Substring(37).Trim();
            DataView temp;


            if (IsFiltered)
            {
                temp = filtered.CopyToDataTable().DefaultView;
            }
            else
                temp = table.DefaultView;

            switch (field)
            {
                case "Маркою":
                    if (ASC)
                        temp.Sort = "Mark ASC";
                    else
                        temp.Sort = "Mark DESC";
                    break;
                case "Моделлю":
                    if (ASC)
                        temp.Sort = "Model ASC";
                    else
                        temp.Sort = "Model DESC";
                    break;
                case "Роком":
                    if (ASC)
                        temp.Sort = "Year ASC";
                    else
                        temp.Sort = "Year DESC";
                    break;
                case "Типом":
                    if (ASC)
                        temp.Sort = "Type ASC";
                    else
                        temp.Sort = "Type DESC";
                    break;

            }


            Grid.ItemsSource = temp;
        }

        private void Type_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            type = (string)TypeBox.SelectedValue;
        }
        public void Paint(DataTable temp, string column)
        {
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                if (temp.Rows[i].Field<string>(column).ToLower().Contains(SearchBox.Text.ToLower()))
                {
                    var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                    row.Background = Brushes.Purple;
                }
            }
        }

    }
}
