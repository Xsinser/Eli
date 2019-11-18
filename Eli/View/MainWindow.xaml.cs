
using Eli.Presenter;
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
         
        private Checker checker = new Checker();
        private SQLDataWorkerClass worker=new SQLDataWorkerClass();
        private string timer { set { TimeInterface.Content = value; } }
        public event EventHandler OnAddClick;
        public event EventHandler OnStartClick;
        public event EventHandler OnTimerValueChanged;
        bool errorChecker = false;
        public MainWindow()
        {
            InitializeComponent();
            new Presenter_MainForm(this);
            timer = "1 минут";
            errorChecker = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            OnAddClick.Invoke(sender, e);

        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            OnStartClick.Invoke(sender, e);          
         
        }

        private void TimeLabel_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            timer = TimeLabel.Value + " минут";
            if(errorChecker)
            OnTimerValueChanged.Invoke(sender, e);

        }
    }
}
