using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public interface ICamera
    {
        Rectangle Viewport { get; set; }

        void Update();
        void SetBack(int setback);
        bool IsInView(ITangible obj);
    }
}
