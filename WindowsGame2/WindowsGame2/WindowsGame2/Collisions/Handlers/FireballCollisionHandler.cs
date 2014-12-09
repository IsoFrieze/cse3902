using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class FireballCollisionHandler : ICollisionHandler
    {
        IProjectile subject;
        public FireballCollisionHandler(IProjectile projectile)
        {
            this.subject = projectile;
        }

        public void CollisionAbove(ITangible type)
        {
            if (!(type is IPlayer || type is IProjectile))
            {
                HUD.level.AddParticle(new Explosion(subject.Position));
                subject.IsActive = false;
                if (!(type is IEnemy))
                {
                    SoundPanel.PlaySoundEffect(Sound.bumpEffect);
                }
            }
        }
        public void CollisionBelow(ITangible type)
        {
            if (type is IEnemy)
            {
                HUD.level.AddParticle(new Explosion(subject.Position));
                subject.IsActive = false;
            }

            if (type is IBlock && !(type is BlockHidden && type.State is SBlockIdle))
            {
                subject.Position = new Vector2(subject.Position.X, ((IBlock)type).Hitbox.Top() - Hitboxes.FIREBALL_HEIGHT - Hitboxes.FIREBALL_OFFSET_Y);
                subject.Velocity = new Vector2(subject.Velocity.X, -Physics.TERMINAL_VELOCITY_FIREBALL);
            }
        }
        public void CollisionLeft(ITangible type)
        {
            if (!(type is IPlayer || type is IProjectile))
            {
                HUD.level.AddParticle(new Explosion(subject.Position));
                subject.IsActive = false;
                if (!(type is IEnemy))
                {
                    SoundPanel.PlaySoundEffect(Sound.bumpEffect);
                }
            }
        }
        public void CollisionRight(ITangible type)
        {
            if (!(type is IPlayer || type is IProjectile))
            {
                HUD.level.AddParticle(new Explosion(subject.Position));
                subject.IsActive = false;
                if (!(type is IEnemy))
                {
                    SoundPanel.PlaySoundEffect(Sound.bumpEffect);
                }
            }
        }
    }
}
