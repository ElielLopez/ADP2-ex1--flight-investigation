﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP2.Models.Interface
{
    internal interface IFileLoaderModel : INotifyPropertyChanged
    {
        void open(string fn);
    }
}
