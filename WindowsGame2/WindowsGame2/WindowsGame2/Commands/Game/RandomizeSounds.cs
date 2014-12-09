using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class RandomizeSounds : ITechnicalCommand
    {
        public RandomizeSounds()
        {
        }

        public void Execute()
        {
            var list1 = new List<Song>()
            {
                Sound.mainTheme,
                Sound.underworldTheme,
                Sound.underwaterTheme,
                Sound.castleTheme,
                Sound.starmanTheme,
                Sound.levelcompleteTheme,
                Sound.deadTheme,
                Sound.gameover1Theme,
                Sound.gameover2Theme,
                Sound.tunnelTheme,
                Sound.endingTheme,
                Sound.hurryTheme,
                Sound.hurryundergroundTheme,
                Sound.hurryunderwaterTheme,
                Sound.hurrycastleTheme,
                Sound.hurrystarmanTheme,
                Sound.hurryoverworldTheme,
                Sound.silence,
                Sound.castleComplete,
                
                Sound.random04,
                Sound.random05,
                Sound.random06
            };
            
            var list2 = new List<SoundEffect>()
            {
                Sound.powerup1upEffect,
                Sound.bowserfallEffect,
                Sound.bowerfireEffect,
                Sound.breakblockEffect,
                Sound.bumpEffect,
                Sound.coinEffect,
                Sound.fireballEffect,
                Sound.fireworksEffect,
                Sound.flagpoleEffect,
                Sound.gameoverEffect,
                Sound.jumpsmallEffect,
                Sound.jumpsuperEffect,
                Sound.kickEffect,
                Sound.mariodieEffect,
                Sound.pauseEffect,
                Sound.pipeEffect,
                Sound.powerupEffect,
                Sound.powerupappearsEffect,
                Sound.scoreEffect,
                Sound.stageclearEffect,
                Sound.stompEffect,
                Sound.swimEffect,
                Sound.vineEffect,
                Sound.warningEffect,
                Sound.worldclearEffect,
                
                Sound.randomfx01,
                Sound.randomfx02,
                Sound.randomfx03,
                Sound.randomfx04
            };

            Random random = new Random();

            Sound.mainTheme = list1[random.Next(0, list1.Count())];
            Sound.underworldTheme = list1[random.Next(0, list1.Count())];
            Sound.underwaterTheme = list1[random.Next(0, list1.Count())];
            Sound.castleTheme = list1[random.Next(0, list1.Count())];
            Sound.starmanTheme = list1[random.Next(0, list1.Count())];
            Sound.levelcompleteTheme = list1[random.Next(0, list1.Count())];
            Sound.deadTheme = list1[random.Next(0, list1.Count())];
            Sound.gameover1Theme = list1[random.Next(0, list1.Count())];
            Sound.gameover2Theme = list1[random.Next(0, list1.Count())];
            Sound.tunnelTheme = list1[random.Next(0, list1.Count())];
            Sound.endingTheme = list1[random.Next(0, list1.Count())];
            Sound.hurryTheme = list1[random.Next(0, list1.Count())];
            Sound.hurryundergroundTheme = list1[random.Next(0, list1.Count())];
            Sound.hurryunderwaterTheme = list1[random.Next(0, list1.Count())];
            Sound.hurrycastleTheme = list1[random.Next(0, list1.Count())];
            Sound.hurrystarmanTheme = list1[random.Next(0, list1.Count())];
            Sound.hurryoverworldTheme = list1[random.Next(0, list1.Count())];
            Sound.silence = list1[random.Next(0, list1.Count())];
            Sound.castleComplete = list1[random.Next(0, list1.Count())];

            Sound.powerup1upEffect = list2[random.Next(0, list2.Count())];
            Sound.bowserfallEffect = list2[random.Next(0, list2.Count())];
            Sound.bowerfireEffect = list2[random.Next(0, list2.Count())];
            Sound.breakblockEffect = list2[random.Next(0, list2.Count())];
            Sound.bumpEffect = list2[random.Next(0, list2.Count())];
            Sound.coinEffect = list2[random.Next(0, list2.Count())];
            Sound.fireballEffect = list2[random.Next(0, list2.Count())];
            Sound.fireworksEffect = list2[random.Next(0, list2.Count())];
            Sound.flagpoleEffect = list2[random.Next(0, list2.Count())];
            Sound.gameoverEffect = list2[random.Next(0, list2.Count())];
            Sound.jumpsmallEffect = list2[random.Next(0, list2.Count())];
            Sound.jumpsuperEffect = list2[random.Next(0, list2.Count())];
            Sound.kickEffect = list2[random.Next(0, list2.Count())];
            Sound.mariodieEffect = list2[random.Next(0, list2.Count())];
            Sound.pauseEffect = list2[random.Next(0, list2.Count())];
            Sound.pipeEffect = list2[random.Next(0, list2.Count())];
            Sound.powerupEffect = list2[random.Next(0, list2.Count())];
            Sound.powerupappearsEffect = list2[random.Next(0, list2.Count())];
            Sound.scoreEffect = list2[random.Next(0, list2.Count())];
            Sound.stageclearEffect = list2[random.Next(0, list2.Count())];
            Sound.stompEffect = list2[random.Next(0, list2.Count())];
            Sound.swimEffect = list2[random.Next(0, list2.Count())];
            Sound.vineEffect = list2[random.Next(0, list2.Count())];
            Sound.warningEffect = list2[random.Next(0, list2.Count())];
            Sound.worldclearEffect = list2[random.Next(0, list2.Count())];
        }
    }
}
