using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace blank_canvas
{
    /// <summary>
    /// Exception that will switch the gameState to the GameOver state
    /// </summary>
    class GameOverException : Exception
    {
        public GameOverException()
        {

        }
    }
}
