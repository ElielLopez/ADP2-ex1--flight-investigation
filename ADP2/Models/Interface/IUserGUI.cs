using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP2.Models.Interface
{
    interface IUserGUI : INotifyPropertyChanged
    {
        /*IMediaPlayerModel;*/
        bool Play {get; }
        bool Pause {get; }
        float Forward { set; get; }
        float Backward { set; get; }
        float Speed { set; get; }
        float VideoTime { set; get; }
        float VideoSlider { set; get; }

        void moveVideoSlider();
        void setSpeed(float speedVal);
        
        void playVideo();
        void stopVideo();


        // IFileLoaderModel
        void open(string fn);
    }
}
