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
        private int hitboxLocation;
        public SSpringboardCompressing(IBlock block)
        {
            this.Block = block;
            Block.Sprite = new Animation(Textures.springboardCompressing, 3, 8);
            Block.CollisionHandler = new StaticBlockCollisionHandler(Block);
            Block.Hitbox.Clear();
            SetHitbox();
            hitboxLocation = (int)Block.Position.Y;
            timer = 0;
        }
        public void Update()
        {
            Block.Hitbox.Cycle();
            ShrinkHitbox();
            timer++;

            if (timer == 24)
            {
                 Block.State = new SSpringboardRelaxing(Block);
            }

        }

        public void Spawn() { }

        private void SetHitbox()
        {
            Block.Hitbox.AddRectHitbox(
                    (int)Block.Position.X,
                    (int)Block.Position.Y,
                    Hitboxes.SPRINGBOARD_WIDTH,
                    Hitboxes.SPRINGBOARD_HEIGHT
                );
        }

        private void ShrinkHitbox()
        {
            hitboxLocation--;

            Block.Hitbox.AddRectHitbox(
                    (int)Block.Position.X,
                    hitboxLocation,
                    Hitboxes.SPRINGBOARD_WIDTH,
                    Hitboxes.SPRINGBOARD_HEIGHT
                );
        }
    }
}

