using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLlakitu : IXMLLevelObject
    {
        int x;
        int y;
        int stop;

        public XMLlakitu(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
            String s = tree.Attribute("stop");
            this.stop = s == null ? 10000 : int.Parse(s);
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            matrix[x].Add(new Lakitu(16 * x, 16 * y, 16 * stop));
        }
    }
}
