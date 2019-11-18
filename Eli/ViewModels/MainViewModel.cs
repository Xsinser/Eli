using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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


namespace Eli.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        
        
           
            public event PropertyChangedEventHandler PropertyChanged;
 

            public void OnPropertyChanged([CallerMemberName] string prop = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }

        private int Clck = 0;
        public int Click
            {
                get { return Clck; }
                set { Clck = value; OnPropertyChanged(nameof(Click)); }
            }

         /*   public void doSome()
             {
            Click++;
                }
             */     
   
    }
}
