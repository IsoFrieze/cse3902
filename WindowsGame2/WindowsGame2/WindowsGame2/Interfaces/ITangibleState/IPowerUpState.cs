using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public interface IPowerUpState : ITangibleState
    {
        IPowerUp Powerup { get; set; }
        void Spawn();
    }
}
