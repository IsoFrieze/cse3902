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
    public class SLevelIntro : IGameState
    {
        public Game1 Game { get; set; }
        private int counter = 0;
        private String levelName;

        public SLevelIntro(Game1 game, String levelName)
        {
            SoundPanel.StopSong();
            HUD.TIME = -1;
            Game = game;
            Game.state = this;
            int sublevelName = levelName.IndexOf(HotDAMN.TAG_SUBLEVEL);
            int nameName = levelName.IndexOf(HotDAMN.TAG_NAME);
            this.levelName = levelName.Substring(0, sublevelName != -1 ? sublevelName : (nameName != -1 ? nameName : levelName.Length));
            HUD.worldNum[HUD.currentPlayer] = int.Parse(levelName.Substring(0, 1));
            HUD.levelNum[HUD.currentPlayer] = int.Parse(levelName.Substring(2, 1));
        }

        public void Update()
        {
            if (counter == 200)
            {
                Game.state = new SInLevel(Game, levelName);
            }
            else
            {
                counter++;
            }

        }

        public void Draw(SpriteBatch sb)
        {
            String text = HotDAMN.TEXT_WORLD + levelName.Replace('0', ' ');

            Vector2 textSize = Textures.font.MeasureString(text);
            Vector2 textCenter = new Vector2(Game.GraphicsDevice.Viewport.Width / 2, (Game.GraphicsDevice.Viewport.Height / 2) - 35);
            IAnimatedSprite background = new BackgroundAnimation(Color.Black);
            IAnimatedSprite mario = new MarioAnimation(HUD.currentPlayer == 0 ? Textures.mario0 : Textures.luigi0, Textures.smallRightIdle);

            background.Draw(sb, 0, 0);
            mario.Draw(sb, (int)(textCenter.X - (textSize.X / 2))+15, (int)(textCenter.Y - (textSize.Y / 2))+25);
            sb.DrawString(Textures.font, HotDAMN.TEXT_X, new Vector2(textCenter.X - (textSize.X / 2) + 35, textCenter.Y - (textSize.Y / 2) + 43), Color.White);
            sb.DrawString(Textures.font, HUD.LIVES[HUD.currentPlayer].ToString(), new Vector2(textCenter.X - (textSize.X / 2) + 55, textCenter.Y - (textSize.Y / 2) + 43), Color.White);


            sb.DrawString(Textures.font, text, textCenter - (textSize / 2), Color.White);

            HUD.Draw(sb, levelName);

        }

        public void Pause()
        {

        }

        public void UnPause()
        {

        }
    }
}
