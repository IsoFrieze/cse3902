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
    class SFlagpoleFlagPulledDown : IPowerUpState
    {
        public IPowerUp Powerup { get; set; }
        private int counter;

        public SFlagpoleFlagPulledDown(IPowerUp powerup)
        {
            this.Powerup = powerup;
            this.counter = 0;
            Powerup.Sprite = new Animation(Textures.flagpoleFlag);

            Powerup.Hitbox.Clear();
            SetHitbox();

            Powerup.Velocity = new Vector2(0, 1f);
        }

        public void Update()
        {
            if (counter == HotDAMN.TICKS_UNTIL_FLAG_STOPS)
            {
                Powerup.Velocity = Vector2.Zero;
            }
            counter++;
            Powerup.Hitbox.Cycle();
            SetHitbox();
        }

        public void Spawn() { }

        private void SetHitbox()
        {
            Powerup.Hitbox.AddRectHitbox(
                    (int)Powerup.Position.X,
                    (int)Powerup.Position.Y,
                    0,
                    0
                );
        }
    }
}

