using System;
using System.Collections.Generic;
using System.Text;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GameDevProject.Entities.Animations;
using GameDevProject.Managers;
using GameDevProject.States.PlayerStates;

namespace GameDevProject.Entities
{
    class Player : Entity, IMovable
    {
        #region IMovable implementation
        public Vector2 MaxVelocity { get; set; }
        public IInputReader InputReader { get; set; }
        public float MaxAcceleration { get; set; }
        public float MaxJumpHeight { get; set; }
        public SpriteEffects spriteEffects { get; set; }
        public Vector2 Velocity { get; set; }
        public float Acceleration { get; set; }

        public void Move(GameTime gameTime)
        {
            movementManager.Move(this, gameTime);
        }

        #endregion

        #region Player properties
        public MovementManager movementManager;

        private IPlayerState playerState;
        #endregion

        #region Player constructors
        public Player(List<Texture2D> textures, IInputReader inputReader)
        {
            this.textures = textures;
            this.InputReader = inputReader;
            this.movementManager = new MovementManager();
            
            this.Position = new Vector2(1, 50);
            this.MaxVelocity = new Vector2(2, 2); //horizontal , vertical
            this.MaxAcceleration = 5;
            this.MaxJumpHeight = 5;
            this.Acceleration = 9.81f;
            this.Velocity = new Vector2(0,0);

            AddAnimations();
            SetAnimations();

            playerState = new PlayerWalkingState();
        }
        #endregion

        #region Player methods
        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draw the animation
            playerState.Draw(spriteBatch, this.textures, this.Position, this.animations, this.spriteEffects);
        }

        override public void Update(GameTime gameTime)
        {
            Move(gameTime);
            //Update the animation
            playerState.Update(gameTime, animations);
        }
        #endregion

        private void AddAnimations()
        {
            this.animations.Add(new Animation(10));
            this.animations.Add(new Animation(10));
        }

        private void SetAnimations()
        {
            this.animations[0].GetFramesFromTextureProperties(textures[0].Width, textures[0].Height, 4, 1);
            this.animations[1].GetFramesFromTextureProperties(textures[1].Width, textures[1].Height, 2, 1);
        }
    }
}
