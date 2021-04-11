using ADP2.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP2.Models
{
    public class SlidersModel : ISlidersModel
    {
        private float throttle;
        private float rudder;
        public float Throttle 
        { 
            get
            {
                return throttle;
            }
            set
            {
                throttle = value;
                INotifyPropertyChanged("Throttle");
            }
        }

        public float Rudder
        {
            get
            {
                return rudder;
            }
            set
            {
                rudder = value;
                INotifyPropertyChanged("Rudder");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void INotifyPropertyChanged(string propName)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
