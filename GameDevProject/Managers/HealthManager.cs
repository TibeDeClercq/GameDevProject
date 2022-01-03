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
            Player player = collisionManager.player as Player;

            if (entity != null)
            {
                bool collidesFromTop = collisionManager.CheckCollisionFromTop(entity);

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
            }
        }
    }
}
