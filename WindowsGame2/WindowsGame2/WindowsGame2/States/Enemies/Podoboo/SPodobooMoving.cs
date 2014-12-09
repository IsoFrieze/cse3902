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
    public class SPodobooMoving : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        private float start;
        public SPodobooMoving (IEnemy enemy)
        {
            this.Enemy = enemy;
            start = Enemy.Position.Y;
            Enemy.Sprite = new Animation(Textures.podobooUp);

            Enemy.Hitbox.Clear();
            SetHitbox();
            
            Enemy.Velocity = new Vector2(0,-6.5f);
            Enemy.Acceleration = (Physics.GRAVITY / 6);
        }

        public void Update()
        {
            if (Enemy.Velocity.Y >= 0)
            {
                Enemy.Sprite = new Animation(Textures.podobooDown);
            }
            if (Enemy.Position.Y >= start)
            {
                Enemy.State = new SPodobooWaiting(Enemy);
            }
            Enemy.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox()
        {
            Enemy.Hitbox.AddRectHitbox(
                    (int)Enemy.Position.X,
                    (int)Enemy.Position.Y,
                    Hitboxes.PODOBOO_WIDTH,
                    Hitboxes.PODOBOO_HEIGHT
                );
        }
    }
}
