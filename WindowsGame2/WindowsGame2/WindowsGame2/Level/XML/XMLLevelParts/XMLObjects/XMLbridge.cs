using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLbridge : IXMLLevelObject
    {
        int x;
        int y;
        int width;

        public XMLbridge(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
            this.width = int.Parse(tree.Attribute("width"));
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            for (int i = 0; i < width; i++)
            {
                matrix[x+i].Add(new BlockBridge(16 * (x + i), 16 * (y - 1)));
            }
        }
    }
}
