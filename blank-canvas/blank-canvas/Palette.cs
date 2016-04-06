using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace blank_canvas
{
    enum PaletteColor
    {
        Red,
        Blue,
        Yellow,
        Orange,
        Green,
        Purple,
        Black,
        White,
    }

    /// <summary>
    /// The data structure that holds the color of a gameobject
    /// </summary>
    class Palette
    {
        bool[] colors;

        public Palette()
        {
            colors = new bool[3];
            colors[0] = false;
            colors[1] = false;
            colors[2] = false;
        }

        public void AddColor(PaletteColor color)
        {
            switch (color)
            {
                case PaletteColor.Red:
                    colors[0] = true;
                    break;
                case PaletteColor.Blue:
                    colors[1] = true;
                    break;
                case PaletteColor.Yellow:
                    colors[2] = true;
                    break;
                default:
                    break;
            }
        }

        public PaletteColor GetColor()
        {
            if (colors[0] && colors[1] && colors[2])
                return PaletteColor.Black;

        }
    }
}
