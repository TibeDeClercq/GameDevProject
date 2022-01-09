using Microsoft.Xna.Framework;
using System;

namespace GameDevProject.Interfaces
{
    interface IAttacker
    {
        public TimeSpan AttackCooldown { get; set; }
        public TimeSpan AttackDuration { get; set; }
        public TimeSpan AttackTimer { get; set; }

        public bool CanAttack { get; set; }
        public bool IsAttacking { get; set; }

        public IInputReader InputReader { get; set; }

        public void Attack(GameTime gameTime);
    }
}
