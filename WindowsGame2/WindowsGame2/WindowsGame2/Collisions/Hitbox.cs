using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class Hitbox
    {
        public int xOffset, yOffset;
        //public List<Shape> hitboxesNow, hitboxesThen;
        public Rectangle hitboxNow, hitboxThen;

        public Hitbox(int x = 0, int y = 0)
        {
            SetOffset(x, y);
            hitboxThen = new Rectangle();
            hitboxNow = new Rectangle();
        }

        public void AddRectHitbox(int x, int y, int width, int height)
        {
            //Shape r = new Shape(x, y, width, height);
            //r.Offset(xOffset, yOffset);
            //hitboxesNow.Add(r);
            hitboxNow = new Rectangle(x + xOffset, y + yOffset, width, height);
            if (hitboxThen.IsEmpty)
            {
                hitboxThen = hitboxNow;
            }
        }

        public void AddShapeHitbox(Shape s)
        {
            //s.Offset(xOffset, yOffset);
            //hitboxesNow.Add(s);
        }

        public void Clear()
        {
            //hitboxesNow = new List<Shape>();
        }

        public void SetOffset(int x, int y)
        {
            this.xOffset = x;
            this.yOffset = y;
        }

        public void Cycle()
        {
            //this.hitboxesThen = this.hitboxesNow;
            //this.hitboxesNow = new List<Shape>();
            hitboxThen = hitboxNow;
            hitboxNow = new Rectangle();
        }

        public bool IsEmpty()
        {
            //return hitboxesNow.Count == 0;
            return false;
        }

        public int Top()
        {
            return hitboxNow.Top;
            /*
            int x = hitboxesNow[0].Top();
            foreach (Shape s in hitboxesNow)
            {
                if (s.Top() < x)
                {
                    x = s.Top();
                }
            }
            return x;*/
        }

        public int Left()
        {
            return hitboxNow.Left;
            /*
            int x = hitboxesNow[0].Left();
            foreach (Shape s in hitboxesNow)
            {
                if (s.Left() < x)
                {
                    x = s.Left();
                }
            }
            return x;*/
        }

        public int Right()
        {
            return hitboxNow.Right;
            /*
            int x = hitboxesNow[0].Right();
            foreach (Shape s in hitboxesNow)
            {
                if (s.Right() > x)
                {
                    x = s.Right();
                }
            }
            return x;*/
        }

        public int Bottom()
        {
            return hitboxNow.Bottom;
            /*
            int x = hitboxesNow[0].Bottom();
            foreach (Shape s in hitboxesNow)
            {
                if (s.Bottom() > x)
                {
                    x = s.Bottom();
                }
            }
            return x;*/
        }

        public int Width()
        {
            return hitboxNow.Width;
            //return Right() - Left();
        }

        public int Height()
        {
            return hitboxNow.Height;
            //return Bottom() - Top();
        }

        // this is difficult...
        public static Hitbox Intersect(Hitbox a, Hitbox b)
        {
            Hitbox h = new Hitbox();
            //Rectangle zone = Rectangle.Intersect(a.hitboxesNow[0].shape, b.hitboxesNow[0].shape);
            Rectangle zone = Rectangle.Intersect(a.hitboxNow, b.hitboxNow);
            h.AddRectHitbox(zone.X, zone.Y, zone.Width, zone.Height);

            /*
            if (
                    a.Left() < b.Right() && a.Right() > b.Left() &&
                    a.Top() < b.Bottom() && a.Bottom() > b.Top()
                )
            {
                int top = a.Top() < b.Top() ? a.Top() : b.Top();
                int left = a.Left() < b.Left() ? a.Left() : b.Left();
                int right = a.Right() > b.Right() ? a.Right() : b.Right();
                int bottom = a.Bottom() > b.Bottom() ? a.Bottom() : b.Bottom();

                for (int i = left; i <= right; i++)
                {
                    for (int j = top; j <= bottom; j++)
                    {
                        List<Tuple<int, int>> points = new List<Tuple<int, int>>();
                        points.Add(new Tuple<int, int>(i, j));
                        points.Add(new Tuple<int, int>(i + 1, j));
                        points.Add(new Tuple<int, int>(i + 1, j + 1));
                        points.Add(new Tuple<int, int>(i, j + 1));

                        h.AddShapeHitbox(new Shape(points));
                    }
                }
            }*/

            return h;
        }
    }
}
