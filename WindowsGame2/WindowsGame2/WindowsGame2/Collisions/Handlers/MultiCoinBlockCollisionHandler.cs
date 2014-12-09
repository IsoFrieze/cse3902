using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class MultiCoinBlockCollisionHandler : ICollisionHandler
    {
        BlockMultiCoin subject;

        public MultiCoinBlockCollisionHandler(IBlock block)
        {
            this.subject = (BlockMultiCoin)block;
        }

        public void CollisionAbove(ITangible type)
        {
            
        }
        public void CollisionBelow(ITangible type)
        {
            if (type is IPlayer && subject.State is SBlockIdle)
            {
                if (subject is IContainer && ((IContainer)subject).Contains.Length > 0)
                {
                    subject.State = new SBlockGettingBumped(subject, new SBlockIdle(subject));
                    ((IContainer)subject).Empty((IPlayer)type);
                }
            }
        }
        public void CollisionLeft(ITangible type)
        {

        }
        public void CollisionRight(ITangible type)
        {

        }
    }
}
