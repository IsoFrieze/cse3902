using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLquestionblock : IXMLLevelObject
    {
        int x;
        int y;
        int width;
        int height;
        String contains;
        String go;

        public XMLquestionblock(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
            String w = tree.Attribute("width");
            String h = tree.Attribute("height");
            this.width = w == null ? 1 : int.Parse(w);
            this.height = h == null ? 1 : int.Parse(h);
            String c = tree.Attribute("contains");
            this.contains = c == null ? "coin" : c;
            this.go = tree.Attribute("goto");
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    IPowerUp[] p = GetContents(matrix, x + i, y + j);
                    if (contains.Equals("vine"))
                    {
                        Vine v = new Vine(go, y + j + 1, 16 * (x + i), -1000);
                        matrix[x + i].Add(v);
                        VineSpawner spawner = new VineSpawner(v, 16 * (x + i), 16 * (y + j));
                        matrix[x + i].Add(spawner);
                        p = new IPowerUp[] { spawner };
                    }
                    matrix[x+i].Add(new BlockQuestion(p, 16 * (x + i), 16 * (y + j)));
                }
            }
        }

        private IPowerUp[] GetContents(List<List<Object>> matrix, int x, int y)
        {
            switch (this.contains)
            {
                case "multicoin":
                case "coin":
                    {
                        IPowerUp p = new Coin(16 * x, 16 * y);
                        p.State = new SCoinInBlock(p);
                        matrix[x].Add(p);
                        return new IPowerUp[] { p };
                    }
                case "powerup":
                    {
                        IPowerUp p1 = new Mushroom(16 * x, 16 * y);
                        p1.State = new SMushroomInBlock(p1);
                        IPowerUp p2 = new FireFlower(16 * x, 16 * y);
                        p2.State = new SFireFlowerInBlock(p2);
                        matrix[x].Add(p1);
                        matrix[x].Add(p2);
                        return new IPowerUp[] { p1, p2 };
                    }
                case "star":
                    {
                        IPowerUp p = new Star(16 * x, 16 * y);
                        p.State = new SStarInBlock(p);
                        matrix[x].Add(p);
                        return new IPowerUp[] { p };
                    }
                case "1up":
                    {
                        IPowerUp p = new _1Up(16 * x, 16 * y);
                        p.State = new S1UpInBlock(p);
                        matrix[x].Add(p);
                        return new IPowerUp[] { p };
                    }
                default:
                    {
                        return new IPowerUp[] { };
                    }
            }
        }
    }
}
