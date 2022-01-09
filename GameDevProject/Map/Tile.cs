using System;
using Microsoft.Xna.Framework;
using GameDevProject.Interfaces;

namespace GameDevProject.Map
{
    class Tile : IHitbox
    {
        #region Properties
        public Vector2 Position { get; set; } = new Vector2(0, 0);
        public Rectangle SourceRectangle { get; set; }
        public Rectangle HitboxRectangle { get; set; }
        public int Identifier { get; set; }
        public bool IsBackground { get; set; }
        public bool IsLeftCollide { get; set; }
        public bool IsRightCollide { get; set; }
        public bool IsTopCollide { get; set; }
        public bool IsBottomCollide { get; set; }
        public bool IsFinishCollide { get; set; }
        public bool IsTrapCollide { get; set; }
        public bool CanDropDown { get; set; }

        private int[] leftCollidable = { 0, 3, 8, 11, 16, 19, 27, 24 };
        private int[] rightCollidable = { 2, 10, 11, 18, 19, 27, 26 };
        private int[] topCollidable = { 0, 1, 2, 3, 28, 29, 30, 24, 25, 26, 27 };
        private int[] bottomCollidable = { 16, 17, 18, 19, 24, 25, 26, 27 };
        private int[] finishCollidable = { 4, 5, 6, 12, 13, 14, 20, 21, 22 };
        private int[] trapCollidable = { 43 };
        private int[] dropDownable = { 28, 29, 30, 39, 47 };
        #endregion

        #region Constructor
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
            if (Array.IndexOf(finishCollidable, identifier) != -1)
            {
                this.IsFinishCollide = true;
            }
            if (Array.IndexOf(trapCollidable, identifier) != -1)
            {
                this.IsTrapCollide = true;
            }
            if (Array.IndexOf(dropDownable, identifier) != -1)
            {
                this.CanDropDown = true;
            }
            else
            {
                this.IsBackground = true;
            }
        }
        #endregion
    }
}
