using System;
using System.Collections.Generic;
using System.Text;

using GameDevProject.Entities;
using GameDevProject.Managers;
using GameDevProject.Map;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Levels
{
    class Level
    {
        public World world;

        public List<Entity> entities;

        public HealthManager healthManager;

        public EntityCollisionManager collisionManager;

        public Level(Texture2D worldTileSet, List<Entity> entities, string[,] map, HealthManager healthManager, EntityCollisionManager collisionManager)
        {
            this.world = new World(worldTileSet, map);
            this.healthManager = healthManager;
            this.collisionManager = collisionManager;

            this.entities = new List<Entity>();
            foreach (Entity entity in entities)
            {
                this.entities.Add(entity);
            }
        }
        public Level(Texture2D worldTileSet, string[,] map)
        {
            this.world = new World(worldTileSet, map);
        }
    }
}
