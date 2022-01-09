using GameDevProject.Entities;
using GameDevProject.Interfaces;

namespace GameDevProject.Input.EnemyAI
{
    class Type1EnemyAI : EnemyAI, IInputReader
    {
        #region Properties
        public bool IsDestinationInput => false;
        #endregion

        #region Constructor
        public Type1EnemyAI(Player player, Type1Enemy enemy, float detectionDistance)
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
            return inputParameters;
        }
        #endregion
    }
}
