using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Packman
{
    public class PackmanImg
    {
        Image[] up = new Image[]
        {
            Properties.Resources.Packman0_1,
            Properties.Resources.Packman0_1I,
            Properties.Resources.Packman0_1II,
            Properties.Resources.Packman0_1III,
            Properties.Resources.Packman0_1IIII,
        };
        Image[] down = new Image[]
        {
            Properties.Resources.Packman01,
            Properties.Resources.Packman01I,
            Properties.Resources.Packman01II,
            Properties.Resources.Packman01III,
            Properties.Resources.Packman01IIII,
        };
        Image[] right = new Image[]
        {
            Properties.Resources.Packman10,
            Properties.Resources.Packman10I,
            Properties.Resources.Packman10II,
            Properties.Resources.Packman10III,
            Properties.Resources.Packman10IIII,
        };
        Image[] left = new Image[]
        {
            Properties.Resources.Packman_10,
            Properties.Resources.Packman_10I,
            Properties.Resources.Packman_10II,
            Properties.Resources.Packman_10III,
            Properties.Resources.Packman_10IIII,
        };

        public Image[] Up { get => up; }
        public Image[] Down { get => down; }
        public Image[] Right { get => right; }
        public Image[] Left { get => left; }
    }
}
