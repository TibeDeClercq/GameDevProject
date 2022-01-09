using System;
using Microsoft.Xna.Framework;

namespace Blob.Interfaces
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
