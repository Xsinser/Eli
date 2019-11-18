
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

namespace Eli
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private Checker checker = new Checker();
        private SQLDataWorkerClass worker=new SQLDataWorkerClass();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           worker.InsertData(loginBox.Text, passBox.Text, typesBox.Text);
        
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            checker.Check();
            
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
             timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Start();
         
        }
    }
}
