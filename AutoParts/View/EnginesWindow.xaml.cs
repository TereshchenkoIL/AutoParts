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
    /// Логика взаимодействия для EnginesWindow.xaml
    /// </summary>
    public partial class EnginesWindow : Window
    {
        private DataTable table;
        private EnumerableRowCollection<DataRow> filtered;
        private DBManager manager;
        private bool IsFiltered;
        private bool ASC;
        public EnginesWindow()
        {
            InitializeComponent();
            manager = new DBManager();
            table = manager.Select("SELECT * FROM Engines").Tables[0];
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
                    Paint(temp, "Name");

                    PaintInt(temp, "Power");

                    PaintDouble(temp, "Volume");

                    Paint(temp, "Type");
            }
            else
            {

                if (ByName.IsChecked == true)
                    Paint(temp, "Name");
                if (ByPower.IsChecked == true)
                    PaintInt(temp, "Power");
                if (ByVolume.IsChecked == true)
                    PaintDouble(temp, "Volume");
                if (ByType.IsChecked == true)
                    Paint(temp, "Type");
            }
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
        public void PaintInt(DataTable temp, string column)
        {
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                if (temp.Rows[i].Field<int>(column).ToString().ToLower().Contains(SearchBox.Text.ToLower()))
                {
                    var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                    row.Background = Brushes.Purple;
                }
            }
        }
        public void PaintDouble(DataTable temp, string column)
        {
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                if (temp.Rows[i].Field<double>(column).ToString().ToLower().Contains(SearchBox.Text.ToLower()))
                {
                    var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                    row.Background = Brushes.Purple;
                }
            }
        }

        private void Filter_Button_Click(object sender, RoutedEventArgs e)
        {
            filtered = table.AsEnumerable();
            IsFiltered = true;

            if (NameBox.Text != "")
                filtered = filtered.Where(x => ((string)x["Name"]).Contains(NameBox.Text));
            if (PowerBox.Text != "")
                filtered = filtered.Where(x => ((int)x["Power"]).ToString().Contains(PowerBox.Text));
            if (VolumeBox.Text != "")
                filtered = filtered.Where(x => ((double)x["Volume"]).ToString().Contains(VolumeBox.Text));
            if (TypeBox.Text != "")
                filtered = filtered.Where(x => ((string)x["Type"]).Contains(TypeBox.Text));
            if (filtered.Count() != 0)
                Grid.ItemsSource = filtered.CopyToDataTable().DefaultView;
            else
                MessageBox.Show("Відповідного двигуна не знайшлося");
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
                case "По назві":
                    if (ASC)
                        temp.Sort = "Name ASC";
                    else
                        temp.Sort = "Name DESC";
                    break;
                case "За потужністю":
                    if (ASC)
                        temp.Sort = "Power ASC";
                    else
                        temp.Sort = "Power DESC";
                    break;
                case "За об'ємом":
                    if (ASC)
                        temp.Sort = "Volume ASC";
                    else
                        temp.Sort = "Volume DESC";
                    break; 
            }

            if (IsFiltered)
            {
                filtered = temp.ToTable().AsEnumerable();
            }
            else
                table = temp.ToTable();
            Grid.ItemsSource = temp;
        }
        private void ASC_Click(object sender, RoutedEventArgs e)
        {
            ASC = true;
            Asc.BorderBrush = Brushes.Black;
            Dsc.BorderBrush = Brushes.Transparent;
        }

        private void Dsc_Click(object sender, RoutedEventArgs e)
        {
            ASC = false;
            Asc.BorderBrush = Brushes.Transparent;
            Dsc.BorderBrush = Brushes.Black;
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return;
            DataTable temp;
            //MessageBox.Show(index.ToString());
            if (IsFiltered) temp = filtered.CopyToDataTable();
            else temp = table;

            EditEngine ee = new EditEngine((int)temp.Rows[index]["Engine_Id"]);
            ee.ShowDialog();
            table = manager.Select("SELECT * FROM Engines").Tables[0];
            IsFiltered = false;
            Grid.ItemsSource = table.DefaultView;

        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            EditEngine ee = new EditEngine();
            ee.ShowDialog();
            table = manager.Select("SELECT * FROM Engines").Tables[0];
            IsFiltered = false;
            Grid.ItemsSource = table.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return;
            DataTable temp;

            if (IsFiltered) temp = filtered.CopyToDataTable();
            else temp = table;

            manager.Delete_Engine((int)temp.Rows[index]["Engine_Id"]);

            table = manager.Select("SELECT * FROM Engines").Tables[0];
            IsFiltered = false;
            Grid.ItemsSource = table.DefaultView;
        }
    }
}
