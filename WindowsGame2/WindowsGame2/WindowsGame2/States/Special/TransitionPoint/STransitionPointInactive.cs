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
    class STransitionPointInactive : IBlockState
    {
        public IBlock Block { get; set; }


        public STransitionPointInactive(IBlock block)
        {
            this.Block = block;
            Block.Sprite = new Animation(Textures.platform, 4, 8);

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
                    Hitboxes.TRANSITION_POINT_WIDTH,
                    Hitboxes.TRANSITION_POINT_HEIGHT
                );
        }
    }
}

