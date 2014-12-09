using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class PlainPlayer : TemporaryDecorator
    {
        public PlainPlayer(IPlayer player)
            : base(player)
        {
            base.decoratedPlayer.Sprite.Texture = Textures.mario0;
            this.decoratedPlayer.CollisionHandler = new PlayerCollisionHandler(this.decoratedPlayer);
        }

        public override void Update()
        {
            base.decoratedPlayer.Update();
        }

        public override void Draw(SpriteBatch sb, Rectangle camera)
        {
            base.decoratedPlayer.Draw(sb, camera);
        }
    }
}
