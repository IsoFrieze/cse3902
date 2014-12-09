using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2
{
    public class SCoinSpawning : IPowerUpState
    {
        public IPowerUp Powerup { get; set; }
        private int counter;

        public SCoinSpawning(IPowerUp powerup)
        {
            this.counter = 0;
            this.Powerup = powerup;
            Powerup.Sprite = new Animation(Textures.powerupCoinSpinning, 4, 4);
            Powerup.Velocity = new Vector2(0, -7f);
            Powerup.Acceleration = Physics.GRAVITY / 2;
            SoundPanel.PlaySoundEffect(Sound.coinEffect);
            HUD.COINS[HUD.currentPlayer]++;
            HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_COIN;
        }
        public void  Update()
        {
            counter++;
            if (counter > HotDAMN.TICKS_UNTIL_COIN_DISAPPEARS)
            {
                Powerup.IsActive = false;
                HUD.level.AddParticle(new Score(Powerup.Position, HotDAMN.SCORE_COLLECT_COIN));
            }
        }

        public void Spawn() { }
    }
}
