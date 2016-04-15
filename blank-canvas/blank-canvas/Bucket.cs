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

        public Bucket()
        {
            red = 0;
            blue = 0;
            yellow = 0;
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

        public void DrawColor(Enemy enemy)
        {
            PaletteColor color = enemy.CurrentColor;
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

        public void UsePaint(PaletteColor color)
        {
            switch(color)
            {
                case PaletteColor.Red:
                    red++;
                    break;
                case PaletteColor.Blue:
                    blue++;
                    break;
                case PaletteColor.Yellow:
                    yellow++;
                    break;
            }
        }
    }
}
