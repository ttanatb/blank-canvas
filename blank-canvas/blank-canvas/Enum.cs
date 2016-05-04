using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace blank_canvas
{
    /// This is where all the enums are located


    /// <summary>
    /// The color that can be represented within the game
    /// </summary>
    public enum PaletteColor
    {
        //the red, blue and yellow represents 3 different prime numbers
        //if a color is divisible by one of the primary colors, it contains that primary color
        Red = 2,
        Blue = 3,
        Yellow = 5,
        Orange = 10,
        Green = 15,
        Purple = 6,
        Black = 30,
        White = 1,
    }

    /// <summary>
    /// The state of the game itself
    /// </summary>
    public enum GameState
    {
        MainMenu,
        Gameplay,
        Pause,
        EndOfGame,
        LevelChange
    }

    /// <summary>
    /// Level Enum
    /// </summary>
    public enum Level
    {
        Desert = 1,
        Ice_Caves = 2,
        Forest = 3,
        Mountain = 4,
        Castle = 5,
    }

    /// <summary>
    /// Tile Enum - Determines what type
    /// of tile is read in
    /// </summary>
    public enum TileType
    {
        Ground,
        Floor,
        Wall,
        Theme,
        Blank,
    }


    /// <summary>
    /// The direction of the character
    /// </summary>
    public enum Direction
    {
        Left = -1,
        Right = 1,
    }

    /// <summary>
    /// The state of the puzzle (not quite actually relevant)
    /// </summary>
    public enum PuzzleState
    {
        //the int value is used for drawing (transparency)
        Inactive,
        Active = 8,
        Completed = 1,
    }

    /// <summary>
    /// The animation state of the player
    /// </summary>
    public enum AnimState
    {
        Idle,
        Walk,
        Jump,
        Hurt,
        Shoot,
        Drain,
    }
}
