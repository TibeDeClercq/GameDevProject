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
        private static bool canJump = true;
        public static List<Entity> entities;
        //https://stackoverflow.com/questions/43024877/xna-monogame-platformer-jumping-physics-and-collider-issue

        public static void MoveRight(IMovable movable, World world)
        {
            //begin test Tibe
            if (!IntersectsFromLeft(movable, world))
            {
                movable.Velocity = new Vector2(movable.MaxVelocity.X, movable.Velocity.Y);
            }
            //einde test Tibe
                        
        }
        public static void MoveLeft(IMovable movable, World world)
        {
            //begin test Tibe
            if (!IntersectsFromRight(movable, world))
            {
                movable.Velocity = new Vector2(-movable.MaxVelocity.X, movable.Velocity.Y);
            }
            //einde test Tibe

        }

        public static void AddGravity(IMovable movable, World world)
        {
            if(!IntersectsFromTop(movable, world))
            {
                movable.CanJump = false;
                movable.Acceleration += new Vector2(0, 0.1f);
            }
            else
            {
                movable.IsJumping = false;
                movable.CanJump = true;
                movable.Acceleration = Vector2.Zero;
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

        private static bool IntersectsFromLeft(IMovable movable, World world)
        {
            foreach (Tile tile in world.GetTiles())
            {
                if (tile.IsLeftCollide && movable.HitboxRectangle.Intersects(tile.HitboxRectangle))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IntersectsFromRight(IMovable movable, World world)
        {
            foreach (Tile tile in world.GetTiles())
            {
                if (tile.IsRightCollide && movable.HitboxRectangle.Intersects(tile.HitboxRectangle))
                {
                    Debug.WriteLine("Collided with a tile from the right");
                    return true;
                }
            }
            return false;
        }

        private static bool IntersectsFromTop(IMovable movable, World world)
        {
            foreach (Tile tile in world.GetTiles())
            {
                if (tile.IsTopCollide && movable.HitboxRectangle.Intersects(tile.HitboxRectangle))
                {
                    movable.Position = new Vector2(movable.HitboxRectangle.X, tile.HitboxRectangle.Y - movable.HitboxRectangle.Height + 1);
                    return true;
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
                    return true;
                }
            }
            return false;
        }
    }
}
