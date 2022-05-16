using System;
using System.Collections.Generic;
using System.Media;
using System.Text;

namespace Space
{
    static class Sound
    {
        public readonly static SoundPlayer win = new SoundPlayer(Properties.Resources.win);
        public readonly static SoundPlayer shot = new SoundPlayer(Properties.Resources.shot);
        public readonly static SoundPlayer gameOver = new SoundPlayer(Properties.Resources.gameOver);
        public readonly static SoundPlayer death = new SoundPlayer(Properties.Resources.death);
        public readonly static SoundPlayer bomb = new SoundPlayer(Properties.Resources.bombExp);
        public readonly static SoundPlayer takeBonus = new SoundPlayer(Properties.Resources.takeBonus);
    }
}
