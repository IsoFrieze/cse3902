using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    class InvinciblePlayerCollisionHandler : ICollisionHandler
    {
         IPlayer subject;
         private PlayerCollisionHandler normal;

        public InvinciblePlayerCollisionHandler(IPlayer player)
        {
            this.subject = player;
            this.normal = new PlayerCollisionHandler(subject);
        }

        public void CollisionAbove(ITangible obj)
        {
            if (!(obj is IEnemy || obj is IProjectile))
            {
                normal.CollisionAbove(obj);
            }
        }

        public void CollisionBelow(ITangible obj)
        {
            if (!(obj is IEnemy || obj is IProjectile))
            {
                normal.CollisionBelow(obj);
            }
        }

        public void CollisionLeft(ITangible obj)
        {
            if (!(obj is IEnemy || obj is IProjectile))
            {
                normal.CollisionLeft(obj);
            }
        }

        public void CollisionRight(ITangible obj)
        {
            if (!(obj is IEnemy || obj is IProjectile))
            {
                normal.CollisionRight(obj);
            }
        }
    }
}
