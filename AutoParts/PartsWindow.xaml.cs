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

namespace AutoParts
{
    /// <summary>
    /// Логика взаимодействия для PartsWindow.xaml
    /// </summary>
    public partial class PartsWindow : Window
    {

        private DataTable table;
        private SqlDataAdapter adapter;
        private SqlConnection connection;
        private EnumerableRowCollection<DataRow> filtered;
        private DataTable types;
        private SqlDataAdapter type_adapter;
        public bool IsFiltered;
       private bool ASC;
        public int type_id;
        public PartsWindow()
        {
            InitializeComponent();

            table = new DataTable();

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Autoparts"].ConnectionString);

            connection.Open();
            string select_types = "Select * FROM Pr_Types";
            types = new DataTable();
            string sql = "Select * FROM Parts";
            adapter = new SqlDataAdapter(sql, connection);
            adapter.DeleteCommand = new SqlCommand("sp_DeletePart", connection);
            adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
            adapter.DeleteCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "Part_Id"));
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            type_adapter = new SqlDataAdapter(select_types, connection);
            type_adapter.Fill(types);
            adapter.Fill(table);
            Grid.ItemsSource = table.DefaultView;

            TypeBox.ItemsSource = types.DefaultView;
            TypeBox.DisplayMemberPath = "Name";
            TypeBox.SelectedValuePath = "Type_Id";
            type_id = -1;
            connection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedIndex == -1) return;
            int id;
            connection.Open();

            if(!IsFiltered)
             id = table.Rows[Grid.SelectedIndex].Field<int>("Part_Id");
            else
             id = filtered.CopyToDataTable().Rows[Grid.SelectedIndex].Field<int>("Part_Id");

            
            adapter.DeleteCommand.Parameters["@id"].Value = id;
            adapter.DeleteCommand.ExecuteNonQuery();
            table.Clear();
            adapter.Fill(table);
            IsFiltered = false;
            Grid.ItemsSource = table.DefaultView;
            connection.Close();
        }




        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            
            EditPart ed = new EditPart();
            ed.ShowDialog();
           
            connection.Open();
            table.Clear();
            adapter.Fill(table);
            IsFiltered = false;
            Grid.ItemsSource = table.DefaultView;
            connection.Close();
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return;
            DataRow row;
            if (IsFiltered)
                row = filtered.ElementAt(index);
            else
               row = table.Rows[index];

            EditPart ed = new EditPart(row);
            ed.ShowDialog();
            table.Clear();
            adapter.Fill(table);
            IsFiltered = false;
            Grid.ItemsSource = table.DefaultView;
        }



        private void Filter_Button_Click(object sender, RoutedEventArgs e)
        {
            filtered = table.AsEnumerable();

            IsFiltered = true;

            if (From_Price.Text != "" && To_Price.Text != "")
                filtered = filtered.Where(x => x.Field<decimal>("Price") > decimal.Parse(From_Price.Text) && x.Field<decimal>("Price") < decimal.Parse(To_Price.Text));
            if (Name_box.Text != "")
                filtered = filtered.Where(x => x.Field<string>("Name") == Name_box.Text);
            if (Warrantbox.Text != "")
                filtered = filtered.Where(x => x.Field<int>("Warranty") == int.Parse(Warrantbox.Text));
            if (ProducerBox.Text != "")
            {
                filtered = filtered.Where(x => x.Field<string>("Producer_Name") != null && x.Field<string>("Producer_Name").ToLower() == ProducerBox.Text.ToLower());
            }
            if (Is_Type_Filtered.IsChecked == true && type_id != -1)
                filtered = filtered.Where(x => x.Field<int>("Type_Id") == type_id);
            if (filtered.Count() != 0)
                Grid.ItemsSource = filtered.CopyToDataTable().DefaultView;
            else
                MessageBox.Show("Відповідня деталь відсутня");
        }



        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Grid.Items.Count; i++)
            {
               
                    var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                if(row != null)
                    row.Background = Brushes.White;
                
            }
            DataTable temp;
            if (IsFiltered)
                  temp = filtered.CopyToDataTable();      
            else
                 temp =((DataView) Grid.ItemsSource).Table;            


            if (AllFields.IsChecked == true)
            {
                Paint(temp, "Name");               
                Paint(temp, "Descript");      
                Paint(temp, "Producer_Name");               
                int num = 0;
                bool isNumber = int.TryParse(SearchBox.Text, out num);
                if (!isNumber) return;
              

            }
            else
            {

                if (ByName.IsChecked == true)
                {
                    Paint(temp, "Name");            
                }
                if (ByDesc.IsChecked == true)
                {
                    Paint(temp, "Descript");
                   
                }
                if (ByProd.IsChecked == true)
                {
                    Paint(temp, "Producer_Name");                   
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

               switch(field)
                {
                    case "Ціні":
                        if(ASC)
                        temp.Sort = "Price ASC";
                        else
                            temp.Sort = "Price DESC";
                        break;
                    case "Гарантії":
                        if(ASC)
                        temp.Sort = "Warranty ASC";
                        else
                            temp.Sort = "Warranty DESC";
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

       

       public void Type_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            type_id = (int)TypeBox.SelectedValue;
            //MessageBox.Show(type_id.ToString());
        }

        private void Report_Button_Click(object sender, RoutedEventArgs e)
        {

            int part = SelectedPart();
            Reports r = new Reports(false, part);
            r.ShowDialog();
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

        public int SelectedPart()
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return -1;
            int part = -1;
            if (IsFiltered)
                part = filtered.ElementAt(index).Field<int>("Part_Id");
            else
                part = (int)table.Rows[index]["Part_Id"];
            return part;
        }
    }
}
