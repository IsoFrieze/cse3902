using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class BuzzyBeetleCollisionHandler : ICollisionHandler
    {
        IEnemy subject;
        String left = "left";
        String right = "right";
        public BuzzyBeetleCollisionHandler(IEnemy buzzybeetle)
        {
            this.subject = buzzybeetle;
        }

        public void CollisionAbove(ITangible obj)
        {
            if (obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
            {
                    HUD.KoopaShellSequence(obj);
                
                subject.State = new SBuzzyBeetleDead(subject);
            }

            if (obj is IPlayer)
            {
                if (((IPlayer)obj).Decorator is StarPlayer)
                {
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_BUZZYBEETLE;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_BUZZYBEETLE));
                    subject.State = new SBuzzyBeetleDead(subject);
                }
                else if (!(subject.State is SBuzzyBeetleShelledUpsideDown || subject.State is SBuzzyBeetleUpsideDownShellMovingLeft || subject.State is SBuzzyBeetleUpsideDownShellMovingRight))
                {
                    HUD.StompingPoints(obj);
                    subject.State = new SBuzzyBeetleShelled(subject);
                }
                else
                {
                    HUD.StompingPoints(obj);
                    subject.State = new SBuzzyBeetleShelledUpsideDown(subject);
                }
            }
        }

        public void CollisionBelow(ITangible obj)
        {
            if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
            {
                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) && obj is IProjectile)
                {
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_BUZZYBEETLE;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_BUZZYBEETLE));
                }
                else
                {
                    HUD.KoopaShellSequence(obj);
                }
                subject.State = new SBuzzyBeetleDead(subject);
            }

            if ((obj is IBlock && (obj.State is SBlockGettingBumped || obj.State is SBlockBroken)))
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_BUMP_BUZZYBEETLE;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_BUMP_BUZZYBEETLE));
                subject.State = new SBuzzyBeetleShelledUpsideDown(subject);
            }
            else if (obj is IBlock && !(obj is BlockHidden && obj.State is SBlockIdle))
            {
                subject.Position = new Vector2(subject.Position.X, ((IBlock)obj).Hitbox.Top() - Hitboxes.BUZZYBEETLE_HEIGHT - Hitboxes.BUZZYBEETLE_OFFSET_Y);
                subject.Velocity = new Vector2(subject.Velocity.X, 0);
            }
        }

        public void CollisionLeft(ITangible obj)
        {
            if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
            {
                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                {
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_BUZZYBEETLE;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_BUZZYBEETLE));
                }
                else
                {
                    HUD.KoopaShellSequence(obj);
                }
                subject.State = new SBuzzyBeetleDead(subject, right);
            }
            if (subject.State is SBuzzyBeetleWalkingLeft && !(obj is IPlayer || obj is IPowerUp))
            {
                subject.State = new SBuzzyBeetleWalkingRight(subject);
            }
            if (subject.State is SBuzzyBeetleShelled && obj is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KICK_BUZZYBEETLE;
                SoundPanel.PlaySoundEffect(Sound.kickEffect);
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KICK_BUZZYBEETLE));
                subject.State = new SBuzzyBeetleShellMovingRight(subject);
            }
            if ((subject.State is SBuzzyBeetleShellMovingLeft) && !(obj is IEnemy || obj is IPowerUp || obj is IPlayer))
            {
                subject.State = new SBuzzyBeetleShellMovingRight(subject);
            }
            if (subject.State is SBuzzyBeetleShelledUpsideDown && obj is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KICK_BUZZYBEETLE;
                SoundPanel.PlaySoundEffect(Sound.kickEffect);
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KICK_BUZZYBEETLE));
                subject.State = new SBuzzyBeetleUpsideDownShellMovingRight(subject);
            }
            if ((subject.State is SBuzzyBeetleUpsideDownShellMovingLeft) && !(obj is IEnemy || obj is IPowerUp || obj is IPlayer))
            {
                subject.State = new SBuzzyBeetleUpsideDownShellMovingRight(subject);
            }
        }

        public void CollisionRight(ITangible obj)
        {
            if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaShellMovingRight || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
            {
                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer))
                {
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_BUZZYBEETLE;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_BUZZYBEETLE));
                }
                else
                {
                    HUD.KoopaShellSequence(obj);
                }
                subject.State = new SBuzzyBeetleDead(subject, left);
            }
            if (subject.State is SBuzzyBeetleWalkingRight && !(obj is IPlayer || obj is IPowerUp))
            {
                subject.State = new SBuzzyBeetleWalkingLeft(subject);
            }
            if (subject.State is SBuzzyBeetleShelled && obj is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KICK_BUZZYBEETLE;
                SoundPanel.PlaySoundEffect(Sound.kickEffect);
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KICK_BUZZYBEETLE));
                subject.State = new SBuzzyBeetleShellMovingLeft(subject);
            }
            if ((subject.State is SBuzzyBeetleShellMovingRight) && !(obj is IEnemy || obj is IPowerUp || obj is IPlayer))
            {
                subject.State = new SBuzzyBeetleShellMovingLeft(subject);
            }
            if (subject.State is SBuzzyBeetleShelledUpsideDown && obj is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KICK_BUZZYBEETLE;
                SoundPanel.PlaySoundEffect(Sound.kickEffect);
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KICK_BUZZYBEETLE));
                subject.State = new SBuzzyBeetleUpsideDownShellMovingLeft(subject);
            }
            if ((subject.State is SBuzzyBeetleUpsideDownShellMovingRight) && !(obj is IEnemy || obj is IPowerUp || obj is IPlayer))
            {
                subject.State = new SBuzzyBeetleUpsideDownShellMovingLeft(subject);
            }
        }
    }
}
