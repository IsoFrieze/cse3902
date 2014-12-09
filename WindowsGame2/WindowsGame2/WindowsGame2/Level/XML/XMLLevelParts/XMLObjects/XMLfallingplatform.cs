using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLfallingplatform : IXMLLevelObject
    {
        int x;
        int y;
        int width;

        public XMLfallingplatform(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
            this.width = int.Parse(tree.Attribute("width"));
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            matrix[x].Add(new FallingPlatform(width, 16 * x, 16 * y));
        }
    }
}
