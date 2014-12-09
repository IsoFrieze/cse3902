using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLbouncingkoopa : IXMLLevelObject
    {
        int x;
        int y;

        public XMLbouncingkoopa(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            Koopa k = new Koopa(16 * x, 16 * (y - 1));
            k.State = new SKoopaBouncingLeft(k);
            matrix[x].Add(k);
        }
    }
}
