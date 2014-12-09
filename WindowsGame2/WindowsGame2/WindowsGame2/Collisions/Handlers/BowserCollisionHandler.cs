using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2.Collisions.Handlers
{
    public class BowserCollisionHandler : ICollisionHandler
    {
        IEnemy subject;

        int FireballHitCount;
        public BowserCollisionHandler(IEnemy bowser) {
            this.subject = bowser;
            this.FireballHitCount = 0;
        }
        public void CollisionAbove(ITangible obj) {
            if (obj is Fireball)
            {
                FireballHitCount++;
                if (FireballHitCount == 6)
                {
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_BOWSER;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_BOWSER));
                    subject.State = new SFireballDeadBowser(subject);
                    FireballHitCount = 0;
                }
            }
        }
        public void CollisionBelow(ITangible obj)
        {
            if (obj is IBlock && !(obj is MovingPlatform))
            {
                subject.Position = new Vector2(subject.Position.X, ((IBlock)obj).Hitbox.Top() - Hitboxes.BOWSERS_HEIGHT - Hitboxes.BOWSERS_OFFSET_Y);
                subject.Velocity = new Vector2(subject.Velocity.X, 0);
            }
            else if (obj is Fireball) {
                FireballHitCount++;
                if (FireballHitCount == 6) {
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_BOWSER;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_BOWSER)); 
                    subject.State = new SFireballDeadBowser(subject);
                    FireballHitCount = 0;
                }
            }
        }
        public void CollisionLeft(ITangible obj) {
            if (obj is Fireball)
            {
                FireballHitCount++;
                if (FireballHitCount == 6)
                {
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_BOWSER;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_BOWSER));
                    subject.State = new SFireballDeadBowser(subject);
                    FireballHitCount = 0;
                }
            }
        }
        public void CollisionRight(ITangible obj) { 
            if (obj is Fireball)
            {
                FireballHitCount++;
                if (FireballHitCount == 6)
                {
                    HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_BOWSER;
                    HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_BOWSER));
                    subject.State = new SFireballDeadBowser(subject);
                    FireballHitCount = 0;
                }
            }
        }
    }
}
