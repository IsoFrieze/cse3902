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
    class STransitionPointActive : IBlockState
    {
        public IBlock Block { get; set; }
        private int counter;

        public STransitionPointActive(IBlock block)
        {
            this.Block = block;
            this.counter = 0;
            Block.Sprite = new Animation(Textures.projectileFireball, 8, 8);

            Block.Hitbox.Clear();
            SetHitbox();
        }

        public void Update()
        {
            if (counter == 1)
            {
                Block.State = new STransitionPointInactive(Block);
            }
            counter++;
            Block.Hitbox.Cycle();
            SetHitbox();
        }

        public void Spawn() { }

        private void SetHitbox()
        {
            Block.Hitbox.AddRectHitbox(
                    (int)Block.Position.X,
                    (int)Block.Position.Y,
                    Hitboxes.TRANSITION_POINT_WIDTH,
                    Hitboxes.TRANSITION_POINT_HEIGHT
                );
        }
    }
}

