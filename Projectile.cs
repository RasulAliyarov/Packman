using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Packman
{
    public class Projectile
    {
        public int direct_x, direct_y;
        int x, y;
        int km;
        public int Direct_x
        {
            get => direct_x;
            set
            {
                if (value == 1 || value == -1 || value == 0)
                    direct_x = value;
                else
                    direct_x = 0;
            }
        }
        public int Direct_y
        {
            get => direct_y;
            set
            {
                if (value == 1 || value == -1 || value == 0)
                    direct_y = value;
                else
                    direct_y = 0;
            }
        }

        ProjectileImg projectileimg = new ProjectileImg();
        Image img;
        
        public Image Img { get => img; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }


        public Projectile()
        {
            img = projectileimg.Up;
            DefaultSettings();
            x = y = -10;
            Direct_x = Direct_y = 0;
        } ///Конструктор


        public void Run()
        {
            if (Direct_x == 0 && Direct_y == 0)
                return;

            km += 3;

            PutImg();

            x += Direct_x *3;
            y += Direct_y *3;

            if (km > 140)
                DefaultSettings();
        }
        public void DefaultSettings()
        {
            x = y = -10;
            km = 0;
            Direct_x = Direct_y = 0;
        }
        private void PutImg()
        {
            if (direct_x == 1)
                img = projectileimg.Right;
            if (direct_x == -1)
                img = projectileimg.Left;
            if (direct_y == 1)
                img = projectileimg.Down;
            if (direct_y == -1)
                img = projectileimg.Up;
        }

    }
}
