using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class LevelParser2
    {
        public XMLLevel levelData;
        List<List<Object>> levelMatrix;
        int background = 0, objectIndex = 0, enemyIndex = 0, loopIndex = 0;
        bool addedMario, addedBackground, addedTitlecard, addedCeiling;
        String levelname;
        public IPlayer Player { get; set; }

        public LevelParser2(String levelname)
        {
            XMLTree tree = new XMLTree();
            tree.GetData("levels.xml");
            this.levelData = new XMLLevel(tree);
            if (this.levelData.HasIntro(levelname))
            {
                this.levelData.SetLevel(levelname + (HUD.firstLevelEntrance[HUD.currentPlayer] ? "" : HotDAMN.TAG_SUBLEVEL + "main"));
            }
            else
            {
                this.levelData.SetLevel(levelname);
            }
            this.levelname = levelname;
            HUD.setting = GetSetting();
            addedMario = false;
            addedBackground = false;
            addedTitlecard = levelData.GetLevelProperty("start", "title") == null;
            String ceiling = levelData.GetLevelProperty("setting", "type");
            addedCeiling = ceiling == null || !ceiling.Equals("underwater");
            SetPhysics();

            this.levelMatrix = new List<List<Object>>();
            for (int i = 0; i < Size().Width; i++)
            {
                this.levelMatrix.Add(new List<Object>());
            }

            do { /* party */ } while (NextBackground());
            do { /* your mom */ } while (NextObjects());
        }

        public List<Object> ObjectsAtColumn(int col)
        {
            return levelMatrix[col];
        }

        public bool NextObjects()
        {
            if (!addedMario)
            {
                int x = GetMarioStartX();
                int y = int.Parse(levelData.GetLevelProperty("start", "y"));

                if (levelname.IndexOf(HotDAMN.TAG_NAME) != -1)
                {
                    String name = levelData.GetLevelTag().Name;
                    int success;
                    if (int.TryParse(name, out success))
                    {
                        x = success;
                        y = 0;
                    }
                    else
                    {
                        XMLTree pipe = null;
                        for (int i = 0; i < levelData.ObjectCount(); i++)
                        {
                            String attr = levelData.GetObject(i).Attribute("name");
                            if (attr != null && attr.Equals(name))
                            {
                                pipe = levelData.GetObject(i);
                            }
                        }
                        if (pipe != null)
                        {
                            x = int.Parse(pipe.Attribute("x"));
                            y = int.Parse(pipe.Attribute("y")) - 1;
                        }
                    }
                }

                Player = new Mario(16*x + 8, 16*(y-1));
                if (HUD.MARIO_STATE != null)
                {
                    Player.State = HUD.MarioState(Player, GetSetting());
                }
                Player.State.Update();
                addedMario = true;
                return true;
            }
            if (!addedCeiling)
            {
                int width = int.Parse(levelData.GetLevelProperty("dimensions", "width"));
                XMLinvisibleblock levelObject = new XMLinvisibleblock(0, 2, width, 1);
                levelObject.ProcessObject(levelMatrix);
                addedCeiling = true;
                return true;
            }
            if (objectIndex < levelData.ObjectCount())
            {
                XMLTree objectGroup = levelData.GetObject(objectIndex);

                Object[] args = new Object[] { objectGroup };

                Type type = Type.GetType("WindowsGame2.XML" + objectGroup.Name());
                if (type != null)
                {
                    IXMLLevelObject levelObject = (IXMLLevelObject)Activator.CreateInstance(type, args);

                    levelObject.ProcessObject(levelMatrix);
                }

                objectIndex++;
                return true;
            }
            else if (enemyIndex < levelData.EnemyCount())
            {
                XMLTree objectGroup = levelData.GetEnemy(enemyIndex);

                Object[] args = new Object[] { objectGroup };

                Type type = Type.GetType("WindowsGame2.XML" + objectGroup.Name());
                if (type != null)
                {
                    IXMLLevelObject levelObject = (IXMLLevelObject)Activator.CreateInstance(type, args);

                    levelObject.ProcessObject(levelMatrix);
                }

                enemyIndex++;
                return true;
            }
            else if (loopIndex < levelData.LoopCount())
            {
                XMLTree objectGroup = levelData.GetLoop(loopIndex);

                XMLloop loop = new XMLloop(objectGroup);
                loop.ProcessObject(levelMatrix);

                loopIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NextBackground()
        {
            if (!addedBackground)
            {
                String levelType = levelData.GetLevelProperty("setting", "type");
                switch (levelType)
                {
                    case "underground":
                    case "nighttime":
                    case "snowynighttime":
                    case "castle":
                        {
                            levelMatrix[0].Add(new Background(Color.Black));
                            break;
                        }
                    default:
                        {
                            levelMatrix[0].Add(new Background(new Color(146, 144, 255)));
                            break;
                        }
                }
                addedBackground = true;
                return true;
            }
            else 
            {
                String bgType = levelData.GetLevelProperty("setting", "background");

                int width = int.Parse(levelData.GetLevelProperty("dimensions", "width"));
                int height = int.Parse(levelData.GetLevelProperty("dimensions", "height"));

                if (bgType != null && bgType.Equals("bushesnhills"))
                {
                    if (background >= width) { return false; }
                    switch (background % 48)
                    {
                        case 0:
                            { levelMatrix[background].Add(new BigHill(16 * background, 16 * (height - 5))); background++; return true; }
                        case 8:
                            { levelMatrix[background].Add(new SmallCloud(16 * background, 16 * (height - 12))); background++; return true; }
                        case 11:
                            { levelMatrix[background].Add(new LargeBush(16 * background, 16 * (height - 3))); background++; return true; }
                        case 16:
                            { levelMatrix[background].Add(new SmallHill(16 * background, 16 * (height - 4))); background++; return true; }
                        case 19:
                            { levelMatrix[background].Add(new SmallCloud(16 * background, 16 * (height - 13))); background++; return true; }
                        case 23:
                            { levelMatrix[background].Add(new SmallBush(16 * background, 16 * (height - 3))); background++; return true; }
                        case 27:
                            { levelMatrix[background].Add(new LargeCloud(16 * background, 16 * (height - 12))); background++; return true; }
                        case 36:
                            { levelMatrix[background].Add(new MediumCloud(16 * background, 16 * (height - 13))); background++; return true; }
                        case 41:
                            { levelMatrix[background].Add(new MediumBush(16 * background, 16 * (height - 3))); background++; return true; }
                        default:
                            {
                                background++;
                                if (background >= width)
                                {
                                    if (!addedTitlecard)
                                    {
                                        levelMatrix[0].Add(new TitleCard(48, 32));
                                        addedTitlecard = true;
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                break;
                            }
                    }
                    background++;
                }
                else if (bgType != null && bgType.Equals("clouds"))
                {
                    if (background >= width) { return false; }
                    switch (background % 48)
                    {
                        case 3:
                            { levelMatrix[background].Add(new MediumCloud(16 * background, 16 * (height - 12))); background++; return true; }
                        case 9: case 35:
                            { levelMatrix[background].Add(new SmallCloud(16 * background, 16 * (height - 8))); background++; return true; }
                        case 18:
                            { levelMatrix[background].Add(new MediumCloud(16 * background, 16 * (height - 13))); background++; return true; }
                        case 28: case 46:
                            { levelMatrix[background].Add(new SmallCloud(16 * background, 16 * (height - 4))); background++; return true; }
                        case 38:
                            { levelMatrix[background].Add(new SmallCloud(16 * background, 16 * (height - 9))); background++; return true; }
                        default:
                            {
                                background++;
                                if (background >= width)
                                {
                                    return false;
                                }
                                break;
                            }
                    }
                    background++;
                }
                else if (bgType != null && bgType.Equals("fencesntrees"))
                {
                    if (background >= width) { return false; }
                    switch (background % 48)
                    {
                        case 0: case 30:
                            { levelMatrix[background].Add(new MediumCloud(16 * background, 16 * (height - 12))); background++; return true; }
                        case 11: case 23: case 24: case 40:
                            { levelMatrix[background].Add(new SmallTree(16 * background, 16 * (height - 4))); background++; return true; }
                        case 13: case 21: case 43:
                            { levelMatrix[background].Add(new LargeTree(16 * background, 16 * (height - 5))); background++; return true; }
                        case 14: case 15: case 16: case 17: case 38: case 39: case 41:
                            { levelMatrix[background].Add(new Fence(16 * background, 16 * (height - 3))); background++; return true; }
                        case 18:
                            { levelMatrix[background].Add(new SmallCloud(16 * background, 16 * (height - 12))); background++; return true; }
                        case 27: case 45:
                            { levelMatrix[background].Add(new SmallCloud(16 * background, 16 * (height - 13))); background++; return true; }
                        default:
                            {
                                background++;
                                if (background >= width)
                                {
                                    return false;
                                }
                                break;
                            }
                    }
                    background++;
                }
                else if (bgType != null && bgType.Equals("water"))
                {
                    if (background >= width) { return false; }
                    switch (background % 48)
                    {
                        case 0: { levelMatrix[background].Add(new Water(16 * background, 16 * (height - 13))); background++; return true; }
                        default:
                            {
                                background++;
                                if (background >= width)
                                {
                                    return false;
                                }
                                break;
                            }
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public void SetMusic(List<Song> songs)
        {
            String type = levelData.GetLevelProperty("setting", "type");
            String title = levelData.GetLevelProperty("start", "title");

            if (title != null && bool.Parse(title))
            {
                songs.Add(Sound.silence);
            }

            switch (type)
            {
                case "underground":
                    {
                        songs.Add(Sound.underworldTheme);
                        songs.Add(Sound.hurryTheme);
                        songs.Add(Sound.hurryundergroundTheme);
                        break;
                    }
                case "castle":
                    {
                        songs.Add(Sound.castleTheme);
                        songs.Add(Sound.hurryTheme);
                        songs.Add(Sound.hurrycastleTheme);
                        break;
                    }
                case "underwater":
                    {
                        songs.Add(Sound.underwaterTheme);
                        songs.Add(Sound.hurryTheme);
                        songs.Add(Sound.hurryunderwaterTheme);
                        break;
                    }
                case "skybonus":
                    {
                        songs.Add(Sound.starmanTheme);
                        songs.Add(Sound.hurryTheme);
                        songs.Add(Sound.hurrystarmanTheme);
                        break;
                    }
                default:
                    {
                        songs.Add(Sound.mainTheme);
                        songs.Add(Sound.hurryTheme);
                        songs.Add(Sound.hurryoverworldTheme);
                        break;
                    }
            }
        }

        public bool SetAutoMovement(IPlayer player)
        {
            String s = levelData.GetLevelProperty("start", "auto");
            if (s != null && bool.Parse(s))
            {
                player.AutoMove = new BeginLevelAutoMovement(player);
                return true;
            }
            s = levelData.GetLevelProperty("start", "title");
            if (s != null && bool.Parse(s))
            {
                player.AutoMove = new TitleScreenAutoMovement(player);
                return true;
            }
            return false;
        }

        public void SetTime()
        {
            String s = levelData.GetLevelProperty("time", "seconds");
            if (s != null)
            {
                HUD.TIME = int.Parse(s);
            }
        }

        private int GetMarioStartX()
        {
            String start = levelData.GetLevelProperty("start", "x");
            int x;
            if (GetMidpoint(out x))
            {
                return HUD.midpointHit[HUD.currentPlayer] ? x : int.Parse(start);
            }
            else
            {
                return int.Parse(start);
            }
        }

        public bool GetMidpoint(out int x)
        {
            String midX = levelData.GetLevelProperty("midpoint", "x");
            x = midX == null ? 10000000 : int.Parse(midX);
            return midX != null;
        }

        public String GetFallOffScreenLevel()
        {
            return levelData.GetLevelProperty("offscreen", "goto");
        }

        public void SetPhysics()
        {
            if (GetSetting() == 3)
            {
                Physics.GRAVITY = new Vector2(0, 0.15f);
            }
            else
            {
                Physics.GRAVITY = new Vector2(0, 0.75f);
            }
        }

        public Rectangle Size()
        {
            int width = int.Parse(levelData.GetLevelProperty("dimensions", "width"));
            int height = int.Parse(levelData.GetLevelProperty("dimensions", "height"));
            return new Rectangle(0, 0, 16*width, 16*height);
        }

        private int GetSetting()
        {
            String type = levelData.GetLevelProperty("setting", "type");

            switch (type)
            {
                case "underground":
                    { return 1; }
                case "castle":
                case "snowy":
                case "snowynighttime":
                case "skybonus":
                    { return 2; }
                case "underwater":
                    { return 3; }
                default: { return 0; }
            }
        }
    }
}
