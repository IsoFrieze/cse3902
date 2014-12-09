using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class RidingPlatformCollisionHandler : ICollisionHandler
    {
        IBlock subject;
        int width;
        public RidingPlatformCollisionHandler(IBlock block, int width)
        {
            this.subject = block;
            this.width = width;
        }

        public void CollisionAbove(ITangible type)
        {
            if (subject.State is SPlatformMovingRight)
            {
                type.Position += subject.Velocity;
            }
            else if (type is IPlayer)
            {
                subject.State = new SPlatformMovingRight(subject, width);
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
