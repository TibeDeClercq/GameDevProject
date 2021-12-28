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
        public bool IsBackground { get; set; }
        public bool IsLeftCollide { get; set; }
        public bool IsRightCollide { get; set; }
        public bool IsTopCollide { get; set; }
        public bool IsBottomCollide { get; set; }

        private int[] leftCollidable = { 0, 3, 8, 11, 16, 19 };
        private int[] rightCollidable = {2, 10, 11, 18, 19 };
        private int[] topCollidable = { 0, 1, 2, 3 };
        private int[] bottomCollidable = { 16, 17, 18, 19 };

        public Tile(Rectangle sourceRectangle, Vector2 position, int identifier)
        {
            this.SourceRectangle = sourceRectangle;
            this.HitboxRectangle = new Rectangle((int)position.X, (int)position.Y, sourceRectangle.Width, sourceRectangle.Height);
            this.Position = position;
            this.Identifier = identifier;

            if (Array.IndexOf(leftCollidable, identifier) != -1)
            {
                this.IsLeftCollide = true;
            }
            if (Array.IndexOf(rightCollidable, identifier) != -1)
            {
                this.IsRightCollide = true;
            }
            if (Array.IndexOf(topCollidable, identifier) != -1)
            {
                this.IsTopCollide = true;
            }
            if (Array.IndexOf(bottomCollidable, identifier) != -1)
            {
                this.IsBottomCollide = true;
            }
            else
            {
                this.IsBackground = true;
            }
        }
    }
}
