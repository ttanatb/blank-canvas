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
        //constants
        const int WIDTH = 64;
        const int HEIGHT = 128; //may be subjected to change

        //index
        int doorNum;

        //state
        PuzzleState doorState;

        //keys
        List<PuzzleOrb> puzzleVariables;
        #endregion

        #region Properties
        /// <summary>
        /// State of the puzzle (solved or not)
        /// </summary>
        public PuzzleState DoorState
        {
            get { return doorState; }
        }

        /// <summary>
        /// Index to link with the puzzle orbs
        /// </summary>
        public int DoorNum
        {
            get { return doorNum; }
        }

        /// <summary>
        /// List of puzzle orbs required to activate
        /// </summary>
        public List<PuzzleOrb> PuzzleVariables
        {
            get { return puzzleVariables; }
            set { puzzleVariables = value; }
        }
        #endregion


        #region constructor

        //constructor
        public Gates(Vector2 position, char prevChar) : base(new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT))
        {
            puzzleVariables = new List<PuzzleOrb>();
            doorNum = Convert.ToInt32(prevChar);
            doorState = PuzzleState.Active;
        }
        #endregion

        #region Methods
        //update method
        public void Update()
        {
            //checks if the keys are still active
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

        //draw only if the puzzle is active
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (doorState == PuzzleState.Active)
                base.Draw(spriteBatch);
        }
        #endregion

    }
}
