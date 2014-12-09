using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class RandomizeConstants : ITechnicalCommand
    {
        public RandomizeConstants()
        {
        }

        public void Execute()
        {
            Random random = new Random();
            
            Physics.GRAVITY = new Vector2(0.1f * ((float)random.NextDouble() - 0.5f), (float)random.NextDouble());
            Physics.TERMINAL_VELOCITY_FALLING = 16f * (float)random.NextDouble();
            Physics.TERMINAL_VELOCITY_WALKING = 3f * (float)random.NextDouble();
            Physics.TERMINAL_VELOCITY_RUNNING = 6f * (float)random.NextDouble();

            HotDAMN.MAX_FIREBALL_COUNT = random.Next(20);
            HotDAMN.MULTICOIN_BLOCK_MAXIMUM = random.Next(100);
            HotDAMN.FIREBAR_SPEED = random.Next(5);
            HotDAMN.TICKS_UNTIL_TIMER_DECREMENTS = random.Next(50);
            HotDAMN.TICKS_UNTIL_NEXT_FIREWORK = random.Next(100);
            HotDAMN.TICKS_UNTIL_KOOPA_WARNING = random.Next(500);
            HotDAMN.TICKS_UNTIL_MOVING_PLATFORMS_CYCLE = random.Next(700);
            HotDAMN.TICKS_UNTIL_STAR_POWER_EXPIRES = random.Next(2000);
            HotDAMN.TICKS_UNTIL_BLASTER_SHOOTS = random.Next(500);
            HotDAMN.SCORE_BREAK_BRICK = 50 * random.Next(20);
            HotDAMN.SCORE_BREAK_SCALE_PLATFORMS = 50 * random.Next(20);
            HotDAMN.SCORE_COLLECT_COIN = 50 * random.Next(20);
            HotDAMN.SCORE_COLLECT_MUSHROOM = 50 * random.Next(20);
            HotDAMN.SCORE_COLLECT_FIREFLOWER = 50 * random.Next(20);
            HotDAMN.SCORE_COLLECT_STAR = 50 * random.Next(20);
            HotDAMN.SCORE_COLLECT_FIREWORK = 50 * random.Next(20);
            HotDAMN.SCORE_KICK_BUZZYBEETLE = 50 * random.Next(20);
            HotDAMN.SCORE_KILL_BUZZYBEETLE = 50 * random.Next(20);
            HotDAMN.SCORE_BUMP_BUZZYBEETLE = 50 * random.Next(20);
            HotDAMN.SCORE_DEWING_KOOPA = 50 * random.Next(20);
            HotDAMN.SCORE_KICK_KOOPA = 50 * random.Next(20);
            HotDAMN.SCORE_KILL_KOOPA = 50 * random.Next(20);
            HotDAMN.SCORE_BUMP_KOOPA = 50 * random.Next(20);
            HotDAMN.SCORE_KILL_HAMMERBRO = 50 * random.Next(20);
            HotDAMN.SCORE_BUMP_HAMMERBRO = 50 * random.Next(20);
            HotDAMN.SCORE_KILL_GOOMBA = 50 * random.Next(20);
            HotDAMN.SCORE_BUMP_GOOMBA = 50 * random.Next(20);
            HotDAMN.SCORE_KILL_PIRANHAPLANT = 50 * random.Next(20);
            HotDAMN.SCORE_KILL_CHEEPCHEEP = 50 * random.Next(20);
            HotDAMN.SCORE_KILL_BULLETBILL = 50 * random.Next(20);
            HotDAMN.SCORE_KILL_BLOOPER = 50 * random.Next(20);
            HotDAMN.SCORE_KILL_BOWSER = 50 * random.Next(20);
        }
    }
}
