using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SInLevel: IGameState
    {
        public List<IController> controllers;
        public Level Level { get; set; }
        public Game1 Game { get; set; }
        String levelName;
        private int counter;

        public SInLevel(Game1 game, String levelName)
        {
            Game = game;
            Game.state = this;
            int sublevelName = levelName.IndexOf(HotDAMN.TAG_SUBLEVEL);
            int nameName = levelName.IndexOf(HotDAMN.TAG_NAME);
            this.levelName = levelName.Substring(0, sublevelName != -1 ? sublevelName : (nameName != -1 ? nameName : levelName.Length));
            // WHERE YOU CHANGE THE LEVEL
            Level = new Level(game, levelName);
            Level.InitializeObjects();
            counter = 0;

            controllers = new List<IController>();
            controllers.Add(new KeyboardCommands(game, level: Level));
        }

        public void Update()
        {
            if (counter > HotDAMN.TICKS_UNTIL_TIMER_DECREMENTS && !(Game.state is SLevelComplete))
            {
                HUD.TIME--;
                counter = 0;
            }
            counter++;

            foreach (IController c in controllers)
            {
                c.Update();
            }
            CommandScheduler.ExecuteAll();
            Level.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            Level.Draw(sb);

            HUD.Draw(sb, levelName);
        }

        public void Pause()
        {
            Game.state = new SLevelPaused(Game, this);
        }

        public void UnPause()
        {

        }
    }
}
