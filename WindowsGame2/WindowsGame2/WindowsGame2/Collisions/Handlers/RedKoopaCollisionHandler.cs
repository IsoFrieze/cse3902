using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class RedKoopaCollisionHandler : ICollisionHandler
    {
        IEnemy subject;
        String left = "left";
        String right = "right";
        public RedKoopaCollisionHandler(IEnemy redKoopa)
        {
            this.subject = redKoopa;
        }

        public void CollisionAbove(ITangible obj)
        {
            if (obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
            {

                if (obj is Fireball)
                {
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_KOOPA;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_KOOPA));
                }
                else
                {
                    HUD.KoopaShellSequence(obj);
                }
                subject.State = new SRedKoopaDead(subject);
            }

            if (obj is IPlayer)
            {
                if (((IPlayer)obj).Decorator is StarPlayer)
                {
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_KOOPA;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_KOOPA));
                    subject.State = new SRedKoopaDead(subject);
                }
                    // Will be replaced with paraKoopa
               // else if (subject.State is SKoopaBouncingLeft)
                //{
                    //SoundPanel.PlaySoundEffect(Sound.stompEffect);
                    //HUD.SCORE += HotDAMN.SCORE_DEWING_KOOPA;
                    //HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_DEWING_KOOPA));
                    //subject.State = new SRedKoopaWalkingLeft(subject);
                //}
                //else if (subject.State is SKoopaBouncingRight)
                //{
                    //SoundPanel.PlaySoundEffect(Sound.stompEffect);
                    //HUD.SCORE += HotDAMN.SCORE_DEWING_KOOPA;
                    //HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_DEWING_KOOPA));
                    //subject.State = new SRedKoopaWalkingRight(subject);
                //}
                else if (!(subject.State is SRedKoopaShelledUpsideDown || subject.State is SRedKoopaUpsideDownShellMovingLeft || subject.State is SRedKoopaUpsideDownShellMovingRight))
                {
                    HUD.StompingPoints(obj);
                    subject.State = new SRedKoopaShelled(subject);
                }
                else
                {
                    HUD.StompingPoints(obj);
                    subject.State = new SRedKoopaShelledUpsideDown(subject);
                }
            }
        }

        public void CollisionBelow(ITangible obj)
        {
            if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
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
                subject.State = new SRedKoopaDead(subject);
            }

            if ((obj is IBlock && (obj.State is SBlockGettingBumped || obj.State is SBlockBroken)))
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_BUMP_KOOPA;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_BUMP_KOOPA));
                subject.State = new SRedKoopaShelledUpsideDown(subject);
            }
            else if (obj is IBlock && !(obj is BlockHidden && obj.State is SBlockIdle))
            {
                subject.Position = new Vector2(subject.Position.X, ((IBlock)obj).Hitbox.Top() - Hitboxes.KOOPA_HEIGHT - Hitboxes.KOOPA_OFFSET_Y);
                subject.Velocity = new Vector2(subject.Velocity.X, 0);
            }
        }

        public void CollisionLeft(ITangible obj)
        {
            if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
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
                subject.State = new SRedKoopaDead(subject, right);
            }
            if (subject.State is SRedKoopaWalkingLeft && !(obj is IPlayer || obj is IPowerUp))
            {
                subject.State = new SRedKoopaWalkingRight(subject);
            }
            if ((subject.State is SRedKoopaShelled || subject.State is SRedKoopaWarning) && obj is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KICK_KOOPA;
                SoundPanel.PlaySoundEffect(Sound.kickEffect);
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KICK_KOOPA));
                subject.State = new SRedKoopaShellMovingRight(subject);
            }
            if ((subject.State is SRedKoopaShellMovingLeft) && !(obj is IEnemy || obj is IPowerUp || obj is IPlayer))
            {
                subject.State = new SRedKoopaShellMovingRight(subject);
            }
            if ((subject.State is SRedKoopaShelledUpsideDown || subject.State is SRedKoopaWarningUpsideDown) && obj is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KICK_KOOPA;
                SoundPanel.PlaySoundEffect(Sound.kickEffect);
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KICK_KOOPA));
                subject.State = new SRedKoopaUpsideDownShellMovingRight(subject);
            }
            if ((subject.State is SRedKoopaUpsideDownShellMovingLeft) && !(obj is IEnemy || obj is IPowerUp || obj is IPlayer))
            {
                subject.State = new SRedKoopaUpsideDownShellMovingRight(subject);
            }
        }

        public void CollisionRight(ITangible obj)
        {
            if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is Fireball || obj.State is SKoopaShellMovingRight || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SRedKoopaShellMovingRight || obj.State is SRedKoopaShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingLeft || obj.State is SRedKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight)
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
                subject.State = new SRedKoopaDead(subject, left);
            }
            if (subject.State is SRedKoopaWalkingRight && !(obj is IPlayer || obj is IPowerUp))
            {
                subject.State = new SRedKoopaWalkingLeft(subject);
            }
            if ((subject.State is SRedKoopaShelled || subject.State is SRedKoopaWarning) && obj is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KICK_KOOPA;
                SoundPanel.PlaySoundEffect(Sound.kickEffect);
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KICK_KOOPA));
                subject.State = new SRedKoopaShellMovingLeft(subject);
            }
            if ((subject.State is SRedKoopaShellMovingRight) && !(obj is IEnemy || obj is IPowerUp || obj is IPlayer))
            {
                subject.State = new SRedKoopaShellMovingLeft(subject);
            }
            if ((subject.State is SRedKoopaShelledUpsideDown || subject.State is SRedKoopaWarningUpsideDown) && obj is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KICK_KOOPA;
                SoundPanel.PlaySoundEffect(Sound.kickEffect);
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KICK_KOOPA));
                subject.State = new SRedKoopaUpsideDownShellMovingLeft(subject);
            }
            if ((subject.State is SRedKoopaUpsideDownShellMovingRight) && !(obj is IEnemy || obj is IPowerUp || obj is IPlayer))
            {
                subject.State = new SRedKoopaUpsideDownShellMovingLeft(subject);
            }
        }
    }
}
