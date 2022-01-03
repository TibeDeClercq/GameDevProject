using System;
using System.Collections.Generic;
using System.Text;

using GameDevProject.Entities;
using GameDevProject.Map;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Levels
{
    class Level
    {
        public World world;

        public List<Entity> entities;

        public Level(Texture2D worldTileSet, List<Entity> entities, string[,] map)
        {
            this.world = new World(worldTileSet, map);

            this.entities = new List<Entity>();
            foreach (Entity entity in entities)
            {
                this.entities.Add(entity);
            }
        }
    }
}
