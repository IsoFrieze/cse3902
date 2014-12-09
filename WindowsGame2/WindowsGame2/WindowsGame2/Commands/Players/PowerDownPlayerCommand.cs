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
    public class PowerDownPlayerCommand : IInputCommand
    {
        IPlayer player;

        public PowerDownPlayerCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            ((IPlayerState)player.State).PowerDown();
            
        }
    }
}
