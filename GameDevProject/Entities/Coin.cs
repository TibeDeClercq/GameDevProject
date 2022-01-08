using GameDevProject.Entities.Animations;
using GameDevProject.Interfaces;
using GameDevProject.Map;
using GameDevProject.States.CoinStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameDevProject.Entities
{
    class Coin : Entity, IHitbox, IKillable
    {
        #region Interface Implementation
        public Rectangle HitboxRectangle { get; set; }
        public bool IsDead { get; set; }
        public TimeSpan DeathTimer { get; set ; }
        public TimeSpan DeathDuration { get; set; }
        #endregion

        #region Private Properties
        private IEntityState coinState;
        private const int COIN_FRAMES = 14;
        private const int COIN_FPS = 15;

        public int SpinSpeed = 84;
        private bool SpeedChanged = false;
        #endregion

        #region Constructor
        public Coin(List<Texture2D> textures, Vector2 coordinates)
        {
            this.textures = textures;
            this.HitboxRectangle = new Rectangle((int)((coordinates.X * 16) - 16), (int)((coordinates.Y * 16) - 16), 16, 16);
            this.Position = new Vector2((coordinates.X * 16) - 16, (coordinates.Y * 16) - this.HitboxRectangle.Height);
            this.Health = 1;

            this.IsDead = false;
            this.DeathDuration = TimeSpan.FromSeconds(0.8);
            this.DeathTimer = TimeSpan.Zero;

            AddAnimations();
            SetAnimations();
            SetHitboxes();

            this.coinState = new CoinDefaultState();
        }
        #endregion

        #region Coin Methods
        public override void Draw(SpriteBatch spriteBatch)
        {
            this.coinState.Draw(spriteBatch, this.textures, this.Position, this.animations, SpriteEffects.None);
        }

        public override void Update(GameTime gameTime, World world)
        {
            this.coinState.Update(gameTime, animations, this);
            this.ChangeSpinSpeed();
        }        

        private void ChangeSpinSpeed()
        {
            if (this.Health <= 0 && !SpeedChanged)
            {
                SpeedChanged = true;
                AnimationFrame currentframe = this.animations[0].CurrentFrame;
                this.animations[0] = new Animation(SpinSpeed, COIN_FRAMES);
                SetAnimations();
                SetHitboxes();
                this.animations[0].CurrentFrame = currentframe;

            }
        }
        #endregion

        #region Animation Methods
        private void AddAnimations()
        {
            this.animations.Add(new Animation(COIN_FPS, COIN_FRAMES));
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
            this.animations[0].Hitbox = new Rectangle(0, 0, 16, 16);
        }
        #endregion
    }
}
