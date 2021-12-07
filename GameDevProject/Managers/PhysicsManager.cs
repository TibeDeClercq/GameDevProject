using GameDevProject.Interfaces;
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
        private static Vector2 gravity = new Vector2(0, 1);
        //https://stackoverflow.com/questions/43024877/xna-monogame-platformer-jumping-physics-and-collider-issue

        public static void MoveRight(IMovable movable)
        {
            movable.Velocity = new Vector2(movable.MaxVelocity.X, movable.Velocity.Y);
        }

        public static void MoveLeft(IMovable movable)
        {
            movable.Velocity = new Vector2(-movable.MaxVelocity.X, movable.Velocity.Y);
        }

        public static void Jump(IMovable movable, GameTime gameTime)
        {
            if (canJump)
            {
                canJump = false;
                movable.Velocity = new Vector2(0, -movable.MaxJumpHeight);
            }
            canJump = CheckCollision(movable);
        }

        public static void AddGravity(IMovable movable, GameTime gameTime)
        {
            if (!CheckCollision(movable))
            {
                movable.Velocity += new Vector2(0, movable.Acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds);
                Debug.WriteLine(movable.Velocity);
            }
            else
            {
                movable.Velocity = new Vector2(0);
            }
        }

        private static bool CheckCollision(IMovable movable)
        {
            if (movable.Position.Y >= 50)
                return true;
            else
                return false;
        }
    }
}
