using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP2.Models
{
    public class DashBoardModel : INotifyPropertyChanged
    {

        static Dictionary<string, int> indices = new Dictionary<string, int>();
        public static int aileronIndex;
        public static int elevatorIndex;
        public static int throttleIndex;
        public static int rudderIndex;
        public static int airSpeedIndex;
        public static int altimeterIndex;
        public static int yawIndex;
        public static int rollIndex;
        public static int pitchIndex;
        private float airSpeed;
        float aileronVal = 0;
        float elevatorVal = 0;
        float throttleVal = 0;
        float rudderVal = 0;
        int headingIndex = 0;

        public void openXML(string filename)
        {
            string line;
            int temp = 0;
            StreamReader file = new StreamReader(filename);
            List<string> listOfNames = new List<string>();
            List<string> listOfNamesFinal = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                char[] seps = new char[] { '<', '>' };
                string[] parts = line.Split(seps, StringSplitOptions.None);
                for (int i = 0; i < parts.Length; i++)
                {
                    if (parts[i] == "name")
                    {
                        i++;
                        temp++;
                        listOfNames.Add(parts[i]);
                    }
                    if (parts[i] == "input")
                        break;
                }
            }
            file.Close();
            for (int i = 0; i < temp / 2; i++)
            {
                listOfNamesFinal.Add(listOfNames[i]);
                Console.WriteLine(listOfNamesFinal[i]);
            }
            //finding in listOfNamesFinal the correct index for aileron and elevator and save them on an global int variable
            for (int i = 0; i < temp / 2; i++)
            {
                if (listOfNamesFinal[i] == "aileron")
                {
                    if (!(indices.ContainsKey("aileron")))
                    {
                        indices.Add("aileron", i);
                    }
                }
                if (listOfNamesFinal[i] == "elevator")
                {
                    if (!(indices.ContainsKey("elevator")))
                    {
                        indices.Add("elevator", i);
                    }
                }
                if (listOfNamesFinal[i] == "throttle")
                {
                    if (!(indices.ContainsKey("throttle")))
                    {
                        indices.Add("throttle", i);
                    }
                }
                if (listOfNamesFinal[i] == "rudder")
                {
                    if (!(indices.ContainsKey("rudder")))
                    {
                        indices.Add("rudder", i);
                    }
                }
                if (listOfNamesFinal[i] == "airspeed-kt")
                {
                    if (!(indices.ContainsKey("airspeed-kt")))
                    {
                        indices.Add("airspeed-kt", i);
                    }
                }
                if (listOfNamesFinal[i] == "altimeter_indicated-altitude-ft")
                {
                    if (!(indices.ContainsKey("altimeter_indicated-altitude-ft")))
                    {
                        indices.Add("altimeter_indicated-altitude-ft", i);
                    }
                }
                if (listOfNamesFinal[i] == "heading-deg")
                {
                    if (!(indices.ContainsKey("heading-deg")))
                    {
                        indices.Add("heading-deg", i);
                    }
                }
                if (listOfNamesFinal[i] == "pitch-deg")
                {
                    if (!(indices.ContainsKey("pitch-deg")))
                    {
                        indices.Add("pitch-deg", i);
                    }
                }
                if (listOfNamesFinal[i] == "side-slip-deg")
                {
                    if (!(indices.ContainsKey("side-slip-deg")))
                    {
                        indices.Add("side-slip-deg", i);
                    }
                }
                if (listOfNamesFinal[i] == "roll-deg")
                {
                    if (!(indices.ContainsKey("roll-deg")))
                    {
                        indices.Add("roll-deg", i);
                    }
                }
            }
            //Console.WriteLine("whatgf");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public float AirSpeed
        {
            get
            {

                Console.WriteLine("From MODEL GET {0}", airSpeed);
                return airSpeed;
            }
            set
            {
                airSpeed = value; //2.760
                Console.WriteLine("From MODEL SSSSET {0}", airSpeed);
                NotifyPropertyChanged("AirSpeed");
                
            }
        }

        public Dictionary<string, int> indicVals
        {
            get
            {
                return indices;
            }
        }

        private void NotifyPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
