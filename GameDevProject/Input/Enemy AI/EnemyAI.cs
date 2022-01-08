using GameDevProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Input.EnemyAI
{
    class EnemyAI
    {
        protected Player player;
        protected Enemy enemy;

        protected int LocatePlayer(Player player, Enemy enemy)
        {
            if (player.Position.X - enemy.Position.X > 0.01f)
            {
                return 1;
            }
            else if (enemy.Position.X - player.Position.X > 0.01f)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
