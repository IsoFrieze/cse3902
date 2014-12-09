using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class XMLLevel
    {
        XMLTree tree;
        XMLTree currentLevel;
        XMLTree currentSublevel;
        LevelTag levelTag;

        public XMLLevel(XMLTree tree)
        {
            this.tree = tree;
            this.currentLevel = tree.Child(0);
            this.currentSublevel = currentLevel.SomeChild("sublevel", null);
        }

        public bool SetLevel(String tag)
        {
            LevelTag name = new LevelTag(tag);
            levelTag = name;

            XMLTree foundLevel = tree.SomeChild("level", name.Level);
            if (foundLevel == null) return false;
            this.currentLevel = foundLevel;

            XMLTree foundSubLevel = foundLevel.SomeChild("sublevel", name.Sublevel);
            if (foundSubLevel == null) return false;
            this.currentSublevel = foundSubLevel;

            return true;
        }

        public String GetLevelProperty(String tag, String attr)
        {
            XMLTree property = currentSublevel.SomeChild("properties").SomeChild(tag);
            return property == null ? null : property.Attribute(attr);
        }

        public XMLTree GetObject(int i)
        {
            return currentSublevel.SomeChild("objects").Child(i);
        }

        public XMLTree GetEnemy(int i)
        {
            return currentSublevel.SomeChild("enemies").Child(i);
        }

        public XMLTree GetLoop(int i)
        {
            return currentSublevel.SomeChild("maze").Child(i);
        }

        public int ObjectCount()
        {
            XMLTree objects = currentSublevel.SomeChild("objects");
            return objects == null ? 0 : objects.ChildCount();
        }

        public int EnemyCount()
        {
            XMLTree enemies = currentSublevel.SomeChild("enemies");
            return enemies == null ? 0 : enemies.ChildCount();
        }

        public int LoopCount()
        {
            XMLTree loops = currentSublevel.SomeChild("maze");
            return loops == null ? 0 : loops.ChildCount();
        }

        public LevelTag GetLevelTag()
        {
            return levelTag;
        }

        public bool HasIntro(String levelname)
        {
            LevelTag name = new LevelTag(levelname);
            levelTag = name;

            XMLTree foundLevel = tree.SomeChild("level", name.Level);
            if (foundLevel == null) return false;

            XMLTree foundSubLevel = foundLevel.SomeChild("sublevel", "main");
            if (foundSubLevel == null) return false;

            return true;
        }

        public class LevelTag
        {
            public String Level { get; set; }
            public String Sublevel { get; set; }
            public String Name { get; set; }
            public LevelTag(String tag)
            {
                int sublevelTag = tag.IndexOf("@");
                int nameTag = tag.IndexOf("#");
                int levelTagLength = sublevelTag == -1 ? (nameTag == -1 ? -1 : nameTag) : sublevelTag;
                this.Level = levelTagLength == -1 ? tag : tag.Substring(0, levelTagLength);
                if (sublevelTag != -1)
                {
                    int sublevelTagLength = nameTag == -1 ? tag.Length - levelTagLength - 1 : nameTag - levelTagLength - 1;
                    this.Sublevel = tag.Substring(sublevelTag + 1, sublevelTagLength);
                }
                if (nameTag != -1)
                {
                    int nameTagLength = tag.Length - nameTag - 1;
                    this.Name = tag.Substring(nameTag + 1, nameTagLength);
                }
            }
        }
    }
}
