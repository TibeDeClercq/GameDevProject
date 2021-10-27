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
        public Vector2 Speed { get; set; }
        public IInputReader InputReader { get; set; }

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
            this.animation = new Animation();
            this.Position = new Vector2(1, 1);
            this.Speed = new Vector2(2, 2);
            this.movementManager = new MovementManager();
            this.animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 5, 2);
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
