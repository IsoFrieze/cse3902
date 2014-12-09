using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    // Home
    // of
    // the
    // Direly
    // Awful
    // Magic
    // Numbers

    public static class HotDAMN
    {
        public static float DISTANCE_FROM_PIRSNHA_PLANT = 30f;

        public static int WINDOW_WIDTH = 256;
        public static int WINDOW_HEIGHT = 240;
        public static int CAMERA_OFFSET_X = 0;
        public static int CAMERA_OFFSET_Y = 8;
        public static int GRID = 16;
        public static int SCREEN_MARIO_CUSION = 4;
        public static int SCREEN_BOUNDARY_OFFSET = 2000;

        public static int FULL_CIRCLE = 360;

        public static int INITIAL_LIVES_COUNT = 3;
        public static int INITIAL_WORLD_NUMBER = 1;
        public static int INITIAL_LEVEL_NUMBER = 1; 
        public static int TIME_UNTIL_HURRY_UP = 100;
        public static int MAX_FIREBALL_COUNT = 2;
        public static int MULTICOIN_BLOCK_MAXIMUM = 15;
        public static int OFFSCREEN_TOLERANCE = 8;
        public static int OFFSCREEN_LEVEL_LOAD_BLOCKS = 3;
        public static double COLLISION_RESOLUTION = 0.1;

        public static int FLAGPOLE_5000_HEIGHT = 8;
        public static int FLAGPOLE_2000_HEIGHT = 24;
        public static int FLAGPOLE_800_HEIGHT = 56;
        public static int FLAGPOLE_400_HEIGHT = 128;
        public static int FLAGPOLE_200_HEIGHT = 160;

        public static int FIREBAR_POS_UP = 90;
        public static int FIREBAR_POS_DOWN = 270;
        public static int FIREBAR_SPEED = 2;

        public static int BLOCKS_HAMMERBRO_JUMPS_UP = 5;
        public static int BLOCKS_HAMMERBRO_JUMPS_DOWN = 3;

        public static int TICKS_UNTIL_GAME_OVER_FINISH = 400;
        public static int TICKS_UNTIL_CASTLE_COMPLETE_FINISH = 400;
        public static int TICKS_UNTIL_TIMER_DECREMENTS = 25;
        public static int TICKS_UNTIL_LEVEL_COMPELTE_FANFARE = 160;
        public static int TICKS_UNTIL_LEVEL_TIMER_TALLIES = 250;
        public static int TICKS_UNTIL_NEXT_FIREWORK = 100;
        public static int TICKS_UNTIL_DEAD_ENEMY_REMOVE = 300;
        public static int TICKS_UNTIL_BUZZYBEETLE_AWAKES = 300;
        public static int TICKS_UNTIL_SWIMMING_CHEEPCHEEP_TURNS = 300;
        public static int TICKS_UNTIL_KOOPA_WARNING = 300;
        public static int TICKS_UNTIL_KOOPA_AWAKES = 400;
        public static int TICKS_UNTIL_SHELL_HURTS = 30;
        public static int TICKS_UNTIL_HAMMERBRO_TURNS = 100;
        public static int TICKS_UNTIL_PIRANHAPLANT_MOVES = 80;
        public static int TICKS_UNTIL_PIRANHAPLANT_STOPS = 24;
        public static int TICKS_UNTIL_POWERUP_APPEARS = 15;
        public static int TICKS_UNTIL_POWERUP_MOVES = 63;
        public static int TICKS_UNTIL_COIN_DISAPPEARS = 32;
        public static int TICKS_UNTIL_FLAG_STOPS = 128;
        public static int TICKS_UNTIL_SCORE_DISAPPEARS = 45;
        public static int TICKS_UNTIL_MOVING_PLATFORMS_CYCLE = 300;
        public static int TICKS_UNTIL_MARIO_CLIMBING_TURNS = 20;
        public static int TICKS_UNTIL_MARIO_DEAD_MOVES = 30;
        public static int TICKS_UNTIL_MARIO_TRANSITIONS = 45;
        public static int TICKS_UNTIL_MULTICOIN_BLOCK_EXPIRES = 275;
        public static int TICKS_UNTIL_MARIO_BLINKING_EXPIRES = 100;
        public static int TICKS_UNTIL_STAR_POWER_EXPIRES = 800;
        public static int TICKS_UNTIL_STAR_SONG_STOPS = 700;
        public static int TICKS_UNTIL_BOWSER_DEAD_MOVES = 30;
        public static int TICKS_UNTIL_BOWSERS_FIREBALL_DISAPPEARS = 150;
        public static int TICKS_UNTIL_BOWSERS_GOES_BACK_TO_MOVING = 50;
        public static int TICKS_UNTIL_BLASTER_SHOOTS = 150;
        public static int TICKS_UNTIL_HAMMER_DISAPPEARS = 100;

        public static int SCORE_BREAK_BRICK = 50;
        public static int SCORE_BREAK_SCALE_PLATFORMS = 1000;
        public static int SCORE_COLLECT_COIN = 200;
        public static int SCORE_COLLECT_MUSHROOM = 1000;
        public static int SCORE_COLLECT_FIREFLOWER = 1000;
        public static int SCORE_COLLECT_STAR = 1000;
        public static int SCORE_COLLECT_FIREWORK = 500;
        public static int SCORE_KICK_BUZZYBEETLE = 400;
        public static int SCORE_KILL_BUZZYBEETLE = 200;
        public static int SCORE_BUMP_BUZZYBEETLE = 100;
        public static int SCORE_DEWING_KOOPA = 400;
        public static int SCORE_KICK_KOOPA = 200;
        public static int SCORE_KILL_KOOPA = 200;
        public static int SCORE_BUMP_KOOPA = 100;
        public static int SCORE_KILL_HAMMERBRO = 1000;
        public static int SCORE_BUMP_HAMMERBRO = 1000;
        public static int SCORE_KILL_LAKITU = 800;
        public static int SCORE_KILL_SPINY = 200;
        public static int SCORE_KILL_GOOMBA = 100;
        public static int SCORE_BUMP_GOOMBA = 100;
        public static int SCORE_KILL_PIRANHAPLANT = 200;
        public static int SCORE_KILL_CHEEPCHEEP = 200;
        public static int SCORE_KILL_BULLETBILL = 200;
        public static int SCORE_KILL_BLOOPER = 200;
        public static int SCORE_KILL_BOWSER = 5000;

        public static String TEXT_EMPTY_STRING = "";
        public static String TEXT_WORLD = "WORLD ";
        public static String TEXT_X = "x ";
        public static String TEXT_GAME_OVER = "GAME OVER";
        public static String TAB = "    ";
        public static String TEXT_TITLE_SCREEN_SELECTIONS = TAB + "1 PLAYER GAME\n" + TAB + "2 PLAYER GAME\n" + TAB + "WARP ZONE";
        public static String TEXT_WARP_ZONE_SELECTIONS = TAB + "1-1" + TAB + TAB + "1-2" + TAB + TAB + "1-3" + TAB + TAB + "1-4\n" +
                                                            TAB + "2-1" + TAB + TAB + "2-2" + TAB + TAB + "2-3" + TAB + TAB + "2-4\n" +
                                                            TAB + "3-1" + TAB + TAB + "3-2" + TAB + TAB + "3-3" + TAB + TAB + "3-4\n" +
                                                            TAB + "4-1" + TAB + TAB + "4-2" + TAB + TAB + "4-3" + TAB + TAB + "4-4\n" +
                                                            TAB + "5-1" + TAB + TAB + "5-2" + TAB + TAB + "5-3" + TAB + TAB + "5-4\n" +
                                                            TAB + "6-1" + TAB + TAB + "6-2" + TAB + TAB + "6-3" + TAB + TAB + "6-4\n" +
                                                            TAB + "7-1" + TAB + TAB + "7-2" + TAB + TAB + "7-3" + TAB + TAB + "7-4\n" +
                                                            TAB + "8-1" + TAB + TAB + "8-2" + TAB + TAB + "8-3" + TAB + TAB + "8-4";


        public static char TAG_SUBLEVEL = '@';
        public static char TAG_NAME = '#';
    }
}
