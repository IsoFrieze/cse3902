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
    // The block is idle.
    public class SLedgeIdle : IBlockState
    {
        public IBlock Block { get; set; }
        private int width;

        public SLedgeIdle(IBlock block, int width)
        {
            this.Block = block;
            this.width = width;

            Block.Hitbox.Clear();
            SetHitbox();
        }

        public void Update()
        {
            Block.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox()
        {
            Block.Hitbox.AddRectHitbox(
                    (int)Block.Position.X,
                    (int)Block.Position.Y,
                    Hitboxes.LEDGE_WIDTH * width,
                    Hitboxes.LEDGE_HEIGHT
                );
        }
    }
}
