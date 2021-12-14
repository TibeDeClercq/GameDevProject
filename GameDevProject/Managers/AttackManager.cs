using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Managers
{
    class AttackManager
    {
        public void Attack(IAttacker attacker, GameTime gameTime)
        {
            if (CanAttack)
            {
                this.CanAttack = false;
                this.IsAttacking = true;
                this.Cooldown = TimeSpan.FromSeconds(5);
            }
            else
            {
                this.Cooldown -= gameTime.ElapsedGameTime;
            }
            if (this.Cooldown < TimeSpan.Zero)
            {
                this.CanAttack = true;
            }
        }
    }
}
