using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class KoopaCollisionHandler : ICollisionHandler
    {
        IEnemy subject;
        String left = "left";
        String right = "right";
        public KoopaCollisionHandler(IEnemy koopa)
        {
            this.subject = koopa;
        }

        public void CollisionAbove(ITangible obj)
        {
            if (obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
            {

                if (obj is IProjectile)
                {
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_KOOPA;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_KOOPA));
                }
                else
                {
                    HUD.KoopaShellSequence(obj);
                }
                subject.State = new SKoopaDead(subject);
            }

            if (obj is IPlayer)
            {
                if (((IPlayer)obj).Decorator is StarPlayer)
                {
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_KOOPA;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_KOOPA));
                    subject.State = new SKoopaDead(subject);
                }
                else if (subject.State is SKoopaBouncingLeft)
                {
                    SoundPanel.PlaySoundEffect(Sound.stompEffect);
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_DEWING_KOOPA;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_DEWING_KOOPA));
                    subject.State = new SKoopaWalkingLeft(subject);
                }
                else if (subject.State is SKoopaBouncingRight)
                {
                    SoundPanel.PlaySoundEffect(Sound.stompEffect);
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_DEWING_KOOPA;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_DEWING_KOOPA));
                    subject.State = new SKoopaWalkingRight(subject);
                }
                else if (!(subject.State is SKoopaShelledUpsideDown || subject.State is SKoopaUpsideDownShellMovingLeft || subject.State is SKoopaUpsideDownShellMovingRight))
                {
                    HUD.StompingPoints(obj); 
                    subject.State = new SKoopaShelled(subject);
                }
                else
                {
                    HUD.StompingPoints(obj);
                    subject.State = new SKoopaShelledUpsideDown(subject);
                }
            }
        }

        public void CollisionBelow(ITangible obj)
        {
            if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
            {
                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball)
                {
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_KOOPA;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_KOOPA));
                }
                else
                {
                    HUD.KoopaShellSequence(obj);
                }
                subject.State = new SKoopaDead(subject);
            }

            if ((obj is IBlock && (obj.State is SBlockGettingBumped ||obj.State is SBlockBroken)))
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_BUMP_KOOPA;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_BUMP_KOOPA));
                subject.State = new SKoopaShelledUpsideDown(subject);
            }
            else if (obj is IBlock && !(obj is BlockHidden && obj.State is SBlockIdle))
            {
                if (subject.State is SKoopaBouncingLeft || subject.State is SKoopaBouncingRight)
                {
                    subject.Position = new Vector2(subject.Position.X, ((IBlock)obj).Hitbox.Top() - Hitboxes.KOOPA_HEIGHT - Hitboxes.KOOPA_OFFSET_Y);
                    subject.Velocity = new Vector2(subject.Velocity.X, -Physics.TERMINAL_VELOCITY_KOOPA);
                }
                else
                {
                    subject.Position = new Vector2(subject.Position.X, ((IBlock)obj).Hitbox.Top() - Hitboxes.KOOPA_HEIGHT - Hitboxes.KOOPA_OFFSET_Y);
                    subject.Velocity = new Vector2(subject.Velocity.X, 0);
                }
            }
        }

        public void CollisionLeft(ITangible obj)
        {
            if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
            {
                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball)
                {
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_KOOPA;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_KOOPA));
                }
                else
                {
                    HUD.KoopaShellSequence(obj);
                }
                subject.State = new SKoopaDead(subject, right);
            }
            if (subject.State is SKoopaWalkingLeft && !(obj is IPlayer || obj is IPowerUp))
            {
                subject.State = new SKoopaWalkingRight(subject);
            }
            if ((subject.State is SKoopaShelled || subject.State is SKoopaWarning) && obj is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KICK_KOOPA;
                SoundPanel.PlaySoundEffect(Sound.kickEffect);
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KICK_KOOPA));
                subject.State = new SKoopaShellMovingRight(subject);
            }
            if ((subject.State is SKoopaShellMovingLeft) && !(obj is IEnemy || obj is IPowerUp || obj is IPlayer))
            {
                subject.State = new SKoopaShellMovingRight(subject);
            }
            if ((subject.State is SKoopaShelledUpsideDown || subject.State is SKoopaWarningUpsideDown) && obj is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KICK_KOOPA;
                SoundPanel.PlaySoundEffect(Sound.kickEffect);
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KICK_KOOPA));
                subject.State = new SKoopaUpsideDownShellMovingRight(subject);
            }
            if ((subject.State is SKoopaUpsideDownShellMovingLeft) && !(obj is IEnemy || obj is IPowerUp || obj is IPlayer))
            {
                subject.State = new SKoopaUpsideDownShellMovingRight(subject);
            }
            if (subject.State is SKoopaBouncingLeft)
            {
                subject.State = new SKoopaBouncingRight(subject);
            }
        }

        public void CollisionRight(ITangible obj)
        {
            if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
            {
                if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball)
                {
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_KOOPA;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_KOOPA));
                }
                else
                {
                    HUD.KoopaShellSequence(obj);
                }
                subject.State = new SKoopaDead(subject, left);
            }
            if (subject.State is SKoopaWalkingRight && !(obj is IPlayer || obj is IPowerUp))
            {
                subject.State = new SKoopaWalkingLeft(subject);
            }
            if ((subject.State is SKoopaShelled || subject.State is SKoopaWarning) && obj is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KICK_KOOPA;
                SoundPanel.PlaySoundEffect(Sound.kickEffect);
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KICK_KOOPA));
                subject.State = new SKoopaShellMovingLeft(subject);
            }
            if ((subject.State is SKoopaShellMovingRight) && !(obj is IEnemy || obj is IPowerUp || obj is IPlayer))
            {
                subject.State = new SKoopaShellMovingLeft(subject);
            }
            if ((subject.State is SKoopaShelledUpsideDown || subject.State is SKoopaWarningUpsideDown) && obj is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KICK_KOOPA;
                SoundPanel.PlaySoundEffect(Sound.kickEffect);
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KICK_KOOPA));
                subject.State = new SKoopaUpsideDownShellMovingLeft(subject);
            }
            if ((subject.State is SKoopaUpsideDownShellMovingRight) && !(obj is IEnemy || obj is IPowerUp || obj is IPlayer))
            {
                subject.State = new SKoopaUpsideDownShellMovingLeft(subject);
            }
            if (subject.State is SKoopaBouncingRight)
            {
                subject.State = new SKoopaBouncingLeft(subject);
            }
        }
    }
}
