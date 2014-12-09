using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class FirebarCollisionHandler : ICollisionHandler
    {
        IEnemy subject;
        public FirebarCollisionHandler(IEnemy enemy)
        {
            this.subject = enemy;
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
