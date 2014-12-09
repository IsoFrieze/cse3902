using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WindowsGame2
{
    public class TextSelections
    {
        internal String Text { get; private set;}
        
        internal Vector2 Center { get; private set; }
        internal Vector2 Position { get; private set; }
        internal Vector2 Size { get; private set; }

        internal int Rows { get; private set; }
        internal int Columns { get; private set; }

        public TextSelections(string text, int viewportWidth, int viewportHeight)
        {
            Text = text;
            Rows = Text.Split('\n').Length;
            if (Rows > 3)
            {
                Size = Textures.font.MeasureString(text);
                Center = new Vector2(viewportWidth / 2, (viewportHeight / 2) - 30);
                Position = Center - (Size / 2);
                Columns = 4;
            }
            else
            {
                Columns = 0;
                Size = Textures.font.MeasureString(text);
                Center = new Vector2(viewportWidth / 2, (viewportHeight / 2) + 50);
                Position = Center - (Size / 2);
                Columns = Regex.Split(text, HotDAMN.TAB + HotDAMN.TAB).Length;
            }

            
        }

    }
}
