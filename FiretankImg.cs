using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Packman
{
    public class FiretankImg
    {
        Image[] firetank = new Image[]
        {
            Properties.Resources.Tank012,
            Properties.Resources.Tank01I1,
            Properties.Resources.Tank01II1,
            Properties.Resources.Tank01III1,
            Properties.Resources.Tank01IIII1,
        };

        public Image[] Firetank { get => firetank; }
    }
}
