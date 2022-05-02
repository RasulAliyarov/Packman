using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Packman
{
    class Hunter : Tank
    {
        HunterImg hunterImg = new HunterImg();

        public Hunter(int fieldsize, int x,int y) : base(fieldsize, x, y)
        {
            PutImg();
            PutCurrentImg();
        }///Конструктор

        public void Run(int target_x, int target_y)
        {
            x += Direct_x;
            y += Direct_y;

            if (Math.IEEERemainder(x, 40) == 0 && Math.IEEERemainder(y, 40) == 0)
                Turn(target_x,target_y);

            PutImg();
            Transparent();
            PutCurrentImg();
        }
        public void Turn(int huntertarget_x, int huntertarget_y)
        {
            Direct_x = Direct_y = 0;
            if (X > huntertarget_x)
                Direct_x = -1;
            if (X < huntertarget_x)
                Direct_x = 1;
            if (Y > huntertarget_y)
                Direct_y = -1;
            if (Y < huntertarget_y)
                Direct_y = 1;

            if (Direct_x != 0 && Direct_y != 0)
                if (r.Next(5000) < 2500)
                    direct_x = 0;
                else
                    direct_y = 0;

            PutImg();
        }
        new public void TurnAround()
        {
            direct_x = -1 * direct_x;
            direct_y = -1 * direct_y;
            PutImg();
        }
        public void PutImg()
        {
            if (direct_x == 1)
                img = hunterImg.Right;
            if (direct_x == -1)
                img = hunterImg.Left;
            if (direct_y == 1)
                img = hunterImg.Down;
            if (direct_y == -1)
                img = hunterImg.Up;
        }

    }
}
