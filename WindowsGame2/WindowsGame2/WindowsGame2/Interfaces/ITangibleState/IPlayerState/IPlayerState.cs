using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public interface IPlayerState : ITangibleState
    {
        IPlayer Player { get; set; }
        void GoLeft();
        void GoRight();
        void GoUp();
        void GoDown();
        void GoNowhere();
        void Jump();
        void HoldJump();
        void Run();
        void Climb();
        void PowerUp();
        void PowerDown();
        void KillMe();
    }
}
