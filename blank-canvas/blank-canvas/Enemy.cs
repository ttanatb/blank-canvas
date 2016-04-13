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

        //Prjectile variable (if we want them to shoot at the player)
        Projectile projectile;

        //a child of the character class
        PaletteColor paletteColor;

        // moving/movement variables
        new const float MOVESPEED = 250f;
        #endregion

        #region Properties

        public PaletteColor PaletteColor
        {
            get { return paletteColor; }
        }
        public Projectile Projectile
        {
            get { return projectile; }
        }

        #endregion

        #region Constructor
        //constructor
        public Enemy(Rectangle eRec, int health, PaletteColor pltclr):base(eRec)
        {
            paletteColor = pltclr;
            this.health = health; //Will be set for all enemies as 1 hit (could be set as more in the future)
            paint = 100000; //practically unlimited paint projectiles for enemy

            //spawn enemy facing left

            //possible projectile
            projectile = new Projectile();
        }
        #endregion

        #region
        //methods
        public void ArtificialIntelligence()
        {
            // loop movement starting with moving left


            //moving to the right
            direction = Direction.Right;
            velocity.X = MOVESPEED;


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

