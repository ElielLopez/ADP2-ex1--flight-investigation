using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP2.Models.Interface
{
    interface IMediaPlayerModel : INotifyPropertyChanged
    {
        bool Play { set; get; }
        bool Pause { set; get; }
        float Forward { set; get; }
        float Backward { set; get; }
        float Speed { set; get; }
        float VideoTime { set; get; }
        float VideoSlider { set; get; }

        void moveVideoSlider();
        void setSpeed(float speedVal);

        /*void isPlay();*/
        void start();
        void stop();
    }
}
