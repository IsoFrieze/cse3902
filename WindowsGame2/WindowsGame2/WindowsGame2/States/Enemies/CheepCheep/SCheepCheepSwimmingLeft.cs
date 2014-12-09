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

    
    public class SCheepCheepSwimmingLeft : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        private int timer;
        private float velocityX;
        private float velocityY;
        public SCheepCheepSwimmingLeft(IEnemy enemy)
        {
            this.Enemy = enemy;
            Random random = new Random();
            Enemy.Hitbox.SetOffset(Hitboxes.CHEEPCHEEP_OFFSET_X, Hitboxes.CHEEPCHEEP_OFFSET_Y);
            SetHitbox();

            velocityX = ((float)(random.NextDouble()/2)+ 0.1f);
            velocityY = velocityX / 3;

            Enemy.Velocity = new Vector2(-velocityX, velocityY);
        }

        public void Update()
        {
            Enemy.Hitbox.Cycle();
            SetHitbox();

            timer++;
            if (timer > HotDAMN.TICKS_UNTIL_SWIMMING_CHEEPCHEEP_TURNS)
            {
                Enemy.Velocity = new Vector2(-velocityX, -velocityY);
            }
            if (timer == 2 * HotDAMN.TICKS_UNTIL_SWIMMING_CHEEPCHEEP_TURNS)
            {
                Enemy.Velocity = new Vector2(-velocityX, velocityY);
                timer = 0;
            }
        }

        private void SetHitbox()
        {
            Enemy.Hitbox.AddRectHitbox(
                    (int)Enemy.Position.X,
                    (int)Enemy.Position.Y,
                    Hitboxes.CHEEPCHEEP_WIDTH,
                    Hitboxes.CHEEPCHEEP_HEIGHT
                );
        }
    }
}
