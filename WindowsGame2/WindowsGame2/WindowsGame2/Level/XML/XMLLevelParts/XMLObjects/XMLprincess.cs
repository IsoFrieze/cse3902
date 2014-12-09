using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLprincess : IXMLLevelObject
    {
        int x;
        int y;

        public XMLprincess(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            matrix[x].Add(new Princess(16 * x, 16 * (y-1)));
        }
    }
}
