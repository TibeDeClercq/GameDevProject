using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;

namespace GameDevProject.Managers
{
    class AttackManager
    {
        #region Public methods
        public void Attack(IAttacker attacker, GameTime gameTime)
        {
            if (attacker.IsAttacking)
            {
                attacker.AttackTimer += gameTime.ElapsedGameTime;

                if (attacker.AttackTimer >= attacker.AttackDuration)
                {
                    attacker.IsAttacking = false;
                    attacker.AttackTimer = TimeSpan.Zero;
                }
            }
            else
            {
                if (attacker.CanAttack)
                {
                    if (attacker.InputReader.ReadInput().Attack == true)
                    {
                        SoundManager.PlaySound(Sound.Spin);
                        attacker.IsAttacking = true;
                        attacker.CanAttack = false;
                    }
                }
                else
                {
                    attacker.AttackTimer += gameTime.ElapsedGameTime;

                    if (attacker.AttackTimer >= attacker.AttackCooldown)
                    {
                        attacker.CanAttack = true;
                        attacker.AttackTimer = TimeSpan.Zero;
                    }
                }
            }
        }
        #endregion
    }
}
