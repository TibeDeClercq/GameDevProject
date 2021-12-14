using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Interfaces
{
    interface IAttacker
    {
        public bool IsAttacking { get; set; }

        public void Attack() { }
    }
}
