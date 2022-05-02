using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Packman
{
    public class Packman
    {
        int x, y;
        int fieldsize;
        int direct_x, direct_y;
        int nextdirect_x, nextdirect_y;
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


        PackmanImg packmanImg = new PackmanImg();
        Image[] img;
        private Image currentimage;

        
        public PackmanImg PackmanImg { get => packmanImg; }
        public Image[] Img { get => img; }
        public Image Currentimage { get => currentimage; }
        public int X { get => x; }
        public int Y { get => y; }
        public int Nextdirect_x
        {
            get => nextdirect_x;
            set
            {
                if (value == 0 || value == 1 || value == -1)
                    nextdirect_x = value;
                else
                    nextdirect_x = 0;
            }
        }
        public int Nextdirect_y
        {
            get => nextdirect_y;
            set
            {
                if (value == 0 || value == 1 || value == -1)
                    nextdirect_y = value;
                else
                    nextdirect_y = 0;
            }
        }


        public Packman(int fieldsize)
        {
            this.fieldsize = fieldsize;

            this.Nextdirect_y = -1;
            this.Nextdirect_x = 0;

            this.x = 120;
            this.y = 240;

            this.Direct_x = 0;
            this.Direct_y = -1;

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
            Direct_x = Nextdirect_x;
            Direct_y = Nextdirect_y;
            PutImg();
        }
        int k;
        public void PutCurrentImg()
        {
            currentimage = img[k];
            k++;
            if (k == 5)
                k = 0;
        } 
        public void Transparent()
        {
            if (x == -1)
                x = fieldsize - 21;
            if (x == fieldsize - 19)
                x = 1;
            if (y == -1)
                y = fieldsize - 21;
            if (y == fieldsize - 19)
                y = 1;
        } 
        public void PutImg()
        {
            if (direct_x == 1)
                img = packmanImg.Right;
            if (direct_x == -1)
                img = packmanImg.Left;
            if (direct_y == 1)
                img = packmanImg.Down;
            if (direct_y == -1)
                img = packmanImg.Up;
        } 
       
    }
}
