using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2
{
    public class Pointer
    {
        int row, rows;
        int column, columns;
        int shiftX, shiftY;
        int lastColumn, lastRow;
        int x, y;
        public IAnimatedSprite Sprite { get; private set; }
      

        public Pointer(TextSelections textSelection)
        {
            this.rows = textSelection.Rows;
            this.columns = textSelection.Columns;
            this.shiftX = textSelection.Rows;
            this.shiftY = textSelection.Columns;
            lastColumn = 0;
            lastRow = 0;
            Sprite = new Animation(Textures.mushroomPointer);
            x = (int)textSelection.Position.X;
            y = (int)textSelection.Position.Y + Sprite.Texture.Height/2;
            
        }
        public int GetSelectedRow()
        {
            return row;
        }
        public int GetSelectedColumn()
        {
            return column;
        }
        internal void Update()
        {
            Sprite.Update();
            x += (column - lastColumn) * Textures.font.LineSpacing * 3;
            y += (row - lastRow) * Textures.font.LineSpacing;
            lastColumn = column;
            lastRow = row;
        }

        internal void MoveUp()
        {
            row = ((lastRow - 1) % rows + rows) % rows;
        }

        internal void MoveDown()
        {
            row = ((lastRow + 1) % rows + rows) % rows;
        }

        internal void MoveLeft()
        {
            column = ((lastColumn - 1) % columns + columns) % columns;
        }

        internal void MoveRight()
        {
            column = ((lastColumn + 1) % columns + columns) % columns;
        }

        internal void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, x, y);
        }

    }
}
