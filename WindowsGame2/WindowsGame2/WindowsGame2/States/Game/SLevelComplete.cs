using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SLevelComplete : IGameState
    {
        public Game1 Game { get; set; }
        private SInLevel state;
        private int counter;
        private int fireworks;
        private Vector2[] fireworkPos = { new Vector2(-140, 70), new Vector2(-80, 100), new Vector2(-120, 50), new Vector2(-140, 120), new Vector2(-70, 90), new Vector2(-120, 100)};
        private int fireworkCounter = 0;

        public SLevelComplete(Game1 game, SInLevel state)
        {
            SoundPanel.StopSong();
            this.counter = 0;
            this.Game = game;
            this.state = state;
            Game.state = this;
            this.fireworks = HUD.TIME % 10 == 1 || HUD.TIME % 10 == 3 || HUD.TIME % 10 == 6 ? HUD.TIME % 10 : 0;
            for (int i = 0; i < fireworkPos.Length; i++)
            {
                fireworkPos[i] += new Vector2(state.Level.Size.Width, 0);
            }
        }

        public void Update()
        {
            counter++;
            state.Update();

            if (counter == HotDAMN.TICKS_UNTIL_LEVEL_COMPELTE_FANFARE)
            {
                SoundPanel.PlaySong(Sound.levelcompleteTheme, false);
            }
            if (counter >= HotDAMN.TICKS_UNTIL_LEVEL_TIMER_TALLIES && HUD.TIME > 0)
            {
                HUD.TIME--;
                HUD.SCORE[HUD.currentPlayer] += 50;
                SoundPanel.PlaySoundEffect(Sound.scoreEffect);
            }
            if (HUD.TIME == 0)
            {
                HUD.TIME = -1;
                counter = 1000000;
            }
            if (HUD.TIME == -1 && (fireworks > 0 && counter % 35 == 0))
            {
                HUD.level.AddParticle(new Fireworks(fireworkPos[fireworkCounter]));
                fireworkCounter++;
                fireworks--;
            }
            if (counter >= 1000000 + (fireworks + 2) * HotDAMN.TICKS_UNTIL_NEXT_FIREWORK)
            {
                if (HUD.level.player.AutoMove != null)
                {
                    HUD.level.player.AutoMove.IsActive = false;
                }
                HUD.MARIO_STATE[HUD.currentPlayer] = (IPlayerState)state.Level.player.State;
                HUD.firstLevelEntrance[HUD.currentPlayer] = true;
                HUD.midpointHit[HUD.currentPlayer] = false;
                HUD.NextLevel();
                Game.state = new SLevelIntro(Game, HUD.worldNum[HUD.currentPlayer] + "-" + HUD.levelNum[HUD.currentPlayer]);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            state.Draw(sb);
        }

        public void Pause()
        {
            state.Pause();
        }

        public void UnPause()
        {
            state.UnPause();
        }
    }
}
