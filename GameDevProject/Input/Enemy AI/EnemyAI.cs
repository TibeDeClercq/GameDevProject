using Blob.Entities;

namespace Blob.Input.EnemyAI
{
    class EnemyAI
    {
        #region Properties
        protected Player player;
        protected Enemy enemy;
        protected float detectionDistance;
        #endregion

        #region Private Methods
        protected int LocatePlayer(Player player, Enemy enemy, float detectionDistance)
        {
            if (player.Position.Y - enemy.Position.Y < 32 && player.Position.Y - enemy.Position.Y > -90)
            {
                if (player.Position.X - enemy.Position.X > 0.01f && player.Position.X - enemy.Position.X <= detectionDistance)
                {
                    return 1;
                }
                else if (enemy.Position.X - player.Position.X > 0.01f && enemy.Position.X - player.Position.X <= detectionDistance)
                {
                    return -1;
                }
            }
            return 0;
        }

        protected InputParameters GiveDirection()
        {
            InputParameters inputParameters = new InputParameters();

            switch (LocatePlayer(this.player, this.enemy, this.detectionDistance))
            {
                case -1:
                    inputParameters.DirectionInput.X -= 1;
                    break;
                case 1:
                    inputParameters.DirectionInput.X += 1;
                    break;
                case 0:
                    inputParameters.DirectionInput.X = 0;
                    break;
            }

            return inputParameters;
        }
        #endregion
    }
}
