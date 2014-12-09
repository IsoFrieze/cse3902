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
    public class SHammerBroStay : IEnemyState
    {
        public IEnemy Enemy { get; set; }
        private int counter, throwHammer, jump;
        Random rand;

        public SHammerBroStay(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new SettingDependentAnimation(Textures.hammerBroWalking, 2, 10);
            
            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Acceleration = Physics.GRAVITY / 3;
            this.rand = new Random();
            this.counter = HotDAMN.TICKS_UNTIL_HAMMERBRO_TURNS / 2;
            this.throwHammer = rand.Next(40, 80);
            this.jump = rand.Next(200, 300);
        }

        public void Update()
        {
            if (HUD.TIME < 100)
            {
                Enemy.State = new SHammerBroApproach(Enemy);
            }
            counter++;
            Enemy.Hitbox.Cycle();
            SetHitbox();
            if (counter % HotDAMN.TICKS_UNTIL_HAMMERBRO_TURNS > HotDAMN.TICKS_UNTIL_HAMMERBRO_TURNS / 2)
            {
                Enemy.Position += new Vector2(0.2f, 0f);
            }
            else
            {
                Enemy.Position += new Vector2(-0.2f, 0f);
            }
            if (counter == throwHammer)
            {
                HUD.level.AddDynamicObject(new Hammer((int)Enemy.Position.X, (int)Enemy.Position.Y));
                throwHammer += rand.Next(30, 70);
            }
            if (counter == jump)
            {
                Enemy.State = new SHammerBroJump(Enemy);
            }
        }

        private void SetHitbox()
        {
            Enemy.Hitbox.AddRectHitbox(
                    (int)Enemy.Position.X,
                    (int)Enemy.Position.Y,
                    Hitboxes.HAMMERBRO_WIDTH,
                    Hitboxes.HAMMERBRO_HEIGHT
                );
        }
    }
}
