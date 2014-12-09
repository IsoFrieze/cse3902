using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2
{
    public class TextureMap
    {
        public int Row          { get; private set; }
        public int Column       { get; private set; }
        public int FramesInRow  { get; private set; }
        public int TimePerFrame { get; private set; }

        public TextureMap(int row, int column, int framesInRow = 1, int timePerFrame = 1)
        {
            Row = row;
            Column = column;
            FramesInRow = framesInRow;
            TimePerFrame = timePerFrame;
        }
    }
}

