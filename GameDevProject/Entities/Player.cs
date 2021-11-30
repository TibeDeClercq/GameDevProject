using System;
using System.Collections.Generic;
using System.Text;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GameDevProject.Entities.Animations;
using GameDevProject.Managers;

namespace GameDevProject.Entities
{
    class Player : Entity, IMovable
    {
        #region IMovable implementation
        public Vector2 MaxVelocity { get; set; }
        public IInputReader InputReader { get; set; }
        public float MaxAcceleration { get; set; }
        public float MaxJumpHeight { get; set; }

        public void Move()
        {
            movementManager.Move(this);
        }

        #endregion

        #region Player properties
        public MovementManager movementManager;
        #endregion

        #region Player constructors
        public Player(Texture2D texture, IInputReader inputReader)
        {
            this.texture = texture;
            this.InputReader = inputReader;
            this.movementManager = new MovementManager();
            this.animation = new Animation(10);
            
            this.Position = new Vector2(1, 100);
            this.MaxVelocity = new Vector2(2, 2); //horizontal , vertical
            this.MaxAcceleration = 5;
            this.MaxJumpHeight = 5;
            
            //TODO: changes with character spritesheet
            this.animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 4, 1);
        }
        #endregion

        #region Player methods
        override public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);
        }
        #endregion
    }
}
