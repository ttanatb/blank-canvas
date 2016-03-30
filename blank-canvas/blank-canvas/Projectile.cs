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
    /// The projectile that is used by the player (yet to be utilized)
    /// </summary>
    class Projectile:GameObject
    {
        #region Variables
        const int WIDTH = 64; // Need to be changed/balanced correctly
        const int HEIGHT = 64;
        Point gridPos;
        protected Rectangle[] collisionBoxes;

        // unique variables
        public string projectileColor;
        #endregion

        #region Properties
        public Rectangle[] CollisionBoxes
        {
            get { return collisionBoxes; }
        }

        public string ProjectileColor
        {
            get { return projectileColor; }
        }
        #endregion

        #region Constructors
        public Projectile(Vector2 position, string clr):base(new Rectangle((int)position.X, (int)position.Y,WIDTH, HEIGHT))
        {
            gridPos = new Point((int)position.X / 64, (int)position.Y / 64); //This statement needs to be double checked with logic in stageReader
            projectileColor = clr;
        }

        #endregion


    }
}
