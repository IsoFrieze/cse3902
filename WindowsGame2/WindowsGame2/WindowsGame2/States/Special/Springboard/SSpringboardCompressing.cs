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
    class SSpringboardCompressing : IBlockState
    {
        public IBlock Block { get; set; }

        private int timer;
        public SSpringboardCompressing(IBlock block)
        {
            this.Block = block;
            Block.Sprite = new Animation(Textures.springboardCompressing, 8, 4);
            Block.CollisionHandler = new StaticBlockCollisionHandler(Block);
            Block.Hitbox.Clear();
            SetHitbox();
            timer = 0;
        }
        public void Update()
        {
            Block.Hitbox.Cycle();
            SetHitbox();
            timer++;

            if (timer == 32)
            {
                 Block.State = new SSpringboardIdle(Block);
            }

        }

        private void SetHitbox()
        {
            int offset = (int)(16 * Math.Sin(Math.PI * timer / 32));
            Block.Hitbox.AddRectHitbox(
                    (int)Block.Position.X,
                    (int)Block.Position.Y + offset,
                    Hitboxes.SPRINGBOARD_WIDTH,
                    Hitboxes.SPRINGBOARD_HEIGHT - offset
                );
        }
    }
}

