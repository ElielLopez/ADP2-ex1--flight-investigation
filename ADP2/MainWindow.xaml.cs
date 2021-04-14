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
        //int lineNumber = 0;
        double value = 0;
        bool play = true;
        bool pause = false;

        public double Value
        {
            get { return value; }
            set { }
        }

        /*private void OpenFile_Click(object sender, RoutedEventArgs e)
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
            string currLine;

            arrText = File.ReadAllLines(fileNameTextBox.Text);

            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 5400);
                NetworkStream stream = client.GetStream();
                var lines = File.ReadLines(fileNameTextBox.Text); 

                for (int i = 0; i < counter; i++, value++) // counter = 2147
                {
                    Console.WriteLine("the VALUE is {0}", value);
                    //i = (int)value;
                    i = (int)this.Value;
                    currLine = arrText[i];
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(currLine + "\r\n");
                    stream.Write(data, 0, data.Length);
                    Thread.Sleep(sleepTime);
                    while(pause == true)
                    {
                        Thread.Sleep(1000);
                        if (play == true)
                            break;
                    }
                }

                stream.Close();
                client.Close();
            }
            catch (Exception _e)
            {
                Console.WriteLine("error");
            }
        }*/

/*        private void OpenXMLFile_Click(object sender, RoutedEventArgs e)
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

        private void DragSlider(object sender, RoutedEventArgs e)
        {
            var slider = sender as Slider;
            value = slider.Value;
            // ... Set Window Title.
            this.Title = "Value: " + value.ToString("0.0") + "/" + slider.Maximum;
        }
        //Thumb.DragCompleted="DragSlider"

        private void isPlay(object sender, RoutedEventArgs e)
        {
            play = true;
            pause = false;
        }
        private void isPause(object sender, RoutedEventArgs e)
        {
            pause = true;
            play = false;
        }*/
    }
}
