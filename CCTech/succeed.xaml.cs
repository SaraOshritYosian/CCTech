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
    /// Interaction logic for succeed.xaml
    /// </summary>
    public partial class succeed : Window
    {
        public succeed()
        {
            InitializeComponent();
        }

        private void x_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
