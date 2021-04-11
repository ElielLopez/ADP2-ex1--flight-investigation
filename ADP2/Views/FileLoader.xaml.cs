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
using System.IO;
using Microsoft.Win32;
using System.Net.Sockets;
using System.Threading;

namespace ADP2.Views
{
    /// <summary>
    /// Interaction logic for FileLoader.xaml
    /// </summary>
    public partial class FileLoader : UserControl
    {
        public FileLoader()
        {
            InitializeComponent();
        }

        int counter = 0;
        //int lineNumber = 0;
        double value = 0;
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
                    while (pause == true)
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
        }
    }
}
