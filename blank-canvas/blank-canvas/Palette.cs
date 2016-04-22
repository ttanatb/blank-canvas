using System;

namespace blank_canvas
{

    /// <summary>
    /// The data structure that holds the color of a gameobject
    /// </summary>
    class Palette
    {
        #region variables
        //an array of booleans for the three primary colors
        //colors[0] - red
        //colors[1] - blue
        //colors[2] - yellow

        bool[] colors;
        #endregion

        #region constructor
        public Palette(PaletteColor color)
        {
            //instantialzing the array
            colors = new bool[3];

            //switch statement to determine the initial bool values
            switch (color)
            {
                case PaletteColor.Red:
                    colors[0] = true;
                    colors[1] = false;
                    colors[2] = false;
                    break;

                case PaletteColor.Blue:
                    colors[0] = false;
                    colors[1] = true;
                    colors[2] = false;
                    break;

                case PaletteColor.Yellow:
                    colors[0] = false;
                    colors[1] = false;
                    colors[2] = true;
                    break;

                case PaletteColor.Purple:
                    colors[0] = true;
                    colors[1] = true;
                    colors[2] = false;
                    break;

                case PaletteColor.Green:
                    colors[0] = false;
                    colors[1] = true;
                    colors[2] = true;
                    break;

                case PaletteColor.Orange:
                    colors[0] = true;
                    colors[1] = false;
                    colors[2] = true;
                    break;

                case PaletteColor.Black:
                    colors[0] = true;
                    colors[1] = true;
                    colors[2] = true;
                    break;

                default:
                    colors[0] = false;
                    colors[1] = false;
                    colors[2] = false;
                    break;
            }
        }
        #endregion

        #region property
        public PaletteColor CurrentColor
        {
            //calculates what color the palette current has (based on the 3 bool values)

            get
            {
                if (colors[0])
                {
                    if (colors[1])
                    {
                        if (colors[2])
                            return PaletteColor.Black;
                        else return PaletteColor.Purple;
                    }
                    else if (colors[2])
                        return PaletteColor.Orange;
                    else return PaletteColor.Red;
                }
                else if (colors[1])
                {
                    if (colors[2])
                        return PaletteColor.Green;
                    else return PaletteColor.Blue;
                }
                else if (colors[2])
                    return PaletteColor.Yellow;
                else return PaletteColor.White;
            }

        }
        #endregion

        #region methods
        /// <summary>
        /// Adds a primary color to the palette. If it already contains that primary color, it would return false.
        /// </summary>
        /// <param name="color">A primary color to add to the palette</param>
        /// <returns>Wether or not was the addColor effective</returns>
        public bool AddColor(PaletteColor color)
        {
            //switch statement based on the input color
            switch (color)
            {
                case PaletteColor.Red:
                    if (!colors[0])
                    {
                        colors[0] = true;
                        return true;
                    }
                    else return false; //returns false if color already exists

                case PaletteColor.Blue:
                    if (!colors[1])
                    {
                        colors[1] = true;
                        return true;
                    }
                    else return false; //returns false if color already exists

                case PaletteColor.Yellow:
                    if (!colors[2])
                    {
                        colors[2] = true;
                        return true;
                    }
                    else return false; // returns false if color already exists

                //you shouldn't be able to add a non-primary color
                //the player can only shoot a primary color
                default: throw new Exception(); 
            }
        }

        /// <summary>
        /// A method to clear the current color back to white
        /// </summary>
        public void ResetColor()
        {
            //makes everything false
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = false;
            }
        }
        #endregion
    }
}
