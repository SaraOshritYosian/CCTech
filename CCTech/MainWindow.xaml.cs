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
        //List<Customer> Clist = new List<Customer>();
        //StandsCharging[] standsChargings = new StandsCharging[10];
        Customer[] customers = new Customer[6];
        StandsCharging[] standsChargings = new StandsCharging[4];//ארבעה עמדות טעינה

        public MainWindow()
        {
            InitializeComponent();
            //for (int i = 0; i < 10; i++)
            //{
            //    Clist[i] = null;
            //}
            for (int i = 0; i < 4; i++)
            {
                standsChargings[i] = new StandsCharging();
            }
            customers[0] = new Customer("Naama", "0549707818", 13, DateTime.Now);
            customers[0].isInCharge = true;
            standsChargings[0].available = false;
            customers[1] = new Customer("Sara", "0556678288", 24, DateTime.Now);
            customers[1].isInCharge = true;
            standsChargings[1].available = false;
            customers[2] = new Customer("Yaeli", "054568655", 18, DateTime.Now);
            customers[2].isInCharge = true;
            standsChargings[2].available = false;

        }
        //public int possibblePrecents(Customer c)
        //{

        //}
        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            //while(true)
            //{ 
            Customer customer = new Customer(nameTextbox.Text, phoneTextbox.Text, Convert.ToInt32(currentBTextbox.Text), Convert.ToDateTime(hourTextbox.Text));//?
            customers[Customer.nuberOfCustomers - 1] = customer;                                                                                                                                               //customers[Customer.nuberOfCustomers - 1] = customer;
            if (Customer.mekademOmes < 1)
            {
                barcode b = new barcode();
                b.ShowDialog();
                //b.Close();

            }
            else
            {


                //for(int y=0; y<Customer.nuberOfCustomers-1; y++)
                //{
                //    customers[y].CalcPriority();
                //}
                if (Customer.mekademOmes < 1)
                {
                    int i, j;
                    for (i = 1; i < Customer.nuberOfCustomers - 1; i++)
                    {
                        Customer tmp = new Customer(customers[i].GetName(), customers[i].GetCellphoneNumber(), customers[i].GetCurrentPercentage(), customers[i].getExitTime());
                        tmp.isInCharge = customers[i].isInCharge;
                        for (j = i; j > 0 && tmp.Priority < customers[j - 1].Priority; j--)
                        {
                            customers[j].SetName(customers[j - 1].GetName());
                            customers[j].SetCellphoneNumber(customers[j - 1].GetCellphoneNumber());
                            customers[j].SetCurrentPercentage(customers[j - 1].GetCurrentPercentage());
                            customers[j].setExitTime(customers[j - 1].getExitTime());
                            customers[j].isInCharge = customers[j - 1].isInCharge;
                        }
                        customers[j].SetName(tmp.GetName());
                        customers[j].SetCellphoneNumber(tmp.GetCellphoneNumber());
                        customers[j].SetCurrentPercentage(tmp.GetCurrentPercentage());
                        customers[j].setExitTime(tmp.getExitTime());
                        customers[j].isInCharge = tmp.isInCharge;
                    }
                }
                for (int g = 0; g < StandsCharging.numberOfStands - 1; g++)
                {
                    if (standsChargings[g].available)
                    {
                        customers[0].isInCharge = true;
                        standsChargings[g].available = false;
                        for (int x = 0; x < Customer.nuberOfCustomers - 1; x++)
                        {
                            customers[x] = customers[x + 1];
                            Customer.nuberOfCustomers--;
                            Customer.mekademOmes = StandsCharging.numberOfStands / Customer.nuberOfCustomers;
                        }
                    }
                }
                //for (int z = 0; z < Customer.nuberOfCustomers - 1; z++)
                //{
                //    customers[z].checkIfFinishCharge();
                //}
                //foreach (var customer1 in customers)
                //{
                //    {
                //        foreach (StandsCharging stand in standsChargings)
                //        {
                //            if (stand.GetAvailable())
                //            {
                //                stand.SetAvailable(false);
                //                customer1.checkIfFinishCharge(/*customer1.RaundedHefreshHours()*/);
                //                break;
                //            }
                //        }
                //    }
                //}
                succeed s = new succeed();
                s.ShowDialog();
                //}
            }
        }

        private void x_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void torprint_Click(object sender, RoutedEventArgs e)
        {
            //for(int i=0; i<Customer.nuberOfCustomers;i++)
            //{
            lableshow.Visibility = Visibility.Visible;
            lable1.Content = customers[0].ToString();

            //lable2.Content = Clist.ElementAt(0).ToString();
            //lable3.Content = Clist.ElementAt(1).ToString();
            //lable4.Content = Clist.ElementAt(2).ToString();
            //lable5.Content = Clist.ElementAt(3).ToString();
            //lable6.Content = Clist.ElementAt(4).ToString();
            lable2.Content = customers[1].ToString();
            lable3.Content = customers[2].ToString();
            if (customers[3]!=null)
            {
                lable4.Content = customers[3].ToString();
            }
            if (customers[4] != null)
            {
                lable5.Content = customers[4].ToString();
            }
            if (customers[5] != null)
            {
                lable6.Content = customers[5].ToString();
            }



            //}
        }
    }
}
