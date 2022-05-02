using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Packman
{
    public class Wall
    {
        WallImage wallImage = new WallImage();
        Image img;

        public Image Img { get => img; }

        public Wall()
        {
            img = wallImage.Wallimage;
        }
    }
}
