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
using BankManage;
using BankManage.common;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace BankManage
{
    /// <summary>
    /// LoginForm.xaml 的交互逻辑
    /// </summary>
    public partial class LoginForm : Window
    {
        public static String loginNo;
        public string UserName { get; set; }
        private BankEntities dbEntity = new BankEntities();
        public LoginForm()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            UserName = string.Empty;
            this.MouseDown += LoginForm_MouseDown;
           
			
        }

        void LoginForm_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        
	
		
 
		
        //单击登录时进行身份验证
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textbox1.Text=="普通职员登录")
            {
                
           
            var query = from t in dbEntity.LoginInfo
                        where t.Bno == this.combox.Text && t.Password == this.pass.Password
                        select t;
            if (query.Count() > 0)
            {
                var q = query.First();
                UserName = DataOperation.GetOperateName(q.Bno);
               
                this.Close();
                
            }
            else
            {
                MessageBox.Show("登录失败！");
                this.pass.Clear();
                this.pass.Focus();
            }
            }
            if (textbox1.Text=="管理员登录")
            {
                var query = from t in dbEntity.Admin
                            where t.Id == this.combox.Text && t.adminPass== this.pass.Password
                            select t;
                if (query.Count() > 0)
                {
                    var q = query.First();
                    UserName = DataOperation.GetAdminName(q.Id);

                    this.Hide();
                    AdminForm admin = new AdminForm();
                    admin.ShowDialog();

                }
                else
                {
                    MessageBox.Show("登录失败！");
                    this.pass.Clear();
                    this.pass.Focus();
                }
                

                
            }

        }
        //关闭窗体
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //窗体关闭时进行关闭操作
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.UserName) == true)
            {
                App.Current.Shutdown();
            }
        }
        //将账户表中的账号信息显示到此处
        private void Window_SourceInitialized_1(object sender, EventArgs e)
        {
           


                var query = from t in dbEntity.LoginInfo
                            select t.Bno;
                this.combox.ItemsSource = query.ToList();
                

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            Button btn = e.Source as Button;
            loginNo = null;
            if (btn.Content.ToString()=="普通职员登录")
            {
                textbox1.Text = "普通职员登录";
                button1.Content = "管理员登录";
                grid1.Background = new ImageBrush
                {

                    ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/login.jpg"))
                };
               
                
                var query = from t in dbEntity.LoginInfo
                            select t.Bno;
                this.combox.ItemsSource = query.ToList();
               
               
             
            }
            else
            {
                textbox1.Text = "管理员登录";
                button1.Content = "普通职员登录";
                grid1.Background = new ImageBrush
                {

                    ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/admin.jpg"))
                };
                
                
                var query = from t in dbEntity.Admin
                            select t.Id;
                this.combox.ItemsSource = query.ToList();
                
               
            }

        }

       

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void combox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
                loginNo = combox.SelectedItem.ToString();
            
      

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

     

    }
}
