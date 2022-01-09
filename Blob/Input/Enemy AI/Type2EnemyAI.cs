using System;

using Microsoft.Xna.Framework;

using Blob.Entities;
using Blob.Interfaces;

namespace Blob.Input.EnemyAI
{
    class Type2EnemyAI : EnemyAI, IInputReader
    {
        #region Properties
        private TimeSpan jumpRate = TimeSpan.FromSeconds(1);
        private TimeSpan timer = TimeSpan.Zero;
        private bool canJump = false;
        public bool IsDestinationInput => false;
        #endregion

        #region Constructor
        public Type2EnemyAI(Player player, Type2Enemy enemy, float detectionDistance)
        {
            this.player = player;
            this.enemy = enemy;
            this.detectionDistance = detectionDistance;
        }
        #endregion

        #region Public Methods
        public InputParameters ReadInput()
        {
            InputParameters inputParameters = GiveDirection();

            if (canJump && inputParameters.DirectionInput.X != 0)
            {
                inputParameters.DirectionInput.Y = 1;
            }

            return inputParameters;
        }
        #endregion

        #region Private Methods
        public void TryJump(GameTime gameTime)
        {
            if (jumpRate > timer)
            {
                timer += gameTime.ElapsedGameTime;
                canJump = false;
            }
            else
            {
                timer = TimeSpan.Zero;
                canJump = true;                
            }
        }
        #endregion
    }
}
