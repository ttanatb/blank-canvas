using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace blank_canvas
{

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

        public Palette(PaletteColor color)
        {
            colors = new bool[3];
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
                case PaletteColor.Purple:
                    colors[0] = true;
                    colors[1] = true;
                    break;
                case PaletteColor.Green:
                    colors[1] = true;
                    colors[2] = true;
                    break;
                case PaletteColor.Orange:
                    colors[0] = true;
                    colors[2] = true;
                    break;
                case PaletteColor.Black:
                    colors[0] = true;
                    colors[1] = true;
                    colors[2] = true;
                    break;
                default:
                    break;
            }
        }

        public bool AddColor(PaletteColor color)
        {
            switch (color)
            {
                case PaletteColor.Red:
                    if (!colors[0])
                        colors[0] = true;
                    else return false;
                    break;
                case PaletteColor.Blue:
                    if (!colors[1])
                        colors[1] = true;
                    else return false;
                    break;
                case PaletteColor.Yellow:
                    if (!colors[2])
                        colors[2] = true;
                    else return false;
                    break;
            }
            return true;
        }

        public PaletteColor GetColor()
        {
            // Check's all colors that contain red first, then checks all colors with blue in it, then finally checks if it has yellow, if no color than it displays white as the color
            if(colors[0])
            {
                if(colors[1])
                {
                    if(colors[2]) 
                    {
                        return PaletteColor.Black;
                    }
                    return PaletteColor.Purple;
                }
                if(colors[2])
                {
                    return PaletteColor.Orange;
                }
                return PaletteColor.Red;
            }
            if(colors[1])
            {
              if(colors[2])
                {
                    return PaletteColor.Green;
                }
                return PaletteColor.Blue;
            }
            if(colors[2])
            {
                return PaletteColor.Yellow;
            } 
            else
            {
                return PaletteColor.White;
            }
        }

        public void ResetColor()
        {
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = false;
            }
        }
    }
}
