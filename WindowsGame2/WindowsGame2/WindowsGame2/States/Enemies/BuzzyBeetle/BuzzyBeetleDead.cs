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
    public class SBuzzyBeetleDead : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        private int counter;

        const int DEAD_TIME = 300;

        public SBuzzyBeetleDead(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new Animation(Textures.buzzyBeetleInShellUpsideDown);

            Enemy.Hitbox.SetOffset(Hitboxes.BUZZYBEETLE_SHELL_OFFSET_X, Hitboxes.BUZZYBEETLE_SHELL_OFFSET_Y);
            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = new Vector2(0, -5f);
            Enemy.Acceleration = Physics.GRAVITY / 2;
            counter = 0;
            SoundPanel.PlaySoundEffect(Sound.kickEffect);
        }

        public SBuzzyBeetleDead(IEnemy enemy, String direction)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new Animation(Textures.buzzyBeetleInShellUpsideDown);

            Enemy.Hitbox.SetOffset(Hitboxes.BUZZYBEETLE_SHELL_OFFSET_X, Hitboxes.BUZZYBEETLE_SHELL_OFFSET_Y);
            Enemy.Hitbox.Clear();
            SetHitbox();
            Enemy.Acceleration = Physics.GRAVITY / 2;
            counter = 0;
            SoundPanel.PlaySoundEffect(Sound.kickEffect);

            
            if (direction.Equals("left"))
            {
                Enemy.Velocity = new Vector2(-1f, -5f);
            }
            else
            {
                Enemy.Velocity = new Vector2(1f, -5f);
            }
            
        }

        public void Update()
        {
            if (counter == HotDAMN.TICKS_UNTIL_DEAD_ENEMY_REMOVE)
            {
                Enemy.IsActive = false;
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
                    0,
                    0
                );
        }
    }
}
