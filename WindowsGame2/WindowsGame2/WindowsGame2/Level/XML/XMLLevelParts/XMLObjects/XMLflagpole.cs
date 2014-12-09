using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLflagpole : IXMLLevelObject
    {
        int x;
        int y;

        public XMLflagpole(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            int height = 10;
            matrix[x].Add(new FlagpolePole(height, 16 * x, 16 * (y - height)));
            matrix[x].Add(new FlagpoleFlag(16 * x - 8, 16 * (y - height + 1)));
            matrix[x].Add(new BlockStair(16 * x, 16 * y));
        }
    }
}
