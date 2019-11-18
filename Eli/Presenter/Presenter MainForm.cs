using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Eli.Presenter
{
    class Presenter_MainForm
    {
        private DispatcherTimer timer;
        private Checker checker = new Checker();
        private SQLDataWorkerClass worker = new SQLDataWorkerClass();
        MainWindow mainWindow;
        public Presenter_MainForm( MainWindow window)
        {
            mainWindow = window;
            mainWindow.OnStartClick += TimerStartMethod;
             mainWindow.OnAddClick += InsertDataMethod;
            mainWindow.OnTimerValueChanged += OnCheckTick;  
        }

        void InsertDataMethod(object sender, EventArgs e)
        {
            worker.InsertData(mainWindow.loginBox.Text, mainWindow. passBox.Text, mainWindow.typesBox.Text);
        }

        private void OnCheckTick(object sender, EventArgs e)
        {
            checker.Check();
        }

        private void TinerValuseChanged(object sender, EventArgs e)
        {
            timer.Interval = new TimeSpan(0, Convert.ToInt16(mainWindow.TimeLabel.Value), 0);
        }

        void TimerStartMethod(object sender,EventArgs e)
        {
             timer = new DispatcherTimer();
             timer.Tick += new EventHandler(OnCheckTick);
             timer.Interval = new TimeSpan(0, 1, 0);
             timer.Start();
        }

    }
}
