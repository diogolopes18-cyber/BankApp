using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Bank
{
    public class FileHandling
    {
        public string username { get; set; }
        
        internal void SaveHistoryToFile(string username)
        {
            this.username = username;
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            //Create a new file
            StreamWriter file = new StreamWriter(desktopPath + @"\test.txt");

            //Write username to file
            file.WriteLine(this.username);

            //Close file
            file.Close();

        }


    }
}
