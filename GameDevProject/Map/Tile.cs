using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

using GameDevProject.Interfaces;

namespace GameDevProject.Map
{
    class Tile : IHitbox
    {
        public Vector2 Position { get; set; } = new Vector2(0, 0);
        public Rectangle SourceRectangle { get; set; }
        public Rectangle HitboxRectangle { get; set;}
        public int Identifier { get; set; }
        public bool IsCollidable { get; set; }
        public bool IsFloor { get; set; }
        public bool IsCeiling { get; set; } 
        public bool IsBackground { get; set; }
        private int[] collidable = {8, 10, 11, 16, 18, 19, 24, 26, 27};
        private int[] floors = { 0, 1, 2, 3, 24, 25, 26, 27, 28, 29, 30, 32, 33, 38, 39, 40, 41, 46, 47};
        private int[] ceilings = { 16, 17, 18, 19, 24, 25, 26, 27};

        #region IHitbox implementation
        public Vector2 Size { get; set; }
        #endregion

        public Tile(Rectangle sourceRectangle, Vector2 position, int identifier)
        {
            this.SourceRectangle = sourceRectangle;
            this.HitboxRectangle = new Rectangle((int)position.X, (int)position.Y, sourceRectangle.Width, sourceRectangle.Height);
            this.Position = position;
            this.Identifier = identifier;

            if (Array.IndexOf(collidable, identifier) != -1)
            {
                this.IsCollidable = true;
            }
            else if (Array.IndexOf(floors, identifier) != -1)
            {
                this.IsFloor = true;
            }
            else if (Array.IndexOf(ceilings, identifier) != -1)
            {
                this.IsCeiling = true;
            }
            else
            {
                this.IsBackground = true;
            }
        }
    }
}
