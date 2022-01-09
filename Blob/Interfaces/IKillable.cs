using System;

namespace Blob.Interfaces
{
    interface IKillable
    {
        public bool IsDead { get; set; }
        public TimeSpan DeathTimer { get; set; }
        public TimeSpan DeathDuration { get; set; }
    }
}
