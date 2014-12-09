using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class FireflowerCollisionHandler : ICollisionHandler
    {
        IPowerUp subject;
        public FireflowerCollisionHandler(IPowerUp powerup)
        {
            this.subject = powerup;
        }

        public void CollisionAbove(ITangible type)
        {
            if (type is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_FIREFLOWER;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_COLLECT_FIREFLOWER));
                subject.IsActive = false;
            }
        }
        public void CollisionBelow(ITangible type)
        {
            if (type is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_FIREFLOWER;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_COLLECT_FIREFLOWER));
                subject.IsActive = false;
            }
        }
        public void CollisionLeft(ITangible type)
        {
            if (type is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_FIREFLOWER;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_COLLECT_FIREFLOWER));
                subject.IsActive = false;
            }
        }
        public void CollisionRight(ITangible type)
        {
            if (type is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_FIREFLOWER;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_COLLECT_FIREFLOWER));
                subject.IsActive = false;
            }
        }
    }
}
