using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class Collider2
    {
        /*Level level;
        // <These ITangibles>, <Collision partners>, <Collision zones>
        List<ITangible> statics;
        List<ITangible> dynamics;
        public enum CollisionFrom { None, Above, Below, Left, Right }

        public Collider2(Level level)
        {
            if (level != null)
            {
                this.level = level;
                this.statics = level.statics;
                this.dynamics = level.dynamics;
            }
        }

        public void Update()
        {
            HandleCollisions(statics, dynamics);
            level.RemoveInactives(dynamics);
            HandleCollisions(dynamics, dynamics);
            level.RemoveInactives(dynamics);
            level.RemoveInactives(statics);
        }
        
        void HandleCollisions(List<ITangible> tangibles1, List<ITangible> tangibles2)
        {
            List<Collision> collisions;

            for (int i = 0; i < tangibles1.Count; i++ )
            {
                collisions = DetectCollisions(tangibles1[i], tangibles2);
                HandleCollisions(tangibles1[i], collisions);
            }
        }

        List<Collision> DetectCollisions(ITangible tangible1, List<ITangible> tangibles2)
        {
            Rectangle zone;
            List<Collision> collisions = new List<Collision>();

            foreach (ITangible tangible2 in tangibles2.Where(t => t != tangible1))
            {
                zone = Rectangle.Intersect(tangible1.Hitbox, tangible2.Hitbox);
                if (!zone.IsEmpty)
                    collisions.Add(new Collision(tangible2, zone));
            }

            return collisions;
        }

        void HandleCollisions(ITangible tangible, List<Collision> collisions)
        {
            CollisionFrom direction;
            while (collisions.Count > 0)
            {
                collisions.Sort(new Collision.LargestFirst());
                direction = CollisionDirection(tangible, collisions.First());
                switch (direction)
                {
                    case CollisionFrom.Above:
                        tangible.CollisionHandler.CollisionAbove(collisions.First().Obstacle);
                        collisions.First().Obstacle.CollisionHandler.CollisionBelow(tangible);
                        break;
                    case CollisionFrom.Below:
                        tangible.CollisionHandler.CollisionBelow(collisions.First().Obstacle);
                        collisions.First().Obstacle.CollisionHandler.CollisionAbove(tangible);
                        break;
                    case CollisionFrom.Left:
                        tangible.CollisionHandler.CollisionLeft(collisions.First().Obstacle);
                        collisions.First().Obstacle.CollisionHandler.CollisionRight(tangible);
                        break;
                    case CollisionFrom.Right:
                        tangible.CollisionHandler.CollisionRight(collisions.First().Obstacle);
                        collisions.First().Obstacle.CollisionHandler.CollisionLeft(tangible);
                        break;
                    default:
                        break;
                }
                collisions.Remove(collisions.First());
            }
        }

        void MergeCollisions(ITangible tnagible1, List<Collision> collisions)
        {
            Rectangle between;

            for (int i = 0; i < collisions.Count; i++)
            {
                for (int j = i + 1; j < collisions.Count; j++)
                {
                    // smaller rectangle has to have intersecting vector with bigger rectangle
                }
            }
        }

        Rectangle RectBetween(Rectangle rect1, Rectangle rect2)
        {
            Rectangle x, y;

            if (rect1.Right < rect2.Right)
                x = new Rectangle(rect1.Right, rect1.Top, rect2.Left - rect1.Right, rect1.Height);
            else if (rect1.Right > rect2.Right)
                x = new Rectangle(rect2.Right, rect1.Top, rect1.Left - rect2.Right, rect1.Height);
            if (rect1.Bottom < rect1.Bottom)
                y = new Rectangle(rect1.Left, rect1.Bottom, rect1.Width, rect2.Top - rect2.Bottom);
            else if (rect1.Bottom > rect1.Bottom)
                y = new Rectangle(rect1.Left, rect1.Bottom, rect1.Width, rect1.Top - rect2.Bottom);

            return new Rectangle();
        }

        CollisionFrom CollisionDirection(ITangible tangible, Collision collision)
        {
            collision.Zone = Rectangle.Intersect(tangible.Hitbox, collision.Obstacle.Hitbox);

            if (collision.Zone.IsEmpty)
                return CollisionFrom.None;
            if (collision.Zone.Width + 1 < collision.Zone.Height)
            {
                if (collision.Zone.Left == tangible.Hitbox.X)
                    return CollisionFrom.Left;
                else
                    return CollisionFrom.Right;
            }
            else
            {
                if (collision.Zone.Top == tangible.Hitbox.Y)
                    return CollisionFrom.Above;
                else
                    return CollisionFrom.Below;
            }
        }*/
    }
}
