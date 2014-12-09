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
    public class SCastleComplete : IGameState
    {
        public Game1 Game { get; set; }
        private SInLevel state;
        private int counter;

        public SCastleComplete(Game1 game, SInLevel state)
        {
            SoundPanel.PlaySong(Sound.castleComplete, false);
            this.counter = 0;
            this.Game = game;
            this.state = state;
            Game.state = this;
        }

        public void Update()
        {
            state.Update();
            if (counter == HotDAMN.TICKS_UNTIL_CASTLE_COMPLETE_FINISH)
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
            counter++;
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
