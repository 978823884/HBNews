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

namespace BankManage.query
{
    /// <summary>
    /// TotalQuery.xaml 的交互逻辑
    /// </summary>
    public partial class TotalQuery : Page
    {
        BankEntities context = new BankEntities();
        public TotalQuery()
        {
            InitializeComponent();
            this.Unloaded += TotalQuery_Unloaded;
        }

        void TotalQuery_Unloaded(object sender, RoutedEventArgs e)
        {
            context.Dispose();
        }
        //查询当前账号的所有记录信息
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var query = from t in context.MoneyInfo
                        from q in context.AccountInfo
                        //where q.IdCard == txtID.Text
                        //select q;
                        where q.IdCard == txtID.Text && t.accountNo == q.accountNo
                        select new
                        {
                             accountName = q.accountName,

                             IdCard = q.IdCard,
                             accountNo = q.accountNo,
                             dealType = t.dealType,
                             balance = t.balance


                        };
            
            if (query.Count()==0||txtID.Text.Equals("")||txtID.Text==null)
            {
                MessageBox.Show("此账户不存在或输入为空");
            }
            else
                datagrid1.ItemsSource = query.ToList();
        }
    }
}
