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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Taxi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string typeCar;
        int passNumber;
        public MainWindow()
        {
            InitializeComponent();
            passNumber = 1;
            passNumTexBlock.Text = passNumber.ToString();            
        }

        private void order_Click(object sender, RoutedEventArgs e)
        {
            string order = "Your order: ";            

            order += nameTexBox.Text + " " + surnameTexBox.Text + "\n" +
                "To: " + addressTexBox.Text + "\n" +
                passNumTexBlock.Text + " passengers\n" +
                "Type: " + typeCar + "\n";

            MessageBox.Show(order, "Order", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void acceptCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameTexBox.Text) || string.IsNullOrEmpty(surnameTexBox.Text) ||
                string.IsNullOrEmpty(addressTexBox.Text))
            {              
                MessageBox.Show("Enter empty fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                acceptCheckBox.IsChecked = false;
                return;
            }

            orderButton.IsEnabled = true;
        }

        private void acceptCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            orderButton.IsEnabled = false;
        }
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            typeCar = $"{((RadioButton)sender).Content}";
        }

        private void canselButton_Click(object sender, RoutedEventArgs e)
        {
            nameTexBox.Clear();
            surnameTexBox.Clear();
            addressTexBox.Clear();
            passNumber = 1;
            passNumTexBlock.Text = passNumber.ToString();
            acceptCheckBox.IsChecked = false;

            ((RadioButton)stackPanelType.Children[0]).IsChecked = true;
        }

        private void numberRepeatButton_Click(object sender, RoutedEventArgs e)
        {           
            if (passNumber == 8)
                passNumber = 0;

            passNumber++;
            passNumTexBlock.Text = passNumber.ToString();
        }
    }
}
