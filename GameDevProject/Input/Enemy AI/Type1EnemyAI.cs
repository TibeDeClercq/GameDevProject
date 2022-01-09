using GameDevProject.Entities;
using GameDevProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Input.EnemyAI
{
    class Type1EnemyAI : EnemyAI, IInputReader
    {      
        public Type1EnemyAI(Player player, Type1Enemy enemy, float detectionDistance)
        {
            this.player = player;
            this.enemy = enemy;
            this.detectionDistance = detectionDistance;
        }

        public bool IsDestinationInput => false;

        public InputParameters ReadInput()
        {
            InputParameters inputParameters = GiveDirection();
            return inputParameters;
        }        
    }
}
