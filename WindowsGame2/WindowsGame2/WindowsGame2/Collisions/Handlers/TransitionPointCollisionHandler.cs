using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class TransitionPointCollisionHandler : ICollisionHandler
    {
        IBlock subject;
        public TransitionPointCollisionHandler(IBlock block)
        {
            this.subject = block;
        }

        public void CollisionAbove(ITangible type)
        {
            if (type is IPlayer)
            {
                subject.State = new STransitionPointActive(subject);
            }
        }
        public void CollisionBelow(ITangible type)
        {
            if (type is IPlayer)
            {
                subject.State = new STransitionPointActive(subject);
            }
        }
        public void CollisionLeft(ITangible type)
        {
            if (type is IPlayer)
            {
                subject.State = new STransitionPointActive(subject);
            }
        }
        public void CollisionRight(ITangible type)
        {
            if (type is IPlayer)
            {
                subject.State = new STransitionPointActive(subject);
            }
        }
    }
}
