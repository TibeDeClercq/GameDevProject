﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Map
{
    class Tile
    {
        public Vector2 Position = new Vector2(0, 0);
        public Rectangle SourceRectangle { get; set; }

        public Tile(Rectangle sourceRectangle, Vector2 position)
        {
            this.SourceRectangle = sourceRectangle;
            this.Position = position;
        }
    }
}
