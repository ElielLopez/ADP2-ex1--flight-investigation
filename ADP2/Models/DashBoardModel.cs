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
        // Rudder:1
        //Throttle:2
        //AireSpeed
        // the value of AireSpeed in line number 100 is "4.5"
        private float airSpeed;
        int aileronIndex = 0;
        float aileronVal = 0;
        int elevatorIndex = 0;
        float elevatorVal = 0;
        int throttleIndex = 0;
        float throttleVal = 0;
        int rudderIndex = 0;
        float rudderVal = 0;
        int airSpeedIndex = 0;
        int altimeterIndex = 0;
        int headingIndex = 0;
        int yawIndex = 0;
        int rollIndex = 0;
        int pitchIndex = 0;
/*        char[] delimeters = new char[] { ',' };
        string[] vals = arrText[i].Split(delimeters, StringSplitOptions.None);*/

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
                    aileronIndex = i;
                }
                if (listOfNamesFinal[i] == "elevator")
                {
                    elevatorIndex = i;
                }
                if (listOfNamesFinal[i] == "throttle")
                {
                    throttleIndex = i;
                }
                if (listOfNamesFinal[i] == "rudder")
                {
                    rudderIndex = i;
                }
                if (listOfNamesFinal[i] == "airspeed-kt")
                {
                    airSpeedIndex = i;
                }
                if (listOfNamesFinal[i] == "altimeter_indicated-altitude-ft")
                {
                    altimeterIndex = i;
                }
                if (listOfNamesFinal[i] == "heading-deg")
                {
                    headingIndex = i;
                }
                if (listOfNamesFinal[i] == "pitch-deg")
                {
                    pitchIndex = i;
                }
                if (listOfNamesFinal[i] == "side-slip-deg")
                {
                    yawIndex = i;
                }
                if (listOfNamesFinal[i] == "roll-deg")
                {
                    rollIndex = i;
                }
            }

            //Console.WriteLine("TABTAB");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public float AirSpeed
        {
            get
            {
                return airSpeed;
            }
            set
            {
                airSpeed = value;
                NotifyPropertyChanged("AirSpeed");
            }
        }

        private void NotifyPropertyChanged(string v)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
