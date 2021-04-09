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

namespace ADP2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int sleepTime = 100;
        int counter = 0;
        int lineNumber = 1;

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            Nullable<bool> result = openFileDialog.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                string filename = openFileDialog.FileName;
                fileNameTextBox.Text = filename;
            }

            using (StreamReader file = new StreamReader(fileNameTextBox.Text))
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
            string lineThreeHundred;

            arrText = File.ReadAllLines(fileNameTextBox.Text);
            //lineThreeHundred = arrText[counter];

            //Mutex m = new Mutex();
            //int lineNumber = 0;
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 5400);
                NetworkStream stream = client.GetStream();
                //StreamWriter stream = new StreamWriter(client.GetStream());
                var lines = File.ReadLines(fileNameTextBox.Text); //TODO
                                                                  //this._num_line = 0;

                //string l = lines.ElementAt(lineNumber);
                //while(l != null)

                /*                foreach (string l in lines)
                                {
                                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(l + "\r\n");
                                    stream.Write(data, 0, data.Length);
                                    Thread.Sleep(sleepTime);
                                    //m.WaitOne();
                                    //lineNumber++;
                                    //m.ReleaseMutex();
                                    //l = lines.ElementAt(lineNumber);
                                }*/

                // int x = Int32.Parse(str);
                for (int i = 1; i < counter; i++)
                {
                    lineNumber = (int)timeSlider.Value;
                    //lineNumber *= 10;
                    Console.WriteLine(lineNumber);
                    i = i + lineNumber;
                    lineThreeHundred = arrText[i];
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(lineThreeHundred + "\r\n");
                    stream.Write(data, 0, data.Length);
                    Thread.Sleep(sleepTime);
                }



                stream.Close();
                client.Close();

            }
            catch (Exception _e)
            {
                Console.WriteLine("error");
            }


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
