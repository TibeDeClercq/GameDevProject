using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GameDevProject.Interfaces;
using GameDevProject.Managers;
using GameDevProject.Map;
using GameDevProject.States.EnemyStates;


namespace GameDevProject.Entities
{
    class Enemy : Entity, IMovable, IHitbox, IKillable
    {
        #region Properties
        public MovementManager MovementManager;
        protected IEntityState enemyState;

        private const int MOVEMENT_LIMITER = 2;
        private int timer = 0;
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
        public Vector2 Gravity { get; set; }
        public Rectangle HitboxRectangle { get; set; }
        public int IdleHitboxWidth { get; set; }

        public void Move(GameTime gameTime, World world)
        {
            if (this.timer >= MOVEMENT_LIMITER)
            {
                this.MovementManager.Move(this, gameTime, world);
                this.timer = 0;
            }
            this.timer++;
        }

        #endregion

        #region Constructor
        public Enemy()
        {
            this.enemyState = new EnemyIdleState();
            this.MovementManager = new MovementManager();
            this.IsDead = false;
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
            this.enemyState.Update(gameTime, this.animations, this);
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
                if (IsWalking())
                {
                    this.enemyState = new EnemyWalkState();
                    SoundManager.PlaySound(Sound.EnemyWalk);
                }
                else
                {
                    this.enemyState = new EnemyIdleState();
                    SoundManager.StopSound(Sound.EnemyWalk);
                }
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
