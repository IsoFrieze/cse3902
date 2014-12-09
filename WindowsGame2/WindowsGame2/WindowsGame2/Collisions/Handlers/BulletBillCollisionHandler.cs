using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class BulletBillCollisionHandler : ICollisionHandler
    {
        IEnemy subject;
        String left = "left";
        String right = "right";
        public BulletBillCollisionHandler(IEnemy bulletbill)
        {
            this.subject = bulletbill;
        }

        public void CollisionAbove(ITangible type)
        {

            if ((type is IPlayer && ((IPlayer)type).Decorator is StarPlayer))
            {
                subject.State = new SBulletDead(subject);
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_BULLETBILL;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_BULLETBILL));
            }
            else if (type is IPlayer)
            {
                subject.State = new SBulletStomped(subject);
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_BULLETBILL;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_BULLETBILL));
            }
        }
        public void CollisionBelow(ITangible type)
        {
            if ((type is IPlayer && ((IPlayer)type).Decorator is StarPlayer))
            {
                subject.State = new SBulletDead(subject);
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_BULLETBILL;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_BULLETBILL));
            }
        }
        public void CollisionLeft(ITangible type)
        {
            if ((type is IPlayer && ((IPlayer)type).Decorator is StarPlayer))
            {
                subject.State = new SBulletDead(subject, right);
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_BULLETBILL;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_BULLETBILL));
            }
        }
        public void CollisionRight(ITangible type)
        {
            if ((type is IPlayer && ((IPlayer)type).Decorator is StarPlayer))
            {
                subject.State = new SBulletDead(subject, left);
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_BULLETBILL;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_BULLETBILL));
            }
        }
    }
}
