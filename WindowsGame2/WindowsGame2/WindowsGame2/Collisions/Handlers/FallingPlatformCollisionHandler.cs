using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class FallingPlatformCollisionHandler : ICollisionHandler
    {
        IBlock subject;
        int width;
        public FallingPlatformCollisionHandler(IBlock block, int width)
        {
            this.subject = block;
            this.width = width;
        }

        public void CollisionAbove(ITangible type)
        {
            if (type is IPlayer)
            {
                subject.State = new SPlatformMovingDown(subject, width);
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
