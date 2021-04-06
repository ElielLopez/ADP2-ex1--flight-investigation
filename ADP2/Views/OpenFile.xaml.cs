using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace ADP2.Views
{
    /// <summary>
    /// Interaction logic for OpenFile.xaml
    /// </summary>
    public partial class OpenFile : UserControl
    {
        public OpenFile()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            Mutex m = new Mutex();
            int lineNumber = 0;
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 5400);
                NetworkStream stream = client.GetStream();
                var lines = File.ReadLines("reg_flight.csv"); //TODO
                //this._num_line = 0;

                string l = lines.ElementAt(lineNumber);
                while(l != null)
                {
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(l);
                    stream.Write(data, 0, data.Length);
                    Thread.Sleep(1000 / 10);
                    m.WaitOne();
                    lineNumber++;
                    m.ReleaseMutex();
                    l = lines.ElementAt(lineNumber);
                }

                stream.Close();

            }
            catch
            {

            }

            //------------


/*            string line;
            int temp = 0;
            StreamReader file = new StreamReader("reg_flight.csv");
            List<string> listOfNames = new List<string>();
            //List<string> listOfNamesFinal = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                char[] seps = new char[] { ',' };
                string[] parts = line.Split(seps, StringSplitOptions.None);
                for (int i = 0; i < parts.Length; i++)
                {
                    i++;
                    temp++;
                    listOfNames.Add(parts[i]);
                }
            }
            file.Close();*/
        }

        private void OpenXMLFile_Click(object sender, RoutedEventArgs e)
        {
            string line;
            int temp = 0;
            StreamReader file = new StreamReader("playback_small.xml");
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
        }
    }
}
