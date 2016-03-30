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

    public class Enemy : Character
    {
        //a child of the character class


        //constructor
        public Enemy(Rectangle eRec, int hlth):base(eRec)
        {
            health = hlth; //Will be set for all enemies as 1 hit (could be set as more in the future)
            paint = 100000; //practically unlimited paint projectiles for enemy
        }

        //methods

        //collision method for an enemy (can't bump into it)
        public bool CheckCollision(Character character)
        {
            foreach (Rectangle r in character.CollisionBoxes)
            {
                if (r.Intersects(this.Rectangle))
                    return true;
            }
            return false;
        }
    }
}

