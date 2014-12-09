using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public static class XMLTokenizer
    {
        public static List<String> Tokenize(String filename)
        {
            List<String> tokens = new List<String>();
            StreamReader read = new StreamReader("../../../../WindowsGame2Content/Levels/" + filename);

            String line = read.ReadLine();

            while (line != null)
            {
                String remains = line.Trim();

                while (remains.Length > 0)
                {
                    int j;
                    // <tag>, </tag>, <tag, >, />
                    if (remains[0] == '<' || remains[0] == '>' || remains[0] == '/')
                    {
                        j = remains.IndexOf(" ");
                    }
                    else
                    {
                        int i = remains.IndexOf("\"");
                        int k = remains.IndexOf(" ");
                        // attr="val", attr
                        if (i == -1 || (k != -1 && k < i))
                        {
                            j = k;
                        }
                        // attr="val">
                        else
                        {
                            j = remains.IndexOf("\"", i + 1) + 1;
                        }
                    }

                    if (j == -1)
                    {
                        tokens.Add(remains);
                        remains = "";
                    }
                    else
                    {
                        tokens.Add(remains.Substring(0, j));
                        remains = remains.Substring(j).Trim();
                    }
                }
                line = read.ReadLine();
            }

            return tokens;
        }
    }
}
