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
    /// The basic enemy class
    /// </summary>
    class Enemy : Character
    {
        #region fields

        const float MOVESPEED = 100f;
        const double PAUSE_TIME = 2000.0; //the amount of time to take for pausing

        const int WIDTH = 64;
        const int HEIGHT = 64;

        #endregion

        #region variables

        Palette palette;
        Random rndm;
        bool active;

        #endregion

        #region properties

        /// <summary>
        /// The current color based on the palette
        /// </summary>
        public PaletteColor CurrentColor
        {
            get { return palette.CurrentColor; }
        }

        /// <summary>
        /// Wether or not is the enemy active
        /// </summary>
        public bool Active
        {
            get { return active; }
        }

        #endregion

        #region constructor
        public Enemy(Vector2 position, PaletteColor color) : base(new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT))
        {
            //instantializing the variables
            palette = new Palette(color);
            rndm = new Random();
            active = true;
        }
        #endregion

        #region methods
        /// <summary>
        /// Updates the position of the enemy based on the velocity and direction
        /// </summary>
        /// <param name="deltaTime">The time since the last update</param>
        public void Update(double deltaTime)
        {
            //checks to make sure that it is active
            if (active)
            {
                velocity.X = (int)direction * MOVESPEED;
                UpdatePos(deltaTime);
            }
        }

        /// <summary>
        /// Changes the direction
        /// </summary>
        public void ChangeDirection()
        {
            direction = (Direction)(-1 * (int)direction);
        }

        /// <summary>
        /// Resets the color of the enemy
        /// </summary>
        /// <returns>The current color of the enemy</returns>
        public PaletteColor DrainColor()
        {
            //sets the enemy inactive
            active = false;

            //get the color from the palette
            PaletteColor color = CurrentColor;

            //reset the palette
            palette.ResetColor();

            //return the color from the palette
            return color; 
        }

        /// <summary>
        /// Reinvigorates the enemy with a projectile
        /// </summary>
        /// <param name="projectile">The projectile to add the color</param>
        public void AddColor(Projectile projectile)
        {
            palette.AddColor(projectile.ProjectileColor);
        }

        /// <summary>
        /// Draw the enemy based on its current color
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            //sprite effect that reflect the direction that the enemy is facing
            SpriteEffects spriteEffects;
            Color color;
            if (direction == Direction.Right)
                spriteEffects = SpriteEffects.None;
            else spriteEffects = SpriteEffects.FlipHorizontally;

            //the overlaying color is based on the palette
            switch (CurrentColor)
            {
                case (PaletteColor.Red):
                    color = new Color(alpha, 0, 0, alpha);
                    break;
                case (PaletteColor.Blue):
                    color = new Color(0, 0, alpha, alpha);
                    break;
                case (PaletteColor.Yellow):
                    color = new Color(alpha, alpha, 0, alpha);
                    break;
                default:
                    color = new Color(alpha, alpha, alpha, alpha);
                    break;
            }

            //actual draw method
            spriteBatch.Draw(texture, Rectangle, new Rectangle(0, 0, width, height), color, 0f, Vector2.Zero, spriteEffects, 1);

        }
        #endregion
    }
}

