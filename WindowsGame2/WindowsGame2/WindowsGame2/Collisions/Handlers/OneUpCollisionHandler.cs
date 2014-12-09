using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class OneUpCollisionHandler : ICollisionHandler
    {
        IPowerUp subject;
        public OneUpCollisionHandler(IPowerUp powerup)
        {
            this.subject = powerup;
        }

        public void CollisionAbove(ITangible type)
        {
            if (type is IPlayer)
            {
                subject.IsActive = false;
                HUD.LIVES[HUD.currentPlayer]++;
                HUD.level.AddParticle(new Score(subject.Position, 0));
                SoundPanel.PlaySoundEffect(Sound.powerup1upEffect);
            }
        }
        public void CollisionBelow(ITangible type)
        {
            if (type is IPlayer)
            {
                subject.IsActive = false;
                HUD.LIVES[HUD.currentPlayer]++;
                HUD.level.AddParticle(new Score(subject.Position, 0));
                SoundPanel.PlaySoundEffect(Sound.powerup1upEffect);
            }
            else if (type is IBlock && !(type is BlockHidden && type.State is SBlockIdle))
            {
                subject.Position = new Vector2(subject.Position.X, ((IBlock)type).Hitbox.Top() - Hitboxes.ONE_UP_HEIGHT - Hitboxes.ONE_UP_OFFSET_Y);
                subject.Velocity = new Vector2(subject.Velocity.X, 0);
            }
        }
        public void CollisionLeft(ITangible type)
        {
            if (type is IPlayer)
            {
                subject.IsActive = false;
                HUD.LIVES[HUD.currentPlayer]++;
                HUD.level.AddParticle(new Score(subject.Position, 0));
                SoundPanel.PlaySoundEffect(Sound.powerup1upEffect);
            }
            else if (!(type is IEnemy || type is IPowerUp))
            {
                subject.State = new S1UpMovingRight(subject);
            }
        }
        public void CollisionRight(ITangible type)
        {
            if (type is IPlayer)
            {
                HUD.LIVES[HUD.currentPlayer]++;
                subject.IsActive = false;
                HUD.level.AddParticle(new Score(subject.Position, 0));
                SoundPanel.PlaySoundEffect(Sound.powerup1upEffect);

            }
            else if (!(type is IEnemy || type is IPowerUp))
            {
                subject.State = new S1UpMovingLeft(subject);
            }
        }
    }
}
