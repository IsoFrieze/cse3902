using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public static class HUD
    {
        public static int numOfPlayers, currentPlayer, nextPlayer, deathCount, TIME, SONG_INDEX, HangTime = 0, setting, glowFrame, glowCount;

        public static List<IPlayerState> MARIO_STATE = new List<IPlayerState>();

        public static int[] ShellSequnce = { 500, 800, 1000, 2000, 4000, 5000, 8000 }, 
            StompSequnce = { 100, 200, 400, 500, 800, 1000, 2000, 4000, 5000, 8000 };
        
        private static String world = "WORLD", time = "TIME";
        public static List<String> playerName = new List<String>();
        public static List<int> LIVES = new List<int>(), COINS = new List<int>(), SCORE = new List<int>(), worldNum = new List<int>(), levelNum = new List<int>();
        private static IAnimatedSprite miniCoin = new Animation(Textures.miniCoin, 6, 10, glowFrame, glowCount);

        public static IPlayer player;
        public static Level level;
        public static List<bool> midpointHit = new List<bool>(), firstLevelEntrance = new List<bool>();

        public static void Initialize()
        {
            nextPlayer = 0;
            deathCount = 0;
            glowFrame = 0;
            glowCount = 0;
            TIME = 0;
            SONG_INDEX = 0;            

        }

        public static void Draw(SpriteBatch sb, String levelname)
        {
            if (COINS[currentPlayer] >= 100)
            {
                LIVES[currentPlayer]++;
                COINS[currentPlayer] = 0;
                SoundPanel.PlaySoundEffect(Sound.powerup1upEffect);
            }

            miniCoin.Update();
            miniCoin.Draw(sb, 90 , 21);

            if (glowCount % 10 == 0)
            {
                glowFrame++;

                if (glowFrame == 6)
                {
                    glowFrame = 0;
                }
            }
            glowCount++;

            String timer = (TIME < 0 ? 0 : TIME).ToString("D3"), points = SCORE[currentPlayer].ToString("D6"), coin = HotDAMN.TEXT_X + COINS[currentPlayer].ToString("D2");

            sb.DrawString(Textures.font, playerName[currentPlayer], new Vector2(25, 5), Color.White);
            sb.DrawString(Textures.font, points, new Vector2(25, 16), Color.White);

            sb.DrawString(Textures.font, coin, new Vector2(100, 16), Color.White);

            sb.DrawString(Textures.font, world, new Vector2(140, 5), Color.White);
            sb.DrawString(Textures.font, levelname.Replace('0',' '), new Vector2(155, 16), Color.White);

            sb.DrawString(Textures.font, time, new Vector2(210, 5), Color.White);
            sb.DrawString(Textures.font, timer, new Vector2(215, 16), Color.White);
            
        }

        public static IPlayerState MarioState(IPlayer player, int setting)
        {
            if (MARIO_STATE == null || MARIO_STATE.Count == 0)
            {
                return new SIdleRightSmallMario(player);
            }
            if (setting != 3)
            {
                if (MARIO_STATE[currentPlayer] == null || MARIO_STATE[currentPlayer] is ISmallMarioState)
                {
                    return new SIdleRightSmallMario(player);
                }
                if (MARIO_STATE[currentPlayer] is IFireMarioState)
                {
                    return new SIdleRightFireMario(player);
                }
                else
                {
                    return new SIdleRightBigMario(player);
                }
            }
            else
            {
                if (MARIO_STATE[currentPlayer] == null || MARIO_STATE[currentPlayer] is ISmallMarioState)
                {
                    return new SWaterIdleRightSmallMario(player);
                }
                if (MARIO_STATE[currentPlayer] is IFireMarioState)
                {
                    return new SWaterIdleRightFireMario(player);
                }
                else
                {
                    return new SWaterIdleRightBigMario(player);
                }
            }
        }

        public static void KoopaShellSequence(ITangible obj)
        {
            if (obj.SequenceCounter == ShellSequnce.Length)
            {
                LIVES[currentPlayer]++;
            }
            else
            {
                SCORE[currentPlayer] += StompSequnce[obj.SequenceCounter];
                level.AddParticle(new Score(obj.Position, StompSequnce[obj.SequenceCounter]));
                obj.SequenceCounter++;
            }
        }

        public static int FlagpolePoints(float marioHeight, float poleHeight) {
            int point = 0;
            if (marioHeight <= poleHeight + (HotDAMN.FLAGPOLE_5000_HEIGHT)) point = 5000;
            else if (marioHeight <= poleHeight + (HotDAMN.FLAGPOLE_2000_HEIGHT)) point = 2000;
            else if (marioHeight <= poleHeight + (HotDAMN.FLAGPOLE_800_HEIGHT)) point = 800;
            else if (marioHeight <= poleHeight + (HotDAMN.FLAGPOLE_400_HEIGHT)) point = 400;
            else if (marioHeight <= poleHeight + HotDAMN.FLAGPOLE_200_HEIGHT) point = 200;
            SCORE[currentPlayer] += point;

            Score score = new Score(new Vector2(HUD.level.Size.Width - 179, 196), point);
            score.State = new SParticleFlagpolePoints(score);
            HUD.level.AddParticle(score);

            return point;
        }

        public static void StompingPoints(ITangible obj)
        {
            if(HangTime != 0){
                if (obj.SequenceCounter == ShellSequnce.Length)
                {
                    LIVES[currentPlayer]++;
                }
                else
                {
                    SCORE[currentPlayer] += StompSequnce[obj.SequenceCounter];
                    level.AddParticle(new Score(obj.Position, StompSequnce[obj.SequenceCounter]));
                    obj.SequenceCounter++;
                }
            }
        }

        public static void NextLevel()
        {
            levelNum[currentPlayer]++;
            if (levelNum[currentPlayer] > 4)
            {
                worldNum[currentPlayer]++;
                levelNum[currentPlayer] = 1;
            }
        }

        public static void SetPlayerInfo() {
            for (int count = 0; count < numOfPlayers; count++)
            {
                LIVES.Add(HotDAMN.INITIAL_LIVES_COUNT);
                COINS.Add(0);
                SCORE.Add(0);
                worldNum.Add(HotDAMN.INITIAL_WORLD_NUMBER);
                levelNum.Add(HotDAMN.INITIAL_LEVEL_NUMBER);
                midpointHit.Add(false);
                MARIO_STATE.Add(null);
                firstLevelEntrance.Add(true);
                if (count == 1)
                    playerName.Add("LUIGI");
                else
                    playerName.Add("MARIO");
            }
        }
    }
}
