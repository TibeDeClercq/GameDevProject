using Microsoft.Xna.Framework;

using GameDevProject.Interfaces;
using GameDevProject.Map;

namespace GameDevProject.Managers
{
    class PhysicsManager
    {
        #region Public methods
        public static void MoveRight(IMovable movable, World world)
        {
            if (!IntersectsFromLeft(movable, world))
            {
                movable.Velocity = new Vector2(movable.MaxVelocity.X, movable.Velocity.Y);
            }
        }

        public static void MoveLeft(IMovable movable, World world)
        {
            if (!IntersectsFromRight(movable, world))
            {
                movable.Velocity = new Vector2(-movable.MaxVelocity.X, movable.Velocity.Y);
            }
        }

        public static void AddGravity(IMovable movable, World world)
        {
            if (!IntersectsFromTop(movable, world))
            {
                movable.CanJump = false;
                movable.Acceleration += movable.Gravity;
            }
            else
            {
                movable.IsJumping = false;
                movable.CanJump = true;
                if (movable.Acceleration.Y > 0)
                {
                    movable.Acceleration = Vector2.Zero;
                }
            }
        }

        public static void AddJump(IMovable movable, World world)
        {
            if (movable.IsJumping)
            {
                movable.CanJump = false;
                if (IntersectsFromBottom(movable, world))
                {
                    movable.IsJumping = false;
                    movable.Acceleration = Vector2.Zero;
                }
            }

        }

        public static void Drop(IMovable movable, World world)
        {
            ChangeDropDownTile(movable, world);
        }
        #endregion

        #region Private methods
        private static bool IntersectsFromLeft(IMovable movable, World world)
        {
            foreach (Tile tile in world.GetTiles())
            {
                if (movable.HitboxRectangle.Intersects(tile.HitboxRectangle))
                {
                    if (tile.IsLeftCollide && !MovableLowerThanTile(movable, tile))
                    {
                        if ((movable.HitboxRectangle.X + movable.HitboxRectangle.Width >= tile.HitboxRectangle.X) && (movable.HitboxRectangle.X + movable.HitboxRectangle.Width <= tile.HitboxRectangle.X + tile.HitboxRectangle.Width - 2)) //Herwerken, nog een aantal bugs
                        {
                            movable.Position = new Vector2(tile.Position.X - movable.IdleHitboxWidth, movable.Position.Y);
                        }
                        else if (tile.IsRightCollide)
                        {
                            movable.Position = new Vector2(movable.Position.X + 1, movable.Position.Y);
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool IntersectsFromRight(IMovable movable, World world)
        {
            foreach (Tile tile in world.GetTiles())
            {
                if (movable.HitboxRectangle.Intersects(tile.HitboxRectangle))
                {
                    if (tile.IsRightCollide && !MovableLowerThanTile(movable, tile))
                    {
                        if ((movable.HitboxRectangle.X <= tile.HitboxRectangle.X + tile.HitboxRectangle.Width) && (movable.HitboxRectangle.X >= tile.HitboxRectangle.X + tile.HitboxRectangle.Width - 1))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private static bool IntersectsFromTop(IMovable movable, World world)
        {
            foreach (Tile tile in world.GetTiles())
            {
                if (tile.IsTopCollide && movable.HitboxRectangle.Intersects(tile.HitboxRectangle) && MovableLowerThanTile(movable, tile))
                {
                    movable.Position = new Vector2(movable.HitboxRectangle.X, tile.HitboxRectangle.Y - movable.HitboxRectangle.Height);
                    return true;
                }
                if (tile.CanDropDown && movable.HitboxRectangle.Intersects(tile.HitboxRectangle))
                {
                    if (movable.Position.Y < tile.Position.Y)
                    {
                        tile.IsTopCollide = true;
                    }
                }
            }
            return false;
        }

        private static bool IntersectsFromBottom(IMovable movable, World world)
        {
            foreach (Tile tile in world.GetTiles())
            {
                if (tile.IsBottomCollide && movable.HitboxRectangle.Intersects(tile.HitboxRectangle))
                {
                    if((movable.HitboxRectangle.Y <= tile.HitboxRectangle.Y + tile.HitboxRectangle.Height) && (movable.HitboxRectangle.Y >= tile.HitboxRectangle.Y + tile.HitboxRectangle.Height - 1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool MovableLowerThanTile(IMovable movable, Tile tile)
        {
            if (tile.HitboxRectangle.Y >= movable.HitboxRectangle.Y + movable.HitboxRectangle.Height - 4)
            {
                return true;
            }
            return false;
        }

        private static void ChangeDropDownTile(IMovable movable, World world)
        {
            foreach (Tile tile in world.GetTiles())
            {
                if(tile.CanDropDown && movable.HitboxRectangle.Intersects(tile.HitboxRectangle))
                {
                    tile.IsTopCollide = false;
                }
            }
        }
        #endregion
    }
}
