using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLfirebar : IXMLLevelObject
    {
        int x;
        int y;
        bool ccw;
        int size;

        public XMLfirebar(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
            String c = tree.Attribute("direction");
            this.ccw = c != null && c.Equals("counterclockwise");
            String s = tree.Attribute("size");
            this.size = s != null ? (s.Equals("small") ? 6 : 10) : 0;
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            matrix[x].Add(new Firebar(size, ccw, 16 * x, 16 * y));
        }
    }
}
