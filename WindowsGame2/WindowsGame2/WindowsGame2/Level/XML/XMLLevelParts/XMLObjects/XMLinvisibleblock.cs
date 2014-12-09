using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLinvisibleblock : IXMLLevelObject
    {
        int x;
        int y;
        int width;
        int height;

        public XMLinvisibleblock(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    matrix[x + i].Add(new BlockInvisible(16 * (x + i), 16 * (y + j)));
                }
            }
        }
    }
}
