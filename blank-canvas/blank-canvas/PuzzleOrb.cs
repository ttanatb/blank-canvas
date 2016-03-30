using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace blank_canvas
{
    class PuzzleOrb:GameObject
    {
        #region Variables
        const int WIDTH = 64;
        const int HEIGHT = 64;
        Point gridPos;
        bool[] colors;
        bool[] colorKey;
        #endregion

        #region Properties
        //nothing currently
        #endregion

        #region Constructors
        public PuzzleOrb(Vector2 position, bool[] key):base(new Rectangle((int)position.X, (int)position.Y,WIDTH, HEIGHT))
        {
            // Sets the puzzle orb position
            gridPos = new Point((int)position.X / 64, (int)position.Y / 64); //This statement needs to be double checked with logic in stageReader
            colors = new bool[3];

            // Sets all the colors of the orb to false
            for (int i = 0; i <= colors.Length; i++)
            {
                colors[i] = false;
            }

            // Sets the key for the orb to solve the puzzle
            colorKey = key;
        }
        #endregion

        #region Methods
        public void ChangeColor(Projectile projectile)
        {
            // Check if the projectile intersects with the orb
            foreach(Rectangle r in projectile.CollisionBoxes)
            {
                if(r.Intersects(this.Rectangle))
                {
                    // Change color
                    // Yellow
                    if (projectile.ProjectileColor == "Yellow")
                    {
                        colors[0] = true;
                    }
                    // Blue
                    if (projectile.ProjectileColor == "Blue")
                    {
                        colors[1] = true;
                    }
                    // Red
                    if (projectile.ProjectileColor == "Red")
                    {
                        colors[2] = true;
                    }
                }
            }


        }

        public void ResetColor()
        {
            // Player swipes the orb
            for(int i =0; i<colors.Length;i++)
            {
                colors[i] = false;
            } 
        }
        #endregion

    }
}
