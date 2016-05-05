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

        const int WIDTH = 64;
        const int HEIGHT = 64;

        const double FRAME_TIMER = 0.2;

        const int SIDE_MARGIN = 9;
        const int TOP_MARGIN = 9;
        const int BOTTOM_MARGIN = 9;
        #endregion

        #region variables

        Palette palette;
        Random rndm;
        bool active;
        int frame;
        double timer;

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

        public Rectangle CollisionRect
        {
            get { return new Rectangle((int)X + SIDE_MARGIN, (int)Y + TOP_MARGIN, WIDTH - SIDE_MARGIN, Height - BOTTOM_MARGIN); }
        }

        #endregion

        #region constructor
        public Enemy(Vector2 position, PaletteColor color) : base(new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT))
        {
            //instantializing the variables
            palette = new Palette(color);
            rndm = new Random();
            active = true;
            frame = 0;
            timer = 0;
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

                timer += deltaTime;

                if (timer > FRAME_TIMER)
                {
                    if (frame == 0)
                        frame = 1;
                    else frame = 0;
                    timer = 0;
                }
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
            active = true;
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
                    color = new Color(205, 92, 92, 255);
                    break;
                case (PaletteColor.Blue):
                    color = new Color(70, 130, 180, 255);
                    break;
                case (PaletteColor.Yellow):
                    color = new Color(255, 255, 51, 255);
                    break;
                default:
                    color = new Color(255, 255, 255, 255);
                    break;
            }

            //actual draw method
            spriteBatch.Draw(texture, Rectangle, new Rectangle(frame * width, 0, width, height), color, 0f, Vector2.Zero, spriteEffects, 1);

        }
        #endregion
    }
}

