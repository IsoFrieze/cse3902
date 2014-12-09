using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class LevelLoader
    {
        public LevelParser2 parser;
        public String levelname;

        public LevelLoader(String levelname)
        {
            this.levelname = levelname;
            this.parser = new LevelParser2(levelname);
        }

        public void SetLevelSettings(Level level)
        {
            level.player = parser.Player;
            level.dynamics.Add(parser.Player);
            parser.GetMidpoint(out level.midpoint);
            level.fallOffScreenLevel = parser.GetFallOffScreenLevel();
            parser.SetAutoMovement(level.player);
            parser.SetMusic(level.songs);
            parser.SetTime();
        }

        public void Update(Level level)
        {
            if (level.camXNow > level.camXThen)
            {
                for (int i = level.camXThen; i < level.camXNow; i++)
                {
                    List<Object> objs = parser.ObjectsAtColumn(i + HotDAMN.OFFSCREEN_LEVEL_LOAD_BLOCKS);

                    for (int j = 0; j < objs.Count; j++)
                    {
                        Object obj = objs[j];

                        if (obj is IBackground)
                        {
                            level.scenery.Add((IBackground)obj);
                        }
                        if (obj is IBlock)
                        {
                            ((IBlock)obj).IsActive = true;
                            level.statics.Add((IBlock)obj);
                        }
                        else if (!(obj is NullObject) && obj is ITangible)
                        {
                            ((ITangible)obj).IsActive = true;
                            level.dynamics.Add((ITangible)obj);
                        }
                    }
                }
            }

            level.camXThen = level.camXNow;
            level.camXNow = level.camera.Viewport.Right / HotDAMN.GRID;
        }

        public Rectangle Reset()
        {
            parser = new LevelParser2(levelname);
            return parser.Size();
        }
    }
}
