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
    public class SPipeIdle : IBlockState
    {
        public IBlock Block { get; set; }
        private int height;

        public SPipeIdle(IBlock block, int height)
        {
            this.Block = block;
            this.height = height;

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
                    Hitboxes.PIPE_WIDTH,
                    Hitboxes.PIPE_HEIGHT * height
                );
        }
    }
}
