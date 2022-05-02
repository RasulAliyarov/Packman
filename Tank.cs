using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Packman
{
    public class Tank
    {
        public int direct_x, direct_y;
        protected int x, y;
        protected int k;
        protected int fieldsize;
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


        private TankImg tankImg = new TankImg();
        protected static Random r;
        protected Image[] img;
        protected Image currentimage;


        public int X { get => x; }
        public int Y { get => y; }
        public TankImg TankImg { get => tankImg; }
        public Image[] Img { get => img;}
        public Image Currentimage { get => currentimage;  }


        public Tank(int fieldsize,int x, int y)
        {
            this.fieldsize = fieldsize;
            r = new Random();
            
            Direct_x = 0;
            Direct_y = 1;
            this.x = x;
            this.y = y;
            PutImg(); 
            PutCurrentImg();
        } ///Конструктор


        public void Run()
        {
            x += direct_x;
            y += direct_y;

            if (Math.IEEERemainder(x, 40) == 0 && Math.IEEERemainder(y, 40) == 0)
                Turn();

            Transparent();
            PutCurrentImg();
        }
        public void Turn()
        {
            if(r.Next(5000) <2500)
            {
                while(Direct_y==0)
                {
                    Direct_x = 0;
                    Direct_y = r.Next(-1, 2);
                }
            }
            else
            { 
                while(Direct_x == 0)
                {
                    Direct_y = 0;
                    Direct_x = r.Next(-1,2);
                }
            }
            PutImg();
        }
        public void TurnAround()
        {
            direct_x = -1* direct_x;
            direct_y = -1* direct_y;
            PutImg();
        }
        public void Transparent()
        {
            if (x == -1)
                x = fieldsize - 21;
            if (x == fieldsize - 19)
                x = 1;
            if (y == -1)
                y = fieldsize - 19;
            if (y == fieldsize - 19)
                y = 1;
        }
        protected void PutCurrentImg()
        {
            currentimage = img[k];
            k++;
            if (k == 5)
                k = 0;
        }
        private void PutImg()
        {
            if (direct_x == 1)
                img = tankImg.Right;
            if (direct_x == -1)
                img = tankImg.Left;
            if (direct_y == 1)
                img = tankImg.Down;
            if (direct_y == -1)
                img = tankImg.Up;
        }
    }
}
