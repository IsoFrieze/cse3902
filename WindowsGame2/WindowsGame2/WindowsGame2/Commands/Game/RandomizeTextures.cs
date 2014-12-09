using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class RandomizeTextures : ITechnicalCommand
    {
        public RandomizeTextures()
        {
        }

        public void Execute()
        {
            var list = new List<Texture2D>()
            {
                Textures.powerup1up,
                Textures.powerupMushroom,
                Textures.powerupStar,
                Textures.powerupFireFlower,
                Textures.powerupCoin,
                Textures.powerupCoinSpinning,

                Textures.miniCoin,
                Textures.titleCard,

                Textures.blockQuestion,
                Textures.blockBrick,
                Textures.blockHidden,
                Textures.blockStair,
                Textures.blockUsed,
                Textures.blockFloor,
                Textures.blockPipe,
                Textures.blockPipeSideways,
                Textures.blockAxe,
                Textures.blockBillBlaster,
                Textures.blockBridge,
                Textures.blockBowserBridge,

                Textures.grassLedge,
                Textures.mushroomLedge,
                Textures.platform,

                Textures.springboardIdle,
                Textures.springboardCompressing,
                Textures.springboardRelaxing,

                Textures.water,

                Textures.flagpolePole,
                Textures.flagpoleFlag,

                Textures.vine,

                Textures.goombaWalking,
                Textures.goombaStomped,
                Textures.goombaDead,

                Textures.koopaLeftWalking,
                Textures.koopaRightWalking,
                Textures.koopaInShell,
                Textures.koopaWarning,
                Textures.koopaDead,
                Textures.koopaInShellUpsideDown,
                Textures.koopaWarningUpsideDown,
                Textures.koopaBouncingLeft,
                Textures.koopaBouncingRight,

                Textures.redKoopaLeftWalking,
                Textures.redKoopaRightWalking,
                Textures.redKoopaInShell,
                Textures.redKoopaWarning,
                Textures.redKoopaInShellUpsideDown,
                Textures.redKoopaWarningUpsideDown,
                Textures.redParaKoopaLeft,
                Textures.redParaKoopaRight,

                Textures.piranhaPlantGreen,
                Textures.piranhaPlantRed,

                Textures.hammerBroWalking,
                Textures.hammerBroDead,

                Textures.podobooUp,
                Textures.podobooDown,

                Textures.bowserMovingLeft,
                Textures.bowserMovingRight,
                Textures.bowserShootingFireLeft,
                Textures.bowserFireballLeft,
                Textures.World1Death,
                Textures.World2Death,
                Textures.World3Death,
                Textures.World4Death,
                Textures.World5Death,
                Textures.World6Death,
                Textures.World7Death,
                Textures.bowserDeadLeft,
                Textures.bowserDeadRight,

                Textures.hammer,

                Textures.bulletBillLeft,
                Textures.bulletBillRight,

                Textures.buzzyBeetleLeftWalking,
                Textures.buzzyBeetleRightWalking,
                Textures.buzzyBeetleInShell,
                Textures.buzzyBeetleInShellUpsideDown,

                Textures.cheepCheepRedLeft,
                Textures.cheepCheepRedRight,
                Textures.cheepCheepGrayLeft,
                Textures.cheepCheepGrayRight,
                Textures.cheepCheepRedDeadLeft,
                Textures.cheepCheepGrayDeadLeft,

                Textures.blooperSwimming,
                Textures.blooperIdle,
                Textures.blooperDead,

                Textures.lakituLeft,
                Textures.lakituRight,
                Textures.lakituInCloud,
                Textures.lakituDead,

                Textures.spinyLeft,
                Textures.spinyRight,
                Textures.spinyDeadRight,
                Textures.spinyDeadLeft,
                Textures.spinyInEgg,

                Textures.projectileFireball,

                Textures.largeCloud,
                Textures.mediumCloud,
                Textures.smallCloud,
                Textures.largeBush,
                Textures.mediumBush,
                Textures.smallBush,
                Textures.bigHill,
                Textures.smallHill,
                Textures.bigTree,
                Textures.smallTree,
                Textures.fence,
                Textures.castleBig,
                Textures.castleSmall,
                Textures.castleFlag,
                Textures.castleWall,

                Textures.toad,
                Textures.princess,

                Textures.particle1up,
                Textures.particleBricks,
                Textures.particleBubble,
                Textures.particleExplosion,
                Textures.particleScore100,
                Textures.particleScore200,
                Textures.particleScore400,
                Textures.particleScore500,
                Textures.particleScore800,
                Textures.particleScore1000,
                Textures.particleScore2000,
                Textures.particleScore4000,
                Textures.particleScore5000,
                Textures.particleScore8000,
            };

            Random random = new Random();

            Textures.powerup1up = list[random.Next(0, list.Count())];
                Textures.powerupMushroom = list[random.Next(0, list.Count())];
                Textures.powerupStar = list[random.Next(0, list.Count())];
                Textures.powerupFireFlower = list[random.Next(0, list.Count())];
                Textures.powerupCoin = list[random.Next(0, list.Count())];
                Textures.powerupCoinSpinning = list[random.Next(0, list.Count())];

                Textures.miniCoin = list[random.Next(0, list.Count())];
                Textures.titleCard = list[random.Next(0, list.Count())];

                Textures.blockQuestion = list[random.Next(0, list.Count())];
                Textures.blockBrick = list[random.Next(0, list.Count())];
                Textures.blockHidden = list[random.Next(0, list.Count())];
                Textures.blockStair = list[random.Next(0, list.Count())];
                Textures.blockUsed = list[random.Next(0, list.Count())];
                Textures.blockFloor = list[random.Next(0, list.Count())];
                Textures.blockPipe = list[random.Next(0, list.Count())];
                Textures.blockPipeSideways = list[random.Next(0, list.Count())];
                Textures.blockAxe = list[random.Next(0, list.Count())];
                Textures.blockBillBlaster = list[random.Next(0, list.Count())];
                Textures.blockBridge = list[random.Next(0, list.Count())];
                Textures.blockBowserBridge = list[random.Next(0, list.Count())];

                Textures.grassLedge = list[random.Next(0, list.Count())];
                Textures.mushroomLedge = list[random.Next(0, list.Count())];
                Textures.platform = list[random.Next(0, list.Count())];

                Textures.springboardIdle = list[random.Next(0, list.Count())];
                Textures.springboardCompressing = list[random.Next(0, list.Count())];
                Textures.springboardRelaxing = list[random.Next(0, list.Count())];

                Textures.water = list[random.Next(0, list.Count())];

                Textures.flagpolePole = list[random.Next(0, list.Count())];
                Textures.flagpoleFlag = list[random.Next(0, list.Count())];

                Textures.vine = list[random.Next(0, list.Count())];

                Textures.goombaWalking = list[random.Next(0, list.Count())];
                Textures.goombaStomped = list[random.Next(0, list.Count())];
                Textures.goombaDead = list[random.Next(0, list.Count())];

                Textures.koopaLeftWalking = list[random.Next(0, list.Count())];
                Textures.koopaRightWalking = list[random.Next(0, list.Count())];
                Textures.koopaInShell = list[random.Next(0, list.Count())];
                Textures.koopaWarning = list[random.Next(0, list.Count())];
                Textures.koopaDead = list[random.Next(0, list.Count())];
                Textures.koopaInShellUpsideDown = list[random.Next(0, list.Count())];
                Textures.koopaWarningUpsideDown = list[random.Next(0, list.Count())];
                Textures.koopaBouncingLeft = list[random.Next(0, list.Count())];
                Textures.koopaBouncingRight = list[random.Next(0, list.Count())];

                Textures.redKoopaLeftWalking = list[random.Next(0, list.Count())];
                Textures.redKoopaRightWalking = list[random.Next(0, list.Count())];
                Textures.redKoopaInShell = list[random.Next(0, list.Count())];
                Textures.redKoopaWarning = list[random.Next(0, list.Count())];
                Textures.redKoopaInShellUpsideDown = list[random.Next(0, list.Count())];
                Textures.redKoopaWarningUpsideDown = list[random.Next(0, list.Count())];
                Textures.redParaKoopaLeft = list[random.Next(0, list.Count())];
                Textures.redParaKoopaRight = list[random.Next(0, list.Count())];

                Textures.piranhaPlantGreen = list[random.Next(0, list.Count())];
                Textures.piranhaPlantRed = list[random.Next(0, list.Count())];

                Textures.hammerBroWalking = list[random.Next(0, list.Count())];
                Textures.hammerBroDead = list[random.Next(0, list.Count())];

                Textures.podobooUp = list[random.Next(0, list.Count())];
                Textures.podobooDown = list[random.Next(0, list.Count())];

                Textures.bowserMovingLeft = list[random.Next(0, list.Count())];
                Textures.bowserMovingRight = list[random.Next(0, list.Count())];
                Textures.bowserShootingFireLeft = list[random.Next(0, list.Count())];
                Textures.bowserFireballLeft = list[random.Next(0, list.Count())];
                Textures.World1Death = list[random.Next(0, list.Count())];
                Textures.World2Death = list[random.Next(0, list.Count())];
                Textures.World3Death = list[random.Next(0, list.Count())];
                Textures.World4Death = list[random.Next(0, list.Count())];
                Textures.World5Death = list[random.Next(0, list.Count())];
                Textures.World6Death = list[random.Next(0, list.Count())];
                Textures.World7Death = list[random.Next(0, list.Count())];
                Textures.bowserDeadLeft = list[random.Next(0, list.Count())];
                Textures.bowserDeadRight = list[random.Next(0, list.Count())];

                Textures.hammer = list[random.Next(0, list.Count())];

                Textures.bulletBillLeft = list[random.Next(0, list.Count())];
                Textures.bulletBillRight = list[random.Next(0, list.Count())];

                Textures.buzzyBeetleLeftWalking = list[random.Next(0, list.Count())];
                Textures.buzzyBeetleRightWalking = list[random.Next(0, list.Count())];
                Textures.buzzyBeetleInShell = list[random.Next(0, list.Count())];
                Textures.buzzyBeetleInShellUpsideDown = list[random.Next(0, list.Count())];

                Textures.cheepCheepRedLeft = list[random.Next(0, list.Count())];
                Textures.cheepCheepRedRight = list[random.Next(0, list.Count())];
                Textures.cheepCheepGrayLeft = list[random.Next(0, list.Count())];
                Textures.cheepCheepGrayRight = list[random.Next(0, list.Count())];
                Textures.cheepCheepRedDeadLeft = list[random.Next(0, list.Count())];
                Textures.cheepCheepGrayDeadLeft = list[random.Next(0, list.Count())];

                Textures.blooperSwimming = list[random.Next(0, list.Count())];
                Textures.blooperIdle = list[random.Next(0, list.Count())];
                Textures.blooperDead = list[random.Next(0, list.Count())];

                Textures.lakituLeft = list[random.Next(0, list.Count())];
                Textures.lakituRight = list[random.Next(0, list.Count())];
                Textures.lakituInCloud = list[random.Next(0, list.Count())];
                Textures.lakituDead = list[random.Next(0, list.Count())];

                Textures.spinyLeft = list[random.Next(0, list.Count())];
                Textures.spinyRight = list[random.Next(0, list.Count())];
                Textures.spinyDeadRight = list[random.Next(0, list.Count())];
                Textures.spinyDeadLeft = list[random.Next(0, list.Count())];
                Textures.spinyInEgg = list[random.Next(0, list.Count())];

                Textures.projectileFireball = list[random.Next(0, list.Count())];

                Textures.largeCloud = list[random.Next(0, list.Count())];
                Textures.mediumCloud = list[random.Next(0, list.Count())];
                Textures.smallCloud = list[random.Next(0, list.Count())];
                Textures.largeBush = list[random.Next(0, list.Count())];
                Textures.mediumBush = list[random.Next(0, list.Count())];
                Textures.smallBush = list[random.Next(0, list.Count())];
                Textures.bigHill = list[random.Next(0, list.Count())];
                Textures.smallHill = list[random.Next(0, list.Count())];
                Textures.bigTree = list[random.Next(0, list.Count())];
                Textures.smallTree = list[random.Next(0, list.Count())];
                Textures.fence = list[random.Next(0, list.Count())];
                Textures.castleBig = list[random.Next(0, list.Count())];
                Textures.castleSmall = list[random.Next(0, list.Count())];
                Textures.castleFlag = list[random.Next(0, list.Count())];
                Textures.castleWall = list[random.Next(0, list.Count())];

                Textures.toad = list[random.Next(0, list.Count())];
                Textures.princess = list[random.Next(0, list.Count())];

                Textures.particle1up = list[random.Next(0, list.Count())];
                Textures.particleBricks = list[random.Next(0, list.Count())];
                Textures.particleBubble = list[random.Next(0, list.Count())];
                Textures.particleExplosion = list[random.Next(0, list.Count())];
                Textures.particleScore100 = list[random.Next(0, list.Count())];
                Textures.particleScore200 = list[random.Next(0, list.Count())];
                Textures.particleScore400 = list[random.Next(0, list.Count())];
                Textures.particleScore500 = list[random.Next(0, list.Count())];
                Textures.particleScore800 = list[random.Next(0, list.Count())];
                Textures.particleScore1000 = list[random.Next(0, list.Count())];
                Textures.particleScore2000 = list[random.Next(0, list.Count())];
                Textures.particleScore4000 = list[random.Next(0, list.Count())];
                Textures.particleScore5000 = list[random.Next(0, list.Count())];
                Textures.particleScore8000 = list[random.Next(0, list.Count())];
        }
    }
}
