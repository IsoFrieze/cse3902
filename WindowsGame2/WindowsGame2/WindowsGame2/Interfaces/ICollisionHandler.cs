using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public interface ICollisionHandler
    {
        void CollisionAbove(ITangible obj);
        void CollisionBelow(ITangible obj);
        void CollisionLeft(ITangible obj);
        void CollisionRight(ITangible obj);
    }
}
