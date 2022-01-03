using GameDevProject.Entities;
using GameDevProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDevProject.Managers
{
    static class HealthManager
    {
        public static void UpdateHealth()
        {
            Entity entity = EntityCollisionManager.CheckCollision();
            Player player = EntityCollisionManager.Player as Player;

            if (entity != null)
            {
                bool collidesFromTop = EntityCollisionManager.CheckCollisionFromTop(entity);

                if (entity.Health > 0 && player.IsAttacking)
                {
                    entity.Health--;
                }
                else
                {
                    if (player.Health > 0)
                    {
                        player.Health--;
                    }
                }
            }
        }
    }
}
