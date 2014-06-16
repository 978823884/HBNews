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

namespace BankManage.employee
{
    /// <summary>
    /// ChangePay.xaml 的交互逻辑
    /// </summary>
    public partial class ChangePay : Page
    {
        private BankEntities context = new BankEntities();
        public ChangePay()
        {
            InitializeComponent();
            
            ShowResult();
        }
       
        public void ShowResult()
        {
            var q = from t in context.EmployeeInfo
                    select t;
                    
            datagrid2.ItemsSource = q.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            datagrid2.IsReadOnly = false;
            tb2.Visibility = System.Windows.Visibility.Visible;
            tb2.Text = "已进入可修改状态！";
           
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                datagrid2.IsReadOnly = true;
                context.SaveChanges();
                MessageBox.Show("保存成功！");
				
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "保存失败!");
            }

            tb2.Visibility = System.Windows.Visibility.Hidden;

        }

        
    }
}
