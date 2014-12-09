using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SHammer: IProjectileState
    {
        public IProjectile Projectile { get; set; }
        private int counter;
        public SHammer(IProjectile projectile)
        {
            this.counter = 0;
            this.Projectile = projectile;
            Projectile.Hitbox.Clear();
            SetHitbox();

            Projectile.Velocity = new Vector2(-1f, -3f);
        }
        public void Update()
        {
            Projectile.Hitbox.Cycle();
            SetHitbox();
            if (counter == HotDAMN.TICKS_UNTIL_HAMMER_DISAPPEARS)
                Projectile.IsActive = false;
            counter++;
        }

        private void SetHitbox()
        {
            Projectile.Hitbox.AddRectHitbox(
                    (int)Projectile.Position.X,
                    (int)Projectile.Position.Y,
                    Hitboxes.HAMMER_WIDTH,
                    Hitboxes.HAMMER_HEIGHT
                );
        }
    }
}
