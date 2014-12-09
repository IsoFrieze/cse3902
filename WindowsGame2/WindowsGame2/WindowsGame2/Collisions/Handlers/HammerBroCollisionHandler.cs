using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class HammerBroCollisionHandler : ICollisionHandler
    {
        IEnemy subject;
        public HammerBroCollisionHandler(IEnemy hammerbro)
        {
            this.subject = hammerbro;
        }

        public void CollisionAbove(ITangible obj)
        {
            if (!(subject.State is SHammerBroDead || obj is IPowerUp || obj is IEnemy))
            {
                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
                {
                    if (obj is Fireball || (obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                    {
                        HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_HAMMERBRO;
                        HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_HAMMERBRO));
                    }
                    else
                    {
                        HUD.KoopaShellSequence(obj);
                    }
                    subject.State = new SHammerBroDead(subject);
                }
                else if (obj is IPlayer)
                {
                    HUD.StompingPoints(obj);
                    subject.State = new SHammerBroDead(subject);
                }
            }
        }

        public void CollisionBelow(ITangible obj)
        {
            if (!(subject.State is SHammerBroDead))
            {
                if (!(subject.State is SHammerBroJump) && obj is IBlock && !(obj is BlockHidden && obj.State is SBlockIdle))
                {
                    subject.Position = new Vector2(subject.Position.X, ((IBlock)obj).Hitbox.Top() - Hitboxes.HAMMERBRO_HEIGHT - Hitboxes.HAMMERBRO_OFFSET_Y);
                    subject.Velocity = new Vector2(subject.Velocity.X, 0);
                }
                if (obj is IBlock && (obj.State is SBlockGettingBumped ||obj.State is SBlockBroken ))
                {
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_BUMP_HAMMERBRO;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_BUMP_HAMMERBRO));
                    subject.State = new SHammerBroDead(subject);
                }
                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
                {
                    if (obj is Fireball || (obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                    {
                        HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_HAMMERBRO;
                        HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_HAMMERBRO));
                    }
                    else
                    {
                       HUD.KoopaShellSequence(obj);
                    }
                    subject.State = new SHammerBroDead(subject);
                }
            }
        }

        public void CollisionLeft(ITangible obj)
        {
            if (!(subject.State is SHammerBroDead))
            {
                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
                {
                    if (obj is Fireball || (obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                    {
                        HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_HAMMERBRO;
                        HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_HAMMERBRO));
                    }
                    else
                    {
                        HUD.KoopaShellSequence(obj);
                    }
                    subject.State = new SHammerBroDead(subject);
                }
            }
        }

        public void CollisionRight(ITangible obj)
        {
            if (!(subject.State is SHammerBroDead))
            {

                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
                {
                    if (obj is Fireball || (obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                    {
                        HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_HAMMERBRO;
                        HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_HAMMERBRO));
                    }
                    else
                    {
                        HUD.KoopaShellSequence(obj);
                    }
                    subject.State = new SHammerBroDead(subject);
                }
            }
        }
    }
}
