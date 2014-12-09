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


    public class SBlooperSwimming : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        private int timer;

        public SBlooperSwimming (IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new Animation(Textures.blooperSwimming, 2, 30);
            Enemy.Acceleration = Vector2.Zero;

            Enemy.Hitbox.SetOffset(Hitboxes.BLOOPER_OFFSET_X, Hitboxes.BLOOPER_OFFSET_Y);
            Enemy.Hitbox.Clear();
            SetHitbox();
            timer = 0;

        }

        public void Update()
        {
            Enemy.Hitbox.Cycle();
            SetHitbox();

            if (Enemy.Position.Y < 30 || (Math.Abs(Enemy.Position.X - HUD.level.player.Position.X) < 5))
            {
                Enemy.State = new SBlooperIdle(Enemy);
            }

        }

        private void SetHitbox()
        {
            Enemy.Hitbox.AddRectHitbox(
                    (int)Enemy.Position.X,
                    (int)Enemy.Position.Y,
                    Hitboxes.BLOOPER_WIDTH,
                    Hitboxes.BLOOPER_HEIGHT
                );
        }

        private void SetVelocity()
        {
            if (HUD.level.player.Position.X > Enemy.Position.X)
            {
                Enemy.Velocity = new Vector2(1f, -0.8f);
            }
            else
            {
                Enemy.Velocity = new Vector2(-1f, -0.8f);
            }
        }
    }
}
