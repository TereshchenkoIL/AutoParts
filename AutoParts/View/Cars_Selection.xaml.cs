using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data;
using AutoParts.Model;

namespace AutoParts.View
{
    /// <summary>
    /// Логика взаимодействия для Cars_Selection.xaml
    /// </summary>
    public partial class Cars_Selection : Window
    {

        private DataTable table;
        private DataTable cars;
        private DataTable modification;
        private EnumerableRowCollection<DataRow> filtered;
        private DataTable types;  
        private bool IsFiltered;
        private bool ASC;
        private int type_id;
        private DBManager manager;
        private Basket basket;
        private readonly int User;
        private PartPicker picker = new PartPicker();
        private Car car;
     
        public Cars_Selection()
        {
            InitializeComponent();
            table = new DataTable();
            manager = new DBManager();
            types = manager.GetTypes().Tables[0];
            table = manager.GetParts().Tables[0];      
            Grid.ItemsSource = table.DefaultView;
            TypeBox.ItemsSource = types.DefaultView;
            TypeBox.DisplayMemberPath = "Name";
            TypeBox.SelectedValuePath = "Type_Id";
            type_id = -1;
            basket = new Basket();
            PrepareCarsMenu();
            User = 1;
        }

        public Cars_Selection(int id)
        {
            InitializeComponent();
            table = new DataTable();
            manager = new DBManager();
            types = manager.GetTypes().Tables[0];
            table = manager.GetParts().Tables[0];
            Grid.ItemsSource = table.DefaultView;
            TypeBox.ItemsSource = types.DefaultView;
            TypeBox.DisplayMemberPath = "Name";
            TypeBox.SelectedValuePath = "Type_Id";
            type_id = -1;
            basket = new Basket();
            User = id;
            PrepareCarsMenu();
            //MessageBox.Show(User.ToString());

        }
        private void Filter_Button_Click(object sender, RoutedEventArgs e)
        {
            filtered = table.AsEnumerable();

            IsFiltered = true;

            if (From_Price.Text != "" && To_Price.Text != "")
                filtered = filtered.Where(x => x.Field<decimal>("Price") > decimal.Parse(From_Price.Text) && x.Field<decimal>("Price") < decimal.Parse(To_Price.Text));
            if (Name_box.Text != "")
                filtered = filtered.Where(x => x.Field<string>("Name").ToLower() == Name_box.Text.ToLower());
            if (Warrantbox.Text != "")
                filtered = filtered.Where(x => x.Field<int>("Гарантія") == int.Parse(Warrantbox.Text));
            if (ProducerBox.Text != "")
            {
                filtered = filtered.Where(x => x.Field<string>("Producer_Name") != null && x.Field<string>("Producer_Name").ToLower() == ProducerBox.Text.ToLower());
            }
            if (Is_Type_Filtered.IsChecked == true && type_id != -1)
                filtered = filtered.Where(x => x.Field<string>("Тип") == types.AsEnumerable().Where(y => (int)y["Type_Id"] == type_id).Select(z => (string)z["Name"]).ToList()[0]);
            if (From_Rate.Text != "" && To_Rate.Text != "")
                filtered = filtered.Where(x => x.Field<double?>("Середня оцінка") != null && x.Field<double>("Середня оцінка") > double.Parse(From_Rate.Text) && x.Field<double>("Середня оцінка") < double.Parse(To_Rate.Text));
            if (filtered.Count() != 0)
                Grid.ItemsSource = filtered.CopyToDataTable().DefaultView;
            else
                MessageBox.Show("Відповідна деталь відсутня");
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
                    
                    Paint(temp, "Producer_Name");

                int num = 0;
                    bool isNumber = int.TryParse(SearchBox.Text, out num);
                    if (!isNumber) return;
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        if (temp.Rows[i].Field<int>("Гарантія") == num)
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
                         Paint(temp, "Name");                                   
                    if (ByProd.IsChecked == true)
                          Paint(temp, "Producer_Name");
                    if (ByType.IsChecked == true)
                          Paint(temp, "Тип");
                    if (ByСar.IsChecked == true)
                          Paint(temp, "Car");

                }
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

        private void Report_Button_Click(object sender, RoutedEventArgs e)
        {
                int part= SelectedPart();
                Reports r = new Reports(false, part);
                r.ShowDialog();           
        }

        private void Info_Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return;
            int id = -1;
            if (IsFiltered)
            {
                id = filtered.ToList()[index].Field<int>("Part_Id");
            } else
                id = (int)table.Rows[index]["Part_Id"];
            if (id == -1) return;
            EditPart ep = new EditPart(id);
            ep.ShowDialog();
        }
        public void Type_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            type_id = (int)TypeBox.SelectedValue;
           // MessageBox.Show(type_id.ToString());
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
                case "Ціні":
                    if (ASC)
                        temp.Sort = "Price ASC";
                    else
                        temp.Sort = "Price DESC";
                    break;
                case "Гарантії":
                    if (ASC)
                        temp.Sort = "Гарантія ASC";
                    else
                        temp.Sort = "Гарантія DESC";
                    break;
                case "По рейтингу":
                    if (ASC)
                        temp.Sort = "Середня оцінка ASC";
                    else
                        temp.Sort = "Середня оцінка DESC";
                    break;

