using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

/*
    Class: StageReader
    Purpose: reads in the stage from a text file

*/

namespace blank_canvas
{
    class StageReader
    {
        // sets filename
        private string[] filename;
        // the path for the original file
        private string sourcePath;

        // constructor that gets string
        public StageReader()
        {
            try
            {
                sourcePath = Path.GetFullPath(@"stage-builder\bin\Debug");
                filename = Directory.GetFiles(sourcePath, "*.txt");
                //Console.WriteLine(sourcePath + "\n" + filename[0]);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Error. Press any key.");
            }

        }

        // moves and reads in file
        public void ReadFile()
        {

            try
            {
                BinaryReader reader = new BinaryReader(File.OpenRead(filename[0]));
                Console.WriteLine(reader.ReadString());
                Console.WriteLine(reader.ReadInt32());
                reader.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error. Press any key.");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error. Null Reference. Press any key.");
            }
        }
    }
}
