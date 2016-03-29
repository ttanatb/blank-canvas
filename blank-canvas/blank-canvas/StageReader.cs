using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;

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
        // creates tile
        Grid grid;
        // creates player
        Player p;
        // creates enemy
        List<Enemy> e;

        // position counter
        int xpos;
        int ypos;

        string title;
        int level;

        // constructor that gets string
        public StageReader()
        {
            e = new List<Enemy>();
            grid = new Grid();

            try
            {
                sourcePath = Path.GetFullPath(@"..\..\..\..\..\stage-builder\stage-builder\stage-builder\bin\Debug"); //doesn't handle multiple text files
                filename = Directory.GetFiles(sourcePath, "*.txt");
                Console.WriteLine(sourcePath + "\n" + filename[0]);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(sourcePath);
                Console.WriteLine("Error. Press any key.");
            }

        }

        #region Properties

        public Player Player
        {
            get { return p; }
        }

        public Enemy[] Enemy
        {
            get
            {
                Enemy[] enemy = new Enemy[e.Count];
                for (int i = 0; i < e.Count; i++)
                    enemy[i] = e[i];
                return enemy;
            }
        }

        public Grid Grid
        {
            get { return grid; }
        }

        public int Level
        {
            get { return level; }
        }

        public string Title
        {
            get { return title; }
        }

        #endregion

        // reads in file
        public void ReadFile()
        {
            BinaryReader reader = null;

            try
            {
                //does reader thing
                reader = new BinaryReader(File.OpenRead(filename[0]));
                char character;

                //a bit of info: every line ends with a '\r\n'


                //reads the title
                title = "";

                while ((character = reader.ReadChar()) != '\r') //reads until line break
                {
                    title += character;
                }
                Console.WriteLine(title);

                reader.ReadChar(); //reads away the '\n'


                string lvlString = ""; //string to Parse
                while ((character = reader.ReadChar()) != '\r') //reads until line break
                {
                    lvlString += character; //concatnates an int of level
                }

                int.TryParse(lvlString, out level); //parses it back to int
                Console.WriteLine(level);

                reader.ReadChar(); //reads away the '\n'

                // counts the position in the binary reader
                xpos = 0;
                ypos = 0;

                // checks to see if the current position is equal to the length of the text file
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    character = reader.ReadChar();

                    if (character.Equals('_'))
                    {
                        // initializes new ground tile
                        grid.AddTile(xpos / 64, ypos / 64);
                        Console.WriteLine("Tile created: " + xpos + ", " + ypos);
                    }

                    else if (character.Equals('P'))
                    {
                        // initializes player in the world
                        p = new Player(new Rectangle(xpos, ypos, 64, 128)); //
                        Console.WriteLine("Player created: " + xpos + ", " + ypos);
                    }

                    else if (character.Equals('E'))
                    {
                        // initializes enemy
                        // e[xpos] = new Enemy(new Rectangle(20, 40, 100, 100));
                    }

                    else if (character.Equals('o'))
                    {
                        // initializes puzzle orb
                        // class not created yet
                    }

                    else if (character.Equals('0'))
                    {
                        // initializes end orb
                        // class not created yet
                    }

                    else if (character.Equals('|'))
                    {
                        // initializes door
                        // class not created yet
                    }

                    xpos += 64;

                    if (character.Equals('\r'))
                    {
                        reader.ReadChar(); //reads away the '\n'
                        ypos += 64;
                        xpos = 0;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error. File not found.");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error. Null Reference. Press any key.");
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
