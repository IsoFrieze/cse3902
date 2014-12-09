using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class BrickBlockCollisionHandler : ICollisionHandler
    {
        IBlock subject;
        public BrickBlockCollisionHandler(IBlock block)
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
                if (subject is IContainer && ((IContainer)subject).Contains.Length > 0)
                {
                    subject.State = new SBlockGettingBumped(subject, new SBlockUsed(subject));
                    ((IContainer)subject).Empty((IPlayer)type);
                }
                else
                {
                    if (type.State is ISmallMarioState)
                    {
                        subject.State = new SBlockGettingBumped(subject, new SBlockIdle(subject));
                    }
                    else
                    {
                        HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_BREAK_BRICK;
                        subject.State = new SBlockBroken(subject);
                    }
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
