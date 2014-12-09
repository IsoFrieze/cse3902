using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class VineSpawnerCollisionHandler : ICollisionHandler
    {
        IPowerUp subject;
        public VineSpawnerCollisionHandler(IPowerUp powerup)
        {
            this.subject = powerup;
        }

        public void CollisionAbove(ITangible type)
        {

        }
        public void CollisionBelow(ITangible type)
        {

        }
        public void CollisionLeft(ITangible type)
        {

        }
        public void CollisionRight(ITangible type)
        {

        }
    }
}
