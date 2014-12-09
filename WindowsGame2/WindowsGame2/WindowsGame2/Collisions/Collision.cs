using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    class Collision
    {
        public ITangible Obstacle { get; set; }
        public Rectangle Zone { get; set; }

        public Collision(ITangible obstacle, Rectangle zone)
        {
            Obstacle = obstacle;
            Zone = zone;
        }

        public class LargestFirst : IComparer<Collision>
        {
            public int Compare(Collision collision1, Collision collision2)
            {
                return ((collision1.Zone.Width * collision1.Zone.Height).CompareTo(collision2.Zone.Width * collision2.Zone.Height));
            }
        }

        public class LeftTopMostFirst : IComparer<Collision>
        {
            public int Compare(Collision collision1, Collision collision2)
            {
                if (collision1.Zone.Left != collision1.Zone.Left)
                    return collision1.Zone.Left.CompareTo(collision1.Zone.Left);
                else
                    return collision1.Zone.Top.CompareTo(collision1.Zone.Top);
            }
        }

        public class TopLeftMostFirst : IComparer<Collision>
        {
            public int Compare(Collision collision1, Collision collision2)
            {
                if (collision1.Zone.Top != collision1.Zone.Top)
                    return collision1.Zone.Top.CompareTo(collision1.Zone.Top);
                else
                    return collision1.Zone.Left.CompareTo(collision1.Zone.Left);
            }
        }
    }
}
