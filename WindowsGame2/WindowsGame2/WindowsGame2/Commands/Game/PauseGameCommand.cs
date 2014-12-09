using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2
{
    public class PauseGameCommand : ITechnicalCommand
    {
        Game1 game;

        public PauseGameCommand(Game1 game)
        {
            this.game = game;
          
        }

        public void Execute()
        {
            if (game.state is STitleScreen)
            {
                if (((STitleScreen)game.state).pointer.GetSelectedRow() == 0)
                {
                    HUD.numOfPlayers = 1;
                    HUD.SetPlayerInfo();
                    game.state = new SLevelIntro(game, HUD.worldNum[HUD.currentPlayer] + "-" + HUD.levelNum[HUD.currentPlayer]);
                }
                else if (((STitleScreen)game.state).pointer.GetSelectedRow() == 1)
                {
                    HUD.numOfPlayers = 2;
                    HUD.SetPlayerInfo();
                    game.state = new SLevelIntro(game, HUD.worldNum[HUD.currentPlayer] + "-" + HUD.levelNum[HUD.currentPlayer]);
                }
                else if (((STitleScreen)game.state).pointer.GetSelectedRow() == 2)
                {
                    HUD.numOfPlayers = 1;
                    HUD.SetPlayerInfo();
                    game.state = new SWarpZone(game);
                }

                
                
            }
            else if (game.state is SWarpZone)
            {
                int column;
                int world = 1;
                int level = 1;
                column = ((SWarpZone)game.state).pointer.GetSelectedColumn();
                level = ((SWarpZone)game.state).pointer.GetSelectedRow() + 1;
                if (column == 0)
                {
                    world = 1;
                    if (level < 5)
                    {
                        game.state = new SLevelIntro(game, world + "-" + level);
                    }
                    else
                    {
                        level = level - 4;
                        world = world + 1;
                        game.state = new SLevelIntro(game, world + "-" + level);
                    }
                }
                else if (column == 1)
                {
                    world = 3;
                    if (level < 5)
                    {
                        game.state = new SLevelIntro(game, world + "-" + level);
                    }
                    else
                    {
                        level = level - 4;
                        world = world + 1;
                        game.state = new SLevelIntro(game, world + "-" + level);
                    }
                }
                else if (column == 2)
                {
                    world = 5;
                    if (level < 5)
                    {
                        game.state = new SLevelIntro(game, world + "-" + level);
                    }
                    else
                    {
                        level = level - 4;
                        world = world + 1;
                        game.state = new SLevelIntro(game, world + "-" + level);
                    }
                }
                else if (column == 3)
                {
                    world = 7;
                    if (level < 5)
                    {
                        game.state = new SLevelIntro(game, world + "-" + level);
                    }
                    else
                    {
                        level = level - 4;
                        world = world + 1;
                        game.state = new SLevelIntro(game, world + "-" + level);
                    }
                }
            }
            else
            {
                if (game.state is SLevelPaused)
                {
                    game.state.UnPause();
                }
                else
                {
                    game.state.Pause();
                }
                SoundPanel.PlaySoundEffect(Sound.pauseEffect);
            }
        }
    }
}
