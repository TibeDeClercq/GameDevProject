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
        protected float detectionDistance;

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
    }
}
