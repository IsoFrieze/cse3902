using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class QuestionBlockCollisionHandler : ICollisionHandler
    {
        IBlock subject;
        public QuestionBlockCollisionHandler(IBlock block)
        {
            this.subject = block;
        }

        public void CollisionAbove(ITangible type)
        {

        }

        public void CollisionBelow(ITangible type)
        {
            if (type is IPlayer && subject.State is SBlockIdle)
            {
                subject.State = new SBlockGettingBumped(subject, new SBlockUsed(subject));
                if (subject is IContainer)
                {
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
