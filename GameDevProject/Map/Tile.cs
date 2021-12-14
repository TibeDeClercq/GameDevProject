using Microsoft.Xna.Framework;
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
        public int identifier { get; set; }
        public bool isCollidable { get; set; }
        public bool isFloor { get; set; }
        public bool isCeiling { get; set; } 
        public bool isBackground { get; set; }
        private int[] collidable = {8, 10, 11, 16, 18, 19, 24, 26, 27};
        private int[] floors = { 0, 1, 2, 3, 24, 25, 26, 27, 28, 29, 30, 32, 33, 38, 39, 40, 41, 46, 47};
        private int[] ceilings = { 16, 17, 18, 19, 24, 25, 26, 27};

        public Tile(Rectangle sourceRectangle, Vector2 position, int identifier)
        {
            this.SourceRectangle = sourceRectangle;
            this.Position = position;
            this.identifier = identifier;

            if (Array.IndexOf(collidable, identifier) != -1)
            {
                this.isCollidable = true;
            }
            else if (Array.IndexOf(floors, identifier) != -1)
            {
                this.isFloor = true;
            }
            else if (Array.IndexOf(ceilings, identifier) != -1)
            {
                this.isCeiling = true;
            }
            else
            {
                this.isBackground = true;
            }

        }
    }
}
