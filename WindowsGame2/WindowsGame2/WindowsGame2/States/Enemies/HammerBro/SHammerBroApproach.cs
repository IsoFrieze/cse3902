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
    public class SHammerBroApproach : IEnemyState
    {
        public IEnemy Enemy { get; set; }
        private int counter, throwHammer, jump;
        Random rand;

        public SHammerBroApproach(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new SettingDependentAnimation(Textures.hammerBroWalking, 2, 10);
            
            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Acceleration = Physics.GRAVITY / 3;
            this.rand = new Random();
            this.counter = 0;
            this.throwHammer = rand.Next(30, 70);
            this.jump = rand.Next(200, 300);
        }

        public void Update()
        {
            counter++;
            Enemy.Hitbox.Cycle();
            SetHitbox();
            Enemy.Position += new Vector2(-0.5f, 0f);
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
