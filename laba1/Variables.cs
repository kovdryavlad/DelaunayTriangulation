using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    public class Variables : INotifyPropertyChanged
    {
        int n = 10;
     
        public int N
        {
            get { return n; }
            set
            {
                n = value;
                OnPropertyChanged();
            }
        }


        int steps = 3;
        public int Steps
        {
            get { return steps; }
            set
            {
                steps = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
