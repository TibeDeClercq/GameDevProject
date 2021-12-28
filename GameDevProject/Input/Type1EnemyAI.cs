using GameDevProject.Entities;
using GameDevProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Input
{
    class Type1EnemyAI : IInputReader
    {
        private Player player;
        private Type1Enemy enemy;

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
                case 1:
                    inputParameters.DirectionInput.X -= 1;
                    break;
                case -1:
                    inputParameters.DirectionInput.X += 1;
                    break;
            }

            return inputParameters;
        }

        private int LocatePlayer(Player player, Type1Enemy enemy)
        {
            if (player.Position.X - enemy.Position.X > 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
