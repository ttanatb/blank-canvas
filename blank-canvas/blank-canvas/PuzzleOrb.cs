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
    /// The puzzle orb can be shot (painted) by the player. 
    /// If it matches the key color, then the corresponding gate
    /// dematerializes. The player can also draw back a color in
    /// the orb.
    /// 
    /// Things to work on:
    /// Collision between projectile and orb
    /// Drawing back the paint from the orb
    /// Linking the orb to a gate
    /// Linking multiple orbs to a gate?
    /// </summary>
    class PuzzleOrb : GameObject
    {
        #region Variables
        const int WIDTH = 64;
        const int HEIGHT = 64; //may be subjected to change

        const int ORB_WIDTH = 37;
        const int ORB_HEIGHT = 41;

        const int HORIZONTAL_OFFSET = 5;
        const int VERTICAL_OFFSET = 4;

        int orbNum;
        Palette palette;            //manages the color
        PaletteColor colorKey;      //the key required to solve the orb
        PuzzleState state;         

        Texture2D orbTexture;
        Vector2 orbPosition;
        Rectangle orbCollisionBox;
        #endregion

        #region Properties
        public Texture2D OrbTexture
        {
            set { orbTexture = value; }
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
        public PuzzleOrb(Vector2 position, PaletteColor key, char prevChar) :base(new Rectangle((int)position.X, (int)position.Y,WIDTH, HEIGHT))
        {
            // Sets the puzzle orb position
            palette = new Palette(PaletteColor.White);
            orbPosition = new Vector2(position.X + 13, position.Y + 11);
            orbCollisionBox = new Rectangle((int)orbPosition.X + VERTICAL_OFFSET, 
                (int)orbPosition.Y + HORIZONTAL_OFFSET,
                ORB_WIDTH - 2 * VERTICAL_OFFSET, 
                ORB_HEIGHT - 2 * HORIZONTAL_OFFSET);

            // Sets the key for the orb to solve the puzzle
            orbNum = Convert.ToInt32(prevChar);
            colorKey = key;
            state = PuzzleState.Active;
        }
        #endregion

        #region Methods
        public bool AddColor(Projectile projectile)
        {
            return palette.AddColor(projectile.ProjectileColor);
        }

        public PaletteColor DrainColor()
        {
            PaletteColor color = palette.CurrentColor;
            palette.ResetColor();
            return color;
        }

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

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (state == PuzzleState.Active || state == PuzzleState.Completed)
            {
                base.Draw(spriteBatch);
                int a = alpha * 3 / 4;
                if (state == PuzzleState.Completed)
                    alpha = 150;
                switch (CurrentColor)
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
