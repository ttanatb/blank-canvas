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
        private string[] fileNames; // sets filename
        private string sourcePath; // the path for the original file

        Player player;
        List<Tile> tiles;
        List<Enemy> enemies;
        List<Rectangle> collisionBoxes;

        // position counter
        int xpos;
        int ypos;

        string title;
        int level;

        // constructor that gets string
        public StageReader()
        {
            enemies = new List<Enemy>();
            tiles = new List<Tile>();
            collisionBoxes = new List<Rectangle>();

            try
            {
                sourcePath = Path.GetFullPath(@"..\..\..\..\..\stage-builder\stage-builder\stage-builder\bin\Debug"); //doesn't handle multiple text files
                fileNames = Directory.GetFiles(sourcePath, "*.txt");
                Console.WriteLine(sourcePath + "\n" + fileNames[0]);
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
            get { return player; }
        }

        public Enemy[] Enemies
        {
            get
            {
                Enemy[] e = new Enemy[enemies.Count];
                for (int i = 0; i < enemies.Count; i++)
                    e[i] = enemies[i];
                return e;
            }
        }

        public Tile[] Tile
        {
            get
            {
                Tile[] t = new Tile[tiles.Count];
                for (int i = 0; i < tiles.Count; i++)
                    t[i] = tiles[i];
                return t;
            }
        }

        public Rectangle[] CollisionBoxes
        {
            get
            {
                Rectangle[] boxes = new Rectangle[collisionBoxes.Count];
                for (int i = 0; i < collisionBoxes.Count; i++)
                    boxes[i] = collisionBoxes[i];
                return boxes;
            }
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
                reader = new BinaryReader(File.OpenRead(fileNames[0]));
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
                    lvlString += character; //concatnates the string of numbers
                }

                int.TryParse(lvlString, out level); //parses it back to int
                Console.WriteLine(level);

                reader.ReadChar(); //reads away the '\n'

                // counts the position in the binary reader
                xpos = 0;
                ypos = 0;
                int i = 0;
                int startingPos = 0;

                // checks to see if the current position is equal to the length of the text file
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    character = reader.ReadChar();

                    if (character.Equals('_'))
                    {
                        // initializes new ground tile
                        Tile tile = new Tile(new Vector2(xpos, ypos));
                        tiles.Add(tile);
                        Console.WriteLine("Tile created: " + xpos + ", " + ypos);

                        if (i == 0)
                            startingPos = xpos;

                        i++;
                    }

                    else if (character.Equals('P'))
                    {
                        // initializes player in the world
                        player = new Player(new Rectangle(xpos, ypos, 64, 128)); //
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

                    else if ((character.Equals(' ')) || (reader.BaseStream.Position == reader.BaseStream.Length) || character.Equals('\r'))
                    {
                        if (i != 0)
                        {
                            collisionBoxes.Add(new Rectangle(startingPos, ypos, 64 * i, 64));
                            Console.WriteLine("CollisionBox added at: " + startingPos + " to " + 64*i + startingPos);
                            i = 0;
                        }

                        if (character.Equals('\r'))
                        {
                            reader.ReadChar(); //reads away the '\n'
                            ypos += 64;
                            xpos = -64;
                        }
                    }

                    xpos += 64;


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
