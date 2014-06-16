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

namespace BankManage.other
{
    /// <summary>
    /// ChangeOperate.xaml 的交互逻辑
    /// </summary>
    public partial class ChangeOperate : Page
    {
        BankEntities context = new BankEntities();
        public ChangeOperate()
        {
            InitializeComponent();
        }
        //更改密码
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var query = from t in context.LoginInfo
                        where t.Bno == this.txtAccount.Text
                        select t;
            if (query.Count() > 0)
            {
                var q = query.First();
                if (q.Password == this.txtOldPass.Password)
                {
                    if (txtNewPass.Password == txtPassConf.Password && txtNewPass.Password != "")
                    {
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("更改密码成功！");
                        }
                        catch
                        {
                            MessageBox.Show("更改密码失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("新密码确认输入有误，请重新输入！");
                    }
                }
                else
                {
                    MessageBox.Show("旧密码确认不正确！");
                }
            }
            else
            {
                MessageBox.Show("不存在该用户！");
            }
        }
        //取消更改
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.txtNewPass.Clear();
            this.txtPassConf.Clear();
        }
    }
}
