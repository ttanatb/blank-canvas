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
        public Enemy(Rectangle eRec):base(eRec)
        {

        }

        //methods

        //collision method for an enemy (can't bump into it)
        public bool CheckCollision(Character character)
        {
            foreach (Rectangle r in character.CollisionBoxes)
            {
                if (r.Intersects(this.Rectangle))

                    // Damage player here?
                    character.Health = character.Health - 2; //I have this as 2 as a default (can be changed later)
                    return true;
            }
            return false;
        }
    }
}

