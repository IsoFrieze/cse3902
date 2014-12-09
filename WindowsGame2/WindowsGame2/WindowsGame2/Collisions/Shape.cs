using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class Shape
    {
        public Rectangle shape;

        public Shape(int x, int y, int width, int height)
        {
            this.shape = new Rectangle(x, y, width, height);
        }

        public void Offset(int x, int y)
        {
            shape.Offset(x, y);
        }

        public int Top()
        {
            return shape.Top;
        }

        public int Left()
        {
            return shape.Left;
        }

        public int Right()
        {
            return shape.Right;
        }

        public int Bottom()
        {
            return shape.Bottom;
        }
        /*
        List<Tuple<int, int>> points;

        public Shape(List<Tuple<int,int>> points)
        {
            this.points = points;
        }

        public void Offset(int x, int y)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i] = new Tuple<int, int>(points[i].Item1 + x, points[i].Item2 + y);
            }
        }

        public int Top()
        {
            int x = points[0].Item2;
            foreach (Tuple<int, int> t in points)
            {
                if (t.Item2 < x)
                {
                    x = t.Item2;
                }
            }
            return x;
        }

        public int Left()
        {
            int x = points[0].Item1;
            foreach (Tuple<int, int> t in points)
            {
                if (t.Item1 < x)
                {
                    x = t.Item1;
                }
            }
            return x;
        }

        public int Right()
        {
            int x = points[0].Item1;
            foreach (Tuple<int, int> t in points)
            {
                if (t.Item1 > x)
                {
                    x = t.Item1;
                }
            }
            return x;
        }

        public int Bottom()
        {
            int x = points[0].Item2;
            foreach (Tuple<int, int> t in points)
            {
                if (t.Item1 > x)
                {
                    x = t.Item2;
                }
            }
            return x;
        }*/
    }
}
