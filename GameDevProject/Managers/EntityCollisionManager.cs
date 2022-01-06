using GameDevProject.Entities;
using GameDevProject.Interfaces;
using GameDevProject.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Managers
{
    class EntityCollisionManager
    {
        private World World;
        public List<Entity> Entities;
        public Entity Player;

        public EntityCollisionManager(List<Entity> entities, World world)
        {
            this.Entities = entities;
            this.World = world;

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

            foreach (Tile tile in this.World.GetTiles())
            {
                if (tile.IsTrapCollide)
                {
                    IMovable movable = Player as IMovable;
                    if (movable.HitboxRectangle.Intersects(tile.HitboxRectangle))
                    {
                        return Player;
                    }
                }
            }

            return null;
        }
    }
}
