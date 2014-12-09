using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SBowserShootingFireBallsLeft : IEnemyState
    {
        public IEnemy Enemy { get; set; }
        public IProjectile Fireball, Hammer;
        private int MovingCount;
        public SBowserShootingFireBallsLeft(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new Animation(Textures.bowserShootingFireLeft, 2, 10);

            Fireball = new BowserFireball((int)Enemy.Position.X + 4, (int)Enemy.Position.Y + 8);
            HUD.level.AddDynamicObject(Fireball);

            this.Enemy.Hitbox.Clear();
            SetHitbox();
            this.Enemy.Velocity = new Vector2(-0.5f, 0f);
            this.Enemy.Acceleration = Physics.GRAVITY;
            this.MovingCount = 0;
        }
        public void Update()
        {
            Enemy.Hitbox.Cycle();
            SetHitbox();
            if (HUD.level.player.Position.X > Enemy.Position.X)
                Enemy.State = new SBowserMovingRight(Enemy);
            if (MovingCount == HotDAMN.TICKS_UNTIL_BOWSERS_GOES_BACK_TO_MOVING)
                Enemy.State = new SBowserMovingLeft(Enemy);
            MovingCount++;
        }
        private void SetHitbox()
        {
            Enemy.Hitbox.AddRectHitbox(
                    (int)Enemy.Position.X,
                    (int)Enemy.Position.Y,
                    Hitboxes.BOWSERS_WIDTH,
                    Hitboxes.BOWSERS_HEIGHT
                );
        }
    }
}
