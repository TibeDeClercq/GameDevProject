﻿using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GameDevProject.Entities.Animations;
using GameDevProject.Managers;
using GameDevProject.States.PlayerStates;
using GameDevProject.Map;
using GameDevProject.Interfaces;

namespace GameDevProject.Entities
{
    class Player : Entity, IMovable, IAttacker, IHitbox, IKillable
    {
        #region Player properties
        public int Score { get; set; } = 0;

        public AttackManager AttackManager;
        public MovementManager MovementManager;

        private IPlayerState playerState;

        private const int IDLE_FRAMES = 2;
        private const int WALK_FRAMES = 4;
        private const int JUMP_FRAMES = 9;
        private const int SPIN_FRAMES = 12;
        private const int SLEEP_FRAMES = 6;
        private const int DEAD_FRAMES = 15;

        private const int IDLE_FPS = 5;
        private const int WALK_FPS = 10;
        private const int JUMP_FPS = 10;
        private const int SPIN_FPS = SPIN_FRAMES / 2; //fixen
        private const int SLEEP_FPS = 10;
        private const int DEAD_FPS = 11;
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
            this.MovementManager.Move(this, gameTime, world);
        }

        #endregion

        #region IAttacker implementation
        public TimeSpan AttackCooldown { get; set; }
        public TimeSpan AttackDuration { get; set; }
        public TimeSpan AttackTimer { get; set; }
        public bool CanAttack { get; set; }
        public bool IsAttacking { get; set; }
        

        public void Attack(GameTime gameTime)
        {
            this.AttackManager.Attack(this, gameTime);
        }
        #endregion        

        #region IKillable Implementation
        public bool IsDead { get; set; }
        public TimeSpan DeathTimer { get; set; }
        public TimeSpan DeathDuration { get; set; }
        #endregion

        #region Player constructors
        public Player(List<Texture2D> textures, IInputReader inputReader, Vector2 coordinates)
        {
            this.textures = textures;
            this.InputReader = inputReader;
            this.MovementManager = new MovementManager();
            this.AttackManager = new AttackManager();

            this.CanJump = true;

            this.MaxVelocity = new Vector2(1, 1);
            this.Acceleration = new Vector2(0, 0);
            this.Gravity = new Vector2(0, 0.1f);
            this.HitboxRectangle = new Rectangle(0, 0, 45, 30);
            this.Position = new Vector2((coordinates.X * 16) - 16, (coordinates.Y * 16) - this.HitboxRectangle.Height);
            this.Velocity = new Vector2(0,0);
            this.Health = 1;

            this.AttackCooldown = TimeSpan.FromSeconds(3);
            this.AttackDuration = TimeSpan.FromSeconds(2);
            this.AttackTimer = TimeSpan.Zero;

            this.IsDead = false;
            this.DeathDuration = TimeSpan.FromSeconds(1.5);
            this.DeathTimer = TimeSpan.Zero;

            this.CanAttack = true;
            this.IsAttacking = false;

            AddAnimations();
            SetAnimations();
            SetHitboxes();

            this.playerState = new PlayerSleepState();
        }
        #endregion

        #region Player methods
        public override void Draw(SpriteBatch spriteBatch)
        {
            this.playerState.Draw(spriteBatch, this.textures, this.Position, this.animations, this.SpriteEffects);
        }

        override public void Update(GameTime gameTime, World world)
        {
            if (!HasNoHealth())
            {
                this.Attack(gameTime);
            }
            this.Move(gameTime, world);            
            this.ChangeState();
            this.playerState.Update(gameTime, animations, this);
            ScoreManager.Score = Score;
        }
        #endregion

        #region Animation Methods
        private void AddAnimations()
        {
            this.animations.Add(new Animation(IDLE_FPS, IDLE_FRAMES));
            this.animations.Add(new Animation(WALK_FPS, WALK_FRAMES ));
            this.animations.Add(new Animation(JUMP_FPS, JUMP_FRAMES));
            this.animations.Add(new Animation(SPIN_FPS, SPIN_FRAMES));
            this.animations.Add(new Animation(SLEEP_FPS, SLEEP_FRAMES));
            this.animations.Add(new Animation(DEAD_FPS, DEAD_FRAMES));
        }

        private void SetAnimations()
        {
            for (int i = 0; i < this.animations.Count; i++)
            {
                this.animations[i].GetFramesFromTextureProperties(textures[i].Width, textures[i].Height, 1);
            }
        }

        private void SetHitboxes()
        {
            this.animations[0].Hitbox = new Rectangle(8, 15, 29, 30);
            this.animations[1].Hitbox = new Rectangle(2, 15, 40, 30);
            this.animations[2].Hitbox = new Rectangle(0, 15, 45, 30);
            this.animations[3].Hitbox = new Rectangle(6, 15, 32, 30);
            this.animations[4].Hitbox = new Rectangle(0, 15, 45, 30);
            this.animations[5].Hitbox = new Rectangle(0, 15, 45, 30);

            this.IdleHitboxWidth = this.animations[0].Hitbox.Width - 1;
        }
        #endregion

        #region StateChanges
        private void ChangeState()
        {
            if (IsSpinning())
            {
                this.playerState = new PlayerSpinState();
            }
            else if (IsWalking())
            {
                SoundManager.PlaySound(Sound.PlayerWalk);
                this.playerState = new PlayerWalkState();
            }
            else
            {
                SoundManager.StopSound(Sound.PlayerWalk);
                this.playerState = new PlayerIdleState();
            }
            if (HasNoHealth())
            {
                this.playerState = new PlayerDeadState();
            }
        }

        private bool IsWalking()
        {
            return this.Velocity.X != 0;
        }

        private bool IsSpinning()
        {
            return this.IsAttacking;
        }

        private bool HasNoHealth()
        {
            return this.Health <= 0;
        }
        #endregion
    }
}
