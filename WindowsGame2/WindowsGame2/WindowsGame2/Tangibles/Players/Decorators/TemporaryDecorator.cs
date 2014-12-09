using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public abstract class TemporaryDecorator
    {
        protected IPlayer decoratedPlayer;

        public TemporaryDecorator(IPlayer player)
        {
            this.decoratedPlayer = player;
        }
        public abstract void Update();
        public abstract void Draw(SpriteBatch sb, Rectangle camera);
    }
}
