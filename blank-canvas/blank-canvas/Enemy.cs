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
    public class Enemy : Character
    {
        #region Variables
        new const float MOVESPEED = 100f;
        const double PAUSE_TIME = 2000.0;
        const int WIDTH = 64;
        const int HEIGHT = 64;

        //Prjectile variable (if we want them to shoot at the player)
        //Projectile projectile;

        PaletteColor paletteColor;
        Random rndm;

        #endregion

        #region Properties

        public PaletteColor CurrentColor
        {
            get { return paletteColor; }
        }

        #endregion

        #region Constructor
        //constructor
        public Enemy(Vector2 position, PaletteColor color) : base(new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT))
        {
            paletteColor = color;

            rndm = new Random();
            
            //Will be set for all enemies as 1 hit (could be set as more in the future)
            //paint = 100000; //practically unlimited paint projectiles for enemy

            //spawn enemy facing left

            //possible projectile
            //projectile = new Projectile();
        }
        #endregion

        #region methods
        //methods
        public void Update(double deltaTime)
        {
            velocity.X = (int)direction * MOVESPEED;
            UpdatePos(deltaTime);
        }

        public void ChangeDirection()
        {
            direction = (Direction)(-1 * (int)direction);
        }


        //lol this isn't used
        //collision method for an enemy (can't bump into it)
        public bool CheckCollision(Character character)
        {
            foreach (Rectangle r in character.CollisionBoxes)
            {
                if (r.Intersects(Rectangle))
                    return true;
            }
            return false;
        }

        #endregion
    }
}

