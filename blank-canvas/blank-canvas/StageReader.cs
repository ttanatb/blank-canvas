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
        List<Tile> t;
        // creates player
        Player p;
        // creates enemy
        List<Enemy> e;

        // position counter
        int pos;

        // constructor that gets string
        public StageReader()
        {
            e = new List<Enemy>();
            t = new List<Tile>();

            try
            {
                sourcePath = Path.GetFullPath(@"..\..\..\..\..\stage-builder\stage-builder\stage-builder\bin\Debug");
                filename = Directory.GetFiles(sourcePath, "*.txt");
                //Console.WriteLine(sourcePath + "\n" + filename[0]);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(sourcePath);
                Console.WriteLine("Error. Press any key.");
            }

        }

        // reads in file
        public void ReadFile()
        {
            BinaryReader reader = null;
            try
            {
                reader = new BinaryReader(File.OpenRead(filename[0]));
                //reader.ReadString();
                //reader.ReadInt32();

                // counts the position in the binary reader
                pos = 0;

                // checks to see if the current position is equal to the length of the text file
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    char character = reader.ReadChar();

                    if (character.Equals('_'))
                    {
                        int y = 8;
                        int prevX = 0;
                        if (prevX == pos)
                        {

                        }
                        // initializes new ground tile
                        t.Add(new Tile(new Vector2(pos * 64, y * 64)));
                    }
                    else if (character.Equals('P'))
                    {
                        // initializes player in the world
                        p = new Player(new Rectangle(20, -200, 100, 100)); //
                    }
                    else if (character.Equals('E'))
                    {
                        // initializes enemy
                        // e[pos] = new Enemy(new Rectangle(20, 40, 100, 100));

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
                    else
                    {
                        // do nothing
                    }
                    //this should be where the world is generated?
                    //make sure the whole thing doesn't like exist in one line
                    pos++;
                }

                t.Add(new Tile(new Vector2((pos-3) * 64, 7 * 64)));
                t.Add(new Tile(new Vector2((pos-7) * 64, 5 *64)));

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

        public Tile[] Tile
        {
            get
            {
                Tile[] tile = new Tile[t.Count];
                for (int i = 0; i < t.Count; i++)
                    tile[i] = t[i];
                return tile;
            }
        }
    }
}
