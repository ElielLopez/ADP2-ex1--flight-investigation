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

        private float speedVal;
        //Boolean isPlayPressed = true;
        //volatile Boolean isPausePressed = false;
        public UserGUIViewModel(IUserGUI model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                onPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public bool VM_Play
        {
            get
            {
                return model.Play;
            }
        }
        public bool VM_Pause
        {
            get
            {
                return model.Pause;
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
        public double VideoSliderChanged
        {
            set
            {
                this.model.VideoSlider = value;
            }

        }
        public void pauseVideo()
        {
            this.model.stopVideo();
        }
        public void playVideo()
        {
            this.model.playVideo();
        }

        public void jumpFarward()
        {
            this.model.jumpF();
        }
        public void jumpBackward()
        {
            this.model.jumpB();
        }
        public void SpeedUpVideo()
        {
            this.model.SpeedUp();
        }
        public void SpeedDownVideo()
        {
            this.model.SpeedDown();
        }

        public void goHere(double timeValue)
        {
            this.model.goToPoint(timeValue);
        }

        // FileLoaderViewModel
        public void OpenCSVFile(string filename)
        {
            this.model.open(filename);
        }



        private void NotifyPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void onPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
