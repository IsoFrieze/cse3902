using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2
{
    public static class Sound
    {
        //Music variables
        public static Song mainTheme;

        public static Song underworldTheme;
        public static Song underwaterTheme;
        public static Song castleTheme;
        public static Song starmanTheme;
        public static Song levelcompleteTheme;
        public static Song deadTheme;
        public static Song gameover1Theme;
        public static Song gameover2Theme;
        public static Song tunnelTheme;
        public static Song endingTheme;
        public static Song hurryTheme;
        public static Song hurryundergroundTheme;
        public static Song hurryunderwaterTheme;
        public static Song hurrycastleTheme;
        public static Song hurrystarmanTheme;
        public static Song hurryoverworldTheme;
        public static Song silence;
        public static Song castleComplete;

        public static Song random04;
        public static Song random05;
        public static Song random06;

        //Effect variables

        public static SoundEffect powerup1upEffect;
        public static SoundEffect bowserfallEffect;
        public static SoundEffect bowerfireEffect;
        public static SoundEffect breakblockEffect;
        public static SoundEffect bumpEffect;
        public static SoundEffect coinEffect;
        public static SoundEffect fireballEffect;
        public static SoundEffect fireworksEffect;
        public static SoundEffect flagpoleEffect;
        public static SoundEffect gameoverEffect;
        public static SoundEffect jumpsmallEffect;
        public static SoundEffect jumpsuperEffect;
        public static SoundEffect kickEffect;
        public static SoundEffect mariodieEffect;
        public static SoundEffect pauseEffect;
        public static SoundEffect pipeEffect;
        public static SoundEffect powerupEffect;
        public static SoundEffect powerupappearsEffect;
        public static SoundEffect scoreEffect;
        public static SoundEffect stageclearEffect;
        public static SoundEffect stompEffect;
        public static SoundEffect swimEffect;
        public static SoundEffect vineEffect;
        public static SoundEffect warningEffect;
        public static SoundEffect worldclearEffect;

        public static SoundEffect randomfx01;
        public static SoundEffect randomfx02;
        public static SoundEffect randomfx03;
        public static SoundEffect randomfx04;

        public static void InitializeSounds(ContentManager Content)
        {
            LoadSounds(Content);
        }

        public static void LoadSounds(ContentManager Content)
        {
            //Music Initialize
            mainTheme = Content.Load<Song>("Audio/Music/main-theme-overworld");
            underworldTheme = Content.Load<Song>("Audio/Music/underworld");
            underwaterTheme = Content.Load<Song>("Audio/Music/underwater");
            castleTheme = Content.Load<Song>("Audio/Music/castle");
            starmanTheme = Content.Load<Song>("Audio/Music/starman");
            levelcompleteTheme = Content.Load<Song>("Audio/Music/level-complete");
            deadTheme = Content.Load<Song>("Audio/Music/you-re-dead");
            gameover1Theme = Content.Load<Song>("Audio/Music/game-over");
            gameover2Theme = Content.Load<Song>("Audio/Music/game-over-2");
            tunnelTheme = Content.Load<Song>("Audio/Music/into-the-tunnel");
            endingTheme = Content.Load<Song>("Audio/Music/ending");
            hurryTheme = Content.Load<Song>("Audio/Music/hurry");
            hurryundergroundTheme = Content.Load<Song>("Audio/Music/hurry-underground");
            hurryunderwaterTheme = Content.Load<Song>("Audio/Music/hurry-underwater");
            hurrycastleTheme = Content.Load<Song>("Audio/Music/hurry-castle");
            hurrystarmanTheme = Content.Load<Song>("Audio/Music/hurry-starman");
            hurryoverworldTheme = Content.Load<Song>("Audio/Music/hurry-overworld");
            silence = Content.Load<Song>("Audio/Music/nothing");
            castleComplete = Content.Load<Song>("Audio/Music/world_clear");

            random04 = Content.Load<Song>("Audio/Random/random04");
            random05 = Content.Load<Song>("Audio/Random/random05");
            random06 = Content.Load<Song>("Audio/Random/random06");


            //Effect Initialize
            powerup1upEffect = Content.Load<SoundEffect>("Audio/Effects/1-up");
            bowserfallEffect = Content.Load<SoundEffect>("Audio/Effects/bowserfall");
            bowerfireEffect = Content.Load<SoundEffect>("Audio/Effects/bowserfire");
            breakblockEffect = Content.Load<SoundEffect>("Audio/Effects/breakblock");
            bumpEffect = Content.Load<SoundEffect>("Audio/Effects/bump");
            coinEffect = Content.Load<SoundEffect>("Audio/Effects/coin");
            fireballEffect = Content.Load<SoundEffect>("Audio/Effects/fireball");
            fireworksEffect = Content.Load<SoundEffect>("Audio/Effects/fireworks");
            flagpoleEffect = Content.Load<SoundEffect>("Audio/Effects/flagpole");
            gameoverEffect = Content.Load<SoundEffect>("Audio/Effects/gameover");
            jumpsmallEffect = Content.Load<SoundEffect>("Audio/Effects/jumpsmall");
            jumpsuperEffect = Content.Load<SoundEffect>("Audio/Effects/jump-super");
            kickEffect = Content.Load<SoundEffect>("Audio/Effects/kick");
            mariodieEffect = Content.Load<SoundEffect>("Audio/Effects/mariodie");
            pauseEffect = Content.Load<SoundEffect>("Audio/Effects/pause");
            pipeEffect = Content.Load<SoundEffect>("Audio/Effects/pipe");
            powerupEffect = Content.Load<SoundEffect>("Audio/Effects/powerup");
            powerupappearsEffect = Content.Load<SoundEffect>("Audio/Effects/powerup_appears");
            scoreEffect = Content.Load<SoundEffect>("Audio/Effects/score");
            stageclearEffect = Content.Load<SoundEffect>("Audio/Effects/stage_clear");
            stompEffect = Content.Load<SoundEffect>("Audio/Effects/stomp");
            swimEffect = Content.Load<SoundEffect>("Audio/Effects/stomp");
            vineEffect = Content.Load<SoundEffect>("Audio/Effects/vine");
            warningEffect = Content.Load<SoundEffect>("Audio/Effects/warning");
            worldclearEffect = Content.Load<SoundEffect>("Audio/Effects/world_clear");

            randomfx01 = Content.Load<SoundEffect>("Audio/Random/randomfx01");
            randomfx02 = Content.Load<SoundEffect>("Audio/Random/randomfx02");
            randomfx03 = Content.Load<SoundEffect>("Audio/Random/randomfx03");
            randomfx04 = Content.Load<SoundEffect>("Audio/Random/randomfx04");
        }

    }
}
