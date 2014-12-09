using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class ScalePlatformCollisionHandler : ICollisionHandler
    {
        IBlock subject;
        public ScalePlatformCollisionHandler(IBlock block)
        {
            this.subject = block;
        }

        public void CollisionAbove(ITangible type)
        {
            if (type is IPlayer)
            {
                subject.Position += new Vector2(0, 1f);
                ((ScalePlatform)subject).partner.Position -= new Vector2(0, 1f);
            }
        }
        public void CollisionBelow(ITangible type)
        {

        }
        public void CollisionLeft(ITangible type)
        {

        }
        public void CollisionRight(ITangible type)
        {

        }
    }
}
