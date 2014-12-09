using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SFireballDeadBowser : IEnemyState
    {
        public IEnemy Enemy { get; set; }
        private int counter;
        public SFireballDeadBowser(IEnemy enemy) {
            this.Enemy = enemy;
            if (HUD.worldNum[HUD.currentPlayer] == 1)
                this.Enemy.Sprite = new Animation(Textures.World1Death);
            else if (HUD.worldNum[HUD.currentPlayer] == 2)
                this.Enemy.Sprite = new Animation(Textures.World2Death);
            else if (HUD.worldNum[HUD.currentPlayer] == 3)
                this.Enemy.Sprite = new Animation(Textures.World3Death);
            else if (HUD.worldNum[HUD.currentPlayer] == 4)
                this.Enemy.Sprite = new Animation(Textures.World4Death);
            else if (HUD.worldNum[HUD.currentPlayer] == 5)
                this.Enemy.Sprite = new Animation(Textures.World5Death);
            else if (HUD.worldNum[HUD.currentPlayer] == 6)
                this.Enemy.Sprite = new Animation(Textures.World6Death);
            else if (HUD.worldNum[HUD.currentPlayer] == 7)
                this.Enemy.Sprite = new Animation(Textures.World7Death);
            else {
                if (enemy.State is SBowserMovingLeft)
                    this.Enemy.Sprite = new Animation(Textures.bowserDeadLeft);
                else
                    this.Enemy.Sprite = new Animation(Textures.bowserDeadRight);
            }
            this.counter = 0;
            this.Enemy.Velocity = Vector2.Zero;
            this.Enemy.Acceleration = Vector2.Zero;
            Enemy.Hitbox.Clear();
            SetHitbox();
        }

        public void Update() {
            if (counter == HotDAMN.TICKS_UNTIL_BOWSER_DEAD_MOVES) {
                Enemy.Velocity = new Vector2(0f, 0.5f);
                Enemy.Acceleration = Physics.GRAVITY / 3;
            }
            if (counter == HotDAMN.TICKS_UNTIL_DEAD_ENEMY_REMOVE)
                Enemy.IsActive = false;
            counter++;
            Enemy.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox() {
            Enemy.Hitbox.AddRectHitbox(
                (int)Enemy.Position.X,
                    (int)Enemy.Position.Y,
                    0,
                    0);
        }
    }
}
