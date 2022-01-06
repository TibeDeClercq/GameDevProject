using GameDevProject.Entities;
using GameDevProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDevProject.Managers
{
    class HealthManager
    {
        public void UpdateHealth(EntityCollisionManager collisionManager)
        {
            Entity entity = collisionManager.CheckCollision();
            Player player = collisionManager.Player as Player;

            if (entity != null)
            {
                if (entity.Health > 0 && player.IsAttacking)
                {
                    entity.Health--;
                }
                else
                {
                    if (player.Health > 0 && !player.IsAttacking)
                    {
                        player.Health--;
                    }
                }

                if (entity is Player && entity.Health > 0)
                {
                    entity.Health--;
                }
            }
        }
    }
}
