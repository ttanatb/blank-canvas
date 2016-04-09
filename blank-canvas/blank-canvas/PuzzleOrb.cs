using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace blank_canvas
{
    class PuzzleOrb : GameObject
    {
        #region Variables
        const int WIDTH = 64;
        const int HEIGHT = 64;
        Palette palette;
        PaletteColor currentColor;
        PaletteColor colorKey;
        bool active;

        Texture2D orbTexture;
        Vector2 orbPosition;
        #endregion

        #region Properties

        public Texture2D OrbTexture
        {
            set { orbTexture = value; }
        }
        #endregion

        #region Constructors
        public PuzzleOrb(Vector2 position, PaletteColor key):base(new Rectangle((int)position.X, (int)position.Y,WIDTH, HEIGHT))
        {
            // Sets the puzzle orb position
            palette = new Palette();
            orbPosition = new Vector2(position.X + 13, position.Y + 11);
            currentColor = PaletteColor.White;

            // Sets the key for the orb to solve the puzzle
            colorKey = key;
            active = true;
        }
        #endregion

        #region Methods
        public void ChangeColor(Projectile projectile)
        {
            palette.AddColor(projectile.ProjectileColor);
        }

        public PaletteColor TakeColor()
        {
            PaletteColor color = palette.GetColor();
            palette.ResetColor();
            return color;
        }

        public void Update()
        {
            if (active)
            {
                currentColor = palette.GetColor();
                if (currentColor == colorKey)
                {
                    active = false;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            /*
                    Red = 2,
        Blue = 3,
        Yellow = 5,
        Orange = 10,
        Green = 15,
        Purple = 6,
        Black = 30,
        White = 1,
        */
            if (active)
            {
                base.Draw(spriteBatch);
                int a = alpha * 3 / 4;
                switch (currentColor)
                {
                    case (PaletteColor.Red):
                        spriteBatch.Draw(orbTexture, orbPosition, new Color(alpha, 0, 0, a));
                        break;
                    case (PaletteColor.Blue):
                        spriteBatch.Draw(orbTexture, orbPosition, new Color(0, 0, alpha, a));
                        break;
                    case (PaletteColor.Yellow):
                        spriteBatch.Draw(orbTexture, orbPosition, new Color(alpha, alpha, 0, a));
                        break;
                    case (PaletteColor.Orange):
                        spriteBatch.Draw(orbTexture, orbPosition, new Color(alpha, alpha/2, 0, a));
                        break;
                    case (PaletteColor.Green):
                        spriteBatch.Draw(orbTexture, orbPosition, new Color(0, alpha, 0, a));
                        break;
                    case (PaletteColor.Purple):
                        spriteBatch.Draw(orbTexture, orbPosition, new Color(alpha/2, 0, alpha/2, a));
                        break;
                    case (PaletteColor.Black):
                        spriteBatch.Draw(orbTexture, orbPosition, new Color(0, 0, 0, alpha));
                        break;
                    case (PaletteColor.White):
                        spriteBatch.Draw(orbTexture, orbPosition, new Color(alpha, alpha, alpha, alpha));
                        break;
                }
            }
        }
        #endregion

    }
}
