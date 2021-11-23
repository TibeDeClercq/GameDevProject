using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Map
{
    class WorldTile
    {
        public Vector2 Position = new Vector2(0,0);
        public Rectangle SourceRectangle { get; set; }

        public WorldTile(Rectangle sourceRectangle)
        {
            SourceRectangle = sourceRectangle;
        }
    }
}
