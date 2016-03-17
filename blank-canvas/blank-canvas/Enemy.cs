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
<<<<<<< HEAD
    public class Enemy: Character
=======
    public class Enemy : Character
>>>>>>> d909b04d77a90b37b7dc3a4f2fa66a63c36a65e9
    {
        //a child of the character class

        //attributes
        Rectangle enemyRec;

        //constructor
        public Enemy(Rectangle eRec):base(eRec)
        {
            enemyRec = eRec;
        }

        //methods

        //collision method for an enemy (can't bump into it)
        public bool CheckCollision(Character character)
        {
            foreach (Rectangle r in character.CollisionBoxes)
            {
                if (r.Intersects(this.Rectangle))

                    // Damage player here?
                    character.Heath = character.Heath - 2; //I have this as 2 as a default (can be changed later)
                    return true;
            }
            return false;
        }
    }
}

