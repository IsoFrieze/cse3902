using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2
{
    public class StarPlayer : TemporaryDecorator
    {
        private IPlayer player;
        private int starFrame;
        private int timer;

        public StarPlayer(IPlayer player)
            : base(player)
        {
            this.player = player;
            this.starFrame = 0;
            this.decoratedPlayer.CollisionHandler = new InvinciblePlayerCollisionHandler(this.decoratedPlayer);
            this.timer = 0;

            SoundPanel.PlaySong(HUD.TIME < HotDAMN.TIME_UNTIL_HURRY_UP ? Sound.hurrystarmanTheme : Sound.starmanTheme);
        }

        public override void Update()
        {
            base.decoratedPlayer.Update();
            if (timer == HotDAMN.TICKS_UNTIL_STAR_SONG_STOPS)
            {
                SoundPanel.StopSong();
            }
            int increment = timer > HotDAMN.TICKS_UNTIL_STAR_SONG_STOPS ? 1 : 2;
            starFrame = starFrame + increment >= 24 ? 0 : starFrame + increment;

            if (starFrame / 6 % 2 == 0)
            {
                if (starFrame / 6 == 0)
                    base.decoratedPlayer.Sprite.Texture = Textures.mario0;
                else
                    base.decoratedPlayer.Sprite.Texture = Textures.mario2;
            }
            else
            {
                if (starFrame / 6 == 1)
                    base.decoratedPlayer.Sprite.Texture = Textures.mario1;
                else
                    base.decoratedPlayer.Sprite.Texture = Textures.mario3;
            }

            timer++;
            if (timer > HotDAMN.TICKS_UNTIL_STAR_POWER_EXPIRES)
            {
                player.Decorator = new PlainPlayer(player);
            }
        }

        public override void Draw(SpriteBatch sb, Rectangle camera)
        {
            base.decoratedPlayer.Draw(sb, camera);
        }
    }
}
