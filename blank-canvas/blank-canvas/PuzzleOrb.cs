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
        PaletteColor colorKey;
        bool active;
        #endregion

        #region Properties
        //nothing currently
        #endregion

        #region Constructors
        public PuzzleOrb(Vector2 position, PaletteColor key):base(new Rectangle((int)position.X, (int)position.Y,WIDTH, HEIGHT))
        {
            // Sets the puzzle orb position
            palette = new Palette();

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
                if (palette.GetColor() == colorKey)
                {
                    active = false;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (active)
                base.Draw(spriteBatch);
        }
        #endregion

    }
}
