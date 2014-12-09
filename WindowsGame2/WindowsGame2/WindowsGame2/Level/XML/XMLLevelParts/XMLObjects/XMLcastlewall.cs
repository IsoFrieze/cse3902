using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLcastlewall : IXMLLevelObject
    {
        int x;
        int y;
        int width;
        int height;

        public XMLcastlewall(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
            this.width = int.Parse(tree.Attribute("width"));
            this.height = int.Parse(tree.Attribute("height"));
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            matrix[x].Add(new CastleWall(16 * x, 16 * y, width, height));
        }
    }
}
