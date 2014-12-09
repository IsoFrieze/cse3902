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
    public class S1UpSpawning : IPowerUpState
    {
        public IPowerUp Powerup { get; set; }
        private int counter;

        public S1UpSpawning(IPowerUp powerup)
        {
            this.Powerup = powerup;
            this.counter = 0;
            Powerup.Velocity = Vector2.Zero;
            SoundPanel.PlaySoundEffect(Sound.powerupappearsEffect);
        }

        public void Update()
        {
            counter++;
            if (counter > HotDAMN.TICKS_UNTIL_POWERUP_APPEARS)
            {
                Powerup.Sprite = new Animation(Textures.powerup1up, 1, 1);
                Powerup.Velocity = new Vector2(0, -0.3f);
            }
            if (counter > HotDAMN.TICKS_UNTIL_POWERUP_MOVES)
            {
                Powerup.State = new S1UpMovingRight(Powerup);
            }
        }

        public void Spawn() { }
    }
}
