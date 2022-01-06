using GameDevProject.Entities;
using GameDevProject.Interfaces;
using GameDevProject.Map;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDevProject.Managers
{
    class EntityCollisionManager
    {
        #region Properties
        private World World;
        public List<Entity> Entities;
        public Entity Player;
        #endregion

        #region Constructor
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
        #endregion

        #region Collision Methods
        public Entity CheckCollision()
        {
            foreach (Entity entity in Entities)
            {
                var movablePlayer = Player as IMovable;
                var movableEntity = entity as IMovable;
                if (movableEntity.HitboxRectangle.Intersects(movablePlayer.HitboxRectangle) && entity != Player && entity.Health > 0)
                {
                    return entity;
                }                
            }

            foreach (Tile tile in World.GetTiles())
            {
                if (tile.IsTrapCollide)
                {
                    var movablePlayer = Player as IMovable;
                    if (movablePlayer.HitboxRectangle.Intersects(tile.HitboxRectangle))
                    {
                        return Player;
                    }
                }
            }

            return null;
        }
        #endregion
    }
}
