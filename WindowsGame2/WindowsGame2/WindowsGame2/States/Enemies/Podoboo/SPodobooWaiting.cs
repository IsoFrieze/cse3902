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
    public class SPodobooWaiting : IEnemyState
    {
        public IEnemy Enemy { get; set; }
        private int counter;
        private Random rand;

        public SPodobooWaiting(IEnemy enemy)
        {
            this.rand = new Random();
            this.counter = 0;
            this.Enemy = enemy;
            Enemy.Sprite = new Animation(Textures.blockHidden);

            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = Vector2.Zero;
            Enemy.Acceleration = Vector2.Zero;
        }

        public void Update()
        {
            if (counter >= 30 && rand.Next(50) == 42)
            {
                Enemy.State = new SPodobooMoving(Enemy);
            }
            counter++;
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
