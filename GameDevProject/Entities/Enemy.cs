﻿using GameDevProject.Interfaces;
using GameDevProject.Managers;
using GameDevProject.Map;
using GameDevProject.States.EnemyStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace GameDevProject.Entities
{
    class Enemy : Entity, IMovable, IHitbox, IKillable
    {
        #region Properties
        public MovementManager MovementManager;
        protected IEntityState enemyState;
        #endregion

        #region Constructor
        public Enemy()
        {
            this.enemyState = new EnemyIdleState();
            this.MovementManager = new MovementManager();
            this.IsDead = false;
        }
        #endregion 

        #region IKillable Implementation
        public bool IsDead { get; set; }
        public TimeSpan DeathTimer { get; set; }
        public TimeSpan DeathDuration { get; set; }
        #endregion

        #region IMovable implementation
        public bool CanJump { get; set; }
        public bool IsJumping { get; set; }

        public Vector2 MaxVelocity { get; set; }
        public IInputReader InputReader { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Rectangle HitboxRectangle { get; set; }

        public void Move(GameTime gameTime, World world)
        {
            this.MovementManager.Move(this, gameTime, world);
        }

        #endregion

        #region Enemy Methods
        public override void Draw(SpriteBatch spriteBatch)
        {
            this.enemyState.Draw(spriteBatch, this.textures, this.Position, this.animations, this.SpriteEffects);
        }
        public override void Update(GameTime gameTime, World world)
        {
            this.Move(gameTime, world);            
            this.ChangeState();
            this.enemyState.Update(gameTime, this.animations);
        }
        #endregion

        #region StateChanges
        private void ChangeState()
        {
            if (HasNoHealth())
            {
                this.enemyState = new EnemyDeadState();
            }
            else
            {
                this.enemyState = new EnemyIdleState();
            }

            if (IsWalking())
            {
                SoundManager.PlaySound(Sound.EnemyWalk);
            }
        }

        private bool HasNoHealth()
        {
            return this.Health <= 0;            
        }

        private bool IsWalking()
        {
            return this.Velocity.X != 0;
        }
        #endregion
    }
}
