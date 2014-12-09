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
    public class SLakituHide : IEnemyState
    {
        public IEnemy Enemy { get; set; }
        private Random random;
        private int counter, nextAction;

        public SLakituHide(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new Animation(Textures.lakituInCloud);
            
            Enemy.Hitbox.Clear();
            SetHitbox();

            this.counter = 0;
            this.random = new Random();
            this.nextAction = random.Next(5, 30);
        }

        public void Update()
        {
            counter++;
            Enemy.Hitbox.Cycle();
            SetHitbox();

            float xDiff = Enemy.Position.X - HUD.level.player.Position.X;
            Enemy.Acceleration = new Vector2(-0.0005f * xDiff, 0);

            if (counter == nextAction)
            {
                Enemy.State = new SLakituHover(Enemy);
            }
            int xLeft = HUD.level.camera.Viewport.X + (HotDAMN.WINDOW_WIDTH / 8);
            if (Enemy.Position.X < xLeft)
            {
                Enemy.Position = new Vector2(xLeft, Enemy.Position.Y);
            }
            int xRight = HUD.level.camera.Viewport.X + (7 * HotDAMN.WINDOW_WIDTH / 8);
            if (Enemy.Position.X > xRight)
            {
                Enemy.Position = new Vector2(xRight, Enemy.Position.Y);
            }
        }

        private void SetHitbox()
        {
            Enemy.Hitbox.AddRectHitbox(
                    (int)Enemy.Position.X,
                    (int)Enemy.Position.Y,
                    Hitboxes.LAKITU_WIDTH,
                    Hitboxes.LAKITU_HEIGHT
                );
        }
    }
}

