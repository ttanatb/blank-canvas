using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace blank_canvas
{
    /// <summary>
    /// A basic tile that makes up the walls and floors
    /// </summary>
    class Tile : GameObject
    {
        #region fields

        const int WIDTH = 64;
        const int HEIGHT = 64;
        Level level;
        TileType tileType;

        #endregion

        #region constructors

        /// <param name="position">X and Y coordinates of top-left corner</param>
        public Tile(Vector2 position, TileType TT, Level l) : base(new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT))
        {
            level = l;
            tileType = TT;
        }

        #endregion

        #region Methods
        // Updating the Draw method based on the level this is a work in progress
        public override void Draw(SpriteBatch spriteBatch)
        {
            switch (level) // Determines the type of tiles are loaded in based on the level
            {
                #region Level1Desert
                case Level.Desert:
                    switch (tileType)
                    {
                        case TileType.Ground:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(0 * WIDTH, 0 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                        case TileType.Floor:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(1 * WIDTH, 0 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                        case TileType.Wall:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(2 * WIDTH, 0 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                        case TileType.Theme:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(3 * WIDTH, 0 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                    }
                    break;
                #endregion

                #region Level2IceCaves
                case Level.Ice_Caves:
                    switch (tileType)
                    {
                        case TileType.Ground:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(0 * WIDTH, 1 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                        case TileType.Floor:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(1 * WIDTH, 1 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                        case TileType.Wall:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(2 * WIDTH, 1 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                        case TileType.Theme:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(3 * WIDTH, 1 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                    }
                    break;
                #endregion

                #region Level3Forest
                case Level.Forest:
                    switch (tileType)
                    {
                        case TileType.Ground:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(0 * WIDTH, 2 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                        case TileType.Floor:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(1 * WIDTH, 2 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                        case TileType.Wall:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(2 * WIDTH, 2 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                        case TileType.Theme:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(3 * WIDTH, 2 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                    }
                    break;
                #endregion

                #region Level4Mountain
                case Level.Mountain:
                    switch (tileType)
                    {
                        case TileType.Ground:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(0 * WIDTH, 3 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                        case TileType.Floor:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(1 * WIDTH, 3 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                        case TileType.Wall:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(2 * WIDTH, 3 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                        case TileType.Theme:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(3 * WIDTH, 3 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                    }
                    break;
                #endregion

                #region Level5Castle
                case Level.Castle:
                    switch (tileType)
                    {
                        case TileType.Ground:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(0 * WIDTH, 4 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                        case TileType.Floor:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(1 * WIDTH, 4 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                        case TileType.Wall:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(2 * WIDTH, 4 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                        case TileType.Theme:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(3 * WIDTH, 4 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                    }
                    break;
                    #endregion

            }

            #endregion

        }
    }
}
