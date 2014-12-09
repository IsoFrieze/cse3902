using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class AxeCollisionHandler : ICollisionHandler
    {
        IBlock subject;
        public AxeCollisionHandler(IBlock block)
        {
            this.subject = block;
        }

        public void CollisionAbove(ITangible type)
        {
            if (type is IPlayer)
            {
                subject.IsActive = false;
            }

        }
        public void CollisionBelow(ITangible type)
        {
            if (type is IPlayer)
            {
                subject.IsActive = false;
            }
        }
        public void CollisionLeft(ITangible type)
        {
            if (type is IPlayer)
            {
                subject.IsActive = false;
            }
        }
        public void CollisionRight(ITangible type)
        {
            if (type is IPlayer)
            {
                subject.IsActive = false;
            }
        }
    }
}
