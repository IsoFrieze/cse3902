using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLtoad : IXMLLevelObject
    {
        int x;
        int y;

        public XMLtoad(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            matrix[x].Add(new Toad(16 * x, 16 * (y-1)));
        }
    }
}
