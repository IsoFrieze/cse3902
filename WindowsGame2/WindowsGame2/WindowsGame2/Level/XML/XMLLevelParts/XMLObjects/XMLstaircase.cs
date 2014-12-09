using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLstaircase : IXMLLevelObject
    {
        int x;
        int y;
        int width;
        int height;
        bool left;

        public XMLstaircase(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
            this.width = int.Parse(tree.Attribute("width"));
            this.height = int.Parse(tree.Attribute("height"));
            this.left = tree.Attribute("direction").Equals("left");
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (left ? width - j > i : j <= i)
                    {
                        matrix[x+i].Add(new BlockStair(16 * (x + i), 16 * (y - j)));
                    }
                }
            }
        }
    }
}
