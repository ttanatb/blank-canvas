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
    class Projectile : GameObject
    {
        #region Variables
        const int WIDTH = 32; // Need to be changed/balanced correctly
        const int HEIGHT = 32;
        protected Rectangle collisionBox;

        // unique variables
        PaletteColor projectileColor;
        #endregion

        #region Properties
        public Rectangle CollisionBox
        {
            get { return collisionBox; }
        }

        public PaletteColor ProjectileColor
        {
            get { return projectileColor; }
        }
        #endregion

        #region Constructors
        public Projectile(Character character, PaletteColor color) : base(new Rectangle((int)character.X, (int)character.Y,WIDTH, HEIGHT))
        {
            projectileColor = color;
        }

        private bool CheckValidTarget(GameObject gameObject)
        {
            if (gameObject is PuzzleOrb)
                return true;
            else return false;
        }

        public bool CheckCollision(GameObject gameObject)
        {

        }

        //methods to check intersection

        #endregion


    }
}
