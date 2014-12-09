using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLfloorblock : IXMLLevelObject
    {
        int x;
        int y;
        int width;
        int height;

        public XMLfloorblock(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
            String w = tree.Attribute("width");
            String h = tree.Attribute("height");
            this.width = w == null ? 1 : int.Parse(w);
            this.height = h == null ? 1 : int.Parse(h);
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    matrix[x+i].Add(new BlockFloor(16 * (x + i), 16 * (y + j)));
                }
            }
        }
    }
}
