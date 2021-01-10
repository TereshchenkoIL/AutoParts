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
    /// Логика взаимодействия для DiscountsWindow.xaml
    /// </summary>
    public partial class DiscountsWindow : Window
    {
        DataTable table;
        DBManager manager;
        private EnumerableRowCollection<DataRow> filtered;
        bool IsFiltered;
        private bool ASC;
        
        public DiscountsWindow()
        {
            InitializeComponent();
            manager = new DBManager();
            table = manager.Select("SELECT * FROM Discounts").Tables[0];
            Grid.ItemsSource = table.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = GetName();
            if (name == "") return;
            manager.Delete_Disc(name);
            IsFiltered = false;
            table = manager.Select("SELECT * FROM Discounts").Tables[0];
            Grid.ItemsSource = table.DefaultView;

        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            EditDiscount ed = new EditDiscount();
            ed.ShowDialog();
            IsFiltered = false;
            table = manager.Select("SELECT * FROM Discounts").Tables[0];
            Grid.ItemsSource = table.DefaultView;
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return ;
            DataRow row;
            if (IsFiltered)
                row = filtered.ElementAt(index);
            else
                row = table.Rows[index];

            EditDiscount ed = new EditDiscount(row);
            ed.ShowDialog();
            IsFiltered = false;
            table = manager.Select("SELECT * FROM Discounts").Tables[0];
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

                Paint(temp, "Discount_Name");
                Paint(temp, "Descript");
                int num = 0;
                bool isNumber = int.TryParse(SearchBox.Text, out num);
                if (!isNumber) return;
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    if (temp.Rows[i].Field<int>("Disc") == num)
                    {
                        var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                        if (row != null)
                            row.Background = Brushes.Green;
                    }
                }

            }
            else
            {

                if (ByName.IsChecked == true)
                    Paint(temp, "Discount_Name");
                if (ByDesc.IsChecked == true)
                    Paint(temp, "Descript");              
            }
        }

        private void Filter_Button_Click(object sender, RoutedEventArgs e)
        {
            filtered = table.AsEnumerable();

            IsFiltered = true;
            if (From_Disc.Text != "" && To_Disc.Text != "")
                filtered = filtered.Where(x => x.Field<int>("Disc") > int.Parse(From_Disc.Text) && x.Field<int>("Disc") < int.Parse(To_Disc.Text));
            if (NameBox.Text != "")
                filtered = filtered.Where(x => x.Field<string>("Discount_Name").ToLower() == NameBox.Text.ToLower());
            if (DescBox.Text != "")
                filtered = filtered.Where(x => x.Field<string>("Descript").ToLower() == DescBox.Text.ToLower());

            if (filtered.Count() != 0)
                Grid.ItemsSource = filtered.CopyToDataTable().DefaultView;
            else
                MessageBox.Show("Відповідньої знижки не знайшлося");
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
                        temp.Sort = "Discount_Name ASC";
                    else
                        temp.Sort = "Discount_Name DESC";
                    break;
                case "По знижці":
                    if (ASC)
                        temp.Sort = "Disc ASC";
                    else
                        temp.Sort = "Disc DESC";
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

        public string GetName()
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return "";
            string name = "";
            if (IsFiltered)
                name = filtered.ElementAt(index).Field<string>("Discount_Name");
            else
                name = (string)table.Rows[index]["Discount_Name"];
            return name;
        }

    }
}
