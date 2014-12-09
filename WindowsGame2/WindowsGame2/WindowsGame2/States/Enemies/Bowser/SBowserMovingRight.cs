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
    public class SBowserMovingRight : IEnemyState 
    {
        public IEnemy Enemy { get; set; }
        private int JumpCount, jump, shoot;
        private Random rnd = new Random();
        public SBowserMovingRight(IEnemy enemy) {
            this.Enemy = enemy;
            this.Enemy.Sprite = new Animation(Textures.bowserMovingRight, 2, 10);

            this.Enemy.Hitbox.Clear();
            SetHitbox();

            this.Enemy.Velocity = new Vector2(0.5f, 0f);
            Enemy.Acceleration = Physics.GRAVITY/3;
            this.JumpCount = 0;
            this.jump = rnd.Next(20, 101);
            this.shoot = rnd.Next(20, 51);
        }

        public void Update()
        {
            Enemy.Hitbox.Cycle();
            SetHitbox();
            if (HUD.level.player.Position.X < Enemy.Position.X)
                Enemy.State = new SBowserMovingLeft(Enemy);
            if (JumpCount == jump)
            {
                Enemy.Velocity += new Vector2(0f, -5);
                JumpCount = 0;
                jump = rnd.Next(20, 101);
            }
            JumpCount++;
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
