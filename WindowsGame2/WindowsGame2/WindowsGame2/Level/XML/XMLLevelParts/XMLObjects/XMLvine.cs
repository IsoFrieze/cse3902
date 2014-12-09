using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLvine : IXMLLevelObject
    {
        int x;
        int y;
        int height;

        public XMLvine(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
            this.height = int.Parse(tree.Attribute("height"));
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            matrix[x].Add(new Vine(null, height, 16 * x, 16 * y));
        }
    }
}
