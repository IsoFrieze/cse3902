using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class FlagpoleFlagCollisionHandler : ICollisionHandler
    {
        IPowerUp subject;
        public FlagpoleFlagCollisionHandler(IPowerUp powerup)
        {
            this.subject = powerup;
        }

        public void CollisionAbove(ITangible type)
        {
            if (type is IPlayer)
            {
                HUD.FlagpolePoints(type.Position.Y, subject.Position.Y);
                subject.State = new SFlagpoleFlagPulledDown(subject);
            }
        }
        public void CollisionBelow(ITangible type)
        {
            if (type is IPlayer)
            {
                HUD.FlagpolePoints(type.Position.Y, subject.Position.Y);
                subject.State = new SFlagpoleFlagPulledDown(subject);
            }
        }
        public void CollisionLeft(ITangible type)
        {
            if (type is IPlayer)
            {
                HUD.FlagpolePoints(type.Position.Y, subject.Position.Y);
                subject.State = new SFlagpoleFlagPulledDown(subject);
            }
        }
        public void CollisionRight(ITangible type)
        {
            if (type is IPlayer)
            {
                HUD.FlagpolePoints(type.Position.Y, subject.Position.Y);
                subject.State = new SFlagpoleFlagPulledDown(subject);
            }
        }
    }
}
