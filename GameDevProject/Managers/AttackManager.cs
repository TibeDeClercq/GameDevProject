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
            var input = attacker.InputReader.ReadInput();

            if (input.Attack == true)
            {
                attacker.IsAttacking = true;
            }
        }
    }
}
