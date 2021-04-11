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
using ADP2.ViewModel;
using ADP2.Models;

namespace ADP2.Views
{
    public partial class FileLoader : UserControl
    {
        FileLoaderViewModel vm;
        public string filename;
        public FileLoader()
        {
            InitializeComponent();
            vm = new FileLoaderViewModel(new UserGUI());
            DataContext = vm;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            Nullable<bool> result = openFileDialog.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                filename = openFileDialog.FileName;
                fileNameTextBox.Text = filename;
            }
            vm.OpenCSVFile(filename);
        }
    }
}




/*{
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
            currLine = arrText[i];
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(currLine + "\r\n");
            stream.Write(data, 0, data.Length);
            Thread.Sleep(100);
        }

        stream.Close();
        client.Close();
    }
    catch (Exception _e)
    {
        Console.WriteLine("error");
    }
}*/
