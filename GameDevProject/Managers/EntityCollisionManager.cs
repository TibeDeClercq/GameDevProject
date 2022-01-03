using GameDevProject.Entities;
using GameDevProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Managers
{
    static class EntityCollisionManager
    {
        public static List<Entity> Entities;
        public static Entity Player;

        public static Entity CheckCollision()
        {
            foreach (Entity entity in Entities)
            {
                var movableEntity = entity as IMovable;
                var movablePlayer = Player as IMovable;

                if (movableEntity.HitboxRectangle.Intersects(movablePlayer.HitboxRectangle) && entity != Player)
                {
                    return entity;
                }                
            }
            return null;
        }

        public static bool CheckCollisionFromTop(Entity entity)
        {
            return true;
        }
    }
}
