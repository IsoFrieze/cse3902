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
    public class STitleScreen : IGameState
    {
        public List<IController> controllers;
        public Level Level { get; set; }
        public Game1 Game { get; set; }
        public Pointer pointer;
        TextSelections textSelections;

        public STitleScreen(Game1 game)
        {
            Game = game;
            Game.state = this;
            Level = new Level(game, "0-1");
            Level.InitializeObjects();
            HUD.TIME = 999;
            HUD.currentPlayer = 0;
            textSelections = new TextSelections(HotDAMN.TEXT_TITLE_SCREEN_SELECTIONS, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height);
            pointer = new Pointer(textSelections);
            new List<Keys>();
            controllers = new List<IController>();
            controllers.Add(new KeyboardCommands(Game, pointer));
        }

        public void Update()
        {
            foreach (IController controller in controllers)
                controller.Update();
//            Console.Write("Command? ");
            
            CommandScheduler.ExecuteAll();
            Level.Update();
            pointer.Update();
            //HUD.midpointHit[HUD.currentPlayer] = false;
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
