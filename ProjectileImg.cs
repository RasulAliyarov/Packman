using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Packman
{
    public class ProjectileImg
    {
        Image up = Properties.Resources.Projectile0_1;
        Image down = Properties.Resources.Projectile01;
        Image right = Properties.Resources.Projectile10;
        Image left = Properties.Resources.Projectile_10;

        public Image Up { get => up; }
        public Image Down { get => down; }
        public Image Right { get => right; }
        public Image Left { get => left;  }
    }
}
