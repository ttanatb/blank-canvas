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

        //attributes
        Rectangle enemyRec;

        //constructor
        public Enemy(Rectangle eRec):base(eRec)
        {
            enemyRec = eRec;
        }
    }
}

