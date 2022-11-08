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
    /// Interaction logic for barcode.xaml
    /// </summary>
    public partial class barcode : Window
    {
        public barcode()
        {
            InitializeComponent();
            anstext.Visibility = Visibility.Visible;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Convert.ToInt32(anstext.Text)==1)
            {
                //this.Close();
                MainWindow m = new MainWindow();
                m.Show();
            }
            else
            {
                n.Visibility = Visibility.Visible;
                
            }
            
        }

        private void x_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
