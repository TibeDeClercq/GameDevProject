using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Map
{
    class WorldTile
    {
        public Rectangle SourceRectangle { get; set; }

        public WorldTile(Rectangle sourceRectangle)
        {
            SourceRectangle = sourceRectangle;
        }
    }
}
