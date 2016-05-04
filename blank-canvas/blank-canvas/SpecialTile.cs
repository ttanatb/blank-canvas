using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace blank_canvas
{
    class SpecialTile: GameObject
    {
        #region fields
        const int WIDTH = 64;
        const int HEIGHT = 64;
        Level level;
        PuzzleState activeState;
        TileType tileType;
        #endregion

        #region Properties
        public PuzzleState ActiveState
        {
            get { return activeState; }
            set { activeState = value; }
        }

        public TileType TileType
        {
            get { return tileType; }
        }
        #endregion

        #region Constructor
        public SpecialTile(Vector2 position, TileType TT, Level l):base(new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT))
        {
            // Blank Canvas Block
            activeState = PuzzleState.Inactive;
        }
        #endregion

        #region Methods
        public override void Draw(SpriteBatch spriteBatch)
        {
            switch (level) // Determines the type of tiles are loaded in based on the level
            {
                #region Level1Desert
                case Level.Desert:
                    switch (tileType)
                    {
                        case TileType.Hazard:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(4 * WIDTH, 0 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                        case TileType.Blank:
                            if (activeState == PuzzleState.Inactive)
                            {
                                spriteBatch.Draw(texture, Rectangle, new Rectangle(0 * WIDTH, 5 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            }
                            else
                            {
                                spriteBatch.Draw(texture, Rectangle, new Rectangle(2 * WIDTH, 0 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            }
                            break;
                    }
                    break;
                #endregion

                #region Level2IceCaves
                case Level.Ice_Caves:
                    switch (tileType)
                    {
                        case TileType.Hazard:
                            spriteBatch.Draw(texture, Rectangle, new Rectangle(4 * WIDTH, 1 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            break;
                        case TileType.Blank:
                            if (activeState == PuzzleState.Inactive)
                            {
                                spriteBatch.Draw(texture, Rectangle, new Rectangle(0 * WIDTH, 5 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            }
                            else
                            {
                                spriteBatch.Draw(texture, Rectangle, new Rectangle(2 * WIDTH, 1 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            }
                            break;
                    }
                    break;
                #endregion

                #region Level3Forest
                case Level.Forest:
                    switch (tileType)
                    {
                        case TileType.Blank:
                            if (activeState == PuzzleState.Inactive)
                            {
                                spriteBatch.Draw(texture, Rectangle, new Rectangle(0 * WIDTH, 5 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            }
                            else
                            {
                                spriteBatch.Draw(texture, Rectangle, new Rectangle(2 * WIDTH, 2 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            }
                            break;
                    }
                    break;
                #endregion

                #region Level4Mountain
                case Level.Mountain:
                    {
                        switch (tileType)
                        {
                            case TileType.Hazard:
                                spriteBatch.Draw(texture, Rectangle, new Rectangle(4 * WIDTH, 3 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                                break;
                            case TileType.Blank:
                                if (activeState == PuzzleState.Inactive)
                                {
                                    spriteBatch.Draw(texture, Rectangle, new Rectangle(0 * WIDTH, 5 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                                }
                                else
                                {
                                    spriteBatch.Draw(texture, Rectangle, new Rectangle(2 * WIDTH, 3 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                                }
                                break;
                        }
                        break;
                    }
                #endregion

                #region Level5Castle
                case Level.Castle:
                    switch (tileType)
                    {
                        case TileType.Blank:
                            if (activeState == PuzzleState.Inactive)
                            {
                                spriteBatch.Draw(texture, Rectangle, new Rectangle(0 * WIDTH, 5 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            }
                            else
                            {
                                spriteBatch.Draw(texture, Rectangle, new Rectangle(2 * WIDTH, 4 * HEIGHT, WIDTH, HEIGHT), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                            }
                            break;
                    }
                    break;
                    #endregion
            }
        }
        #endregion
    }
}
