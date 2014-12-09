using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SLevelPaused : IGameState
    {
        public List<IController> controllers;
        public Game1 Game { get; set; }
        private IGameState state;

        public SLevelPaused(Game1 game, IGameState state)
        {
            Game = game;
            this.state = state;
            controllers = new List<IController>();
            controllers.Add(new KeyboardCommands(Game));
            SoundPanel.PauseSong();
        }

        public void Update()
        {
            foreach (IController c in controllers)
            {
                c.Update();
            }
            CommandScheduler.ExecuteAll();
        }

        public void Draw(SpriteBatch sb)
        {
            state.Draw(sb);
        }

        public void Pause()
        {
        }

        public void UnPause()
        {
            SoundPanel.UnpauseSong();
            Game.state = state;
        }
    }
}
