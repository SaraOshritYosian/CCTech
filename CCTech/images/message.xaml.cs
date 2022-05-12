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

namespace CCTech.images
{
    /// <summary>
    /// Interaction logic for message.xaml
    /// </summary>
    public partial class message : Window
    {
        
        public message()
        {
            InitializeComponent();
        
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            message1.Visibility = Visibility.Hidden;
            number1.IsEnabled = false;
           number1.Visibility = Visibility.Hidden;
            scan.Visibility = Visibility.Visible;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
