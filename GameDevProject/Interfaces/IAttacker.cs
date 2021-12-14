using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Interfaces
{
    interface IAttacker
    {
        public TimeSpan AttackCooldown { get; set; }
        public bool CanAttack { get; set; }
        public bool IsAttacking { get; set; }

        public IInputReader InputReader { get; set; }

        public void Attack(GameTime gameTime) { }
    }
}
