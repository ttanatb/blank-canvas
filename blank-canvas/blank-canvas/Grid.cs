using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace blank_canvas
{
    /// <summary>
    /// This is the data structure that will hold all the grid positions of the tiles in the map
    /// </summary>
    class Grid
    {
        Tile[,] grid;
        Tile tile;

        public Grid()
        {
            grid = new Tile[0, 0];
        }

        /*
        in a 2d array like this
        a, b, c
        d, e, f

            [0,0] = a
            [2,3] = f
            [3,2] = error

            GetLength(0) number of rows
            GetLength(1) number of columns
        */

        private Tile CreateTile(int row, int column)
        {
            return new Tile(new Vector2(column * 64, row * 64));
        }

        public void AddTile(int x, int y)
        {
            int rowNum = y + 1;
            int columnNum = x + 1;


            if ((rowNum > grid.GetLength(0)) && (columnNum > grid.GetLength(1)))
            {
                Tile[,] tempGrid = new Tile[rowNum, columnNum];
                for (int i = 0; i < tempGrid.GetLength(0); i++)
                {
                    for (int j = 0; j < tempGrid.GetLength(1); j++)
                    {
                        try
                        {
                            tempGrid[i, j] = grid[i, j];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Tile t = null;
                            tempGrid[i, j] = t;
                        }
                    }
                }
                grid = tempGrid;
            }
            else if (columnNum > grid.GetLength(1))
            {
                Tile[,] tempGrid = new Tile[grid.GetLength(0), columnNum];

                //files in the row and column
                for (int i = 0; i < tempGrid.GetLength(0); i++)
                {
                    for (int j = 0; j < tempGrid.GetLength(1); j++)
                    {
                        try
                        {
                            tempGrid[i, j] = grid[i, j];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Tile t = null;
                            tempGrid[i, j] = t;
                        }
                    }
                }
                grid = tempGrid;
            }
            else if (rowNum > grid.GetLength(0))
            {
                Tile[,] tempGrid = new Tile[rowNum, grid.GetLength(1)];

                //files in the row and column
                for (int i = 0; i < tempGrid.GetLength(0); i++)
                {
                    for (int j = 0; j <tempGrid.GetLength(1); j++)
                    {
                        try
                        {
                            tempGrid[i, j] = grid[i, j];
                        }
                        catch(IndexOutOfRangeException)
                        {
                            Tile t = null;
                            tempGrid[i, j] = t;
                        }
                    }
                }
                grid = tempGrid;
            }

            grid[rowNum - 1, columnNum - 1] = CreateTile(rowNum, columnNum);
        }

        public void LoadContent(ContentManager content, string tileTexture)
        {
            foreach(Tile t in grid)
            {
                if (t != null)
                    t.Texture = content.Load<Texture2D>(tileTexture);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile t in grid)
            {
                if (t != null)
                    t.Draw(spriteBatch);
            }
        }

        public Tile SearchNearestTileInRow(int row, int columnPos, Direction facingDirection)
        {
            Tile t = grid[row, columnPos];

            int i = row;
            if (facingDirection == Direction.Left)
            {
                do
                {
                    i--;
                    t = grid[i, columnPos];
                }
                while (t == null);
            }
            else
            {
                do
                {
                    i++;
                    t = grid[i, columnPos];
                }
                while (t == null);
            }

            return t;
        }
    }
}
