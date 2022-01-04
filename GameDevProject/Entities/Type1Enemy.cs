using GameDevProject.Entities.Animations;
using GameDevProject.Input;
using GameDevProject.Interfaces;
using GameDevProject.Managers;
using GameDevProject.Map;
using GameDevProject.States.Type1EnemyStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDevProject.Entities
{
    class Type1Enemy : Entity , IMovable , IHitbox, IKillable
    {
        #region Enemy Properties
        public MovementManager MovementManager;

        public DeathManager DeathManager;

        private IType1EnemyState enemyState;

        private const int IDLE_FRAMES = 2;
        private const int DEAD_FRAMES = 15;

        private const int IDLE_FPS = 5;
        private const int DEAD_FPS = 10;
        #endregion

        #region Constructor
        public Type1Enemy(List<Texture2D> textures, Player player)
        {
            this.MovementManager = new MovementManager();
            this.DeathManager = new DeathManager();

            this.textures = textures;
            this.Position = new Vector2(150, 10);
            this.MaxVelocity = new Vector2(1, 2);
            this.Velocity = new Vector2(0, 0);
            this.HitboxRectangle = new Rectangle((int)this.Position.X, (int)this.Position.Y, 45, 45);
            this.InputReader = new Type1EnemyAI(player, this);
            this.Health = 1;

            this.IsDead = false;
            this.DeathDuration = TimeSpan.FromSeconds(1.5);
            this.DeathTimer = TimeSpan.Zero;

            AddAnimations();
            SetAnimations();

            this.enemyState = new Type1EnemyIdleState();            
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

        #region Animations
        private void AddAnimations()
        {
            this.animations.Add(new Animation(IDLE_FPS));
            this.animations.Add(new Animation(DEAD_FPS));
        }

        private void SetAnimations()
        {
            this.animations[0].GetFramesFromTextureProperties(textures[0].Width, textures[0].Height, IDLE_FRAMES, 1);
            this.animations[1].GetFramesFromTextureProperties(textures[1].Width, textures[1].Height, DEAD_FRAMES, 1);
        }
        #endregion

        #region StateChanges
        private void ChangeState()
        {
            if (HasNoHealth())
            {
                this.enemyState = new Type1EnemyDeadState();
            }
            else
            {
                this.enemyState = new Type1EnemyIdleState();
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
