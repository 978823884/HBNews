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
    /// EmployeeBase.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeBase : Page
    {
        
        private BankEntities context = new BankEntities();
        public EmployeeBase()
        {
            InitializeComponent();
            this.Unloaded += EmployeeBase_Unloaded;
            ShowResult();
        }

        void EmployeeBase_Unloaded(object sender, RoutedEventArgs e)
        {
            context.Dispose();
        }

       
        public void ShowResult() 
        {
            using (BankEntities c = new BankEntities())
            {
                var q = from t in c.EmployeeInfo
                        select t;
                datagrid1.ItemsSource = q.ToList(); 
            }
           
        }
       
       
        private void Button_Click(object sender, RoutedEventArgs e)//修改
        {
            datagrid1.IsReadOnly = false;
            datagrid1.CanUserAddRows = false;
            tb1.Visibility = System.Windows.Visibility.Visible ;
            tb1.Text = "已进入可修改状态！";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//添加
        {
            datagrid1.IsReadOnly = false;
            datagrid1.CanUserAddRows = true;
            tb1.Visibility = System.Windows.Visibility.Visible;
            tb1.Text = "已进入可添加状态！";
        }
       
        private void Button_Click_1(object sender, RoutedEventArgs e)//删除
        {
            var item = datagrid1.SelectedItem as EmployeeInfo;

                var q = from t in context.EmployeeInfo
                        where t.EmployeeNo == item.EmployeeNo
                        select t;
                try
                {
                    foreach (var v in q)
                    {
                        context.EmployeeInfo.Remove(v);
                    }
                    var m = MessageBox.Show("是否删除？","警告",MessageBoxButton.YesNo);
                    if (m==MessageBoxResult.Yes)
                    {
                    context.SaveChanges();
                    ShowResult();  
                    MessageBox.Show("已成功删除!");
                    }
                }
                catch
                {
                    MessageBox.Show("请选择删除项!");
                }
                 
        }

        
        private void Button_Click_3(object sender, RoutedEventArgs e)//保存
        {
            if (datagrid1.CanUserAddRows == true)
            {
                try
                {
                    var item = datagrid1.SelectedItem as EmployeeInfo;

                    EmployeeInfo employeeInfo = new EmployeeInfo()
                    {
                        EmployeeNo = item.EmployeeNo,
                        EmployeeName = item.EmployeeName,
                        sex = item.sex,
                        position = item.position,
                        workDate = item.workDate,
                        Psalary = item.Psalary,
                        Nsalary = item.Nsalary,
                        telphone = item.telphone,
                        idCard = item.idCard,
                        photo = item.photo
                    };

                    context.EmployeeInfo.Add(employeeInfo);
                    context.SaveChanges();
                    MessageBox.Show("添加成功！");
                   
                    //ShowResult(); 
                }
                catch (Exception )
                {
                    MessageBox.Show("未添加任何信息！", "警告");
                }
                finally
                {
                    datagrid1.IsReadOnly = true;
                    datagrid1.CanUserAddRows = false;
                }

            }

            else if (datagrid1.IsReadOnly == false && datagrid1.CanUserAddRows == false)
            {
                try
                {
                    context.SaveChanges();
                    ShowResult();
                    MessageBox.Show("修改成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "修改失败！");
                }
                finally
                {
                    datagrid1.IsReadOnly = true;
                    datagrid1.CanUserAddRows = false;
                }

            }
            else
            {
                MessageBox.Show("未进行任何修改或添加操作！","警告");
            }
            tb1.Visibility=System.Windows.Visibility.Hidden;
    
        }

        private void importPB_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog o = new Microsoft.Win32.OpenFileDialog();
            if (o.ShowDialog()==true)
            {
                System.IO.Stream myStream = o.OpenFile();
                byte[] bt = new byte[myStream.Length];
                myStream.Read(bt,0,(int)myStream.Length);

                var item = datagrid1.SelectedItem as EmployeeInfo;
                var q = from t in context.EmployeeInfo
                        where t.EmployeeNo == item.EmployeeNo
                        select t;
                try
                {
                    var q1 = q.FirstOrDefault();
                    if (q1!=null)
                    {
                        q1.photo = bt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   
                }
            }
        }

       

        

       
    }
}
