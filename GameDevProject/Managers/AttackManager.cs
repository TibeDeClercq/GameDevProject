using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDevProject.Managers
{
    class AttackManager
    {
        public void Attack(IAttacker attacker, GameTime gameTime)
        {
            if (attacker.IsAttacking)
            {
                attacker.Timer += gameTime.ElapsedGameTime;

                Debug.WriteLine($"attack done in {attacker.AttackDuration - attacker.Timer} secondes");

                if (attacker.Timer >= attacker.AttackDuration)
                {
                    attacker.IsAttacking = false;
                    attacker.Timer = TimeSpan.Zero;
                }
            }
            else
            {
                if (attacker.CanAttack)
                {
                    if (attacker.InputReader.ReadInput().Attack == true)
                    {
                        attacker.IsAttacking = true;
                        attacker.CanAttack = false;
                    }
                }
                else
                {
                    attacker.Timer += gameTime.ElapsedGameTime;

                    if (attacker.Timer >= attacker.AttackCooldown)
                    {
                        attacker.CanAttack = true;
                        attacker.Timer = TimeSpan.Zero;
                    }

                    Debug.WriteLine($"attack ready in {attacker.AttackCooldown - attacker.Timer} secondes");

                }
            }
        }
    }
}
