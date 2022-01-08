using GameDevProject.Entities;
using GameDevProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Input.EnemyAI
{
    class Type1EnemyAI : EnemyAI, IInputReader
    {      
        public Type1EnemyAI(Player player, Type1Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
        }

        public bool IsDestinationInput => false;

        public InputParameters ReadInput()
        {
            InputParameters inputParameters = new InputParameters();

            switch (LocatePlayer(this.player, this.enemy))
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
    }
}
