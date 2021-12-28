using GameDevProject.Entities.Animations;
using GameDevProject.Interfaces;
using GameDevProject.Managers;
using GameDevProject.Map;
using GameDevProject.States.Type1EnemyStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Entities
{
    class Type1Enemy : Entity , IMovable , IHitbox
    {
        #region Enemy Properties
        public MovementManager MovementManager;

        private IType1EnemyState enemyState;

        private const int IDLE_FRAMES = 2;

        private const int IDLE_FPS = 5;
        public SpriteEffects spriteEffects { get; set; }
        #endregion

        #region Constructor
        public Type1Enemy(List<Texture2D> textures)
        {
            this.textures = textures;
            this.Position = new Vector2(150, 10);
            this.MaxVelocity = new Vector2(0.5f, 1);
            this.Velocity = new Vector2(0, 0);
            this.HitboxRectangle = new Rectangle((int)this.Position.X, (int)this.Position.Y, 45, 45);

            this.MovementManager = new MovementManager();
            this.enemyState = new Type1EnemyIdleState();
            AddAnimations();
            SetAnimations();
        }
        #endregion

        #region IMobale Implementation
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

        #region Enemy Methods
        public override void Draw(SpriteBatch spriteBatch)
        {
            this.enemyState.Draw(spriteBatch, this.textures, this.Position, this.animations, this.spriteEffects);
        }
        public override void Update(GameTime gameTime, World world)
        {
            this.enemyState.Update(gameTime, this.animations);
            Move(gameTime, world);
        }
        #endregion

        private void AddAnimations()
        {
            this.animations.Add(new Animation(IDLE_FPS));
        }

        private void SetAnimations()
        {
            this.animations[0].GetFramesFromTextureProperties(textures[0].Width, textures[0].Height, IDLE_FRAMES, 1);
        }        
    }
}
