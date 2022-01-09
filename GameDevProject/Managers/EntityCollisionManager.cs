using System.Collections.Generic;
using GameDevProject.Entities;
using GameDevProject.Interfaces;
using GameDevProject.Map;

namespace GameDevProject.Managers
{
    class EntityCollisionManager
    {
        #region Properties
        private World world;
        public List<Entity> Entities;
        public Entity Player;
        #endregion

        #region Constructor
        public EntityCollisionManager(List<Entity> entities, World world)
        {
            this.Entities = entities;
            this.world = world;

            foreach(Entity entity in entities)
            {
                if (entity is Player)
                {
                    this.Player = entity;
                }
            }            
        }
        #endregion

        #region Public methods
        public Entity CheckCollision()
        {
            foreach (Entity entity in Entities)
            {
                var movablePlayer = this.Player as IHitbox;
                var movableEntity = entity as IHitbox;
                if (movableEntity.HitboxRectangle.Intersects(movablePlayer.HitboxRectangle) && entity != this.Player && entity.Health > 0)
                {
                    return entity;
                }         
            }

            foreach (Tile tile in world.GetTiles())
            {
                if (tile.IsTrapCollide)
                {
                    var movablePlayer = this.Player as IHitbox;
                    if (movablePlayer.HitboxRectangle.Intersects(tile.HitboxRectangle))
                    {
                        return this.Player;
                    }
                }
            }

            return null;
        }
        #endregion
    }
}
