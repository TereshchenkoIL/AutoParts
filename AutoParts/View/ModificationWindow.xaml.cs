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
    /// Логика взаимодействия для ModificationWindow.xaml
    /// </summary>
    public partial class ModificationWindow : Window
    {
        private DataTable table;
        private EnumerableRowCollection<DataRow> filtered;
        private DBManager manager;
        private bool IsFiltered;
        private bool ASC;
        public ModificationWindow()
        {
            InitializeComponent();
            manager = new DBManager();
            table = manager.GetModifications().Tables[0];
            string sql = "SELECT CONCAT(c.Mark,' ', c.Model, ' ',c.Year) AS Car FROM CARS C; ";
            CarBox.ItemsSource = manager.Select(sql).Tables[0].DefaultView;
            CarBox.DisplayMemberPath = "Car";
            CarBox.SelectedValuePath = "Car";
            sql = "SELECT CONCAT(e.Name,' ', e.Power, 'лс.  ', e.Volume, 'л. ') AS Engine FROM ENGINES E; ";
            EngineBox.ItemsSource = manager.Select(sql).Tables[0].DefaultView;
            EngineBox.DisplayMemberPath = "Engine";
            EngineBox.SelectedValuePath = "Engine";
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

                    Paint(temp, "Complect");

                    Paint(temp, "Engine");

                    Paint(temp, "Car");

                    Paint(temp, "Drive_type");
            }
            else
            {

                if (ByName.IsChecked == true)
                    Paint(temp, "Name");
                if (ByComplect.IsChecked == true)
                    Paint(temp, "Complect");
                if (ByEngine.IsChecked == true)
                    Paint(temp, "Engine");
                if (ByCar.IsChecked == true)
                    Paint(temp, "Car");
                if (ByType.IsChecked == true)
                    Paint(temp, "Drive_type");
            }
        }

        private void Filter_Button_Click(object sender, RoutedEventArgs e)
        {
            filtered = table.AsEnumerable();
            IsFiltered = true;

            if (NameBox.Text != "")
                filtered = filtered.Where(x => ((string)x["Name"]).Contains(NameBox.Text));
            if (ComplectcBox.Text != "")
                filtered = filtered.Where(x => ((string)x["Complect"]).Contains(ComplectcBox.Text));
            if (EngineBox.Text != "")
                filtered = filtered.Where(x => ((string)x["Engine"]).ToString().Contains(EngineBox.Text));
            string car = (string)CarBox.SelectedValue;
            if(car != null)
                filtered = filtered.Where(x => ((string)x["Car"]).ToString().Contains(car));
            if (TypeBox.Text != "")
                filtered = filtered.Where(x => ((string)x["Drive_type"]).ToString().Contains(TypeBox.Text));
            if (filtered.Count() != 0)
                Grid.ItemsSource = filtered.CopyToDataTable().DefaultView;
            else
                MessageBox.Show("Відповідньої модифікації не знайшлося");
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
                        temp.Sort = " Name DESC";
                    break;
                case "По комплектації":
                    if (ASC)
                        temp.Sort = "Complect ASC";
                    else
                        temp.Sort = "Complect DESC";
                    break;
                case "По двигуну":
                    if (ASC)
                        temp.Sort = "Engine ASC";
                    else
                        temp.Sort = "Engine DESC";
                    break;
                case "По автомобілі":
                    if (ASC)
                        temp.Sort = "Car ASC";
                    else
                        temp.Sort = "Car DESC";
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return;
            DataTable temp;

            if (IsFiltered) temp = filtered.CopyToDataTable();
            else temp = table;

            manager.Delete_Modification((int)temp.Rows[index]["Modif_Id"]);
            table = manager.GetModifications().Tables[0];
            IsFiltered = false;
            Grid.ItemsSource = table.DefaultView;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            EditModification em = new EditModification();
            em.ShowDialog();
            table = manager.GetModifications().Tables[0];
            IsFiltered = false;
            Grid.ItemsSource = table.DefaultView;
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return;
            DataTable temp;

            if (IsFiltered) temp = filtered.CopyToDataTable();
            else temp = table;

            EditModification em = new EditModification((int)temp.Rows[index]["Modif_Id"]);
            em.ShowDialog();
            table = manager.GetModifications().Tables[0];
            IsFiltered = false;
            Grid.ItemsSource = table.DefaultView;
        }

        private void Cast_Button_Click(object sender, RoutedEventArgs e)
        {
            IsFiltered = false;
            Grid.ItemsSource = table.DefaultView;
            CarBox.SelectedIndex = -1;
            EngineBox.SelectedIndex = -1;
        }
    }
}
