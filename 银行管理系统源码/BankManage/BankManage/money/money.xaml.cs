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

namespace BankManage.money
{
    /// <summary>
    /// money.xaml 的交互逻辑
    /// </summary>
    public partial class money : Page
    {
        public money()
        {
            InitializeComponent();
          
            
        }

      

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Navigate(new Uri("money/NewAccount.xaml", UriKind.Relative));

        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Navigate(new Uri("money/Deposit.xaml",UriKind.Relative));
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Navigate(new Uri("money/Withdraw.xaml",UriKind.Relative));
        }

      
     
    }
}
