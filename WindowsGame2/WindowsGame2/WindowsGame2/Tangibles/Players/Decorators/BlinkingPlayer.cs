using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class BlinkingPlayer : TemporaryDecorator
    {
        private IPlayer player;
        private int blinkFrame;
        private int timer;

        public BlinkingPlayer(IPlayer player)
            : base(player)
        {
            this.player = player;
            this.blinkFrame = 0;
            this.timer = 0;
            this.decoratedPlayer.CollisionHandler = new InvinciblePlayerCollisionHandler(this.decoratedPlayer);
        }

        public override void Update()
        {
            base.decoratedPlayer.Update();

            timer++;
            if (timer > HotDAMN.TICKS_UNTIL_MARIO_BLINKING_EXPIRES)
            {
                player.Decorator = new PlainPlayer(player);
            }
            blinkFrame = blinkFrame == 3 ? 0 : blinkFrame + 1;
        }

        public override void Draw(SpriteBatch sb, Rectangle camera)
        {
            if (blinkFrame < 2)
            {
                base.decoratedPlayer.Draw(sb, camera);
            }
        }
    }
}
