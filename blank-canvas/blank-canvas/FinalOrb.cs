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
    /// The final orb can be shot (painted) multiple times by the player. 
    /// If it matches the key color, then the level changes. 
    /// The orb fills up, ultimately filling the world with color.
    /// </summary>
    class FinalOrb : GameObject
    {
        #region Variables
        const int WIDTH = 192;
        const int HEIGHT = 192;

        const int HORIZONTAL_OFFSET = 5;
        const int VERTICAL_OFFSET = 4;

        int progress = 0;           // keeps track of the orb completion progress

        Palette palette;            //manages the color
        PaletteColor colorKey;      //the key required to solve the orb

        Rectangle orbCollisionBox;
        PuzzleState state;
        #endregion

        #region Properties
        public PaletteColor CurrentColor
        {
            get { return palette.CurrentColor; }
        }

        public Rectangle CollisionBox
        {
            get { return orbCollisionBox; }
        }

        public PuzzleState State
        {
            get { return state; }
        }

        public int Progress
        {
            get { return progress; }
            set { progress = value; }
        }
        #endregion

        #region Constructors
        public FinalOrb(Vector2 position, PaletteColor key) : base(new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT))
        {
            // Sets the puzzle orb position
            palette = new Palette(PaletteColor.White);
            orbCollisionBox = new Rectangle((int)X + VERTICAL_OFFSET,
                (int)Y + HORIZONTAL_OFFSET,
                WIDTH - 2 * VERTICAL_OFFSET,
                HEIGHT - 2 * HORIZONTAL_OFFSET);

            // Sets the key for the orb to solve the puzzle
            colorKey = key;
            state = PuzzleState.Active;
        }
        #endregion

        #region Methods

        /// <summary>
        /// When the projectile hits the puzzle orb, color is added to the palette
        /// </summary>
        public bool AddColor(Projectile projectile)
        {
            return palette.AddColor(projectile.ProjectileColor);
        }

        /// <summary>
        /// Updates the check if the color matches the key
        /// </summary>
        public void Update()
        {
            if (state == PuzzleState.Active)
            {
                if (CurrentColor == colorKey)
                {
                    if (progress == 5)
                    {
                        state = PuzzleState.Completed;
                    }
                }
            }
        }

        /// <summary>
        /// Draw is based on the current color
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (state == PuzzleState.Active || state == PuzzleState.Completed)
            {
                //this draws the actual orb and tints it accordingly
                int a = alpha * 3 / 4; //this makes it fade a bit

                if (state != PuzzleState.Completed)
                {
                    while (progress != 5)
                    {
                        switch (colorKey)
                        {
                            case (PaletteColor.Red):
                                spriteBatch.Draw(texture, Rectangle, new Rectangle(WIDTH * (progress + 1), 0 , WIDTH, HEIGHT), new Color(alpha, 0, 0, 100));
                                break;
                            case (PaletteColor.Blue):
                                spriteBatch.Draw(texture, Rectangle, new Rectangle(WIDTH * (progress + 1), 0, WIDTH, HEIGHT), new Color(0, 0, alpha, 100));
                                break;
                            case (PaletteColor.Yellow):
                                spriteBatch.Draw(texture, Rectangle, new Rectangle(WIDTH * (progress + 1), 0, WIDTH, HEIGHT), new Color(alpha, alpha, 0, 100));
                                break;
                        }
                        progress++;
                    }
                }
                //draws the base of the actual sprite

                spriteBatch.Draw(texture, Rectangle, new Rectangle(0, 0, WIDTH, HEIGHT), Color.White);

            }
        }
        #endregion
    }
}
