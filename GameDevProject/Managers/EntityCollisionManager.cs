using GameDevProject.Entities;
using GameDevProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Managers
{
    class EntityCollisionManager
    {
        public  List<Entity> entities;
        private  Entity player;

        public EntityCollisionManager(List<Entity> entities)
        {
            this.entities = entities;

            foreach(Entity entity in entities)
            {
                if (entity.isPlayer)
                {
                    this.player = entity;
                }
            }            
        }

        public  Entity CheckCollision()
        {
            foreach (Entity entity in entities)
            {
                var movableEntity = entity as IMovable;
                var movablePlayer = player as IMovable;

                if (movableEntity.HitboxRectangle.Intersects(movablePlayer.HitboxRectangle) && entity != player && entity.Health > 0)
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
