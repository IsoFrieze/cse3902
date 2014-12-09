using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SWarpZoneScreen : IGameState
    {
        public List<IController> controllers;
        public Level Level { get; set; }
        public Game1 Game { get; set; }

        TextSelections textSelections;

        internal Pointer pointer;

        public SWarpZoneScreen(Game1 game)
        {
            Game = game;
            Game.state = this;
            Level = new Level(game, "warpzone");
            Level.InitializeObjects();
            HUD.TIME = 999;

            textSelections = new TextSelections(HotDAMN.TEXT_WARP_ZONE_SELECTIONS, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height);
            pointer = new Pointer(textSelections);
            new List<Keys>();
            controllers = new List<IController>();
            controllers.Add(new CustomKeyboard(Game, pointer));
        }

        public void Update()
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            CommandScheduler.ExecuteAll();
            Level.Update();
            pointer.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            Level.Draw(sb);
            sb.DrawString(Textures.font, textSelections.Text, textSelections.Position, Color.White);
            pointer.Draw(sb);
        }

        public void Pause()
        {

        }

        public void UnPause()
        {

        }
    }
}
