using ADP2.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADP2.Models
{
    class UserGUIModel : IUserGUI
    {
        private int sleepTime;
        private int counter = 0;
        public Boolean isPaused;
        public Boolean isPlay;
        public int jumper;
        public bool defaultJumper;
        public bool defaultTimePoint;
        public float speedValue;
        public double videoSlider;
        private int lineNum;
        public UserGUIModel()
        {
            sleepTime = 100;
            isPlay = true;
            isPaused = false;
            jumper = 0;
            defaultJumper = false;
            speedValue = 1;
            videoSlider = 0;
        }

        public void open(string filename)
        {
            using (StreamReader file = new StreamReader(filename))
            {
                counter = 0;
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    Console.WriteLine(ln);
                    counter++;
                }
                file.Close();
                Console.WriteLine("NUMBER OF LINES IS {0}", counter);
            }

            string[] arrText;
            string currLine;
            char[] delimeters = new char[] { ',' };
            arrText = File.ReadAllLines(filename);
            new Thread(delegate ()
            {
                
                while (true)
                {
                    try
                    {
                        TcpClient client = new TcpClient("127.0.0.1", 5400);
                        NetworkStream stream = client.GetStream();
                        var lines = File.ReadLines(filename);

                        for (int i = 0; i < counter; i++) // counter = 2147
                        {
                            if (defaultJumper)
                            {
                                i += jumper;
                                defaultJumper = false;
                            }
                            if (defaultTimePoint)
                            {
                                i = (int)videoSlider;
                                defaultTimePoint = false;
                            }
                           
                            // in line i i want to take the value of column "aileron" and send it to XAML
                            currLine = arrText[i];
                            
                            string[] vals = arrText[i].Split(delimeters, StringSplitOptions.None);
                            Console.WriteLine(vals[1]);

                            Byte[] data = System.Text.Encoding.ASCII.GetBytes(currLine + "\r\n");
                            stream.Write(data, 0, data.Length);
                            Console.Write(currLine);
                            while(isPaused)
                            {
                                Thread.Sleep(sleepTime);
                            }
                            Thread.Sleep((int)(sleepTime / speedValue));
                        }

                        stream.Close();
                        client.Close();
                    }
                    catch (Exception _e)
                    {
                        Console.WriteLine("error");
                    }
                }
            }).Start();
        }

        // MediaPLayerModel

        public bool Play
        {
            get
            {
                return isPlay;
            }
            set
            {
                isPlay = value;
                NotifyPropertyChanged("Play");
            }
        }
        public bool Pause
        {
            get
            {
                return isPaused;
            }
            set
            {
                isPaused = value;
                NotifyPropertyChanged("Pause");
            }
        }
        public float Forward 
        {
            get
            {
                return jumper;
            }
            set
            {
                jumper += (int)value;
                NotifyPropertyChanged("Forward");
            }
        }
        public float Backward 
        {
            get
            {
                return jumper;
            }
            set
            {
                jumper -= (int)value;
                NotifyPropertyChanged("Backward");
            }
        }
        public float Speed
        {
            get
            {
                return speedValue;
            }
            set
            {
                speedValue = (int)value;
                NotifyPropertyChanged("Speed");
            }
        }
        public float VideoTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double VideoSlider
        {
            get
            {
                return videoSlider;
            }
            set
            {
                videoSlider = value;
                NotifyPropertyChanged("VideoSlider");
            }
        }

        public void moveVideoSlider()
        {
            throw new NotImplementedException();
        }

        public void SpeedUp()
        {
            speedValue += (float)0.1;
        }
        public void SpeedDown()
        {
            speedValue -= (float)0.1;
        }

        public void playVideo()
        {
            this.isPlay = true;
            this.isPaused = false;
        }

        public void stopVideo()
        {
            this.isPlay = false;
            this.isPaused = true;
        }

        // 100 rows = 10 seconds
        public void jumpF()
        {
            this.defaultJumper = true;
            this.jumper = 100;
        }
        public void jumpB()
        {
            this.defaultJumper = true;
            this.jumper = -100;
        }
        public void goToPoint(double timeValue)
        {
            this.defaultTimePoint = true;
            this.videoSlider = timeValue;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

    }
}
