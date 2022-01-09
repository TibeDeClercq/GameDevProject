using System.Collections.Generic;
using GameDevProject.Entities;
using GameDevProject.Managers;
using GameDevProject.Map;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Levels
{
    class Level
    {
        public World World;

        public List<Entity> Entities;

        public HealthManager HealthManager;

        public EntityCollisionManager CollisionManager;

        public Level(Texture2D worldTileSet, List<Entity> entities, string[,] map)
        {
            this.World = new World(worldTileSet, map);
            this.CollisionManager = new EntityCollisionManager(entities, this.World);
            this.HealthManager = new HealthManager(this.CollisionManager);            

            this.Entities = new List<Entity>();
            foreach (Entity entity in entities)
            {
                this.Entities.Add(entity);
            }
        }
        public Level(Texture2D worldTileSet, string[,] map)
        {
            this.World = new World(worldTileSet, map);
        }
    }
}
