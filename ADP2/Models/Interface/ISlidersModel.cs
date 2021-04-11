using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP2.Models.Interface
{
    interface ISlidersModel : INotifyPropertyChanged
    {
        float Throttle { set; get; }
        float Rudder { set; get; }
    }
}
