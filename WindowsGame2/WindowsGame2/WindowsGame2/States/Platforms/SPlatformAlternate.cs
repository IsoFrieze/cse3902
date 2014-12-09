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
    public class SPlatformAlternate : IBlockState
    {
        public IBlock Block { get; set; }
        int width, time;
        Vector2 p1, p2;

        public SPlatformAlternate(IBlock block, int width, int x1, int y1, int x2, int y2)
        {
            this.Block = block;
            this.width = width;
            this.time = 0;
            this.p1 = new Vector2(x1, y1);
            this.p2 = new Vector2(x2, y2);
            SetPos();

            Block.Hitbox.Clear();
            SetHitbox();
        }

        public void Update()
        {
            SetPos();
            time++;
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

        private void SetPos()
        {
            double posx = p1.X + ((p2.X - p1.X) * ((Math.Cos(2 * Math.PI * time / HotDAMN.TICKS_UNTIL_MOVING_PLATFORMS_CYCLE) + 1) / 2));
            double posy = p1.Y + ((p2.Y - p1.Y) * ((Math.Cos(2 * Math.PI * time / HotDAMN.TICKS_UNTIL_MOVING_PLATFORMS_CYCLE) + 1) / 2));
            Block.Position = new Vector2((float)posx, (float)posy);
        }
    }
}
