using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace blank_canvas
{
    /// <summary>
    /// The data structure that represents 
    /// </summary>
    class Bucket
    {
        int red;
        int blue;
        int yellow;
        PaletteColor currentColor;

        public Bucket()
        {
            red = 0;
            blue = 0;
            yellow = 0;
            currentColor = PaletteColor.Red;
        }

        public int Red
        {
            get { return red; }
        }

        public int Blue
        {
            get { return blue; }
        }

        public int Yellow
        {
            get { return yellow; }
        }

        public PaletteColor CurrentColor
        {
            get { return currentColor; }
        }

        public void AddColor(Enemy enemy)
        {
            PaletteColor color = enemy.CurrentColor;
            DistributeColor(color);
            //enemy.RemoveColor()?
        }

        public void AddColor(PuzzleOrb puzzleOrb)
        {
            PaletteColor color = puzzleOrb.CurrentColor;
            DistributeColor(color);
            //puzzleOrb.RemoveColor()?
        }

        /// <summary>
        /// switches through red blue yellow
        /// </summary>
        public void SwitchRBY()
        {
            if (blue == 0 && red == 0 && yellow == 0)
                return;

            switch (currentColor)
            {
                case PaletteColor.Red:
                    if (blue > 0)
                        currentColor = PaletteColor.Blue;
                    else goto case PaletteColor.Blue;
                    break;

                case PaletteColor.Blue:
                    if (yellow > 0)
                        currentColor = PaletteColor.Yellow;
                    else goto case PaletteColor.Yellow;
                    break;

                case PaletteColor.Yellow:
                    if (red > 0)
                        currentColor = PaletteColor.Red;
                    else goto case PaletteColor.Red;
                    break;
            }
        }

        /// <summary>
        /// switches through yellow blue red
        /// </summary>
        public void SwitchYBR()
        {
            if (blue == 0 && red == 0 && yellow == 0)
                return;

            switch (currentColor)
            {
                case PaletteColor.Yellow:
                    if (blue > 0)
                        currentColor = PaletteColor.Blue;
                    else goto case PaletteColor.Blue;
                    break;
                case PaletteColor.Blue:
                    if (red > 0)
                        currentColor = PaletteColor.Red;
                    else goto case PaletteColor.Red;
                    break;
                case PaletteColor.Red:
                    if (yellow > 0)
                        currentColor = PaletteColor.Yellow;
                    else goto case PaletteColor.Yellow;
                    break;
            }
        }

        private void DistributeColor(PaletteColor color)
        {
            int r = (int)color % 2;
            int b = (int)color % 3;
            int y = (int)color % 5;

            if (r == 0)
                red++;
            if (b == 0)
                blue++;
            if (y == 0)
                yellow++;
        }

        public void ReducePaint(PaletteColor color)
        {
            switch(color)
            {
                case PaletteColor.Red:
                    if (red > 0)
                        red--;  
                    break;
                case PaletteColor.Blue:
                    if (blue > 0)
                        blue--;
                    break;
                case PaletteColor.Yellow:
                    if (yellow > 0)
                        yellow--;
                    break;
            }
        }
    }
}
