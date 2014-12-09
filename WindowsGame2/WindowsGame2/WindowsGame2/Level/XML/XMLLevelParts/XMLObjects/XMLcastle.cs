using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLcastle : IXMLLevelObject
    {
        int x;
        int y;
        String size;

        public XMLcastle(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
            this.size = tree.Attribute("size");
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            switch (size)
            {
                case "small":
                    {
                        matrix[x].Add(new CastleSmall(16 * x, 16 * (y - 4)));
                        break;
                    }
                case "large":
                    {
                        matrix[x < 0 ? 0 : x].Add(new CastleBig(16 * x, 16 * (y - 10) + 1));
                        break;
                    }
            }
        }
    }
}
