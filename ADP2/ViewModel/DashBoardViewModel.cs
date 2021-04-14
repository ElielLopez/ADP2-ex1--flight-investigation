using ADP2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP2.ViewModel
{
    internal class DashBoardViewModel : INotifyPropertyChanged
    {
        private DashBoardModel model;
        public float airS;
        public DashBoardViewModel(DashBoardModel model)
        {
            this.model = model;
            this.model.PropertyChanged += (sender, args) => NotifyPropertyChanged("VM_" + args.PropertyName);
        }

        public void OpenXMLFile(string filename)
        {
            this.model.openXML(filename);
        }

        public float VM_AirSpeed
        {
            get
            {
                
                Console.WriteLine("VIEWMODEL GET {0}", model.AirSpeed);
                return model.AirSpeed;
            }
            set
            {
                //model.AirSpeed = value;
                airS = model.AirSpeed;
                NotifyPropertyChanged("VM_AirSpeed");
            }
        }
        private void NotifyPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
/*        public void onPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }*/
    }
}
