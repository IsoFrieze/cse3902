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


    public class SBlooperIdle : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        private int timer;
        private int timerLimit;
        private Random rand;
        public SBlooperIdle(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new Animation(Textures.blooperIdle);
            Enemy.Hitbox.SetOffset(Hitboxes.BLOOPER_OFFSET_X, Hitboxes.BLOOPER_OFFSET_Y);
            Enemy.Hitbox.Clear();
            SetHitbox();
            timer = 0;
            Enemy.Acceleration = new Vector2(0, 0.001f);
            rand = new Random();
            timerLimit = ((rand.Next())%200) + 100;
            
        }

        public void Update()
        {
            Enemy.Hitbox.Cycle();
            SetHitbox();

            timer++;

            if ((timer >= timerLimit) || Enemy.Position.Y > HotDAMN.WINDOW_HEIGHT - 32) 
            {
                Enemy.State = new SBlooperSwimming(Enemy);
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
    }
}
