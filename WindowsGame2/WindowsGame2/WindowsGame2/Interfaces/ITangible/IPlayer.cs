using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public interface IPlayer : ITangible
    {        
        TemporaryDecorator Decorator { get; set; }

        IAutoMovement AutoMove { get; set; }
        bool IsRunning { get; set; }
    }
}
