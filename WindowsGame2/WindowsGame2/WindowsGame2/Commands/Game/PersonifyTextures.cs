using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class PersonifyTextures : ITechnicalCommand
    {
        Game1 game;

        public PersonifyTextures()
        {
        }

        public void Execute()
        {
            Random random = new Random();

            // David is powerup
            Textures.powerup1up = Textures.david[0];
            Textures.powerupMushroom = Textures.david[0];
            Textures.powerupStar = Textures.david[1];
            Textures.powerupFireFlower = Textures.david[2];
            Textures.powerupCoin = Textures.david[3];
            Textures.powerupCoinSpinning = Textures.david[4];

            // Alex is block
            Textures.blockQuestion = Textures.alex[0];
            Textures.blockBrick = Textures.alex[1];
            Textures.blockHidden = Textures.alex[2];
            Textures.blockStair = Textures.alex[3];
            Textures.blockUsed = Textures.alex[4];

            // Dan is goomba
            Textures.goombaWalking = Textures.dan[0];
            Textures.goombaStomped = Textures.dan[1];
            Textures.goombaDead = Textures.dan[2];
            Textures.piranhaPlantGreen = Textures.dan[3];
            Textures.blockPipe = Textures.dan[4];

            // Mike is koopa
            Textures.koopaLeftWalking = Textures.mike[0];
            Textures.koopaRightWalking = Textures.mike[0];
            Textures.koopaInShell = Textures.mike[1];
            Textures.koopaWarning = Textures.mike[2];
            Textures.koopaDead = Textures.mike[1];
            Textures.koopaInShellUpsideDown = Textures.mike[3];
            Textures.koopaWarningUpsideDown = Textures.mike[2];
            Textures.koopaBouncingLeft = Textures.mike[4];
            Textures.koopaBouncingRight = Textures.mike[4];

            // Christian is background
            Textures.largeBush = Textures.christian[0];
            Textures.mediumBush = Textures.christian[0];
            Textures.smallBush = Textures.christian[0];
            Textures.largeCloud = Textures.christian[1];
            Textures.mediumCloud = Textures.christian[1];
            Textures.smallCloud = Textures.christian[1];
            Textures.bigTree = Textures.christian[2];
            Textures.smallTree = Textures.christian[2];
            Textures.fence = Textures.christian[3];
            Textures.bigHill = Textures.christian[4];
            Textures.smallHill = Textures.christian[4];

            // Matt is bowser
            Textures.bowserDeadLeft = Textures.matt[1];
            Textures.bowserDeadRight = Textures.matt[2];
            Textures.bowserMovingLeft = Textures.matt[0];
            Textures.bowserMovingRight = Textures.matt[0];
            Textures.bowserShootingFireLeft = Textures.matt[0];
            Textures.hammer = Textures.matt[2];
            Textures.blockAxe = Textures.matt[3];
        }
    }
}
