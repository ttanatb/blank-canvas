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
        //a child of the character class
        PaletteColor paletteColor;

        public PaletteColor PaletteColor
        {
            get { return paletteColor; }
        }

        //constructor
        public Enemy(Rectangle eRec, int health):base(eRec)
        {
            this.health = health; //Will be set for all enemies as 1 hit (could be set as more in the future)
            paint = 100000; //practically unlimited paint projectiles for enemy
        }

        //methods

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
    }
}

