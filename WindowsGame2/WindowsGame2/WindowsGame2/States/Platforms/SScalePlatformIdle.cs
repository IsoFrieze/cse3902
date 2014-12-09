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
    public class SScalePlatformIdle : IBlockState
    {
        public IBlock Block { get; set; }
        private int width, ymin;

        public SScalePlatformIdle(IBlock block, int width, int ymin)
        {
            this.Block = block;
            this.width = width;
            this.ymin = ymin;

            Block.Hitbox.Clear();
            SetHitbox();

            Block.Acceleration = Vector2.Zero;
            Block.Velocity = Vector2.Zero;
        }

        public void Update()
        {
            ScalePlatform partner = ((ScalePlatform)Block).partner;

            if (partner.Position.Y < ymin)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_BREAK_SCALE_PLATFORMS;
                HUD.level.AddParticle(new Score(new Vector2(partner.Position.X + Block.Position.X / 2, partner.Position.Y), HotDAMN.SCORE_BREAK_SCALE_PLATFORMS));

                Block.State = new SPlatformFalling(Block, width);
                partner.State = new SPlatformFalling(partner, width);
                Block.CollisionHandler = new StaticBlockCollisionHandler(Block);
                partner.CollisionHandler = new StaticBlockCollisionHandler(partner);
            }
            Block.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox()
        {
            Block.Hitbox.AddRectHitbox(
                    (int)Block.Position.X,
                    (int)Block.Position.Y,
                    Hitboxes.PLATFORM_WIDTH * width,
                    Hitboxes.PLATFORM_HEIGHT
                );
        }
    }
}
