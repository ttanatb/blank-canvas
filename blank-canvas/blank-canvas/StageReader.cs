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
        List<PuzzleOrb> puzzleOrbs;
        List<Gates> puzzleGates;

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
            puzzleOrbs = new List<PuzzleOrb>();
            puzzleGates = new List<Gates>();

            try
            {
                sourcePath = Path.GetFullPath(@"..\..\..\..\..\stage-builder\stage-builder\stage-builder\bin\Debug"); //doesn't handle multiple text files
                fileNames = Directory.GetFiles(sourcePath, "Orb.txt");
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

        public PuzzleOrb[] PuzzleOrbs
        {
            get
            {
                PuzzleOrb[] orb = new PuzzleOrb[puzzleOrbs.Count];
                for (int i = 0; i < puzzleOrbs.Count; i++)
                    orb[i] = puzzleOrbs[i];
                return orb;
            }
        }
        public Gates[] PuzzleGates
        {
            get
            {
                Gates[] gate = new Gates[puzzleGates.Count];
                for (int i = 0; i < puzzleGates.Count; i++)
                    gate[i] = puzzleGates[i];
                return gate;
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
                char prevCharacter = ' ';

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

                    #region Tile Creation
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
                    #endregion

                    #region Player Spawn
                    else if (character.Equals('P'))
                    {
                        // initializes player in the world
                        player = new Player(new Vector2(xpos, ypos)); //
                        Console.WriteLine("Player created: " + xpos + ", " + ypos);
                    }
                    #endregion

                    #region Enemy Spawning
                    // Enemy Spawning
                    // Red
                    else if (character.Equals('r')) //probably need to change this to spawn different colored enemies
                    {
                        enemies.Add(new Enemy(new Vector2(xpos, ypos), PaletteColor.Red));
                        Console.WriteLine("Red enemy created: " + xpos + ", " + ypos);
                    }
                    else if (character.Equals('y')) //probably need to change this to spawn different colored enemies
                    {
                        enemies.Add(new Enemy(new Vector2(xpos, ypos), PaletteColor.Yellow));
                        Console.WriteLine("Yellow enemy created: " + xpos + ", " + ypos);
                    }
                    else if (character.Equals('b')) //probably need to change this to spawn different colored enemies
                    {
                        enemies.Add(new Enemy(new Vector2(xpos, ypos), PaletteColor.Blue));
                        Console.WriteLine("Blue enemy created: " + xpos + ", " + ypos);
                    }
                    #endregion

                    #region Orb Creation
                    else if (character.Equals('R'))
                    {
                        puzzleOrbs.Add(new PuzzleOrb(new Vector2(xpos, ypos), PaletteColor.Red, prevCharacter));
                        Console.WriteLine("Red Orb(" + prevCharacter + ") " + "created: " + xpos + ", " + ypos);
                    }
                    else if (character.Equals('B'))
                    {
                        puzzleOrbs.Add(new PuzzleOrb(new Vector2(xpos, ypos), PaletteColor.Blue, prevCharacter));
                        Console.WriteLine("Blue Orb(" + prevCharacter + ") " + "created: " + xpos + ", " + ypos);
                    }
                    else if (character.Equals('Y'))
                    {
                        puzzleOrbs.Add(new PuzzleOrb(new Vector2(xpos, ypos), PaletteColor.Yellow, prevCharacter));
                        Console.WriteLine("Yellow Orb(" + prevCharacter + ") " + "created: " + xpos + ", " + ypos);
                    }
                    else if (character.Equals('O'))
                    {
                        puzzleOrbs.Add(new PuzzleOrb(new Vector2(xpos, ypos), PaletteColor.Orange, prevCharacter));
                        Console.WriteLine("Orange Orb(" + prevCharacter + ") " + "created: " + xpos + ", " + ypos);
                    }
                    else if (character.Equals('R'))
                    {
                        puzzleOrbs.Add(new PuzzleOrb(new Vector2(xpos, ypos), PaletteColor.Purple, prevCharacter));
                        Console.WriteLine("Purple Orb(" + prevCharacter + ") " + "created: " + xpos + ", " + ypos);
                    }
                    else if (character.Equals('G'))
                    {
                        puzzleOrbs.Add(new PuzzleOrb(new Vector2(xpos, ypos), PaletteColor.Green, prevCharacter));
                        Console.WriteLine("Green Orb(" + prevCharacter + ") " + "created: " + xpos + ", " + ypos);
                    }
                    else if (character.Equals('A'))
                    {
                        puzzleOrbs.Add(new PuzzleOrb(new Vector2(xpos, ypos), PaletteColor.Black, prevCharacter));
                        Console.WriteLine("Black Orb(" + prevCharacter + ") " + "created: " + xpos + ", " + ypos);
                    }
                    #endregion

                    #region Door
                    else if (character.Equals('/'))
                    {

                        puzzleGates.Add(new Gates(new Vector2(xpos, ypos), prevCharacter));

                        Console.WriteLine("Door(" + prevCharacter + ") " + "created: " + xpos + ", " + ypos);
                    }
                    // class not created yet

                    #endregion

                    #region Level End Orb
                    else if (character.Equals('0'))
                    {
                        // initializes end orb
                        // class not created yet
                    }
                    #endregion

                    else if ((character.Equals(' ')) || (reader.BaseStream.Position == reader.BaseStream.Length) || character.Equals('\r'))
                    {
                        if (i != 0)
                        {
                            collisionBoxes.Add(new Rectangle(startingPos, ypos, 64 * i, 50));
                            Console.WriteLine("CollisionBox added at: " + startingPos + " to " + 64 * i + startingPos);
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
                    prevCharacter = character;

                }

                // Linking the Orbs to the gates
                foreach(Gates gate in puzzleGates)
                {
                    foreach(PuzzleOrb orb in puzzleOrbs)
                    {
                        if(gate.DoorNum == orb.OrbNum)
                        {
                            gate.PuzzleVariables.Add(orb);
                        }
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
