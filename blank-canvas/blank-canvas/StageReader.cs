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
            BinaryReader reader = null;
            try
            {
                reader = new BinaryReader(File.OpenRead(filename[0]));
                reader.ReadString();
                reader.ReadInt32();

                // checks to see if the current position is equal to the length of the text file
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    char character = reader.ReadChar();

                    //this should be where the world is generated?
                    //make sure the whole thing doesn't like exist in one line

                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error. Press any key.");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error. Null Reference. Press any key.");
            }
            finally { reader.Close(); }
        }
    }
}
