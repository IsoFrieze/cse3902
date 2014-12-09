using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SpinyCollisionHandler : ICollisionHandler
    {
        IEnemy subject;
        public SpinyCollisionHandler(IEnemy spiny)
        {
            this.subject = spiny;
        }

        public void CollisionAbove(ITangible obj)
        {
            if (!(subject.State is SSpinyEgg || subject.State is SSpinyDeadLeft || subject.State is SSpinyDeadRight || obj is IPowerUp || obj is IEnemy))
            {

                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
                {
                    if (obj is IProjectile || (obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                    {
                        HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_SPINY;
                        HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_SPINY));
                    }
                    else
                    {
                        HUD.KoopaShellSequence(obj);
                    }
                    subject.State = new SSpinyDeadLeft(subject);
                }
            }
        }

        public void CollisionBelow(ITangible obj)
        {
            if (subject.State is SSpinyEgg && obj is IBlock)
            {
                if (HUD.level.player.Position.X < subject.Position.X)
                {
                    subject.State = new SSpinyMovingLeft(subject);
                }
                else
                {
                    subject.State = new SSpinyMovingRight(subject);
                }
            }
            if (obj is IBlock && !(obj is BlockHidden && obj.State is SBlockIdle))
            {
                subject.Position = new Vector2(subject.Position.X, ((IBlock)obj).Hitbox.Top() - Hitboxes.SPINY_HEIGHT - Hitboxes.SPINY_OFFSET_Y);
                subject.Velocity = new Vector2(subject.Velocity.X, 0);
            }
            if (!(subject.State is SSpinyDeadLeft || subject.State is SSpinyDeadRight))
            {
                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
                {
                    if (obj is IProjectile || (obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                    {
                        HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_SPINY;
                        HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_SPINY));
                    }
                    else
                    {
                        HUD.KoopaShellSequence(obj);
                    }
                    subject.State = new SSpinyDeadLeft(subject);
                }
            }
        }

        public void CollisionLeft(ITangible obj)
        {
            if (!(subject.State is SSpinyEgg || subject.State is SSpinyDeadLeft || subject.State is SSpinyDeadRight))
            {


                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
                {
                    if (obj is IProjectile || (obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                    {
                        HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_SPINY;
                        HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_SPINY));
                    }
                    else
                    {
                        HUD.KoopaShellSequence(obj);
                    }
                    subject.State = new SSpinyDeadLeft(subject);
                }
                else if (!(obj is IPowerUp || obj is IPlayer))
                {
                    subject.State = new SSpinyMovingRight(subject);
                }
            }
        }

        public void CollisionRight(ITangible obj)
        {
            if (!(subject.State is SSpinyEgg || subject.State is SSpinyDeadLeft || subject.State is SSpinyDeadRight))
            {

                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
                {
                    if (obj is IProjectile || (obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                    {
                        HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_SPINY;
                        HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_SPINY));
                    }
                    else
                    {
                        HUD.KoopaShellSequence(obj);
                    }

                    subject.State = new SSpinyDeadLeft(subject);
                }
                else if (!(obj is IPowerUp || obj is IPlayer))
                {
                    subject.State = new SSpinyMovingLeft(subject);
                }
            }
        }
    }
}
