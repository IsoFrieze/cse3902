using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLgenerator : IXMLLevelObject
    {
        int xStart;
        int xEnd;
        String type;

        public XMLgenerator(XMLTree tree)
        {
            this.xStart = int.Parse(tree.Attribute("xstart"));
            String e = tree.Attribute("xend");
            this.xEnd = e == null ? 10000 : int.Parse(e);
            this.type = tree.Attribute("type");
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            switch (type)
            {
                case "fireballs":
                    {
                        matrix[0].Add(new GeneratorFireballs(16 * xStart, 16 * xEnd));
                        break;
                    }
                case "swimmingfish":
                    {
                        matrix[0].Add(new GeneratorFishSwimming(16 * xStart, 16 * xEnd));
                        break;
                    }
                case "jumpingfish":
                    {
                        matrix[0].Add(new GeneratorFishJumping(16 * xStart, 16 * xEnd));
                        break;
                    }
                case "bulletbills":
                    {
                        matrix[0].Add(new GeneratorBulletBills(16 * xStart, 16 * xEnd));
                        break;
                    }
                default: { break; }
            }
        }
    }
}
