using GameDevProject.Interfaces;
using GameDevProject.Managers;
using GameDevProject.Map;
using GameDevProject.States.EnemyStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GameDevProject.Entities
{
    class Enemy : Entity, IMovable, IHitbox, IKillable
    {
        protected IEnemyState enemyState;
        public MovementManager MovementManager;
        public DeathManager DeathManager;

        public Enemy()
        {
            this.enemyState = new EnemyIdleState();
            this.MovementManager = new MovementManager();
            this.DeathManager = new DeathManager();
            this.IsDead = false;
        }

        #region Enemy Methods
        public override void Draw(SpriteBatch spriteBatch)
        {
            this.enemyState.Draw(spriteBatch, this.textures, this.Position, this.animations, this.SpriteEffects);
        }
        public override void Update(GameTime gameTime, World world)
        {
            if (!HasNoHealth())
            {
                this.Move(gameTime, world);
            }
            this.Die(gameTime);
            this.ChangeState();
            this.enemyState.Update(gameTime, this.animations);
        }
        #endregion

        #region IMovable Implementation
        public bool CanJump { get; set; }
        public bool IsJumping { get; set; }

        public Vector2 MaxVelocity { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Rectangle HitboxRectangle { get; set; }
        public IInputReader InputReader { get; set; }

        public void Move(GameTime gameTime, World world)
        {
            this.MovementManager.Move(this, gameTime, world);
        }
        #endregion

        #region IKillable Implementation
        public bool IsDead { get; set; }
        public TimeSpan DeathTimer { get; set; }
        public TimeSpan DeathDuration { get; set; }

        public void Die(GameTime gameTime)
        {
            this.DeathManager.Die(this, gameTime);
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
        }

        private bool HasNoHealth()
        {
            if (this.Health <= 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
