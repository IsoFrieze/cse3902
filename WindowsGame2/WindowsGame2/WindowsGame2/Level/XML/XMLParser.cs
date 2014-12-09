using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public static class XMLParser
    {
        public static void Parse(XMLTree tree, String filename)
        {
            List<String> tokens = XMLTokenizer.Tokenize(filename);

            ParseTree(tree, tokens, 0);
        }

        // will only be called when tokens[index] is an opening tag
        public static int ParseTree(XMLTree tree, List<String> tokens, int index)
        {
            int startIndex = index;
            if (ParseTagName(tree, tokens[index]))
            {
                index++;
                while (tokens[index].IndexOf(">") == -1)
                {
                    ParseAttribute(tree, tokens[index]);
                    index++;
                }
            }
            bool hasChildren = tokens[index].IndexOf("/") == -1;
            index++;
            while (hasChildren && index < tokens.Count && tokens[index].IndexOf("/"+tree.name) == -1)
            {
                XMLTree child = new XMLTree();
                tree.children.Add(child);
                int subConsumed = ParseTree(child, tokens, index);
                index += subConsumed;
            }
            if (hasChildren)
            {
                index++;
            }
            return index - startIndex;
        }


        // return true if attributes present
        public static bool ParseTagName(XMLTree tree, String token)
        {
            int i = token.IndexOf('<');
            int j = token.IndexOf('>');
            tree.name = token.Substring(i + 1, j == -1 ? token.Length - i - 1 : j - i - 1);
            return j == -1;
        }

        // return true if flag attribute (no value)
        public static bool ParseAttribute(XMLTree tree, String token)
        {
            int i = token.IndexOf("=");
            if (i == -1)
            {
                tree.attributes.Add(token, "true");
                return true;
            }
            else
            {
                int j = token.IndexOf("\"");
                tree.attributes.Add(token.Substring(0, i), token.Substring(j + 1, token.IndexOf("\"", j + 1) - j - 1));
                return false;
            }
        }

        public static void PrintTree(XMLTree tree, int i)
        {
            for (int j = 0; j < i; j++) { Console.Write(" "); }
            Console.Write("<" + tree.name);
            foreach (KeyValuePair<String, String> p in tree.attributes)
            {
                Console.Write(" " + p.Key + "=\"" + p.Value + "\"");
            }
            if (tree.children.Count > 0)
            {
                Console.WriteLine(">");
                foreach (XMLTree child in tree.children)
                {
                    PrintTree(child, i + 3);
                }
                for (int j = 0; j < i; j++) { Console.Write(" "); }
                Console.WriteLine("</" + tree.name + ">");
            }
            else
            {
                Console.WriteLine(" />");
            }
        }
    }
}
