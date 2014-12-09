using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class BlooperCollisionHandler : ICollisionHandler
    {
        IEnemy subject;
        public BlooperCollisionHandler(IEnemy blooper)
        {
            this.subject = blooper;
        }

        public void CollisionAbove(ITangible type)
        {
            if ((type is IPlayer && ((IPlayer)type).Decorator is StarPlayer) || type is Fireball)
            {
                subject.State = new SBlooperDead(subject);
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_CHEEPCHEEP;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_BLOOPER));
                Sound.kickEffect.Play();
            }
        }
        public void CollisionBelow(ITangible type)
        {
            if ((type is IPlayer && ((IPlayer)type).Decorator is StarPlayer) || type is Fireball)
            {
                subject.State = new SBlooperDead(subject);
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_CHEEPCHEEP;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_BLOOPER));
                Sound.kickEffect.Play();
            }
        }
        public void CollisionLeft(ITangible type)
        {
            if ((type is IPlayer && ((IPlayer)type).Decorator is StarPlayer) || type is Fireball)
            {
                subject.State = new SBlooperDead(subject);
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_CHEEPCHEEP;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_BLOOPER));
                Sound.kickEffect.Play();
            }
        }
        public void CollisionRight(ITangible type)
        {
            if ((type is IPlayer && ((IPlayer)type).Decorator is StarPlayer) || type is Fireball)
            {
                subject.State = new SBlooperDead(subject);
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_CHEEPCHEEP;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_BLOOPER));
                Sound.kickEffect.Play();
            }
        }
    }
}
