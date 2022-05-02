using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Packman
{
    public class Firetank
    {
        int x, y;

        FiretankImg firetankImg = new FiretankImg();
        Image[] img;
        Image currentimage;

        public int X { get => x; }
        public int Y { get => y; }
        public Image[] Img { get => img; }
        public Image Currentimage { get => currentimage; }

        public Firetank(int x, int y)  
        {
            this.x = x;
            this.y = y;
            img = firetankImg.Firetank;

            PutCurrentImg();
        } ///Конструктор

        public void Fire()
        {
            PutCurrentImg();
        }
        int k;
        public void PutCurrentImg()
        {
            currentimage = img[k];
            k++;
            if (k == 5)
                k = 0;
        }
    }
}
