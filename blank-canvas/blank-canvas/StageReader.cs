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
        Level levelEnum;

        Player player;
        List<Tile> tiles;
        List<SpecialTile> sTiles;
        List<Enemy> enemies;
        List<Rectangle> collisionBoxes;
        List<PuzzleOrb> puzzleOrbs;
        List<Gates> puzzleGates;
        FinalOrb finalOrb;

        // position counter
        int xpos;
        int ypos;

        string title;

        // constructor that gets string
        public StageReader(int level)
        {
            //instantiates everything
            enemies = new List<Enemy>();
            tiles = new List<Tile>();
            sTiles = new List<SpecialTile>();
            collisionBoxes = new List<Rectangle>();
            puzzleOrbs = new List<PuzzleOrb>();
            puzzleGates = new List<Gates>();
            levelEnum = (Level)level;

            try
            {
                //goes to the directory
                sourcePath = Path.GetFullPath(@"..\..\..\..\..\blank-canvas\blank-canvas\Content\stage"); // Correct Path

                // Added this code for different levels

                fileNames = new string[6];

                string[]files = Directory.GetFiles(sourcePath);
                for(int i = 1; i <= fileNames.Length; i++)
                {
                    Console.WriteLine("i is " + i);
                    for(int j = 0; j < files.Length; j++)
                    {
                        char b = files[j][files[j].Length - 5];
                        char a = i.ToString().ToCharArray()[0];
                        if (b.Equals(a))
                        {
                            fileNames[i-1] = files[j];
                            break;
                        }
                    }
                }
                
                foreach(string s in fileNames)
                    Console.WriteLine(s);
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

        public SpecialTile[] STile
        {
            get
            {
                SpecialTile[] sT = new SpecialTile[sTiles.Count];
                for (int i = 0; i < sTiles.Count; i++)
                    sT[i] = sTiles[i];
                return sT;
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

        public FinalOrb FinalOrb
        {
            get { return finalOrb; }
        }

        public Level LevelEnum
        {
            get { return levelEnum; }
            set { levelEnum = value; }
        }
        #endregion

        // reads in file
        public void ReadFile(int lvl)
        {
            BinaryReader reader = null;

            tiles.Clear();
            sTiles.Clear();
            enemies.Clear();
            collisionBoxes.Clear();
            puzzleOrbs.Clear();
            puzzleGates.Clear();


            try
            {
                //does reader thing
                reader = new BinaryReader(File.OpenRead(fileNames[lvl]));
                char character;
                char prevCharacter = ' ';

                levelEnum = (Level)lvl ;
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


                reader.ReadChar(); //reads away the '\n'

                // counts the position in the binary reader
                xpos = 0;
                ypos = 0;
                int collisionTileLength = 0;
                int startingPos = 0;

                // checks to see if the current position is equal to the length of the text file
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {

                    character = reader.ReadChar();

                    #region Tile Creation
                    if (character.Equals('_') || character.Equals('|') || character.Equals('-') || character.Equals('~'))
                    {
                        // Determines the type of tile that needs to be built
                        TileType TT;

                        if (character.Equals('_')) // Ground Tile "_"
                        {
                            TT = TileType.Ground;
                        }
                        else if (character.Equals('|')) // Wall Tile "|"
                        {
                            TT = TileType.Wall;
                        }
                        else if (character.Equals('-')) // Floor Tile "-"
                        {
                            TT = TileType.Floor;
                        }
                        else if (character.Equals('~')) // Theme Tile "~"
                        {
                            TT = TileType.Theme;
                        }                        
                        else // By default spawned to a ground tile
                        {
                            TT = TileType.Ground;
                        }

                        Tile tile = new Tile(new Vector2(xpos, ypos), TT, (Level)lvl);
                        tiles.Add(tile);

                        /*
                        // initializes new ground tile
                        if (levelEnum == blank_canvas.Level.Desert)
                        {
                            
                        }
                        else if (levelEnum == blank_canvas.Level.Ice_Caves)
                        {
                            Tile tile = new Tile(new Vector2(xpos, ypos), TT, blank_canvas.Level.Ice_Caves);
                            tiles.Add(tile);
                        }
                        else if(levelEnum == blank_canvas.Level.Forest)
                        {
                            Tile tile = new Tile(new Vector2(xpos, ypos), TT, blank_canvas.Level.Forest);
                            tiles.Add(tile);
                        }
                        else if(levelEnum == blank_canvas.Level.Mountain)
                        {
                            Tile tile = new Tile(new Vector2(xpos, ypos), TT, blank_canvas.Level.Mountain);
                            tiles.Add(tile);
                        }
                        else if(levelEnum == blank_canvas.Level.Castle)
                        {
                            Tile tile = new Tile(new Vector2(xpos, ypos), TT, blank_canvas.Level.Castle);
                            tiles.Add(tile);
                        }
                        else
                        {
                            Tile tile = new Tile(new Vector2(xpos, ypos), TT, blank_canvas.Level.Mountain);
                            tiles.Add(tile);
                        }
                        */
                            Console.WriteLine("Tile created: " + xpos + ", " + ypos);

                        if (collisionTileLength == 0)
                            startingPos = xpos;

                        collisionTileLength++;
                    }
                    #endregion

                    #region Special Tile Creation
                    if (character.Equals('?') || character.Equals('!') || character.Equals('*'))
                    {
                        TileType TT;

                        if (character.Equals('?'))
                        {
                            TT = TileType.Blank;
                        }
                        else if (character.Equals('!'))
                        {
                            TT = TileType.Hazard;
                        }
                        else // '*'
                        {
                            TT = TileType.EnemyBlockTile;
                        }

                        SpecialTile sTile = new SpecialTile(new Vector2(xpos, ypos), TT, (Level)lvl);
                        sTiles.Add(sTile);

                        Console.WriteLine("Special Tile created: " + xpos + ", " + ypos);

                        
                    }
                    #endregion

                    #region Player Spawn
                    else if (character.Equals('$'))
                    {
                        // initializes player in the world
                        player = new Player(new Vector2(xpos, (ypos - 64))); //
                        Console.WriteLine("Player created: " + xpos + ", " + (ypos - 64));
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
                    else if (character.Equals('P'))
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

                        puzzleGates.Add(new Gates(new Vector2(xpos, ypos - 64), prevCharacter));

                        Console.WriteLine("Door(" + prevCharacter + ") " + "created: " + xpos + ", " + (ypos - 64));
                    }
                    // class not created yet

                    #endregion

                    #region Level End Orb
                    else if (character.Equals('@'))
                    {
                        if (prevCharacter.Equals('1'))
                        {
                            finalOrb = new FinalOrb(new Vector2(xpos - 64, ypos - 128), PaletteColor.Yellow);
                            Console.WriteLine("Final Red Orb created: " + xpos + ", " + (ypos - 128));
                        }
                        if (prevCharacter.Equals('2'))
                        {
                            finalOrb = new FinalOrb(new Vector2(xpos - 64, ypos - 128), PaletteColor.Blue);
                            Console.WriteLine("Final Blue Orb created: " + xpos + ", " + (ypos - 128));
                        }
                        if (prevCharacter.Equals('3'))
                        {
                            finalOrb = new FinalOrb(new Vector2(xpos - 64, ypos - 128), PaletteColor.Red);
                            Console.WriteLine("Final Yellow Orb created: " + xpos + ", " + (ypos - 128));
                        }
                    }
                    #endregion

                    
                    if (character.Equals(' ')                        
                        || character.Equals('*') // Enemy Special Block
                        || character.Equals('?') // Blank Canvas Block
                        || character.Equals('!') // Hazard Block
                        || character.Equals('$') // Player Spawn
                        || character.Equals('y') // Yellow Enemy
                        || character.Equals('r') // Red Enemy
                        || character.Equals('b') // Blue Enemy
                        || character.Equals('B') // Blue Orb
                        || character.Equals('R') // Red Orb
                        || character.Equals('Y') // Yellow Orb
                        || character.Equals('G') // Green Orb
                        || character.Equals('O') // Orange Orb
                        || character.Equals('P') // Purple Orb
                        || character.Equals('A') // Black Orb
                        || character.Equals('/') // Door
                        || (reader.BaseStream.Position == reader.BaseStream.Length) 
                        || character.Equals('\r'))
                    {
                        if (collisionTileLength != 0)
                        {
                            collisionBoxes.Add(new Rectangle(startingPos, ypos, 64 * collisionTileLength, 50));
                            Console.WriteLine("CollisionBox added at: " + startingPos + " to " + 64 * collisionTileLength + startingPos);
                            collisionTileLength = 0;
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
                foreach (Gates gate in puzzleGates)
                {
                    foreach (PuzzleOrb orb in puzzleOrbs)
                    {
                        if (gate.DoorNum == orb.OrbNum)
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
