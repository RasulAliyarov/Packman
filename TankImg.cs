using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Packman
{
    public class TankImg
    {
        Image[] up = new Image[]
        {
            Properties.Resources.Tank0_1,
            Properties.Resources.Tank0_1I,
            Properties.Resources.Tank0_1II,
            Properties.Resources.Tank0_1III,
            Properties.Resources.Tank0_1IIII,
        };
        Image[] down = new Image[]
        {
            Properties.Resources.Tank01,
            Properties.Resources.Tank01I,
            Properties.Resources.Tank01II,
            Properties.Resources.Tank01III,
            Properties.Resources.Tank01IIII,
        };
        Image[] right = new Image[]
        {
            Properties.Resources.Tank10,
            Properties.Resources.Tank10I,
            Properties.Resources.Tank10II,
            Properties.Resources.Tank10III,
            Properties.Resources.Tank10IIII,
        };
        Image[] left = new Image[]
        {
            Properties.Resources.Tank_10,
            Properties.Resources.Tank_10I,
            Properties.Resources.Tank_10II,
            Properties.Resources.Tank_10III,
            Properties.Resources.Tank_10IIII,
        };

        public Image[] Left { get => left; }
        public Image[] Right { get => right; }
        public Image[] Down { get => down; }
        public Image[] Up { get => up; }
    }
}
