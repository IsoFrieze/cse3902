using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLpipe : IXMLLevelObject
    {
        int x;
        int y;
        int width;
        int height;
        bool showtop;
        String name;
        String go;

        public XMLpipe(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
            this.height = int.Parse(tree.Attribute("height"));
            String w = tree.Attribute("width");
            this.width = w == null ? 0 : int.Parse(w);
            this.name = tree.Attribute("name");
            this.go = tree.Attribute("goto");
            String s = tree.Attribute("showtop");
            this.showtop = s != null;
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            if (width == 0)
            {
                matrix[x].Add(new BlockPipe(name, height, true, 16 * x, 16 * y));
                if (go != null)
                {
                    matrix[x].Add(new LevelTransitionPoint(go, "down",  (16 * x) + 18, (16 * y)));
                    matrix[x].Add(new LevelTransitionPoint(go, "down", (16 * x) + 10, (16 * y)));
                }
            }
            else
            {
                matrix[x+width].Add(new BlockPipe(name, height - 2, showtop, 16 * (x + width), 16 * (y - height + 2)));
                matrix[x].Add(new BlockPipeSideways(width, 16 * x, 16 * y));
                if (go != null)
                {
                    matrix[x].Add(new LevelTransitionPoint(go, "right", (16 * x), (16 * y) + 16));
                    matrix[x].Add(new LevelTransitionPoint(go, "right", (16 * x), (16 * y) + 28));
                }
            }
        }
    }
}
