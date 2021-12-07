using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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
            var distance = new Vector2(1,0) * movable.MaxVelocity;
            movable.Position += distance;
        }

        public static void MoveLeft(IMovable movable)
        {
            var distance = new Vector2(-1,0) * movable.MaxVelocity;
            movable.Position += distance;
        }

        public static void Jump(IMovable movable, GameTime gameTime)
        {
            if (canJump)
            {
                // while jump
                movable.Velocity = new Vector2(0, movable.MaxJumpHeight);
                var distance = new Vector2(0, -1) * movable.MaxJumpHeight;
                movable.Position += distance;
                //jump done
            }            
        }

        public static void AddGravity(IMovable movable, GameTime gameTime)
        {
            if (!CheckCollision(movable))
            {
                movable.Velocity += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                movable.Position += movable.Velocity;
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
