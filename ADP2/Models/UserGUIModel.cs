using ADP2.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private int counter = 0;
        public Boolean isPaused;
        public Boolean isPlay;
        public int jumper;
        public int defaultJumper;
        public UserGUIModel()
        {
            isPlay = true;
            isPaused = false;
            jumper = 0;
            defaultJumper = 0;
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
                            i += jumper;
                            currLine = arrText[i];
                            Byte[] data = System.Text.Encoding.ASCII.GetBytes(currLine + "\r\n");
                            stream.Write(data, 0, data.Length);
                            Console.Write(currLine);
                            while(isPaused)
                            {
                                Thread.Sleep(100);
                            }
                            Thread.Sleep(100);
                            //jumper -= jumper;
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
                INotifyPropertyChanged("Play");
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
                INotifyPropertyChanged("Pause");
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
                INotifyPropertyChanged("Forward");
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
                INotifyPropertyChanged("Backward");
            }
        }
        public float Speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float VideoTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float VideoSlider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void moveVideoSlider()
        {
            throw new NotImplementedException();
        }

        public void setSpeed(float speedVal)
        {
            throw new NotImplementedException();
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

        public void jumpF()
        {
            this.jumper += 100;
        }
        public void jumpB()
        {
            this.jumper -= 100;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void INotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
