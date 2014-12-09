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
using System.Collections;

namespace WindowsGame2
{
    public class ThrowFireballCommand : IInputCommand
    {
        Level level;
        ITangible subject;

        public ThrowFireballCommand(Level level, ITangible subject)
        {
            this.level = level;
            this.subject = subject;
        }

        public void Execute()
        {
            if (subject.State is IFireMarioState)
            {
                bool left = subject.State is ILeftMarioState;
                level.TryAddFireball(left, (int)(subject.Position.X + subject.Hitbox.Width() / 2), (int)(subject.Position.Y + subject.Hitbox.Height() / 4));
            }
        }
    }
}
