using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class CommandExit : ITechnicalCommand
    {
        Game1 game;

        public CommandExit(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.Exit();
        }
    }
}
