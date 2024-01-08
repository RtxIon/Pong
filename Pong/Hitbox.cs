using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Hitbox
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public int vspeed;
        public int hspeed;
        public Hitbox(int ex, int why, int wiif, int hite)
        {
            x = ex; y = why; width = wiif; height = hite;
        }
    }
}
