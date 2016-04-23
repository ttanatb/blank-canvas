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

        int doorNum;

        PuzzleState doorState;
        List<PuzzleOrb> puzzleVariables;

        Texture2D doorTexture;
        Vector2 doorPosition;
        #endregion

        #region Properties
        public Texture2D DoorTexture
        {
            set { doorTexture = value; }
        }

        public PuzzleState DoorState
        {
            get { return doorState; }
        }

        public int DoorNum
        {
            get { return doorNum; }
        }

        public List<PuzzleOrb> PuzzleVariables
        {
            get { return puzzleVariables; }
            set { puzzleVariables = value; }
        }
        #endregion


        public Gates(Vector2 position, char prevChar) : base(new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT))
        {
            puzzleVariables = new List<PuzzleOrb>();
            doorPosition = new Vector2(position.X, position.Y);
            doorNum = Convert.ToInt32(prevChar);
            doorState = PuzzleState.Active;

        }



        #region Methods
        public void Update()
        {
            foreach(PuzzleOrb orbs in puzzleVariables)
            {
                if(orbs.PuzzleState == PuzzleState.Active)
                {
                    return;
                }               
            }
            // all PuzzleStates are complete
            doorState = PuzzleState.Completed;
        }
        #endregion

    }
}
