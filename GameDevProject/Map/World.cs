using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Map
{
    class World //op betere locatie zetten?
    {
        private string name;
        private int id;

        private char[][] worldTiles;

        public World(char[][] worldTiles)
        {
            this.worldTiles = worldTiles;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }

    }
}
