using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SBowserFireballLeft : IProjectileState
    {
        public IProjectile Projectile { get; set; }
        private int counter;
        public SBowserFireballLeft(IProjectile projectile) {
            this.counter = 0;
            this.Projectile = projectile;
            Projectile.Hitbox.Clear();
            SetHitbox();

            Projectile.Velocity = new Vector2(-2f, 0f);
            SoundPanel.PlaySoundEffect(Sound.bowerfireEffect);
        }
        public void Update()
        {
            Projectile.Hitbox.Cycle();
            SetHitbox();
            if (counter == HotDAMN.TICKS_UNTIL_BOWSERS_FIREBALL_DISAPPEARS)
                Projectile.IsActive = false;
            counter++;
        }

        private void SetHitbox()
        {
            Projectile.Hitbox.AddRectHitbox(
                    (int)Projectile.Position.X,
                    (int)Projectile.Position.Y,
                    Hitboxes.BOWSERS_FIREBALL_WIDTH,
                    Hitboxes.BOWSERS_FIREBALL_HEIGHT
                );
        }
    }
}
