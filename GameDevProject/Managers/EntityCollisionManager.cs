using GameDevProject.Entities;
using GameDevProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Managers
{
    class EntityCollisionManager
    {
        public  List<Entity> Entities;
        public  Entity Player;

        public EntityCollisionManager(List<Entity> entities)
        {
            this.Entities = entities;

            foreach(Entity entity in entities)
            {
                if (entity is Player)
                {
                    this.Player = entity;
                }
            }            
        }

        public  Entity CheckCollision()
        {
            foreach (Entity entity in Entities)
            {
                var movableEntity = entity as IMovable;
                var movablePlayer = Player as IMovable;

                if (movableEntity.HitboxRectangle.Intersects(movablePlayer.HitboxRectangle) && entity != Player && entity.Health > 0)
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
