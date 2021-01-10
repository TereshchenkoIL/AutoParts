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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AutoParts.Model;

namespace AutoParts.View
{
    /// <summary>
    /// Логика взаимодействия для ProducersWindow.xaml
    /// </summary>
    public partial class ProducersWindow : Window
    {
        private DataTable table;
        private EnumerableRowCollection<DataRow> filtered;
        private DBManager manager;
        private bool IsFiltered;
        private bool ASC;
        public ProducersWindow()
        {
            InitializeComponent();
            manager = new DBManager();
            table = manager.Select("SELECT * FROM Producers").Tables[0];
            Grid.ItemsSource = table.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return;
            string name;

            if (IsFiltered)
                name = (string)filtered.CopyToDataTable().Rows[index]["Producer_Name"];
            else
                name = (string)table.Rows[index]["Producer_Name"];

            manager.Delete_Producer(name);
            table = manager.Select("SELECT * FROM Producers").Tables[0];
            IsFiltered = false;
            Grid.ItemsSource = table.DefaultView;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            EditProducer ep = new EditProducer();
            ep.ShowDialog();
            table = manager.Select("SELECT * FROM Producers").Tables[0];
            IsFiltered = false;
            Grid.ItemsSource = table.DefaultView;
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return;
            string name;

            if (IsFiltered)
                name = (string)filtered.CopyToDataTable().Rows[index]["Producer_Name"];
            else
                name = (string)table.Rows[index]["Producer_Name"];

                EditProducer ep = new EditProducer(name);
            ep.ShowDialog();
            table = manager.Select("SELECT * FROM Producers").Tables[0];
            IsFiltered = false;
            Grid.ItemsSource = table.DefaultView;
        }

        private void Filter_Button_Click(object sender, RoutedEventArgs e)
        {
            filtered = table.AsEnumerable();
            IsFiltered = true;

            if (NameBox.Text != "")
                filtered = filtered.Where(x => ((string)x["Producer_Name"]).Contains(NameBox.Text));
            if (DescBox.Text != "")
                filtered = filtered.Where(x => x.Field<string>("Descript") != null && ((string)x["Descript"]).Contains(DescBox.Text));
            if (YearBox.Text != "")
                filtered = filtered.Where(x => ((int)x["Year"]).ToString().Contains(YearBox.Text));
            if (filtered.Count() != 0)
                Grid.ItemsSource = filtered.CopyToDataTable().DefaultView;
            else
                MessageBox.Show("Відповідного виробника не знайдено");

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
                        temp.Sort = "Producer_Name ASC";
                    else
                        temp.Sort = "Producer_Name DESC";
                    break;
                case "По року заснування":
                    if (ASC)
                        temp.Sort = "Year ASC";
                    else
                        temp.Sort = "Year DESC";
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
                Paint(temp, "Producer_Name");
                Paint(temp, "Descript");
                PaintInt(temp, "Year");
            }
            else
            {

                if (ByName.IsChecked == true)
                    Paint(temp, "Producer_Name");
                if (ByDesc.IsChecked == true)
                    Paint(temp, "Descript");
                if (ByYear.IsChecked == true)
                    PaintInt(temp, "Year");
            }
        }

        public void Paint(DataTable temp, string column)
        {
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                if (temp.Rows[i].Field<string>(column) != null && temp.Rows[i].Field<string>(column).ToLower().Contains(SearchBox.Text.ToLower()))
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
    }
}
