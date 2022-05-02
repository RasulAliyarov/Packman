using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading ;

namespace Packman
{
    public partial class View : UserControl
    {
        Model model;
        public View(Model model)
        {
            this.model = model;

            InitializeComponent();
        }

        public void Draw(PaintEventArgs e)
        {
            DrawWall(e);
            DrawApple(e);
            DrawProjectile(e);
            DrawFiretank(e);
            DrawTanks(e);
            DrawPackman(e);
            if(model.gamestatus == Gamestatus.Playing)
            {
                Thread.Sleep(40);
                Invalidate();
            }
        }

        private void DrawFiretank(PaintEventArgs e)
        {
            foreach (Firetank f in model.Firetank)
                e.Graphics.DrawImage(f.Currentimage, new Point(f.X, f.Y));  
        }

        private void DrawProjectile(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.Projectile.Img, new Point(model.Projectile.X, model.Projectile.Y));
        }

        private void DrawPackman(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.Packman.Currentimage, new Point(model.Packman.X, model.Packman.Y));
        }

        private void DrawApple(PaintEventArgs e)
        {
          //  foreach (Apple a in model.Apple)
            for(int i = 0; i < model.Apple.Count; i++)
                e.Graphics.DrawImage(model.Apple[i].Img, new Point(model.Apple[i].X, model.Apple[i].Y));
        }

        private void DrawWall(PaintEventArgs e)
        {
            for (int x = 20; x < 260; x += 40)
                for (int y = 20; y < 260; y += 40)
                    e.Graphics.DrawImage(model.Wall.Img, new Point(x,y));
        }

        private void DrawTanks(PaintEventArgs e)
        {
            for(int t = 0; t<model.Tank.Count; t++)
                 e.Graphics.DrawImage(model.Tank[t].Currentimage, new Point(model.Tank[t].X, model.Tank[t].Y));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e);
        }
    }
}
