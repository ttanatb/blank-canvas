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

        int doorNum;

        PuzzleState doorState;
        List<PuzzleOrb> puzzleVariables;

        Texture2D doorTexture;
        Vector2 doorPosition;
        //Rectangle doorCollisionBox;
        #endregion

        #region Properties
        public Texture2D DoorTexture
        {
            set { doorTexture = value; }
        }

        /*public Rectangle CollisionBox
        {
            get { return doorCollisionBox; }
        }
        */
        public PuzzleState DoorState
        {
            get { return doorState; }
        }

        public int DoorNum
        {
            get { return doorNum; }
        }
        #endregion


        public Gates(Vector2 position, char prevChar) : base(new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT))
        {
            doorPosition = new Vector2(position.X, position.Y);
            doorNum = Convert.ToInt32(prevChar);
            doorState = PuzzleState.Active;
        }


        #region Methods
        public bool CheckCollision(Player player)
        {
            if (doorState == PuzzleState.Active)
            {
                if ((Max.Y >= player.Min.Y) && (Min.Y < player.Max.Y) && (Max.X > player.Min.X) && (Min.X < player.Max.X))
                {
                    return true; // Only returns true when colliding and the door is active
                }
                else return false;
            }
            else return false;
        }
        #endregion

    }
}
