using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class GoombaCollisionHandler : ICollisionHandler
    {
        IEnemy subject;
        String left = "left";
        String right = "right";
        public GoombaCollisionHandler(IEnemy goomba)
        {
            this.subject = goomba;
        }

        public void CollisionAbove(ITangible obj)
        {
            if (!(subject.State is SGoombaStomped || obj is IPowerUp || obj is IEnemy))
            {
                
                    if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
                    {
                        if (obj is IProjectile || (obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                        {
                            HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_GOOMBA;
                            HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_GOOMBA));
                        }
                        else
                        {
                            HUD.KoopaShellSequence(obj);
                        }
                        subject.State = new SGoombaDead(subject);
                    }
                    else
                    {
                        HUD.StompingPoints(obj);
                        subject.State = new SGoombaStomped(subject);
                    }
                
            }
        }

        public void CollisionBelow(ITangible obj)
        {
            if (obj is IBlock && !(obj is BlockHidden && obj.State is SBlockIdle))
            {
                subject.Position = new Vector2(subject.Position.X, ((IBlock)obj).Hitbox.Top() - Hitboxes.GOOMBA_HEIGHT - Hitboxes.GOOMBA_OFFSET_Y);
                subject.Velocity = new Vector2(subject.Velocity.X, 0);
            }
            if (!(subject.State is SGoombaStomped))
            {
                if (obj is IBlock && (obj.State is SBlockGettingBumped ||obj.State is SBlockBroken ))
                {
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_BUMP_GOOMBA;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_BUMP_GOOMBA));
                    subject.State = new SGoombaDead(subject);
                }
                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
                {
                    if (obj is IProjectile || (obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                    {
                        HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_GOOMBA;
                        HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_GOOMBA));
                    }
                    else
                    {
                       HUD.KoopaShellSequence(obj);
                    }
                    subject.State = new SGoombaDead(subject);
                }
            }
        }

        public void CollisionLeft(ITangible obj)
        {
            if (!(subject.State is SGoombaStomped))
            {


                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
                {
                    if (obj is IProjectile || (obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                    {
                        HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_GOOMBA;
                        HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_GOOMBA));
                    }
                    else
                    {
                        HUD.KoopaShellSequence(obj);
                    }
                    subject.State = new SGoombaDead(subject, right);
                }
                else if (!(obj is IPowerUp || obj is IPlayer))
                {
                    subject.State = new SGoombaMovingRight(subject);
                }
            }
        }

        public void CollisionRight(ITangible obj)
        {
            if (!(subject.State is SGoombaStomped))
            {

                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
                {
                    if (obj is IProjectile || (obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                    {
                        HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_GOOMBA;
                        HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_GOOMBA));
                    }
                    else
                    {
                        HUD.KoopaShellSequence(obj);
                    }

                    subject.State = new SGoombaDead(subject, left);
                }
                else if (!(obj is IPowerUp || obj is IPlayer))
                {
                    subject.State = new SGoombaMovingLeft(subject);
                }
            }
        }
    }
}
