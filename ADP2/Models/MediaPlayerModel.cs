using ADP2.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP2.Models
{
    class MediaPlayerModel : IMediaPlayerModel
    {
        private bool play;
        private bool pause;


        public bool Play {
            get
            {
                return play;
            }
                set => throw new NotImplementedException(); }
        public bool Pause { 
            get 
            {
                return pause;
            }
            
            set => throw new NotImplementedException(); }
        public float Forward { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float Backward { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float Speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float VideoTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float VideoSlider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event PropertyChangedEventHandler PropertyChanged;


        public void moveVideoSlider()
        {
            throw new NotImplementedException();
        }

        public void setSpeed(float speedVal)
        {
            throw new NotImplementedException();
        }

        void IMediaPlayerModel.start()
        {
            play = true;
            pause = false;
        }

        void IMediaPlayerModel.stop()
        {
            play = false;
            pause = true;
        }
    }
}
