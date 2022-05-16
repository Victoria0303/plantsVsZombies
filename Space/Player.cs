using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Space
{
    public class Player
    {
        public bool GoLeft { get; set; }
        public bool GoRight { get; set; }
        public int Speed { get => 12; }
        public bool IsTriple { get; set; } = false;
        public bool IsFastPeas { get; set; } = false;
    }
}
