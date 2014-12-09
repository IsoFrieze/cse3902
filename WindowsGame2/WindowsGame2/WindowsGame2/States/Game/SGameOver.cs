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
    public class SGameOver : IGameState
    {
        public List<IController> controllers;
        public Game1 Game { get; set; }

        private int counter;

        public SGameOver(Game1 game)
        {
            Game = game;
            Game.state = this;
            HUD.TIME = 0;
            this.counter = 0;
            HUD.LIVES[HUD.currentPlayer] = HotDAMN.INITIAL_LIVES_COUNT;
            HUD.worldNum[HUD.currentPlayer] = 1;
            HUD.levelNum[HUD.currentPlayer] = 1;

            SoundPanel.PlaySong(Sound.gameover1Theme, false);
            controllers = new List<IController>();
            controllers.Add(new KeyboardCommands(Game));
        }

        public void Update()
        {
            counter++;
            if (counter > HotDAMN.TICKS_UNTIL_GAME_OVER_FINISH)
              {
                  if (HUD.numOfPlayers == 1 || HUD.deathCount == 1)
                  {
                      Game.state = new STitleScreen(Game);
                  }
                  else
                  {
                      HUD.deathCount++;
                      HUD.level.ResetLevel();
                  }
              }
        }

        public void Draw(SpriteBatch sb)
        {
            String text = HotDAMN.TEXT_GAME_OVER;

            Vector2 textSize = Textures.font.MeasureString(text);
            Vector2 textCenter = new Vector2(Game.GraphicsDevice.Viewport.Width / 2, (Game.GraphicsDevice.Viewport.Height / 2));
            IAnimatedSprite background = new BackgroundAnimation(Color.Black);

            background.Draw(sb, 0, 0);
            sb.DrawString(Textures.font, text, textCenter - (textSize / 2), Color.White);

            HUD.Draw(sb, HotDAMN.TEXT_EMPTY_STRING);
        }

        public void Pause()
        {

        }

        public void UnPause()
        {

        }
    }
}
