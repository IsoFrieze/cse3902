using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class HumanizeTextures : ICommand
    {
        public HumanizeTextures()
        {
        }

        public void Execute()
        {
            Random random = new Random();

            // David is powerup
            Textures.powerup1up = Textures.david[random.Next(0, Textures.david.Count())];
            Textures.powerupMushroom = Textures.david[random.Next(0, Textures.david.Count())];
            Textures.powerupStar = Textures.david[random.Next(0, Textures.david.Count())];
            Textures.powerupFireFlower = Textures.david[random.Next(0, Textures.david.Count())];
            Textures.powerupCoin = Textures.david[random.Next(0, Textures.david.Count())];
            Textures.powerupCoinSpinning = Textures.david[random.Next(0, Textures.david.Count())];

            // Alex is block
            Textures.blockQuestion = Textures.alex[random.Next(0, Textures.alex.Count())];
            Textures.blockBrick = Textures.alex[random.Next(0, Textures.alex.Count())];
            Textures.blockHidden = Textures.alex[random.Next(0, Textures.alex.Count())];
            Textures.blockStair = Textures.alex[random.Next(0, Textures.alex.Count())];
            Textures.blockUsed = Textures.alex[random.Next(0, Textures.alex.Count())];

            // Dan is goomba
            Textures.goombaWalking = Textures.dan[random.Next(0, Textures.dan.Count())];
            Textures.goombaStomped = Textures.dan[random.Next(0, Textures.dan.Count())];
            Textures.goombaDead = Textures.dan[random.Next(0, Textures.dan.Count())];

            // Mike is koopa
            Textures.koopaLeftWalking = Textures.mike[random.Next(0, Textures.mike.Count())];
            Textures.koopaRightWalking = Textures.mike[random.Next(0, Textures.mike.Count())];
            Textures.koopaInShell = Textures.mike[random.Next(0, Textures.mike.Count())];
            Textures.koopaWarning = Textures.mike[random.Next(0, Textures.mike.Count())];
            Textures.koopaDead = Textures.mike[random.Next(0, Textures.mike.Count())];
            Textures.koopaInShellUpsideDown = Textures.mike[random.Next(0, Textures.mike.Count())];
            Textures.koopaWarningUpsideDown = Textures.mike[random.Next(0, Textures.mike.Count())];
            Textures.koopaBouncingLeft = Textures.mike[random.Next(0, Textures.mike.Count())];
            Textures.koopaBouncingRight = Textures.mike[random.Next(0, Textures.mike.Count())];
        }
    }
}
