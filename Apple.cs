using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Packman
{
    public class Apple
    {
        int x, y;

        AplleImg aplleImg = new AplleImg();
        Image img;
        public Apple(int x, int y)
        {
            this.x = x;
            this.y = y;
            img = aplleImg.Appleimg;
        } ///Конструктор

        public AplleImg AplleImg { get => aplleImg; }
        public Image Img { get => img; }
        public int X { get => x; }
        public int Y { get => y; }

    }
}
