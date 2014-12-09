using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class LakituCollisionHandler : ICollisionHandler
    {
        IEnemy subject;
        public LakituCollisionHandler(IEnemy lakitu)
        {
            this.subject = lakitu;
        }

        public void CollisionAbove(ITangible obj)
        {
            if (!(subject.State is SLakituDead || obj is IPowerUp || obj is IEnemy))
            {
                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
                {
                    if (obj is Fireball || (obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                    {
                        HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_LAKITU;
                        HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_LAKITU));
                    }
                    else
                    {
                        HUD.KoopaShellSequence(obj);
                    }
                    subject.State = new SLakituDead(subject);
                }
                else if (obj is IPlayer)
                {
                    HUD.StompingPoints(obj);
                    subject.State = new SLakituDead(subject);
                }
            }
        }

        public void CollisionBelow(ITangible obj)
        {
            if (!(subject.State is SLakituDead))
            {
                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
                {
                    if (obj is Fireball || (obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                    {
                        HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_LAKITU;
                        HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_LAKITU));
                    }
                    else
                    {
                       HUD.KoopaShellSequence(obj);
                    }
                    subject.State = new SLakituDead(subject);
                }
            }
        }

        public void CollisionLeft(ITangible obj)
        {
            if (!(subject.State is SLakituDead))
            {
                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
                {
                    if (obj is Fireball || (obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                    {
                        HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_LAKITU;
                        HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_LAKITU));
                    }
                    else
                    {
                        HUD.KoopaShellSequence(obj);
                    }
                    subject.State = new SLakituDead(subject);
                }
            }
        }

        public void CollisionRight(ITangible obj)
        {
            if (!(subject.State is SLakituDead))
            {

                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
                {
                    if (obj is Fireball || (obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                    {
                        HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_LAKITU;
                        HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_LAKITU));
                    }
                    else
                    {
                        HUD.KoopaShellSequence(obj);
                    }
                    subject.State = new SLakituDead(subject);
                }
            }
        }
    }
}
