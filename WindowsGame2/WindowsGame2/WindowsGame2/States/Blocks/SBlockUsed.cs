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
    // a used block
    public class SBlockUsed : IBlockState
    {
        public IBlock Block { get; set; }

        public SBlockUsed(IBlock block)
        {
            this.Block = block;
            Block.Sprite = new SettingDependentAnimation(Textures.blockUsed);

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
                    Hitboxes.BLOCK_WIDTH,
                    Hitboxes.BLOCK_WIDTH
                );
        }

    }
}
