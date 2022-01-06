﻿using GameDevProject.Entities;
using GameDevProject.Interfaces;
using GameDevProject.Levels;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GameDevProject.Managers
{
    class HealthManager
    {
        private EntityCollisionManager CollisionManager;

        public HealthManager(EntityCollisionManager collisionManager)
        {
            this.CollisionManager = collisionManager;
        }

        public void UpdateHealth(Level level ,GameTime gameTime)
        {
            Entity entity = CollisionManager.CheckCollision();
            Player player = CollisionManager.Player as Player;

            if (entity != null)
            {
                if (entity.Health > 0 && player.IsAttacking)
                {
                    entity.Health--;
                }
                else
                {
                    if (player.Health > 0 && !player.IsAttacking)
                    {
                        player.Health--;
                    }
                }

                if (entity is Player && entity.Health > 0)
                {
                    entity.Health--;
                }               
            }

            Kill(CollisionManager, gameTime);
            ClearDeadEntities(level);
        }

        #region Private Methods
        private void Kill(EntityCollisionManager collisionManager ,GameTime gameTime)
        {
            foreach(Entity entity in collisionManager.Entities)
            {
                if (entity.Health <= 0)
                {
                    var killable = entity as IKillable;
                    killable.DeathTimer += gameTime.ElapsedGameTime;

                    if (killable.DeathTimer > killable.DeathDuration)
                    {
                        killable.IsDead = true;
                    }
                }
            }            
        }

        private void ClearDeadEntities(Level level)
        {
            var entities = new List<Entity>(level.entities);

            foreach (Entity entity in entities)
            {
                var killable = entity as IKillable;
                if (killable != null)
                {
                    if (killable.IsDead)
                    {
                        if (entity is Player)
                        {
                            switch (Game1.State)
                            {
                                case State.Level1:
                                    Game1.State = State.GameOverLevel1;
                                    break;
                                case State.Level2:
                                    Game1.State = State.GameOverLevel2;
                                    break;
                                default:
                                    break;
                            }
                        }
                        level.entities.Remove(entity);
                        level.collisionManager.Entities.Remove(entity);
                    }
                }
            }
        }
        #endregion
    }
}
