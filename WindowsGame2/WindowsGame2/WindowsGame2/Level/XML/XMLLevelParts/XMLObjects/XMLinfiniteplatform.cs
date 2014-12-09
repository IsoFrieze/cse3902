using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLinfiniteplatform : IXMLLevelObject
    {
        int x;
        int width;
        double frequency;
        bool up;
        bool showpath;

        public XMLinfiniteplatform(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.width = int.Parse(tree.Attribute("width"));
            this.frequency = double.Parse(tree.Attribute("frequency"));
            String d = tree.Attribute("direction");
            this.up = d == null ? false : d.Equals("up");
            String s = tree.Attribute("showpath");
            this.showpath = s == null ? false : bool.Parse(s);
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            for (int i = 0; i < frequency; i++)
            {
                matrix[x].Add(new ForeverPlatform(width, up, 16 * x, 16 * i * 16 / frequency));
            }
        }
    }
}
