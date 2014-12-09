using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SFireballBouncingRight : IProjectileState
    {
        public IProjectile Projectile { get; set; }

        public SFireballBouncingRight(IProjectile projectile)
        {
            this.Projectile = projectile;
            Projectile.Sprite = new Animation(Textures.powerup1up);

            Projectile.Hitbox.Clear();
            SetHitbox();

            Projectile.Velocity = new Vector2(6f, Projectile.Velocity.Y);
            SoundPanel.PlaySoundEffect(Sound.fireballEffect);
        }

        public void Update()
        {
            Projectile.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox()
        {
            Projectile.Hitbox.AddRectHitbox(
                    (int)Projectile.Position.X,
                    (int)Projectile.Position.Y,
                    Hitboxes.FIREBALL_WIDTH,
                    Hitboxes.FIREBALL_HEIGHT
                );
        }
    }
}
