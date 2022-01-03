using GameDevProject.Entities;
using GameDevProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Managers
{
    class EntityCollisionManager
    {
        private  List<Entity> entities;
        public  Entity player;

        public EntityCollisionManager(List<Entity> entities, Entity player)
        {
            this.entities = entities;
            this.player = player;
        }

        public  Entity CheckCollision()
        {
            foreach (Entity entity in entities)
            {
                var movableEntity = entity as IMovable;
                var movablePlayer = player as IMovable;

                if (movableEntity.HitboxRectangle.Intersects(movablePlayer.HitboxRectangle) && entity != player)
                {
                    return entity;
                }                
            }
            return null;
        }

        public  bool CheckCollisionFromTop(Entity entity)
        {
            return true;
        }
    }
}
