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
using System.Windows.Threading;
using BankManage; 
namespace BankManage
{
    /// <summary>
    /// Main2.xaml 的交互逻辑
    /// </summary>
    public partial class Main2 : Window
    {
        private DispatcherTimer ShowTimer;
        
        public Main2()
        {
            
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.SourceInitialized += MainWindow_SourceInitialized;
            //获取当前时间
            ShowTimer = new System.Windows.Threading.DispatcherTimer();
            ShowTimer.Tick += new EventHandler(ShowCurTimer);//起个Timer一直获取当前时间
            ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            ShowTimer.Start();
           
        }


        void MainWindow_SourceInitialized(object sender, System.EventArgs e)
        {

            
            //启动登陆窗体
            LoginForm login = new LoginForm();
            login.ShowDialog();
            textName.Text = LoginForm.loginNo;


            if (LoginForm.loginNo=="00001")
            {
                loginimage.Source = new BitmapImage(new Uri("/loginimages/z1.jpg", UriKind.Relative));   
            }
            if (LoginForm.loginNo=="00002")
            {
                loginimage.Source = new BitmapImage(new Uri("/loginimages/z2.jpg", UriKind.Relative)); 
            }
            if (LoginForm.loginNo=="00003")
            {
                loginimage.Source = new BitmapImage(new Uri("/loginimages/z3.jpg", UriKind.Relative)); 
            }
            
        }

       

      

      

        private void cmd_Click(object sender, RoutedEventArgs e)
        {
            menu.IsOpen = true;
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

       
        //从新定位显示页
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = e.Source as MenuItem;
            if (item != null)
            {
                frame1.Source = new Uri(item.Tag.ToString(), UriKind.Relative);
            }
        }

        private void cmd1_Click(object sender, RoutedEventArgs e)
        {
            menu2.IsOpen = true;
        }

        

        private void ButtonExit_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       

        private void ButtonAbout_Click_2(object sender, RoutedEventArgs e)
        {
            Button item = e.Source as Button;
            if (item != null)
            {
                frame1.Source = new Uri(item.Tag.ToString(), UriKind.Relative);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Main2 main2 = new Main2();
            main2.Show();
            
        }

      

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button item = e.Source as Button;
            if (item != null)
            {
                frame1.Source = new Uri(item.Tag.ToString(), UriKind.Relative);
            }
        }

      
        }

        

      
    }

