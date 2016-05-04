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

        int orbNum;
        Palette palette;            //manages the color
        PaletteColor colorKey;      //the key required to solve the orb
        PuzzleState state;

        Texture2D orbTexture;
        Texture2D orbGlow;
        Vector2 orbPosition;
        Rectangle orbCollisionBox;
        #endregion

        #region Properties
        public Texture2D OrbTexture
        {
            set { orbTexture = value; }
        }

        public Texture2D OrbGlowTexture
        {
            set { orbGlow = value; }
        }

        public PaletteColor CurrentColor
        {
            get { return palette.CurrentColor; }
        }

        public Rectangle CollisionBox
        {
            get { return orbCollisionBox; }
        }

        public PuzzleState PuzzleState
        {
            get { return state; }
        }

        public int OrbNum
        {
            get { return orbNum; }
        }
        #endregion

        #region Constructors
        public FinalOrb(Vector2 position, PaletteColor key, char prevChar) :base(new Rectangle((int)position.X, (int)position.Y,WIDTH, HEIGHT))
        {
            // Sets the puzzle orb position
            palette = new Palette(PaletteColor.White);
            orbPosition = new Vector2(position.X + 13, position.Y + 11);
            orbCollisionBox = new Rectangle((int)orbPosition.X + VERTICAL_OFFSET,
                (int)orbPosition.Y + HORIZONTAL_OFFSET,
                WIDTH - 2 * VERTICAL_OFFSET,
                HEIGHT - 2 * HORIZONTAL_OFFSET);

            // Sets the key for the orb to solve the puzzle
            orbNum = Convert.ToInt32(prevChar);
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
                    state = PuzzleState.Completed;
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
                    switch (colorKey)
                    {
                        case (PaletteColor.Red):
                            spriteBatch.Draw(orbGlow, position, new Color(alpha, 0, 0, 100));
                            break;
                        case (PaletteColor.Blue):
                            spriteBatch.Draw(orbGlow, position, new Color(0, 0, alpha, 100));
                            break;
                        case (PaletteColor.Yellow):
                            spriteBatch.Draw(orbGlow, position, new Color(alpha, alpha, 0, 100));
                            break;
                    }
                }

                //draws the base of the actual sprite
                base.Draw(spriteBatch);

                switch (CurrentColor)
                {
                    case (PaletteColor.Red):
                        spriteBatch.Draw(orbTexture, position, new Color(alpha, 0, 0, a));
                        break;
                    case (PaletteColor.Blue):
                        spriteBatch.Draw(orbTexture, position, new Color(0, 0, alpha, a));
                        break;
                    case (PaletteColor.Yellow):
                        spriteBatch.Draw(orbTexture, position, new Color(alpha, alpha, 0, a));
                        break;
                }
            }
        }
        #endregion
    }
}
