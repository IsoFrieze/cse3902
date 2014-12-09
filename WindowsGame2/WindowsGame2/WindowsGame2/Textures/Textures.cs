using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2
{
    public static class Textures
    {
        public const int CLIMBING_FRAME_TIME = 10;
        public const int WALKING_FRAME_TIME = 3;
        public const int RUNNING_FRAME_TIME = 2;
        public const int SWIMMING_FRAME_TIME = 3;
        public const int TRANSITION_FRAME_TIME = 5;

        public static Texture2D powerup1up;
        public static Texture2D powerupMushroom;
        public static Texture2D powerupStar;
        public static Texture2D powerupFireFlower;
        public static Texture2D powerupCoin;
        public static Texture2D powerupCoinSpinning;

        public static Texture2D miniCoin;
        public static Texture2D titleCard;

        public static Texture2D blockQuestion;
        public static Texture2D blockBrick;
        public static Texture2D blockHidden;
        public static Texture2D blockStair;
        public static Texture2D blockUsed;
        public static Texture2D blockFloor;
        public static Texture2D blockPipe;
        public static Texture2D blockPipeSideways;
        public static Texture2D blockAxe;
        public static Texture2D blockBillBlaster;
        public static Texture2D blockBridge;
        public static Texture2D blockBowserBridge;

        public static Texture2D grassLedge;
        public static Texture2D mushroomLedge;
        public static Texture2D platform;

        public static Texture2D springboardIdle;
        public static Texture2D springboardCompressing;
        public static Texture2D springboardRelaxing;

        public static Texture2D water;

        public static Texture2D flagpolePole;
        public static Texture2D flagpoleFlag;

        public static Texture2D vine;

        public static Texture2D goombaWalking;
        public static Texture2D goombaStomped;
        public static Texture2D goombaDead;

        public static Texture2D koopaLeftWalking;
        public static Texture2D koopaRightWalking;
        public static Texture2D koopaInShell;
        public static Texture2D koopaWarning;
        public static Texture2D koopaDead;
        public static Texture2D koopaInShellUpsideDown;
        public static Texture2D koopaWarningUpsideDown;
        public static Texture2D koopaBouncingLeft;
        public static Texture2D koopaBouncingRight;

        public static Texture2D redKoopaLeftWalking;
        public static Texture2D redKoopaRightWalking;
        public static Texture2D redKoopaInShell;
        public static Texture2D redKoopaWarning;
        public static Texture2D redKoopaInShellUpsideDown;
        public static Texture2D redKoopaWarningUpsideDown;
        public static Texture2D redParaKoopaLeft;
        public static Texture2D redParaKoopaRight;

        public static Texture2D piranhaPlantGreen;
        public static Texture2D piranhaPlantRed;

        public static Texture2D hammerBroWalking;
        public static Texture2D hammerBroDead;

        public static Texture2D podobooUp;
        public static Texture2D podobooDown;

        public static Texture2D bowserMovingLeft;
        public static Texture2D bowserMovingRight;
        public static Texture2D bowserShootingFireLeft;
        public static Texture2D bowserFireballLeft;
        public static Texture2D World1Death;
        public static Texture2D World2Death;
        public static Texture2D World3Death;
        public static Texture2D World4Death;
        public static Texture2D World5Death;
        public static Texture2D World6Death;
        public static Texture2D World7Death;
        public static Texture2D bowserDeadLeft;
        public static Texture2D bowserDeadRight;

        public static Texture2D hammer;

        public static Texture2D bulletBillLeft;
        public static Texture2D bulletBillRight;

        public static Texture2D buzzyBeetleLeftWalking;
        public static Texture2D buzzyBeetleRightWalking;
        public static Texture2D buzzyBeetleInShell;
        public static Texture2D buzzyBeetleInShellUpsideDown;

        public static Texture2D cheepCheepRedLeft;
        public static Texture2D cheepCheepRedRight;
        public static Texture2D cheepCheepGrayLeft;
        public static Texture2D cheepCheepGrayRight;
        public static Texture2D cheepCheepRedDeadLeft;
        public static Texture2D cheepCheepGrayDeadLeft;

        public static Texture2D blooperSwimming;
        public static Texture2D blooperIdle;
        public static Texture2D blooperDead;

        public static Texture2D lakituLeft;
        public static Texture2D lakituRight;
        public static Texture2D lakituInCloud;
        public static Texture2D lakituDead;

        public static Texture2D spinyLeft;
        public static Texture2D spinyRight;
        public static Texture2D spinyDeadRight;
        public static Texture2D spinyDeadLeft;
        public static Texture2D spinyInEgg;

        public static Texture2D projectileFireball;

        public static Texture2D largeCloud;
        public static Texture2D mediumCloud;
        public static Texture2D smallCloud;
        public static Texture2D largeBush;
        public static Texture2D mediumBush;
        public static Texture2D smallBush;
        public static Texture2D bigHill;
        public static Texture2D smallHill;
        public static Texture2D bigTree;
        public static Texture2D smallTree;
        public static Texture2D fence;
        public static Texture2D castleBig;
        public static Texture2D castleSmall;
        public static Texture2D castleFlag;
        public static Texture2D castleWall;

        public static Texture2D toad;
        public static Texture2D princess;

        public static Texture2D particle1up;
        public static Texture2D particleBricks;
        public static Texture2D particleBubble;
        public static Texture2D particleExplosion;
        public static Texture2D particleScore100;
        public static Texture2D particleScore200;
        public static Texture2D particleScore400;
        public static Texture2D particleScore500;
        public static Texture2D particleScore800;
        public static Texture2D particleScore1000;
        public static Texture2D particleScore2000;
        public static Texture2D particleScore4000;
        public static Texture2D particleScore5000;
        public static Texture2D particleScore8000;

        public static TextureMap smallRightClimbing;
        public static TextureMap smallRightClimbingIdle;
        public static TextureMap smallRightSwimming;
        public static TextureMap smallRightSwimmingIdle;
        public static TextureMap smallRightIdle;
        public static TextureMap smallRightWalking;
        public static TextureMap smallRightRunning;
        public static TextureMap smallRightTurning;
        public static TextureMap smallRightJumping;
        public static TextureMap smallDead;
        public static TextureMap smallLeftIdle;
        public static TextureMap smallLeftWalking;
        public static TextureMap smallLeftRunning;
        public static TextureMap smallLeftTurning;
        public static TextureMap smallLeftJumping;
        public static TextureMap smallLeftSwimming;
        public static TextureMap smallLeftSwimmingIdle;
        public static TextureMap smallLeftClimbing;
        public static TextureMap smallLeftClimbingIdle;

        public static TextureMap bigRightClimbing;
        public static TextureMap bigRightClimbingIdle;
        public static TextureMap bigRightSwimming;
        public static TextureMap bigRightSwimmingIdle;
        public static TextureMap bigRightIdle;
        public static TextureMap bigRightWalking;
        public static TextureMap bigRightRunning;
        public static TextureMap bigRightTurning;
        public static TextureMap bigRightJumping;
        public static TextureMap bigRightDucking;
        public static TextureMap bigLeftIdle;
        public static TextureMap bigLeftWalking;
        public static TextureMap bigLeftRunning;
        public static TextureMap bigLeftTurning;
        public static TextureMap bigLeftJumping;
        public static TextureMap bigLeftDucking;
        public static TextureMap bigLeftSwimming;
        public static TextureMap bigLeftSwimmingIdle;
        public static TextureMap bigLeftClimbing;
        public static TextureMap bigLeftClimbingIdle;

        public static TextureMap fireRightClimbing;
        public static TextureMap fireRightClimbingIdle;
        public static TextureMap fireRightSwimming;
        public static TextureMap fireRightSwimmingIdle;
        public static TextureMap fireRightIdle;
        public static TextureMap fireRightWalking;
        public static TextureMap fireRightRunning;
        public static TextureMap fireRightTurning;
        public static TextureMap fireRightJumping;
        public static TextureMap fireRightDucking;
        public static TextureMap fireLeftIdle;
        public static TextureMap fireLeftWalking;
        public static TextureMap fireLeftRunning;
        public static TextureMap fireLeftTurning;
        public static TextureMap fireLeftJumping;
        public static TextureMap fireLeftDucking;
        public static TextureMap fireLeftSwimming;
        public static TextureMap fireLeftSwimmingIdle;
        public static TextureMap fireLeftClimbing;
        public static TextureMap fireLeftClimbingIdle;

        public static Texture2D marioTransition;
        
        public static TextureMap smallBigTransitionRight;
        public static TextureMap smallBigTransitionLeft;
        
        public static TextureMap bigSmallTransitionLeft;
        public static TextureMap bigSmallTransitionRight;
        
        public static TextureMap fireIdleTransitionRight;
        public static TextureMap fireRunningTransitionRight;
        public static TextureMap fireJumpingIdleTransitionRight;
        public static TextureMap fireJumpingTransitionRight;
        public static TextureMap fireDuckingTransitionRight;

        public static TextureMap fireIdleTransitionLeft;
        public static TextureMap fireRunningTransitionLeft;
        public static TextureMap fireJumpingIdleTransitionLeft;
        public static TextureMap fireJumpingTransitionLeft;
        public static TextureMap fireDuckingTransitionLeft;

        public static Texture2D mario0;
        public static Texture2D mario1;
        public static Texture2D mario2;
        public static Texture2D mario3;


        public static Texture2D luigi0;
        public static Texture2D luigi1;
        public static Texture2D luigi2;
        public static Texture2D luigi3;

        public static Texture2D luigiTransition;

        public static Texture2D mushroomPointer;

        public static Texture2D[] alex = new Texture2D[5];
        public static Texture2D[] christian = new Texture2D[5];
        public static Texture2D[] dan = new Texture2D[5];
        public static Texture2D[] david = new Texture2D[5];
        public static Texture2D[] mike = new Texture2D[5];
        public static Texture2D[] matt = new Texture2D[5];

        public static int playerRows = 3;
        public static int playerColumns = 33;

        enum PlayerColumnStates { RightIdle, RightWalking, RightTurning, RightJumping, RightDucking, Dead, LeftIdle, LeftWalking, LeftTurning, LeftJumping, LeftDucking, LeftDying };
        enum PlayerRowStates { Small, Big, Fire }

        public static SpriteFont font;

        public static void InitializeTextures(ContentManager Content)
        {
            font = Content.Load<SpriteFont>("Font/MarioFont");
            LoadTextures(Content);
            LoadTextureMaps();
        }

        public static void LoadTextures(ContentManager Content)
        {
            powerup1up = Content.Load<Texture2D>("Sprites/Items/1up");
            powerupMushroom = Content.Load<Texture2D>("Sprites/Items/Mushroom");
            powerupStar = Content.Load<Texture2D>("Sprites/Items/Star");
            powerupFireFlower = Content.Load<Texture2D>("Sprites/Items/FireFlower");
            powerupCoin = Content.Load<Texture2D>("Sprites/Items/Coin");
            powerupCoinSpinning = Content.Load<Texture2D>("Sprites/Items/CoinSpinning");

            miniCoin = Content.Load<Texture2D>("Sprites/HUD/MiniCoin");
            titleCard = Content.Load<Texture2D>("Sprites/HUD/TitleCard");

            blockQuestion = Content.Load<Texture2D>("Sprites/Blocks/BlockQuestion");
            blockBrick = Content.Load<Texture2D>("Sprites/Blocks/BlockBrick");
            blockHidden = Content.Load<Texture2D>("Sprites/Blocks/BlockHidden");
            blockStair = Content.Load<Texture2D>("Sprites/Blocks/BlockStair");
            blockUsed = Content.Load<Texture2D>("Sprites/Blocks/BlockUsed");
            blockFloor = Content.Load<Texture2D>("Sprites/Blocks/BlockFloor");
            blockPipe = Content.Load<Texture2D>("Sprites/Blocks/BlockPipe");
            blockPipeSideways = Content.Load<Texture2D>("Sprites/Blocks/BlockPipeSideways");
            blockAxe = Content.Load<Texture2D>("Sprites/Blocks/Axe");
            blockBillBlaster = Content.Load<Texture2D>("Sprites/Blocks/BillBlaster/BillBlasterTall");
            blockBridge = Content.Load<Texture2D>("Sprites/Blocks/Bridge");
            blockBowserBridge = Content.Load<Texture2D>("Sprites/Blocks/BowserBridge");

            grassLedge = Content.Load<Texture2D>("Sprites/Blocks/GrassLedge");
            mushroomLedge = Content.Load<Texture2D>("Sprites/Blocks/MushroomLedge");
            platform = Content.Load<Texture2D>("Sprites/Blocks/Platform");

            springboardIdle = Content.Load<Texture2D>("Sprites/Blocks/Springboard/SpringboardIdle");
            springboardCompressing = Content.Load<Texture2D>("Sprites/Blocks/Springboard/SpringboardCompressing");
            springboardRelaxing = Content.Load<Texture2D>("Sprites/Blocks/Springboard/SpringboardRelaxing");

            water = Content.Load<Texture2D>("Sprites/Blocks/Water");

            flagpolePole = Content.Load<Texture2D>("Sprites/Ropes/FlagpolePole");
            flagpoleFlag = Content.Load<Texture2D>("Sprites/Blocks/FlagpoleFlag");

            vine = Content.Load<Texture2D>("Sprites/Ropes/Vine");

            goombaWalking = Content.Load<Texture2D>("Sprites/Enemies/Goomba/GoombaWalking");
            goombaStomped = Content.Load<Texture2D>("Sprites/Enemies/Goomba/GoombaStomped");
            goombaDead = Content.Load<Texture2D>("Sprites/Enemies/Goomba/GoombaDead");

            koopaLeftWalking = Content.Load<Texture2D>("Sprites/Enemies/Koopa/KoopaLeftWalking");
            koopaRightWalking = Content.Load<Texture2D>("Sprites/Enemies/Koopa/KoopaRightWalking");
            koopaInShell = Content.Load<Texture2D>("Sprites/Enemies/Koopa/KoopaShell");
            koopaWarning = Content.Load<Texture2D>("Sprites/Enemies/Koopa/KoopaWarning");
            koopaDead = Content.Load<Texture2D>("Sprites/Enemies/Koopa/KoopaDead");
            koopaInShellUpsideDown = Content.Load<Texture2D>("Sprites/Enemies/Koopa/KoopaInShellUpsideDown");
            koopaWarningUpsideDown = Content.Load<Texture2D>("Sprites/Enemies/Koopa/KoopaWarningUpsideDown");
            koopaBouncingLeft = Content.Load<Texture2D>("Sprites/Enemies/Koopa/BouncingKoopaLeft");
            koopaBouncingRight = Content.Load<Texture2D>("Sprites/Enemies/Koopa/BouncingKoopaRight");

            redKoopaLeftWalking = Content.Load<Texture2D>("Sprites/Enemies/Koopa/RedKoopa/RedKoopaWalkingLeft");
            redKoopaRightWalking = Content.Load<Texture2D>("Sprites/Enemies/Koopa/RedKoopa/RedKoopaWalkingRight");
            redKoopaInShell = Content.Load<Texture2D>("Sprites/Enemies/Koopa/RedKoopa/RedKoopaShell");
            redKoopaWarning = Content.Load<Texture2D>("Sprites/Enemies/Koopa/RedKoopa/RedKoopaWarning");
            redKoopaWarningUpsideDown = Content.Load<Texture2D>("Sprites/Enemies/Koopa/RedKoopa/RedKoopaUpsideDownWarning");
            redKoopaInShellUpsideDown = Content.Load<Texture2D>("Sprites/Enemies/Koopa/RedKoopa/RedKoopaShellUpsideDown");
            redParaKoopaLeft = Content.Load<Texture2D>("Sprites/Enemies/Koopa/RedKoopa/ParaKoopaLeft");
            redParaKoopaRight = Content.Load<Texture2D>("Sprites/Enemies/Koopa/RedKoopa/ParaKoopaRight");

            piranhaPlantGreen = Content.Load<Texture2D>("Sprites/Enemies/PiranhaPlant/PiranhaPlantGreen");
            piranhaPlantRed = Content.Load<Texture2D>("Sprites/Enemies/PiranhaPlant/PiranhaPlantRed");

            hammerBroWalking = Content.Load<Texture2D>("Sprites/Enemies/HammerBro/HammerBroWalking");
            hammerBroDead = Content.Load<Texture2D>("Sprites/Enemies/HammerBro/HammerBroDead");

            bowserMovingLeft = Content.Load<Texture2D>("Sprites/Enemies/Bowser/bowserMovingLeft");
            bowserMovingRight = Content.Load<Texture2D>("Sprites/Enemies/Bowser/bowserMovingRight");
            bowserShootingFireLeft = Content.Load<Texture2D>("Sprites/Enemies/Bowser/bowserShootingFireLeft");
            bowserFireballLeft = Content.Load<Texture2D>("Sprites/Projectiles/bowserFireballLeft");
            World1Death = Content.Load<Texture2D>("Sprites/Enemies/Bowser/World1Death");
            World2Death = Content.Load<Texture2D>("Sprites/Enemies/Bowser/World2Death");
            World3Death = Content.Load<Texture2D>("Sprites/Enemies/Bowser/World3Death");
            World4Death = Content.Load<Texture2D>("Sprites/Enemies/Bowser/World4Death");
            World5Death = Content.Load<Texture2D>("Sprites/Enemies/Bowser/World5Death");
            World6Death = Content.Load<Texture2D>("Sprites/Enemies/Bowser/World6Death");
            World7Death = Content.Load<Texture2D>("Sprites/Enemies/Bowser/World7Death");
            bowserDeadLeft = Content.Load<Texture2D>("Sprites/Enemies/Bowser/BowserDeadLeft");
            bowserDeadRight = Content.Load<Texture2D>("Sprites/Enemies/Bowser/BowserDeadRight");

            hammer = Content.Load<Texture2D>("Sprites/Projectiles/Hammer");

            bulletBillLeft = Content.Load<Texture2D>("Sprites/Enemies/BulletBill/BulletBillLeft");
            bulletBillRight = Content.Load<Texture2D>("Sprites/Enemies/BulletBill/BulletBillRight");

            buzzyBeetleLeftWalking = Content.Load<Texture2D>("Sprites/Enemies/BuzzyBeetle/BuzzyBeetleLeft");
            buzzyBeetleRightWalking = Content.Load<Texture2D>("Sprites/Enemies/BuzzyBeetle/BuzzyBeetleRight");
            buzzyBeetleInShell = Content.Load<Texture2D>("Sprites/Enemies/BuzzyBeetle/BuzzyBeetleInShell");
            buzzyBeetleInShellUpsideDown = Content.Load<Texture2D>("Sprites/Enemies/BuzzyBeetle/BuzzyBeetleInShellUpsideDown");

            cheepCheepRedLeft = Content.Load<Texture2D>("Sprites/Enemies/CheepCheep/CheepCheepRedLeft");
            cheepCheepRedRight = Content.Load<Texture2D>("Sprites/Enemies/CheepCheep/CheepCheepRedRight");
            cheepCheepGrayLeft = Content.Load<Texture2D>("Sprites/Enemies/CheepCheep/CheepCheepGrayLeft");
            cheepCheepGrayRight = Content.Load<Texture2D>("Sprites/Enemies/CheepCheep/CheepCheepGrayRight");
            cheepCheepGrayDeadLeft = Content.Load<Texture2D>("Sprites/Enemies/CheepCheep/CheepCheepGrayDeadLeft");
            cheepCheepRedDeadLeft = Content.Load<Texture2D>("Sprites/Enemies/CheepCheep/CheepCheepRedDeadLeft");

            blooperSwimming = Content.Load<Texture2D>("Sprites/Enemies/Blooper/BlooperSwimming");
            blooperIdle = Content.Load<Texture2D>("Sprites/Enemies/Blooper/BlooperIdle");
            blooperDead = Content.Load<Texture2D>("Sprites/Enemies/Blooper/BlooperDead");

            podobooUp = Content.Load<Texture2D>("Sprites/Enemies/Podoboo/PodobooUp");
            podobooDown = Content.Load<Texture2D>("Sprites/Enemies/Podoboo/PodobooDown");

            lakituLeft = Content.Load<Texture2D>("Sprites/Enemies/Lakitu/LakituLeft");
            lakituRight = Content.Load<Texture2D>("Sprites/Enemies/Lakitu/LakituRight");
            lakituInCloud = Content.Load<Texture2D>("Sprites/Enemies/Lakitu/LakituInCloud");
            lakituDead = Content.Load<Texture2D>("Sprites/Enemies/Lakitu/LakituDead");

            spinyLeft = Content.Load<Texture2D>("Sprites/Enemies/Spiny/SpinyLeft");
            spinyRight = Content.Load<Texture2D>("Sprites/Enemies/Spiny/SpinyRight");
            spinyInEgg = Content.Load<Texture2D>("Sprites/Enemies/Spiny/SpinyInEgg");
            spinyDeadRight = Content.Load<Texture2D>("Sprites/Enemies/Spiny/SpinyDeadRight");
            spinyDeadLeft = Content.Load<Texture2D>("Sprites/Enemies/Spiny/SpinyDeadLeft");

            projectileFireball = Content.Load<Texture2D>("Sprites/Projectiles/Fireball");

            largeCloud = Content.Load<Texture2D>("Sprites/Scenery/Cloud/LargeCloud");
            mediumCloud = Content.Load<Texture2D>("Sprites/Scenery/Cloud/MediumCloud");
            smallCloud = Content.Load<Texture2D>("Sprites/Scenery/Cloud/SmallCloud");
            largeBush = Content.Load<Texture2D>("Sprites/Scenery/Bush/LargeBush");
            mediumBush = Content.Load<Texture2D>("Sprites/Scenery/Bush/MediumBush");
            smallBush = Content.Load<Texture2D>("Sprites/Scenery/Bush/SmallBush");
            bigHill = Content.Load<Texture2D>("Sprites/Scenery/Hill/BigHill");
            smallHill = Content.Load<Texture2D>("Sprites/Scenery/Hill/SmallHill");
            bigTree = Content.Load<Texture2D>("Sprites/Scenery/Tree/LargeTree");
            smallTree = Content.Load<Texture2D>("Sprites/Scenery/Tree/SmallTree");
            fence = Content.Load<Texture2D>("Sprites/Scenery/Fence/Fence");

            castleBig = Content.Load<Texture2D>("Sprites/Scenery/Castle/CastleBig");
            castleSmall = Content.Load<Texture2D>("Sprites/Scenery/Castle/CastleSmall");
            castleFlag = Content.Load<Texture2D>("Sprites/Scenery/Castle/CastleFlag");
            castleWall = Content.Load<Texture2D>("Sprites/Scenery/Castle/CastleWall");

            toad = Content.Load<Texture2D>("Sprites/NPC/Toad");
            princess = Content.Load<Texture2D>("Sprites/NPC/Princess");

            particle1up = Content.Load<Texture2D>("Sprites/Particles/Particle1up");
            particleBricks = Content.Load<Texture2D>("Sprites/Particles/ParticleBricks");
            particleBubble = Content.Load<Texture2D>("Sprites/Particles/ParticleBubble");
            particleExplosion = Content.Load<Texture2D>("Sprites/Particles/ParticleExplosion");
            particleScore100 = Content.Load<Texture2D>("Sprites/Particles/ParticleScore100");
            particleScore200 = Content.Load<Texture2D>("Sprites/Particles/ParticleScore200");
            particleScore400 = Content.Load<Texture2D>("Sprites/Particles/ParticleScore400");
            particleScore500 = Content.Load<Texture2D>("Sprites/Particles/ParticleScore500");
            particleScore800 = Content.Load<Texture2D>("Sprites/Particles/ParticleScore800");
            particleScore1000 = Content.Load<Texture2D>("Sprites/Particles/ParticleScore1000");
            particleScore2000 = Content.Load<Texture2D>("Sprites/Particles/ParticleScore2000");
            particleScore4000 = Content.Load<Texture2D>("Sprites/Particles/ParticleScore4000");
            particleScore5000 = Content.Load<Texture2D>("Sprites/Particles/ParticleScore5000");
            particleScore8000 = Content.Load<Texture2D>("Sprites/Particles/ParticleScore8000");

            marioTransition = Content.Load<Texture2D>("Sprites/Players/Mario/MarioTransitions");

            mario0 = Content.Load<Texture2D>("Sprites/Players/Mario/Mario0");
            mario1 = Content.Load<Texture2D>("Sprites/Players/Mario/Mario1");
            mario2 = Content.Load<Texture2D>("Sprites/Players/Mario/Mario2");
            mario3 = Content.Load<Texture2D>("Sprites/Players/Mario/Mario3");

            luigiTransition = Content.Load<Texture2D>("Sprites/Players/Luigi/LuigiTransitions");

            luigi0 = Content.Load<Texture2D>("Sprites/Players/Luigi/Luigi0");
            luigi1 = Content.Load<Texture2D>("Sprites/Players/Luigi/Luigi1");
            luigi2 = Content.Load<Texture2D>("Sprites/Players/Luigi/Luigi2");
            luigi3 = Content.Load<Texture2D>("Sprites/Players/Luigi/Luigi3");

            mushroomPointer = Content.Load<Texture2D>("Sprites/MushroomPointer");

            for (int i = 0; i < 5; i++)
            {
                alex[i] = Content.Load<Texture2D>("People/Alex/Alex" + (i + 1));
                christian[i] = Content.Load<Texture2D>("People/Christian/Christian" + (i + 1));
                dan[i] = Content.Load<Texture2D>("People/Dan/Dan" + (i + 1));
                david[i] = Content.Load<Texture2D>("People/David/David" + (i + 1));
                mike[i] = Content.Load<Texture2D>("People/Mike/Mike" + (i + 1));
                matt[i] = Content.Load<Texture2D>("People/Matt/Matt" + (i + 1));
            }
        }

        public static void LoadTextureMaps()
        {
            smallBigTransitionLeft = new TextureMap(0, 11, 3, TRANSITION_FRAME_TIME);
            smallBigTransitionRight = new TextureMap(0, 0, 3, TRANSITION_FRAME_TIME);
            
            bigSmallTransitionLeft = new TextureMap(0, 4, 3, TRANSITION_FRAME_TIME);
            bigSmallTransitionRight = new TextureMap(0, 7, 3, TRANSITION_FRAME_TIME);
            
            fireIdleTransitionRight = new TextureMap(1, 0, 2, TRANSITION_FRAME_TIME);
            fireRunningTransitionRight = new TextureMap(1, 2, 2, TRANSITION_FRAME_TIME);
            fireJumpingIdleTransitionRight = new TextureMap(1, 6, 2, TRANSITION_FRAME_TIME);
            fireJumpingTransitionRight = new TextureMap(1, 6, 2, TRANSITION_FRAME_TIME);
            fireDuckingTransitionRight = new TextureMap(1, 4, 2, TRANSITION_FRAME_TIME);

            fireIdleTransitionLeft = new TextureMap(2, 0, 2, TRANSITION_FRAME_TIME);
            fireRunningTransitionLeft = new TextureMap(2, 2, 2, TRANSITION_FRAME_TIME);
            fireJumpingIdleTransitionLeft = new TextureMap(2, 6, 2, TRANSITION_FRAME_TIME);
            fireJumpingTransitionLeft = new TextureMap(2, 6, 2, TRANSITION_FRAME_TIME);
            fireDuckingTransitionLeft = new TextureMap(2, 4, 2, TRANSITION_FRAME_TIME);

            smallRightClimbing = new TextureMap(0, 6, 2, CLIMBING_FRAME_TIME);
            smallRightClimbingIdle = new TextureMap(0, 6);
            smallRightSwimming = new TextureMap(0, 0, 6, SWIMMING_FRAME_TIME);
            smallRightSwimmingIdle = new TextureMap(0, 0);
            smallRightIdle = new TextureMap(0, 8);
            smallRightWalking = new TextureMap(0, 9, 3, WALKING_FRAME_TIME);
            smallRightRunning = new TextureMap(0, 9, 3, RUNNING_FRAME_TIME);
            smallRightTurning = new TextureMap(0, 12);
            smallRightJumping = new TextureMap(0, 13);
            smallDead = new TextureMap(0, 16);
            smallLeftJumping = new TextureMap(0, 19);
            smallLeftTurning = new TextureMap(0, 20);
            smallLeftRunning = new TextureMap(0, 21, 3, RUNNING_FRAME_TIME);
            smallLeftWalking = new TextureMap(0, 21, 3, WALKING_FRAME_TIME);
            smallLeftIdle = new TextureMap(0, 24);
            smallLeftSwimming = new TextureMap(0, 27, 6, SWIMMING_FRAME_TIME);
            smallLeftSwimmingIdle = new TextureMap(0, 27);
            smallLeftClimbing = new TextureMap(0, 25, 2, CLIMBING_FRAME_TIME);
            smallLeftClimbingIdle = new TextureMap(0, 25);

            bigRightClimbing = new TextureMap(1, 6, 2, CLIMBING_FRAME_TIME);
            bigRightClimbingIdle = new TextureMap(1, 6);
            bigRightSwimming = new TextureMap(1, 0, 6, SWIMMING_FRAME_TIME);
            bigRightSwimmingIdle = new TextureMap(1, 0);
            bigRightIdle = new TextureMap(1, 8);
            bigRightWalking = new TextureMap(1, 9, 3, WALKING_FRAME_TIME);
            bigRightRunning = new TextureMap(1, 9, 3, RUNNING_FRAME_TIME);
            bigRightTurning = new TextureMap(1, 12);
            bigRightJumping = new TextureMap(1, 13);
            bigRightDucking = new TextureMap(1, 14);
            bigLeftDucking = new TextureMap(1, 18);
            bigLeftJumping = new TextureMap(1, 19);
            bigLeftTurning = new TextureMap(1, 20);
            bigLeftRunning = new TextureMap(1, 21, 3, RUNNING_FRAME_TIME);
            bigLeftWalking = new TextureMap(1, 21, 3, WALKING_FRAME_TIME);
            bigLeftIdle = new TextureMap(1, 24);
            bigLeftSwimming = new TextureMap(1, 27, 6, SWIMMING_FRAME_TIME);
            bigLeftSwimmingIdle = new TextureMap(1, 27);
            bigLeftClimbing = new TextureMap(1, 25, 2, CLIMBING_FRAME_TIME);
            bigLeftClimbingIdle = new TextureMap(1, 25);

            fireRightClimbing = new TextureMap(2, 6, 2, CLIMBING_FRAME_TIME);
            fireRightClimbingIdle = new TextureMap(2, 6);
            fireRightSwimming = new TextureMap(2, 0, 6, SWIMMING_FRAME_TIME);
            fireRightSwimmingIdle = new TextureMap(2, 0);
            fireRightIdle = new TextureMap(2, 8);
            fireRightWalking = new TextureMap(2, 9, 3, WALKING_FRAME_TIME);
            fireRightRunning = new TextureMap(2, 9, 3, RUNNING_FRAME_TIME);
            fireRightTurning = new TextureMap(2, 12);
            fireRightJumping = new TextureMap(2, 13);
            fireRightDucking = new TextureMap(2, 14);
            fireLeftDucking = new TextureMap(2, 18);
            fireLeftJumping = new TextureMap(2, 19);
            fireLeftTurning = new TextureMap(2, 20);
            fireLeftRunning = new TextureMap(2, 21, 3, RUNNING_FRAME_TIME);
            fireLeftWalking = new TextureMap(2, 21, 3, WALKING_FRAME_TIME);
            fireLeftIdle = new TextureMap(2, 24);
            fireLeftSwimming = new TextureMap(2, 27, 6, SWIMMING_FRAME_TIME);
            fireLeftSwimmingIdle = new TextureMap(2, 27);
            fireLeftClimbing = new TextureMap(2, 25, 2, CLIMBING_FRAME_TIME);
            fireLeftClimbingIdle = new TextureMap(2, 25);
        }
    }
}
