using ADP2.Models;
using ADP2.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP2.ViewModel
{
    class SlidersViewModel : INotifyPropertyChanged
    {
        private ISlidersModel model;
        public SlidersViewModel(ISlidersModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        private void NotifyPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public float VM_Throttle
        {
            get { return model.Throttle; }
        }
        public float VM_Rudder
        {
            get { return model.Rudder; }
        }
    }
}
