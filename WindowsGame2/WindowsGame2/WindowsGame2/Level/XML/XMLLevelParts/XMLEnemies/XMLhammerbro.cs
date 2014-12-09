using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLhammerbro : IXMLLevelObject
    {
        int x;
        int y;
        String action;

        public XMLhammerbro(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
            String a = tree.Attribute("action");
            this.action = a == null ? "stay" : a;
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            HammerBro h = new HammerBro(16 * x, 16 * y);
            if (action.Equals("approach"))
            {
                h.State = new SHammerBroApproach(h);
            }
            matrix[x].Add(h);
        }
    }
}
