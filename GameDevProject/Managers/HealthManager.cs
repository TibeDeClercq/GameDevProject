using GameDevProject.Entities;
using GameDevProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDevProject.Managers
{
    class HealthManager
    {
        private int health = 1;
        private IMovable entity;

        public HealthManager(int health, IMovable entity)
        {
            this.health = health;
            this.entity = entity;
        }

        public void Update(List<Entity> entities) // in een gamemanager dat alle entities bijhoudt?
        {            
            foreach (IMovable other in entities)
            {
                if (IsAttackedBy(other) && entity != other)
                {
                    health--;
                }
            }
            Debug.WriteLine($"Health: {health}");            
        }

        public bool IsAttackedBy(IMovable attacker)
        {
            if (entity.HitboxRectangle.Intersects(attacker.HitboxRectangle))
            {
                return true;
            }
            return false;
        }
    }
}
