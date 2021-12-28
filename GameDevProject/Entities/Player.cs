using System;
using System.Collections.Generic;
using System.Text;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GameDevProject.Entities.Animations;
using GameDevProject.Managers;
using GameDevProject.States.PlayerStates;
using GameDevProject.Map;
using System.Diagnostics;

namespace GameDevProject.Entities
{
    class Player : Entity, IMovable, IAttacker, IHitbox
    {
        #region Player properties
        public MovementManager MovementManager;

        public AttackManager AttackManager;

        public HealthManager HealthManager;

        private IPlayerState playerState;

        private const int IDLE_FRAMES = 2;
        private const int WALK_FRAMES = 4;
        private const int JUMP_FRAMES = 9;
        private const int SPIN_FRAMES = 12;
        private const int SLEEP_FRAMES = 6;

        private const int IDLE_FPS = 5;
        private const int WALK_FPS = 10;
        private const int JUMP_FPS = 10;
        private const int SPIN_FPS = SPIN_FRAMES / 2; //fixen
        private const int SLEEP_FPS = 10;
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

        #region IAttacker implementation
        public TimeSpan AttackCooldown { get; set; }
        public TimeSpan AttackDuration { get; set; }
        public TimeSpan Timer { get; set; }
        public bool CanAttack { get; set; }
        public bool IsAttacking { get; set; }

        public void Attack(GameTime gameTime)
        {
            this.AttackManager.Attack(this, gameTime);
        }
        #endregion

        #region Player constructors
        public Player(List<Texture2D> textures, IInputReader inputReader)
        {
            this.textures = textures;
            this.InputReader = inputReader;
            this.MovementManager = new MovementManager();
            this.AttackManager = new AttackManager();

            this.HealthManager = new HealthManager(1, this);

            this.CanJump = true;

            this.Position = new Vector2(40, 10);
            this.MaxVelocity = new Vector2(1, 1); //horizontal , vertical
            this.Acceleration = new Vector2(0, 0);
            this.HitboxRectangle = new Rectangle(0, 0, 45, 45);
            this.Velocity = new Vector2(0,0);

            this.AttackCooldown = TimeSpan.FromSeconds(5);
            this.AttackDuration = TimeSpan.FromSeconds(2);
            this.Timer = TimeSpan.Zero;

            this.CanAttack = true;
            this.IsAttacking = false;

            AddAnimations();
            SetAnimations();

            this.playerState = new PlayerSleepState();
        }
        #endregion

        #region Player methods
        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draw the animation
            this.playerState.Draw(spriteBatch, this.textures, this.Position, this.animations, this.SpriteEffects);
        }

        override public void Update(GameTime gameTime, World world)
        {
            this.Move(gameTime, world);
            this.Attack(gameTime);
            this.ChangeState();
            HealthManager.Update(PhysicsManager.entities);
            //Update the animation
            this.playerState.Update(gameTime, animations);
        }
        #endregion

        private void AddAnimations()
        {
            this.animations.Add(new Animation(IDLE_FPS));
            this.animations.Add(new Animation(WALK_FPS));
            this.animations.Add(new Animation(JUMP_FPS));
            this.animations.Add(new Animation(SPIN_FPS));
            this.animations.Add(new Animation(SLEEP_FPS));
        }

        private void SetAnimations()
        {
            this.animations[0].GetFramesFromTextureProperties(textures[0].Width, textures[0].Height, IDLE_FRAMES, 1);
            this.animations[1].GetFramesFromTextureProperties(textures[1].Width, textures[1].Height, WALK_FRAMES, 1);
            this.animations[2].GetFramesFromTextureProperties(textures[2].Width, textures[2].Height, JUMP_FRAMES, 1);
            this.animations[3].GetFramesFromTextureProperties(textures[3].Width, textures[3].Height, SPIN_FRAMES, 1);
            this.animations[4].GetFramesFromTextureProperties(textures[4].Width, textures[4].Height, SLEEP_FRAMES, 1);
        }

        #region StateChanges
        private void ChangeState()
        {
            if (IsSpinning())
            {
                this.playerState = new PlayerSpinState();
            }
            //else if (IsIdle())
            //{
            //    this.playerState = new PlayerIdleState();
            //}
            else if (IsWalking())
            {
                this.playerState = new PlayerWalkState();
            }
            else
            {
                this.playerState = new PlayerIdleState();
            }
        }

        private bool IsIdle()
        {
            if (this.Velocity == Vector2.Zero)
            {
                return true;
            }
            return false;
        }

        private bool IsWalking()
        {
            if (this.Velocity.X != 0)
            {
                return true;
            }
            return false;
        }

        private bool IsSpinning()
        {
            if (this.IsAttacking == true)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
