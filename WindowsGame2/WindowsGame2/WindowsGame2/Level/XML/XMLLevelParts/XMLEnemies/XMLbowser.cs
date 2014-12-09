using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLbowser : IXMLLevelObject
    {
        int x;
        int y;
        bool hammers;
        bool fireballs;
        String trueform;

        public XMLbowser(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
            String h = tree.Attribute("hammers");
            String f = tree.Attribute("fireballs");
            String t = tree.Attribute("trueform");
            this.hammers = h == null ? false : bool.Parse(h);
            this.fireballs = f == null ? false : bool.Parse(f);
            this.trueform = t == null ? "bowser" : t;
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            Bowser b = new Bowser(HUD.level.player, 16 * x, 16 * (y - 1));
            matrix[x].Add(b);
        }
    }
}
