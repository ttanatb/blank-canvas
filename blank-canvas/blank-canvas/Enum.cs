﻿using System;
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
        //the numbers are used to determine the color in an easy way
        Red = 2,
        Blue = 3,
        Yellow = 5,
        Orange = 10,
        Green = 15,
        Purple = 6,
        Black = 30,
        White = 1,

        /*
        here's how:
        int r = (int)color % 2;
        int b = (int)color % 3;
        int y = (int)color % 5;

        The check if r, b, or y is 0
        if so add to its respective int
        */
    }
}