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

namespace GameDevProject.Entities
{
    class Player : Entity, IMovable, IAttacker
    {
        #region IMovable implementation
        public Vector2 MaxVelocity { get; set; }
        public IInputReader InputReader { get; set; }
        public float MaxAcceleration { get; set; }
        public float MaxJumpHeight { get; set; }
        public SpriteEffects spriteEffects { get; set; }
        public Vector2 Velocity { get; set; }
        public float Acceleration { get; set; }
        public Rectangle hitBox { get; set; }

        public void Move(GameTime gameTime, World world)
        {
            movementManager.Move(this, gameTime, world);
        }

        #endregion

        #region IAttacker implementation
        public TimeSpan AttackCooldown { get; set; }
        public bool CanAttack { get; set; }
        public bool IsAttacking { get; set; }

        public void Attack(GameTime gameTime)
        {
            attackManager.Attack(this, gameTime);


            if (CanAttack)
            {
                this.CanAttack = false;
                this.playerState = new PlayerSpinState();
            }
            else
            {
                this.AttackCooldown -= gameTime.ElapsedGameTime;
            }
            if (this.AttackCooldown < TimeSpan.Zero)
            {
                this.CanAttack = true;
            }
        }

        private const int IDLE_FPS = 5;
        #endregion

        #region Player properties
        public MovementManager movementManager;

        public AttackManager attackManager;

        private IPlayerState playerState;
        #endregion

        #region Player constructors
        public Player(List<Texture2D> textures, IInputReader inputReader)
        {
            this.textures = textures;
            this.InputReader = inputReader;
            this.movementManager = new MovementManager();
            
            this.Position = new Vector2(1, 30);
            this.MaxVelocity = new Vector2(1, 1); //horizontal , vertical
            this.MaxAcceleration = 5;
            this.MaxJumpHeight = 3;
            this.Acceleration = 9.81f;
            this.Velocity = new Vector2(0,0);
            this.hitBox = new Rectangle(0, 0, 45, 45);

            this.attackManager = new AttackManager();

            this.AttackCooldown = TimeSpan.FromSeconds(5);
            this.CanAttack = true;
            this.IsAttacking = false;

            AddAnimations();
            SetAnimations();

            playerState = new PlayerSleepState();
        }
        #endregion

        #region Player methods
        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draw the animation
            playerState.Draw(spriteBatch, this.textures, this.Position, this.animations, this.spriteEffects);
        }

        override public void Update(GameTime gameTime, World world)
        {
            Move(gameTime, world);
            Attack(gameTime);
            ChangeState();
            //Update the animation
            playerState.Update(gameTime, animations);
        }
        #endregion

        private void AddAnimations()
        {
            this.animations.Add(new Animation(IDLE_FPS));
            this.animations.Add(new Animation(10));
            this.animations.Add(new Animation(10));
            this.animations.Add(new Animation(10));
            this.animations.Add(new Animation(10));
        }

        private void SetAnimations()
        {
            this.animations[0].GetFramesFromTextureProperties(textures[0].Width, textures[0].Height, 2, 1);
            this.animations[1].GetFramesFromTextureProperties(textures[1].Width, textures[1].Height, 4, 1);
            this.animations[2].GetFramesFromTextureProperties(textures[2].Width, textures[2].Height, 9, 1);
            this.animations[3].GetFramesFromTextureProperties(textures[3].Width, textures[3].Height, 12, 1);
            this.animations[4].GetFramesFromTextureProperties(textures[4].Width, textures[4].Height, 6, 1);
        }

        #region StateChanges
        private void ChangeState()
        {
            if (IsIdle())
            {
                this.playerState = new PlayerIdleState();
            }
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
        #endregion
    }
}
