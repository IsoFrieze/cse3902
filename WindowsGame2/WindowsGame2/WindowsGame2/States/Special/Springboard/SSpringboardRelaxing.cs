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
    class SSpringboardRelaxing : IBlockState
    {
        public IBlock Block { get; set; }
        private int timer;
        private int hitboxLocation;
        public SSpringboardRelaxing(IBlock block)
        {
            this.Block = block;
            Block.Sprite = new Animation(Textures.springboardRelaxing, 3, 8);
            
            hitboxLocation = (int)Block.Position.Y;
            timer = 0;
        }
        public void Update()
        {
            Block.Hitbox.Cycle();
            GrowHitbox();
            timer++;

            if (timer == 24)
            {
                HUD.level.player.Velocity = new Vector2(HUD.level.player.Velocity.X, 7f);
                Block.State = new SSpringboardIdle(Block);
            }
        }

        public void Spawn() { }

        private void GrowHitbox()
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

