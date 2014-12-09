using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLTree
    {
        public String name;
        public List<XMLTree> children;
        public Dictionary<String, String> attributes;

        public XMLTree()
        {
            children = new List<XMLTree>();
            attributes = new Dictionary<String, String>();
        }

        public void GetData(String filename) {
            XMLParser.Parse(this, filename);
        }

        public String Name()
        {
            return this.name;
        }

        public String Attribute(String attr)
        {
            String value = null;
            this.attributes.TryGetValue(attr, out value);
            return value;
        }

        public int ChildCount()
        {
            return children.Count;
        }

        public XMLTree Child(int i)
        {
            Debug.Assert(i < children.Count);
            return children[i];
        }

        public XMLTree SomeChild(String name)
        {
            for (int i = 0; i < children.Count; i++)
            {
                if (children[i].name.Equals(name))
                {
                    return children[i];
                }
            }
            return null;
        }

        public XMLTree SomeChild(String name, String attr)
        {
            for (int i = 0; i < children.Count; i++)
            {
                if (attr == null)
                {
                    if (children[i].name.Equals(name) && children[i].attributes.Count == 0)
                    {
                        return children[i];
                    }
                }
                else
                {
                    if (children[i].name.Equals(name) && children[i].attributes.ContainsValue(attr))
                    {
                        return children[i];
                    }
                }
            }
            return null;
        }
    }
}
