using ADP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP2.ViewModel
{
    internal class DashBoardViewModel : BaseNotify
    {
        private DashBoardModel model;
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
                return model.AirSpeed;
            }
        }

        internal float setAirSpeed()
        {
            return this.model.AirSpeed;
        }
    }
}
