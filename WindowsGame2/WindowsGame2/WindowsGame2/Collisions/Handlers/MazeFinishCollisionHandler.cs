using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class MazeFinishCollisionHandler : ICollisionHandler
    {
        IBlock subject;
        int setback;
        public MazeFinishCollisionHandler(IBlock block, int setback)
        {
            this.subject = block;
            this.setback = setback;
        }

        public void CollisionAbove(ITangible type)
        {
            if (type is IPlayer)
            {
                CheckCheckpoints();
            }
        }
        public void CollisionBelow(ITangible type)
        {
            if (type is IPlayer)
            {
                CheckCheckpoints();
            }
        }
        public void CollisionLeft(ITangible type)
        {
            if (type is IPlayer)
            {
                CheckCheckpoints();
            }
        }
        public void CollisionRight(ITangible type)
        {
            if (type is IPlayer)
            {
                CheckCheckpoints();
            }
        }

        private void CheckCheckpoints()
        {
            MazeFinish f = (MazeFinish)subject;
            bool goback = false;

            for (int i = 0; i < f.checkpoints.Count; i++)
            {
                if (!f.checkpoints[i].Collected)
                {
                    goback = true;
                }
            }
            if (goback)
            {
                subject.IsActive = false;
                HUD.level.camera.SetBack(16 * setback);
            }
        }
    }
}
