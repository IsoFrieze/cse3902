using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace WindowsGame2
{
    public class SBowserMovingLeft : IEnemyState
    {
        public IEnemy Enemy { get; set; }
        public IProjectile Fireball, Hammer;
        private int JumpCount, FireballCount, HammerTime, HammerCount, jump, shoot;
        private Random rnd = new Random();

        public SBowserMovingLeft(IEnemy enemy) {
            this.Enemy = enemy;
            Enemy.Sprite = new Animation(Textures.bowserMovingLeft, 2, 10);

            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = new Vector2(-0.5f, 0f);
            Enemy.Acceleration = Physics.GRAVITY/3;
            this.JumpCount = 0;
            this.FireballCount = 0;
            this.HammerCount = 0;
            this.HammerTime = 8;
            this.jump = rnd.Next(20, 101);
            this.shoot = rnd.Next(20, 51);
        }

        public void Update()
        {
            Enemy.Hitbox.Cycle();
            SetHitbox();
            if (HUD.level.player.Position.X > Enemy.Position.X)
                Enemy.State = new SBowserMovingRight(Enemy);
            if (HammerCount % HammerTime == 0 && HUD.worldNum[HUD.currentPlayer] > 5)
            {
                Hammer = new Hammer((int)Enemy.Position.X + 4, (int)Enemy.Position.Y + 12);
                HUD.level.AddDynamicObject(Hammer);   
            }
            if (JumpCount == jump)
            {
                Enemy.Velocity += new Vector2(0f, -5f);
                JumpCount = 0;
                jump = rnd.Next(20, 101);
            }
            if (FireballCount == shoot) {
                Enemy.State = new SBowserShootingFireBallsLeft(Enemy);
            }
           HammerCount++;
           JumpCount++;
           FireballCount++;
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
