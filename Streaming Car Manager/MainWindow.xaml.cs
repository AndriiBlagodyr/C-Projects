using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaseOfCarsRemadeVersion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CarManager manager = null;

        List<AbstractCar> findList = null;

        public MainWindow()
        {
            InitializeComponent();
             manager = new CarManager();

            // Update DataGrid 
            UpdateGrid(manager.GetCollection());
        }

        private void UpdateGrid(List<AbstractCar> avto)
        {
            if (avto != null)
            {
                //  DataTable Creation
                var table = new DataTable("CarsBase");

                //  DataColumn objects
                var owner = new DataColumn("Owner");
                var model = new DataColumn("Model");
                var color = new DataColumn("Color");
                var speed = new DataColumn("Speed");

                // Add DataColumn objects in DataTable
                table.Columns.Add(owner);
                table.Columns.Add(model);
                table.Columns.Add(color);
                table.Columns.Add(speed);

                // Rows for each cars' object
                foreach (var car in avto)
                {
                    DataRow row = table.NewRow();
                    row["Owner"] = car.owner;
                    row["Model"] = car.model;
                    row["Color"] = car.color;
                    row["Speed"] = car.speed;
                    table.Rows.Add(row);
                }

                DataGrid.ColumnWidth = 107.5;
                DataGrid.ItemsSource = table.DefaultView;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DialogWindow window = new DialogWindow();

            if (window.ShowDialog() == true)
            {
                manager.AddCar(window.car);

                UpdateGrid(manager.GetCollection());
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int i = DataGrid.SelectedIndex;
            if ((manager.GetCollection().Count > 0 & i == -1) || (i ==  manager.GetCollection().Count) )
            {
                MessageBox.Show("Select the row with cars to delete it, please!");
            }
            else if (manager.GetCollection().Count > 0 & i >= 0)
            {
                manager.GetCollection().RemoveAt(i);
                UpdateGrid(manager.GetCollection());
            }
            else
            {
                MessageBox.Show("You can't delete rows from empty base!");
            }

        }

        private void FinderButton_Click(object sender, RoutedEventArgs e)
        {
            string pattern = (string)TextBox.Text.Trim();
            // Regex for the finder
            var regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            findList = new List<AbstractCar>();

            foreach (var item in manager.GetCollection())
            {
                if (regex.IsMatch((string)item.owner) | regex.IsMatch((string)item.model) | regex.IsMatch((string)item.color) | regex.IsMatch((string)item.speed))
                {
                    findList.Add(item);
                }
            }

            UpdateGrid(findList);
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text = null;
            UpdateGrid(manager.GetCollection());
        }

        private void DeleteAllCarsMenu_Click(object sender, RoutedEventArgs e)
        {
            UpdateGrid(manager.GetCollection());
        }

        private void SaveCarsFileMenu_Click(object sender, RoutedEventArgs e)
        {
            manager.SaveFile();
        }

        private void OpenCarsFileMenu_Click(object sender, RoutedEventArgs e)
        {
            manager.OpenFile();
            UpdateGrid(manager.GetCollection());
        }

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            Application.Close();
        }
    }
}
