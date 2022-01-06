using GameDevProject.Entities;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;

namespace GameDevProject.Managers
{
    class DeathManager
    {
        public void Die(Entity entity, GameTime gameTime)
        {
            IKillable killable = entity as IKillable;

            if (entity.Health <= 0)
            {
                killable.DeathTimer += gameTime.ElapsedGameTime;

                if (killable.DeathTimer > killable.DeathDuration)
                {
                    killable.IsDead = true;
                }
            }
        }
    }
}
