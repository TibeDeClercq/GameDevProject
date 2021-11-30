using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Managers
{
    class PhysicsManager
    {
        private bool canJump = true;
        private Vector2 gravity = new Vector2(0, 5);
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

        public static void Jump(IMovable movable)
        {
            var distance = new Vector2(0, -1) * movable.MaxJumpHeight;
            movable.Position += distance;
        }

        public static void AddGravity(IMovable movable)
        {
            if (!CheckCollision())
            {
                var force = new Vector2(0, 1);
                movable.Position += force;
            }            
        }

        private static bool CheckCollision()
        {
            return false;
        }
    }
}
