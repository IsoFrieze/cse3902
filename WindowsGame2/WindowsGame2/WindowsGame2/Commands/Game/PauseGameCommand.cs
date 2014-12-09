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
    public class PauseGameCommand : ITechnicalCommand
    {
        Game1 game;

        public PauseGameCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.state is SLevelPaused)
            {
                game.state.UnPause();
            }
            else
            {
                game.state.Pause();
            }
        }
    }
}
