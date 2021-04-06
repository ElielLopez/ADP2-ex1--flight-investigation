using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP2.Models
{
    public class XMLReader
    {
        public XMLReader()
        {
            List<string> features = new List<string>();

            try
            {
                using (var sr = new StreamReader("playback_small.xml"))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Thie file could not be read");
                Console.WriteLine(e.Message);
            }
        }
    }
}
