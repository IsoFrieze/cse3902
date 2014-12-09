using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLscaleplatforms : IXMLLevelObject
    {
        int x1;
        int y1;
        int x2;
        int y2;
        int y3;
        int width;

        public XMLscaleplatforms(XMLTree tree)
        {
            this.x1 = int.Parse(tree.Attribute("x1"));
            this.y1 = int.Parse(tree.Attribute("y1"));
            this.x2 = int.Parse(tree.Attribute("x2"));
            this.y2 = int.Parse(tree.Attribute("y2"));
            this.y3 = int.Parse(tree.Attribute("y3"));
            this.width = int.Parse(tree.Attribute("width"));
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            ScalePlatform a = new ScalePlatform(width, 16*x1, 16*y1, 16*(y3 + 1));
            ScalePlatform b = new ScalePlatform(width, 16*x2, 16*y2, 16*(y3 + 1));
            a.SetPartner(b);
            b.SetPartner(a);

            matrix[x1].Add(a);
            matrix[x2].Add(b);
        }
    }
}
