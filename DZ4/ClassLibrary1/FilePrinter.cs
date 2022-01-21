using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WeatherClass
{
    public class FilePrinter: IPrinter 
    {
        string fileName;

        public FilePrinter(string fileName)
        {
            this.fileName = fileName;
        }

        public void ChangeFileName(string fileName)
        {
            this.fileName = fileName;
        }

        public void Print(Weather[] weathers)
        {
            
            /*if (File.Exists(fileName) == false)
            {
                using (StreamWriter sw = File.CreateText(fileName)) ;
                Console.WriteLine("The required file does not exist. Please create it, or change the path.");
                return;
            }*/
            
            
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int i = 0; i < weathers.Length; i++)
                {
                    writer.WriteLine(weathers[i].ToString());
                }
            }
            
        }
    }
}
