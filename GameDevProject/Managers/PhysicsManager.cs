using GameDevProject.Entities;
using GameDevProject.Interfaces;
using GameDevProject.Map;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

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
                        //Debug.WriteLine("Collided with a tile from the left");
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
                        //Debug.WriteLine("Collided with a tile from the right");
                        return true;
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
                    //Debug.WriteLine("Collided with a tile from the top");
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
                    //Debug.WriteLine("Collided with a tile from the bottom");
                    return true;
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
