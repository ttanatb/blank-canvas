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

        const int TOP_OFFSET = 22;
        const int BOTTOM_OFFSET = 70;
        const int SIDE_OFFSET = 52;

        int progress;           // keeps track of the orb completion progress

        PaletteColor colorKey;      //the key required to solve the orb
        PuzzleState state;

        Rectangle orbCollisionBox;
        #endregion

        #region Properties
        public Rectangle CollisionBox
        {
            get { return orbCollisionBox; }
        }
        public int Progress
        {
            get { return progress; }
            set { progress = value; }
        }
        public PuzzleState PuzzleState
        {
            get { return state; }
        }

        #endregion

        #region Constructors
        public FinalOrb(Vector2 position, PaletteColor key) : base(new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT))
        {
            // Sets the puzzle orb position
            orbCollisionBox = new Rectangle((int)X + SIDE_OFFSET,
                (int)Y + TOP_OFFSET,
                WIDTH - 2 * SIDE_OFFSET,
                HEIGHT - (TOP_OFFSET + BOTTOM_OFFSET));

            // Sets the key for the orb to solve the puzzle
            colorKey = key;
            progress = 0;
            state = PuzzleState.Active;
        }
        #endregion

        #region Methods

        /// <summary>
        /// When the projectile hits the puzzle orb, color is added to the palette
        /// </summary>
        public bool AddColor(Projectile projectile)
        {
            if (projectile.ProjectileColor == colorKey && progress < 5)
                return true;
            else return false;
        }

        /// <summary>
        /// Updates the check if the color matches the key
        /// </summary>
        public void Update()
        {
            if (state == PuzzleState.Active)
            {
                if (progress == 4)
                {
                    state = PuzzleState.Completed;
                }
            }
        }

        /// <summary>
        /// Draw is based on the current color
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            //this draws the actual orb and tints it accordingly
            int a = alpha * 3 / 4; //this makes it fade a bit


                switch (colorKey)
                {
                    case (PaletteColor.Red):
                        spriteBatch.Draw(texture, Rectangle, new Rectangle(WIDTH * (progress + 1), 0, WIDTH, HEIGHT), new Color(alpha, 0, 0, 100));
                        break;
                    case (PaletteColor.Blue):
                        spriteBatch.Draw(texture, Rectangle, new Rectangle(WIDTH * (progress + 1), 0, WIDTH, HEIGHT), new Color(0, 0, alpha, 100));
                        break;
                    case (PaletteColor.Yellow):
                        spriteBatch.Draw(texture, Rectangle, new Rectangle(WIDTH * (progress + 1), 0, WIDTH, HEIGHT), Color.Yellow);
                        break;
                }

            //draws the base of the actual sprite

            spriteBatch.Draw(texture, Rectangle, new Rectangle(0, 0, WIDTH, HEIGHT), Color.White);

        }
        #endregion
    }
}
