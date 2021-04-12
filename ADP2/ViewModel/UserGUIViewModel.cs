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
    class UserGUIViewModel : INotifyPropertyChanged
    {
        private IUserGUI model;
        public UserGUIModel uModel;

        private float speedVal;
        volatile Boolean isPlayPressed = true;
        volatile Boolean isPausePressed = false;
        public UserGUIViewModel(IUserGUI model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public bool VM_Play
        {
            get
            {
                return model.Play;
            }
            set
            {
                isPlayPressed = value;
                model.start();
            }
        }
        public bool VM_Pause
        {
            get
            {
                return model.Pause;
            }
            set
            {
                isPausePressed = value;
                model.stop();
            }
        }

        public float VM_Forward
        {
            get
            {
                return model.Forward;
            }
        }
        public float VM_Backward
        {
            get
            {
                return model.Backward;
            }
        }
        public float VM_Speed
        {
            get
            {
                return model.Speed;
            }
            set
            {
                speedVal = value;
            }
        }
        public float VM_VideoTime
        {
            get
            {
                return model.VideoTime;
            }
        }
        public float VM_VideoSlider
        {
            get
            {
                return model.VideoSlider;
            }
        }
        public void pauseVideo(Boolean pauseV)
        {
            uModel.stop();
        }

        // FileLoaderViewModel
        public void OpenCSVFile(string filename)
        {
            this.model.open(filename);
        }


        private void NotifyPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
