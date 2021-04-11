using ADP2.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP2.ViewModel
{
    class MediaPlayerViewModel : INotifyPropertyChanged
    {
        private IMediaPlayerModel model;
        private float speedVal;
        public MediaPlayerViewModel(IMediaPlayerModel model)
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
        public float VM_VideoSlider
        {
            get
            {
                return model.VideoSlider;
            }
        }

        private void NotifyPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void StartPlay()
        {
            this.model.start();
        }
        public void StopPlay()
        {
            this.model.stop();
        }
    }
}
