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

namespace CCTech
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customer> Clist = new List<Customer>();
        public MainWindow()
        {
            InitializeComponent();

        }
            private void add_button_Click(object sender, RoutedEventArgs e)
            {

                Customer customer = new Customer(name.Text, phone.Text, DateTime.Parse(leaveTime.Text), int.Parse(currentPrecentage.Text));
                Clist.Add(customer);
                foreach (Customer customer1 in Clist)
                {
                customer1.CalcPriority();
                }
            }

            private void name_TextChanged(object sender, TextChangedEventArgs e)
            {

            }

            private void currentPrecentage_TextChanged(object sender, TextChangedEventArgs e)
            {

            }
        }
    
}
