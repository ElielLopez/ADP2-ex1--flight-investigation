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
        double VideoSlider { set; get; }
        void moveVideoSlider();
        void SpeedUp();
        void SpeedDown();
        
        void playVideo();
        void stopVideo();
        void jumpF();
        void jumpB();
        void goToPoint(double timeValue);
/*        int lineNumber
        {
            get;
            set;
        }*/
/*        int simLen
        {
            get;
            set;
        }*/

        // IFileLoaderModel
        void open(string fn);
    }
}
