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
using BankManage.common;

namespace BankManage.money
{
    /// <summary>
    /// transferaccounts.xaml 的交互逻辑
    /// </summary>
    public partial class transferaccounts : Page
    {
        public transferaccounts()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Custom custom = DataOperation.GetCustom(this.txtAccount.Text);
            if (custom == null)
            {
                MessageBox.Show("账号不存在！");
            }
            else
            {
                if (custom.AccountInfo.accountPass != this.txtPassword.Password)
                {
                    MessageBox.Show("密码不正确");
                    return;
                }
                else
                {
                    Custom transfercustom1 = DataOperation.GetCustom(this.transmount.Text);
                    if (transfercustom1==null)
                    {
                        MessageBox.Show("收款人账号不存在！");
                    }
                    else
                    {
                        if ( Convert.ToInt32(this.txtmount.Text)<0 ||Convert.ToInt32(this.txtmount.Text)>1000000||this.txtmount.Text=="")
                        {
                            MessageBox.Show("转账金额不能小于0且单笔转账不能大于100万！");
                            
                            
                        }
                        else
                        {
                            if (double.Parse(this.txtmount.Text) > custom.AccountBalance)
                            {
                                MessageBox.Show("余额不足，转账失败！");
                            }
                            else
                            {
                                double money = Convert.ToInt32(this.txtmount.Text);
                                custom.AccountBalance-= money;
                                transfercustom1.AccountBalance += money;
                                MessageBox.Show("转账成功");

                            }
                        }

                    }
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            chushihua page = new chushihua();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);
        }
    }
}
