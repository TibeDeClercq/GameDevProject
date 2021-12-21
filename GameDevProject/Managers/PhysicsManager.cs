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
            movable.Velocity = new Vector2(movable.MaxVelocity.X, movable.Velocity.Y);
        }

        public static void MoveLeft(IMovable movable, World world)
        {
            movable.Velocity = new Vector2(-movable.MaxVelocity.X, movable.Velocity.Y);
        }

        public static void Jump(IMovable movable, World world, GameTime gameTime)
        {
            if (canJump)
            {
                canJump = false;
                movable.Velocity = new Vector2(0, -movable.MaxJumpHeight);
            }
            canJump = CheckFloorCollision(movable, world);
        }

        public static void AddGravity(IMovable movable, World world, GameTime gameTime)
        {
            if (!CheckFloorCollision(movable, world))
            {
                movable.Velocity += new Vector2(0, movable.Acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            else
            {
                movable.Velocity = new Vector2(0);
            }
        }

        private static bool CheckFloorCollision(IMovable movable, World world)
        {
            foreach (Tile tile in world.GetTiles())
            {                
                if (tile.isFloor && IntersectsFromTop(movable.hitBox, tile.hitbox))
                {
                    //Debug.WriteLine($"Colliding with rectangle {tile.hitbox.X}, {tile.hitbox.Y}");
                    movable.Position = new Vector2(movable.Position.X, tile.hitbox.Y - movable.hitBox.Height + 1f);                    
                    return true;                  
                }
            }
            return false;
        }

        private static bool IntersectsFromTop(Rectangle player, Rectangle target)
        {
            var intersection = Rectangle.Intersect(player, target);
            return player.Intersects(target) && intersection.Y == target.Y && intersection.Width >= intersection.Height;
        }

        private static bool IntersectsFromRight(Rectangle player, Rectangle target)
        {
            var intersection = Rectangle.Intersect(player, target);
            return player.Intersects(target) && intersection.X + intersection.Width == target.X + target.Width && intersection.Width <= intersection.Height;

            //if (IntersectsFromRight(movable.hitBox, tile.hitbox))
            //{
            //    movable.Position = new Vector2(tile.hitbox.X + tile.hitbox.Width, movable.Position.Y);
            //}
        }

        private static bool IntersectsFromLeft(Rectangle player, Rectangle target)
        {
            var intersection = Rectangle.Intersect(player, target);
            return player.Intersects(target) && intersection.X == target.X && target.Width >= intersection.Height;

            //if (IntersectsFromRight(movable.hitBox, tile.hitbox))
            //{
            //    movable.Position = new Vector2(tile.hitbox.X + tile.hitbox.Width, movable.Position.Y);
            //}
        }
    }
}
