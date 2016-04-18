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
    /// The puzzle element of the game that is yet to be implemented
    /// </summary>
    class Gates : GameObject
    {
        #region Variables
        const int WIDTH = 64;
        const int HEIGHT = 128; //may be subjected to change

        const int DOOR_WIDTH = 37;
        const int DOOR_HEIGHT = 41;

        // int HORIZONTAL_OFFSET = //num;
        // const int VERTICAL_OFFSET = //num;

        PuzzleState doorState;

        Texture2D doorTexture;
        Vector2 doorPosition;
        Rectangle doorCollisionBox;
        #endregion

        #region Properties
        public Texture2D DoorTexture
        {
            set { doorTexture = value; }
        }

        public Rectangle CollisionBox
        {
            get { return doorCollisionBox; }
        }
        #endregion


        public Gates(Rectangle rect) : base(rect)
        {

        }


    }
}
