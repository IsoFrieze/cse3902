using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLmovingplatform : IXMLLevelObject
    {
        int x1;
        int y1;
        int x2;
        int y2;
        int width;

        public XMLmovingplatform(XMLTree tree)
        {
            this.x1 = int.Parse(tree.Attribute("x1"));
            this.y1 = int.Parse(tree.Attribute("y1"));
            this.x2 = int.Parse(tree.Attribute("x2"));
            this.y2 = int.Parse(tree.Attribute("y2"));
            this.width = int.Parse(tree.Attribute("width"));
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            matrix[x1 < x2 ? x1 : x2].Add(new MovingPlatform(width, 16 * x1, 16 * y1, 16 * x2, 16 * y2));
        }
    }
}
