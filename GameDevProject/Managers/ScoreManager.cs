﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Managers
{
    static class ScoreManager
    {
        public static int Score { get; set; } = 0;
        public static TimeSpan GameTimer { get; set; } = TimeSpan.Zero;
    }
}
