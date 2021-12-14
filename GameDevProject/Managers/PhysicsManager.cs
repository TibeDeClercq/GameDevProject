﻿using GameDevProject.Entities;
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
        public static bool check = true;
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
            canJump = CheckCollision(movable, world);
        }

        public static void AddGravity(IMovable movable, World world, GameTime gameTime)
        {
            if (!CheckCollision(movable, world))
            {
                movable.Velocity += new Vector2(0, movable.Acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            else
            {
                movable.Velocity = new Vector2(0);
            }
        }

        private static bool CheckCollision(IMovable movable, World world)
        {
            if (check)
            {
                foreach (Tile tile in world.GetTiles())
                {
                    if (tile.isFloor)
                    {
                        Debug.WriteLine($"tile {tile.identifier} is a floor");

                    }
                    if (tile.isCeiling)
                    {
                        Debug.WriteLine($"tile {tile.identifier} is a ceiling");

                    }
                    if (tile.isBackground)
                    {
                        Debug.WriteLine($"tile {tile.identifier} is a background");

                    }
                    //if (tile.isFloor && tile.SourceRectangle.Intersects(movable.hitBox))
                    //{
                    //    Debug.WriteLine("Touching floor");
                    //    return true;
                    //}
                }
                check = false;
            }
            
            //Debug.WriteLine("No collisions");
            return true;
            //return movable.Position.Y >= 50;
        }
    }
}
