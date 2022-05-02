using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Packman
{
    public class HunterImg
    {
        Image[] up = new Image[]
        {
            Properties.Resources.Hunter0_1,
            Properties.Resources.Hunter0_1I,
            Properties.Resources.Hunter0_1II,
            Properties.Resources.Hunter0_1III,
            Properties.Resources.Hunter0_1IIIII,
        };
        Image[] down = new Image[]
        {
            Properties.Resources.Hunter01,
            Properties.Resources.Hunter01I,
            Properties.Resources.Hunter01II,
            Properties.Resources.Hunter01III,
            Properties.Resources.Hunter01IIII,
        };
        Image[] right = new Image[]
        {
            Properties.Resources.Hunter10,
            Properties.Resources.Hunter10I,
            Properties.Resources.Hunter10II,
            Properties.Resources.Hunter10III,
            Properties.Resources.Hunter10IIII,
        };
        Image[] left = new Image[]
        {
            Properties.Resources.Hunter_10,
            Properties.Resources.Hunter_10I,
            Properties.Resources.Hunter_10II,
            Properties.Resources.Hunter_10III,
            Properties.Resources.Hunter_10IIII,
        };

        public Image[] Left { get => left; }
        public Image[] Right { get => right; }
        public Image[] Down { get => down; }
        public Image[] Up { get => up;  }
    }
}
