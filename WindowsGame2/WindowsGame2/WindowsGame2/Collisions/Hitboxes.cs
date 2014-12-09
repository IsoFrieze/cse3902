using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public static class Hitboxes
    {
        public static int TRANSITION_POINT_WIDTH = 4;
        public static int TRANSITION_POINT_HEIGHT = 4;

        public static int MAZE_CHECKPOINT_WIDTH = 16;
        public static int MAZE_CHECKPOINT_HEIGHT = 16;

        public static int MAZE_FINISH_WIDTH = 4;
        public static int MAZE_FINISH_HEIGHT = HotDAMN.WINDOW_HEIGHT;

        public static int BLOCK_HEIGHT = 16;
        public static int BLOCK_WIDTH = 16;
        public static int BLOCK_OFFSET_X = 0;
        public static int BLOCK_OFFSET_Y = 0;

        public static int BRIDGE_OFFSET_X = 0;
        public static int BRIDGE_OFFSET_Y = 16;

        public static int ROPE_WIDTH = 4;
        public static int ROPE_HEIGHT = 16;
        public static int ROPE_OFFSET_X = 6;
        public static int ROPE_OFFSET_Y = 16;

        public static int FLAG_WIDTH = 16;
        public static int FLAG_HEIGHT = 160;
        public static int FLAG_OFFSET_X = 14;
        public static int FLAG_OFFSET_Y = 0;

        public static int AXE_HEIGHT = 16;
        public static int AXE_WIDTH = 16;
        public static int AXE_OFFSET_X = 0;
        public static int AXE_OFFSET_Y = 0;

        public static int PIPE_WIDTH = 32;
        public static int PIPE_HEIGHT = 16;
        public static int PIPE_OFFSET_X = 0;
        public static int PIPE_OFFSET_Y = 0;

        public static int LEDGE_WIDTH = 16;
        public static int LEDGE_HEIGHT = 16;
        public static int LEDGE_OFFSET_X = 0;
        public static int LEDGE_OFFSET_Y = 0;

        public static int SPRINGBOARD_WIDTH = 16;
        public static int SPRINGBOARD_HEIGHT = 30;
        public static int SPRINGBOARD_OFFSET_X = 0;
        public static int SPRINGBOARD_OFFSET_Y = 0;

        public static int PLATFORM_WIDTH = 16;
        public static int PLATFORM_HEIGHT = 8;
        public static int PLATFORM_OFFSET_X = 0;
        public static int PLATFORM_OFFSET_Y = 0;

        public static int GOOMBA_WIDTH = 14;
        public static int GOOMBA_HEIGHT = 15;
        public static int GOOMBA_OFFSET_X = 1;
        public static int GOOMBA_OFFSET_Y = 1;

        public static int KOOPA_WIDTH = 14;
        public static int KOOPA_HEIGHT = 15;
        public static int KOOPA_OFFSET_X = 1;
        public static int KOOPA_OFFSET_Y = 17;

        public static int KOOPA_SHELL_WIDTH = 14;
        public static int KOOPA_SHELL_HEIGHT = 15;
        public static int KOOPA_SHELL_OFFSET_X = 1;
        public static int KOOPA_SHELL_OFFSET_Y = 17;

        public static int LAKITU_WIDTH = 14;
        public static int LAKITU_HEIGHT = 24;
        public static int LAKITU_OFFSET_X = 1;
        public static int LAKITU_OFFSET_Y = 8;

        public static int LAKITU_CLOUD_WIDTH = 14;
        public static int LAKITU_CLOUD_HEIGHT = 15;
        public static int LAKITU_CLOUD_OFFSET_X = 1;
        public static int LAKITU_CLOUD_OFFSET_Y = 17;


        public const int BULLETBILL_WIDTH = 16;
        public const int BULLETBILL_HEIGHT = 14;
        public const int BULLETBILL_OFFSET_X = 0;
        public const int BULLETBILL_OFFSET_Y = 1;

        public const int BILLBLASTER_WIDTH = 16;
        public const int BILLBLASTER_HEIGHT = 16;
        public const int BILLBLASTER_OFFSET_X = 0;
        public const int BILLBLASTER_OFFSET_Y = 0;

        public const int CHEEPCHEEP_WIDTH = 15;
        public const int CHEEPCHEEP_HEIGHT = 15;
        public const int CHEEPCHEEP_OFFSET_X = 0;
        public const int CHEEPCHEEP_OFFSET_Y = 1;

        public const int HAMMERBRO_WIDTH = 14;
        public const int HAMMERBRO_HEIGHT = 14;
        public const int HAMMERBRO_OFFSET_X = 1;
        public const int HAMMERBRO_OFFSET_Y = 17;

        public static int BUZZYBEETLE_WIDTH = 15;
        public static int BUZZYBEETLE_HEIGHT = 15;
        public static int BUZZYBEETLE_OFFSET_X = 0;
        public static int BUZZYBEETLE_OFFSET_Y = 1;

        public static int BUZZYBEETLE_SHELL_WIDTH = 14;
        public static int BUZZYBEETLE_SHELL_HEIGHT = 14;
        public static int BUZZYBEETLE_SHELL_OFFSET_X = 1;
        public static int BUZZYBEETLE_SHELL_OFFSET_Y = 2;

        public static int BLOOPER_WIDTH = 14;
        public static int BLOOPER_HEIGHT = 15;
        public static int BLOOPER_OFFSET_X = 1;
        public static int BLOOPER_OFFSET_Y = 1;

        
        public static int PIRANHA_PLANT_WIDTH = 14;
        public static int PIRANHA_PLANT_HEIGHT = 16;
        public static int PIRANHA_PLANT_OFFSET_X = 1;
        public static int PIRANHA_PLANT_OFFSET_Y = 16;

        public static int PODOBOO_WIDTH = 14;
        public static int PODOBOO_HEIGHT = 16;
        public static int PODOBOO_OFFSET_X = 1;
        public static int PODOBOO_OFFSET_Y = 0;

        public static int FIREBAR_WIDTH = 8;
        public static int FIREBAR_HEIGHT = 8;
        public static int FIREBAR_OFFSET_X = 4;
        public static int FIREBAR_OFFSET_Y = 4;

        public static int SPINY_WIDTH = 16;
        public static int SPINY_HEIGHT = 15;
        public static int SPINY_OFFSET_X = 0;
        public static int SPINY_OFFSET_Y = 1;

        public static int SPINY_EGG_WIDTH = 14;
        public static int SPINY_EGG_HEIGHT = 16;
        public static int SPINY_EGG_OFFSET_X = 1;
        public static int SPINY_EGG_OFFSET_Y = 0;

        public static int ONE_UP_WIDTH = 16;
        public static int ONE_UP_HEIGHT = 16;
        public static int ONE_UP_OFFSET_X = 0;
        public static int ONE_UP_OFFSET_Y = 0;

        public static int COIN_WIDTH = 10;
        public static int COIN_HEIGHT = 14;
        public static int COIN_OFFSET_X = 3;
        public static int COIN_OFFSET_Y = 1;

        public static int FIRE_FLOWER_WIDTH = 16;
        public static int FIRE_FLOWER_HEIGHT = 16;
        public static int FIRE_FLOWER_OFFSET_X = 0;
        public static int FIRE_FLOWER_OFFSET_Y = 0;

        public static int MUSHROOM_WIDTH = 16;
        public static int MUSHROOM_HEIGHT = 16;
        public static int MUSHROOM_OFFSET_X = 0;
        public static int MUSHROOM_OFFSET_Y = 0;

        public static int STAR_WIDTH = 14;
        public static int STAR_HEIGHT = 16;
        public static int STAR_OFFSET_X = 1;
        public static int STAR_OFFSET_Y = 0;

        public static int FIREBALL_WIDTH = 8;
        public static int FIREBALL_HEIGHT = 8;
        public static int FIREBALL_OFFSET_X = 0;
        public static int FIREBALL_OFFSET_Y = 0;

        public static int BIG_MARIO_DUCK_WIDTH = 14;
        public static int BIG_MARIO_DUCK_HEIGHT = 15;
        public static int BIG_MARIO_DUCK_OFFSET_X = 1;
        public static int BIG_MARIO_DUCK_OFFSET_Y = 17;

        public static int BIG_MARIO_IDLE_WIDTH = 14;
        public static int BIG_MARIO_IDLE_HEIGHT = 31;
        public static int BIG_MARIO_IDLE_OFFSET_X = 1;
        public static int BIG_MARIO_IDLE_OFFSET_Y = 1;

        public static int BIG_MARIO_JUMP_WIDTH = 14;
        public static int BIG_MARIO_JUMP_HEIGHT = 31;
        public static int BIG_MARIO_JUMP_OFFSET_X = 1;
        public static int BIG_MARIO_JUMP_OFFSET_Y = 1;

        public static int BIG_MARIO_SWIM_WIDTH = 14;
        public static int BIG_MARIO_SWIM_HEIGHT = 31;
        public static int BIG_MARIO_SWIM_OFFSET_X = 1;
        public static int BIG_MARIO_SWIM_OFFSET_Y = 1;

        public static int BIG_MARIO_RUN_WIDTH = 14;
        public static int BIG_MARIO_RUN_HEIGHT = 31;
        public static int BIG_MARIO_RUN_OFFSET_X = 1;
        public static int BIG_MARIO_RUN_OFFSET_Y = 1;

        public static int BIG_MARIO_CLIMBING_WIDTH = 14;
        public static int BIG_MARIO_CLIMBING_HEIGHT = 31;
        public static int BIG_MARIO_CLIMBING_OFFSET_X = 1;
        public static int BIG_MARIO_CLIMBING_OFFSET_Y = 1;

        public static int SMALL_MARIO_IDLE_WIDTH = 14;
        public static int SMALL_MARIO_IDLE_HEIGHT = 15;
        public static int SMALL_MARIO_IDLE_OFFSET_X = 1;
        public static int SMALL_MARIO_IDLE_OFFSET_Y = 17;

        public static int SMALL_MARIO_JUMP_WIDTH = 14;
        public static int SMALL_MARIO_JUMP_HEIGHT = 15;
        public static int SMALL_MARIO_JUMP_OFFSET_X = 1;
        public static int SMALL_MARIO_JUMP_OFFSET_Y = 17;

        public static int SMALL_MARIO_SWIM_WIDTH = 14;
        public static int SMALL_MARIO_SWIM_HEIGHT = 15;
        public static int SMALL_MARIO_SWIM_OFFSET_X = 1;
        public static int SMALL_MARIO_SWIM_OFFSET_Y = 17;

        public static int SMALL_MARIO_RUN_WIDTH = 14;
        public static int SMALL_MARIO_RUN_HEIGHT = 15;
        public static int SMALL_MARIO_RUN_OFFSET_X = 1;
        public static int SMALL_MARIO_RUN_OFFSET_Y = 17;

        public static int SMALL_MARIO_CLIMBING_WIDTH = 14;
        public static int SMALL_MARIO_CLIMBING_HEIGHT = 15;
        public static int SMALL_MARIO_CLIMBING_OFFSET_X = 1;
        public static int SMALL_MARIO_CLIMBING_OFFSET_Y = 17;

        public static int BOWSERS_WIDTH = 32;
        public static int BOWSERS_HEIGHT = 32;
        public static int BOWSERS_FIREBALL_WIDTH = 24;
        public static int BOWSERS_FIREBALL_HEIGHT = 8;
        public static int BOWSERS_OFFSET_X = 0;
        public static int BOWSERS_OFFSET_Y = 0;

        public static int HAMMER_WIDTH = 15;
        public static int HAMMER_HEIGHT = 16;
    }
}
