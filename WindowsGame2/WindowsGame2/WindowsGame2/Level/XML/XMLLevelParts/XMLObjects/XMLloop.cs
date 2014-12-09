using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLloop : IXMLLevelObject
    {
        List<Tuple<int,int,int>> checkpoints;
        Tuple<int,int> finish;

        public XMLloop(XMLTree tree)
        {
            checkpoints = new List<Tuple<int,int,int>>();
            for (int i = 0; i < tree.ChildCount(); i++)
            {
                XMLTree t = tree.Child(i);
                if (t.Name().Equals("finish"))
                {
                    finish = new Tuple<int, int>(int.Parse(t.Attribute("x")), int.Parse(t.Attribute("setback")));
                }
                else
                {
                    checkpoints.Add(new Tuple<int, int, int>(
                        int.Parse(t.Attribute("x")),
                        int.Parse(t.Attribute("y")),
                        int.Parse(t.Attribute("height"))
                            ));
                }
            }
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            MazeFinish f = new MazeFinish(16 * finish.Item1, finish.Item2);
            for (int i = 0; i < checkpoints.Count; i++)
            {
                MazeCheckpoint c = new MazeCheckpoint(16 * checkpoints[i].Item1, 16 * checkpoints[i].Item2, checkpoints[i].Item3);
                f.AddCheckpoint(c);
                matrix[checkpoints[i].Item1].Add(c);
            }
            matrix[finish.Item1].Add(f);
        }
    }
}
