using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using BankManage; 
namespace BankManage
{
    /// <summary>
    /// AdminForm.xaml 的交互逻辑
    /// </summary>
    public partial class AdminForm : Window
    {
		private DispatcherTimer ShowTimer;
        public AdminForm()
        {
            InitializeComponent();
            this.Closing += AdminForm_Closing;
            this.SourceInitialized += AdminForm_SourceInitialized;


            //获取当前时间
            ShowTimer = new System.Windows.Threading.DispatcherTimer();
            ShowTimer.Tick += new EventHandler(ShowCurTimer);//起个Timer一直获取当前时间
            ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            ShowTimer.Start();

          
            
            
            
        }

        void AdminForm_SourceInitialized(object sender, EventArgs e)
        {
            textname2.Text = LoginForm.loginNo;
            if (LoginForm.loginNo == "1")
            {
                loginimage.Source = new BitmapImage(new Uri("/loginimages/admin1.jpg", UriKind.Relative));
            }
            if (LoginForm.loginNo == "2")
            {
                loginimage.Source = new BitmapImage(new Uri("/loginimages/admin2.jpg", UriKind.Relative));
            }
           
        }
        //实现窗体移动
        void AdminForm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            
            
        }
        //强制退出程序
        void AdminForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
          
            Application.Current.Shutdown();
            
        }

        private void cmd1_Click(object sender, RoutedEventArgs e)
        {
            menu.IsOpen = true;
        }

        private void cmd2_Click(object sender, RoutedEventArgs e)
        {
            menu2.IsOpen = true;
        }



        public void ShowCurTimer(object sender, EventArgs e)
        {
            //"星期"+DateTime.Now.DayOfWeek.ToString(("d"))

            //获得星期几
            this.Tt.Text = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("zh-cn"));
            this.Tt.Text += " ";
            //获得年月日
            this.Tt.Text += DateTime.Now.ToString("yyyy年MM月dd日");   //yyyy年MM月dd日
            this.Tt.Text += " ";
            //获得时分秒
            this.Tt.Text += DateTime.Now.ToString("HH:mm:ss");
            //System.Diagnostics.Debug.Print("this.ShowCurrentTime {0}", this.ShowCurrentTime);
        }

        private void ButtonExit_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = e.Source as MenuItem;
            if (item != null)
            {
                frame1.Source = new Uri(item.Tag.ToString(), UriKind.Relative);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button item = e.Source as Button;
            if (item != null)
            {
                frame1.Source = new Uri(item.Tag.ToString(), UriKind.Relative);
            }
        }

        private void ButtonAbout_Click_3(object sender, RoutedEventArgs e)
        {
            Button item = e.Source as Button;
            if (item != null)
            {
                frame1.Source = new Uri(item.Tag.ToString(), UriKind.Relative);
            }
        }

      

        


      

    }
}
