using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class CommandMute : ITechnicalCommand
    {
        public CommandMute()
        {

        }

        public void Execute()
        {
            SoundPanel.ToggleMute();
        }
    }
}