                case "Кількості оцінок":
                    if (ASC)
                        temp.Sort = "Кількість оцінок ASC";
                    else
                        temp.Sort = "Кількість оцінок DESC";
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

        private void AddBusket_Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return;
            if (IsFiltered)
            {             
                if (!basket.Contains(filtered.ElementAt(index)))
                    basket.Add(filtered.ElementAt(index));
            }
            else
            {
                if (!basket.Contains(table.Rows[index]))
                    basket.Add(table.Rows[index]);
            }
            MessageBox.Show("Товар успішно додано");
        }

        private void Basket_Button_Click(object sender, RoutedEventArgs e)
        {
            BasketWindow bw = new BasketWindow(basket,User);
            bw.ShowDialog();

        }

        private void EndFilter_Click(object sender, RoutedEventArgs e)
        {
            IsFiltered = false;
            Grid.ItemsSource = table.DefaultView;
        }

        private void AddReview_Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return;
            int part = -1;
            if (IsFiltered)
                part = filtered.ElementAt(index).Field<int>("Part_Id");
            else
                part = (int)table.Rows[index]["Part_Id"];

            ReviewAddWindow raw = new ReviewAddWindow(User, part);
            raw.ShowDialog();
        }

        private void ViewReview_Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return;
            int part = -1;
            if (IsFiltered)
                part = filtered.ElementAt(index).Field<int>("Part_Id");
            else
                part = (int)table.Rows[index]["Part_Id"];

            ResponseViewWindow rvw = new ResponseViewWindow(part);
            rvw.ShowDialog();

        }

        private void Pick_Item_Click(object sender, RoutedEventArgs e)
        {
            List<int> res;

            res = picker.Pick(new SelectPartArgs(car.Id, type_id, car.Engine));
          

         
            
            IsFiltered = true;
            filtered = table.AsEnumerable();
            filtered = filtered.Where(x => res.Contains((int)x["Part_Id"]));
            if (filtered.Count() != 0)
                Grid.ItemsSource = filtered.CopyToDataTable().DefaultView;
            else
                MessageBox.Show("Деталі не знайдено");
        }

        private void PrepareCarsMenu()
        {
            cars = manager.GetCars().Tables[0];
            car = new Car();
            var marks = manager.Select("SELECT DISTINCT Mark FROM Cars").Tables[0];
            MarkBox.ItemsSource = marks.DefaultView;
            MarkBox.DisplayMemberPath = "Mark";
            MarkBox.SelectedValuePath = "Mark";
            YearBox.IsEnabled = false;
            YearBox.SelectedItem = null;
            ModelBox.SelectedItem = null;
            ModelBox.IsEnabled = false;

            Type_SelectBox.ItemsSource = types.DefaultView;
            Type_SelectBox.DisplayMemberPath = "Name";
            Type_SelectBox.SelectedValuePath = "Type_Id";

        }

        private void MarkBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
          
            car.Mark = (string)combo.SelectedValue;
            YearBox.ItemsSource = cars.AsEnumerable().Where(x => (string)x["Mark"] == car.Mark.Trim()).CopyToDataTable().DefaultView;
            YearBox.IsEnabled = true;
            YearBox.DisplayMemberPath = "Year";
            YearBox.SelectedValuePath = "Year";
            Modif.IsEnabled = false;
            Modif.SelectedItem = null;
            ModelBox.SelectedItem = null;
            ModelBox.IsEnabled = false;
        }

        private void YearBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            if (combo.SelectedValue == null) return;
            car.Year = (int)combo.SelectedValue;
            ModelBox.ItemsSource = cars.AsEnumerable().Where(x => (string)x["Mark"] == car.Mark && (int)x["Year"] == car.Year).CopyToDataTable().DefaultView;
            ModelBox.IsEnabled = true;
            ModelBox.DisplayMemberPath = "Model";
            ModelBox.SelectedValuePath = "Model";
             
            
        }

        private void Modif_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var combo = (ComboBox)sender;
            if (combo.SelectedValue == null) return;
            car.Engine = (int)combo.SelectedValue;

        }

        private void ModelBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            if (combo.SelectedValue == null) return;
            car.Model = (string)combo.SelectedValue;
            Modif.IsEnabled = true;
            car.Id = cars.AsEnumerable().Where(x => (string)x["Mark"] == car.Mark && (int)x["Year"] == car.Year && (string)x["Model"] == car.Model).First().Field<int>("Car_Id");
            

            modification = manager.GetModifications(car.Id).Tables[0];
            Modif.ItemsSource = modification.DefaultView;
            Modif.DisplayMemberPath = "ModName";
            Modif.SelectedValuePath = "Engine_Id";
            Modif.IsEnabled = true;
        }

        private void Type_SelectBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            type_id = (int)Type_SelectBox.SelectedValue;
           
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
