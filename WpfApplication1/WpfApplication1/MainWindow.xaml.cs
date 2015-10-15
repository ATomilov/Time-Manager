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
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DateTime curTime = new DateTime();
        }

        TimeSpan elapsed = new TimeSpan(0,0,0);
        TimeSpan second = new TimeSpan(0,0,1);
        bool timerOn = true;

        private void CountUp_Click(object sender, RoutedEventArgs e)
        {
            timerOn = !timerOn;
            startCountUp();
        }


        public DispatcherTimer timer = new DispatcherTimer();

        public void startCountUp()
        {
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            if (!timerOn)
            {

                CountUp_Button.Content = "Отдыхать";
                timer.Tick += new EventHandler(timerTick);
                timer.Start();                
            }
            else
            {
                CountUp_Button.Content = "Работать";
                timer.Stop();
                timer.Tick -= new EventHandler(timerTick);
            }            
        }

        private void timerTick (object sender, EventArgs e)
        {            
            elapsed = elapsed.Add(second);
            tmlabel.Content= elapsed.ToString();
        }  
          
    }
}
