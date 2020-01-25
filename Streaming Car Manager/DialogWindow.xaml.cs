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

namespace BaseOfCarsRemadeVersion
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public AbstractCar car = null;  

        public DialogWindow()
        {
            InitializeComponent();
        }                        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            int speedValue = 0;
            try
            {
                speedValue = Convert.ToInt32(SpeedTextbox.Text);
            }
            catch (Exception)
            {
                this.car = new TruckCar(OwnerTextbox.Text, ModelTextbox.Text, ColorTextbox.Text, SpeedTextbox.Text);
                MessageBox.Show("TruckCar object is created!");
                return;
            }
           
            if (speedValue > 200)
            {
                this.car = new SportCar(OwnerTextbox.Text, ModelTextbox.Text, ColorTextbox.Text, SpeedTextbox.Text);
                MessageBox.Show("SportCar object is created!");
            }
            else
            {
                this.car = new TruckCar(OwnerTextbox.Text, ModelTextbox.Text, ColorTextbox.Text, SpeedTextbox.Text);
                MessageBox.Show("TruckCar object is created!");
            }
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
