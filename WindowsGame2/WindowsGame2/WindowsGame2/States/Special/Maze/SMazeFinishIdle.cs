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
    class SMazeFinishIdle : IBlockState
    {
        public IBlock Block { get; set; }

        public SMazeFinishIdle(IBlock block)
        {
            this.Block = block;

            SetHitbox();
        }

        public void Update()
        {
            Block.Hitbox.Cycle();
            SetHitbox();
        }

        public void Spawn() { }

        private void SetHitbox()
        {
            Block.Hitbox.AddRectHitbox(
                    (int)Block.Position.X,
                    (int)Block.Position.Y,
                    Hitboxes.MAZE_FINISH_WIDTH,
                    Hitboxes.MAZE_FINISH_HEIGHT
                );
        }
    }
}

