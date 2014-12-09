using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLpiranhaplant : IXMLLevelObject
    {
        int x;
        int y;
        String color;

        public XMLpiranhaplant(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
            this.color = tree.Attribute("color");
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            matrix[x].Add(new PiranhaPlant(16 * x + 8, 16 * y - 8));
        }
    }
}
