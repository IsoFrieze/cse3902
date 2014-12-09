using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class MazeCheckpointCollisionHandler : ICollisionHandler
    {
        IBlock subject;
        public MazeCheckpointCollisionHandler(IBlock block)
        {
            this.subject = block;
        }

        public void CollisionAbove(ITangible type)
        {
            if (type is IPlayer)
            {
                ((MazeCheckpoint)subject).Collected = true;
            }
        }
        public void CollisionBelow(ITangible type)
        {
            if (type is IPlayer)
            {
                ((MazeCheckpoint)subject).Collected = true;
            }
        }
        public void CollisionLeft(ITangible type)
        {
            if (type is IPlayer)
            {
                ((MazeCheckpoint)subject).Collected = true;
            }
        }
        public void CollisionRight(ITangible type)
        {
            if (type is IPlayer)
            {
                ((MazeCheckpoint)subject).Collected = true;
            }
        }
    }
}
