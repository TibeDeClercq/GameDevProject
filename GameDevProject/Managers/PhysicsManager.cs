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
        private static bool isJumping = false;
        private static Vector2 gravity = new Vector2(0, 1);
        //https://stackoverflow.com/questions/43024877/xna-monogame-platformer-jumping-physics-and-collider-issue

        public static void MoveRight(IMovable movable)
        {
            //var distance = new Vector2(1,0) * movable.MaxVelocity;
            //movable.Position += distance;
            movable.Velocity = new Vector2(movable.MaxVelocity.X, 0);
        }

        public static void MoveLeft(IMovable movable)
        {
            //var distance = new Vector2(-1,0) * movable.MaxVelocity;
            //movable.Position += distance;
            movable.Velocity = new Vector2(-movable.MaxVelocity.X, 0);

        }

        public static void Jump(IMovable movable, GameTime gameTime)
        {
            if (canJump)
            {
                canJump = false;
                movable.Velocity = new Vector2(0, 50);
                movable.Position += movable.Velocity * new Vector2(0, -1);
                movable.Velocity = new Vector2(0);
            }
            canJump = CheckCollision(movable);
        }

        public static void AddGravity(IMovable movable, GameTime gameTime)
        {
            if (!CheckCollision(movable))
            {
                movable.Velocity += new Vector2(0, movable.Acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds);
                movable.Position += movable.Velocity;
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
