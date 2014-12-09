using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SpringboardCollisionHandler : ICollisionHandler
    {
        IBlock subject;
        public SpringboardCollisionHandler(IBlock block)
        {
            this.subject = block;
        }

        public void CollisionAbove(ITangible type)
        {
            if (type is IPlayer && subject.State is SSpringboardIdle)
            {
                subject.State = new SSpringboardCompressing(subject);
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
