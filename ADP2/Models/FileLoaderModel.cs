﻿using ADP2.Models.Interface;
using Microsoft.Win32;
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
    class FileLoaderModel : IFileLoaderModel
    {
        //private string fileName;
        private int counter = 0;
        volatile Boolean isPaused = false;

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
                while (!isPaused)
            {
                try
                {
                    TcpClient client = new TcpClient("127.0.0.1", 5400);
                    NetworkStream stream = client.GetStream();
                    var lines = File.ReadLines(filename);

                    for (int i = 0; i < counter; i++) // counter = 2147
                    {
                        //Console.WriteLine("the VALUE is {0}", value);
                        currLine = arrText[i];
                        Byte[] data = System.Text.Encoding.ASCII.GetBytes(currLine + "\r\n");
                        stream.Write(data, 0, data.Length);
                        Console.Write(currLine); // CHECKING
                        Thread.Sleep(100);
                    }

                    stream.Close();
                    client.Close();
                }
                catch (Exception _e)
                {
                    Console.WriteLine("error");
                }
            } }).Start();
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
