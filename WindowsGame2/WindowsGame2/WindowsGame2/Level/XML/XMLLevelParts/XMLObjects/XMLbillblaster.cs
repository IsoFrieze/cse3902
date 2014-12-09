using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLbillblaster : IXMLLevelObject
    {
        int x;
        int y;
        int height;

        public XMLbillblaster(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
            this.height = int.Parse(tree.Attribute("height"));
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            matrix[x].Add(new BlockBillBlaster(16 * x, 16 * y, height));
            matrix[x].Add(new GeneratorBulletShooter(16 * x, 16 * y));
        }
    }
}
