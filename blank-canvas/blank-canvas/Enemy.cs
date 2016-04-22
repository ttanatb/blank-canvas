using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*
    Class: Enemy
    Purpose: creates enemy and all movement required for it
*/

namespace blank_canvas
{
    /// <summary>
    /// The basic enemy class
    /// </summary>
    class Enemy : Character
    {
        #region Variables
        new const float MOVESPEED = 100f;
        const double PAUSE_TIME = 2000.0;
        const int WIDTH = 64;
        const int HEIGHT = 64;

        Palette palette;
        Random rndm;
        bool active;

        #endregion

        #region Properties

        public PaletteColor CurrentColor
        {
            get { return palette.CurrentColor; }
        }

        public bool Active
        {
            get { return active; }
        }

        #endregion

        #region Constructor
        //constructor
        public Enemy(Vector2 position, PaletteColor color) : base(new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT))
        {
            palette = new Palette(color);

            rndm = new Random();
            active = true;
        }
        #endregion

        #region methods
        //methods
        public void Update(double deltaTime)
        {
            if (active)
            {
                velocity.X = (int)direction * MOVESPEED;
                UpdatePos(deltaTime);
            }
        }

        public void ChangeDirection()
        {
            direction = (Direction)(-1 * (int)direction);
        }

        public PaletteColor DrainColor()
        {
            active = false;
            PaletteColor color = CurrentColor;
            palette.ResetColor();
            return color;
        }

        public bool AddColor(Projectile projectile)
        {
            active = true;
            return palette.AddColor(projectile.ProjectileColor);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            int a = alpha * 3 / 4;

            if (!active)
                a = a / 8;
             
            switch (CurrentColor)
            {
                case (PaletteColor.Red):
                    spriteBatch.Draw(texture, position, new Color(alpha, 0, 0, a));
                    break;
                case (PaletteColor.Blue):
                    spriteBatch.Draw(texture, position, new Color(0, 0, alpha, a));
                    break;
                case (PaletteColor.Yellow):
                    spriteBatch.Draw(texture, position, new Color(alpha, alpha, 0, a));
                    break;
                case (PaletteColor.Orange):
                    spriteBatch.Draw(texture, position, new Color(alpha, alpha / 2, 0, a));
                    break;
                case (PaletteColor.Green):
                    spriteBatch.Draw(texture, position, new Color(0, alpha, 0, a));
                    break;
                case (PaletteColor.Purple):
                    spriteBatch.Draw(texture, position, new Color(alpha / 2, 0, alpha / 2, a));
                    break;
                case (PaletteColor.Black):
                    spriteBatch.Draw(texture, position, new Color(0, 0, 0, alpha));
                    break;
                case (PaletteColor.White):
                    spriteBatch.Draw(texture, position, new Color(alpha, alpha, alpha, alpha));
                    break;
            }
        }
        #endregion
    }
}

