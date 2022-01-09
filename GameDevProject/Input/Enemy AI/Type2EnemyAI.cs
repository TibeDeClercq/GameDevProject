using GameDevProject.Entities;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;

namespace GameDevProject.Input.EnemyAI
{
    class Type2EnemyAI : EnemyAI, IInputReader
    {
        #region Properties
        private TimeSpan JumpRate = TimeSpan.FromSeconds(1);
        private TimeSpan Timer = TimeSpan.Zero;

        private bool canJump = false;
        #endregion

        public Type2EnemyAI(Player player, Type2Enemy enemy, float detectionDistance)
        {
            this.player = player;
            this.enemy = enemy;
            this.detectionDistance = detectionDistance;
        }

        public bool IsDestinationInput => false;

        public InputParameters ReadInput()
        {
            InputParameters inputParameters = GiveDirection();

            if (canJump && inputParameters.DirectionInput.X != 0)
            {
                inputParameters.DirectionInput.Y = 1;
            }

            return inputParameters;
        }

        #region Private Methods
        public void TryJump(GameTime gameTime)
        {
            if (JumpRate > Timer)
            {
                Timer += gameTime.ElapsedGameTime;
                canJump = false;
            }
            else
            {
                Timer = TimeSpan.Zero;
                canJump = true;                
            }
        }
        #endregion
    }
}
