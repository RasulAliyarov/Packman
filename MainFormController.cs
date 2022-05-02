using System;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Packman
{
    delegate void Invoker();
    public partial class MainFormController : Form
    {
        Thread modelplay;
        Model model;
        View view;
        bool issound;
        SoundPlayer sp;
        public MainFormController() : this (260) { }
        public MainFormController(int fieldsize) : this (fieldsize, 5) { }
        public MainFormController(int fieldsize, int amounttank) : this (fieldsize, amounttank, 5) { }
        public MainFormController(int fieldsize, int amounttank, int amountapple) : this (fieldsize, amounttank, amountapple, 40) { }
        public MainFormController(int fieldsize, int amounttank, int amountapple, int speedgame)
        {
            InitializeComponent();

            model = new Model(fieldsize, amounttank, amountapple, speedgame);

            model.statusstreep += new STREEP(ChangerStatusLbl);
            sp = new SoundPlayer(Properties.Resources.TankSound11);
            issound = true;
            view = new View(model);
            this.Controls.Add(view);

             sp.Play();
        }

        private void StartStop_btn_Click(object sender, EventArgs e)
        {
            Thread.Sleep(40);
           
            if (model.gamestatus == Gamestatus.Playing)
            {
                model.gamestatus = Gamestatus.Stopping;
                modelplay.Abort();
                ChangerStatusLbl();
                start_pause_pcbx.Image = Properties.Resources._11111111START; 
            }
            else
            {
                start_pause_pcbx.Focus();
                model.gamestatus = Gamestatus.Playing;
                ChangerStatusLbl();

                start_pause_pcbx.Image = Properties.Resources._1111111PAUSE;

               

                modelplay = new Thread(model.Play);
                modelplay.Start();
            }

            view.Invalidate();
        }
        private void MainFormController_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(model.gamestatus ==Gamestatus.Playing)
            modelplay.Abort();

            model.gamestatus = Gamestatus.Stopping;

            DialogResult dr;
            dr = MessageBox.Show("Закрыть игру?", "Танки", MessageBoxButtons.YesNoCancel);

            if (dr == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
        private void ProjectileLocation()
        {
            model.Projectile.Direct_x = model.Packman.Direct_x;
            model.Projectile.Direct_y = model.Packman.Direct_y;

            if (model.Packman.Direct_x == 1)
            {
                model.Projectile.X = model.Packman.X + 20;
                model.Projectile.Y = model.Packman.Y + 5;
            }
            if (model.Packman.Direct_x == -1)
            {
                model.Projectile.X = model.Packman.X;
                model.Projectile.Y = model.Packman.Y + 5;
            }
            if (model.Packman.Direct_y == 1)
            {
                model.Projectile.X = model.Packman.X + 5;
                model.Projectile.Y = model.Packman.Y + 20;
            }
            if (model.Packman.Direct_y == -1)
            {
                model.Projectile.X = model.Packman.X + 5;
                model.Projectile.Y = model.Packman.Y + 5;
            }
        }
        private void Start_pause_pcbx_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch(e.KeyData.ToString())
            {       
                case "A":
                    {
                        model.Packman.Nextdirect_x = -1;
                        model.Packman.Nextdirect_y = 0;
                    };
                    break;
                case "D":
                    {
                        model.Packman.Nextdirect_x = 1;
                        model.Packman.Nextdirect_y = 0;
                    };
                    break;
                case "W":
                    {
                        model.Packman.Nextdirect_y = -1;
                        model.Packman.Nextdirect_x = 0;
                    };
                    break;
                case "S":
                    {
                        model.Packman.Nextdirect_y = 1;
                        model.Packman.Nextdirect_x = 0;
                    };
                    break;
                case "Q" :
                    {
                        ProjectileLocation();  
                    };
                    break;
            }
        }
        void ChangerStatusLbl()
        {
            Invoke(new Invoker(SetValueToStsLbl));
        }
        void SetValueToStsLbl()
        {
            toolStripStatusLabel1.Text = model.gamestatus.ToString();

           
        }
        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.NewGame();
            start_pause_pcbx.Image = Properties.Resources._1111111PAUSE;
            view.Invalidate();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void SoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            issound = !issound;

            if(issound)
                 sp.PlayLooping();
            else
                sp.Stop();
            
            if (issound)
                soundToolStripMenuItem.Image = Properties.Resources.sound;
            else
                soundToolStripMenuItem.Image = Properties.Resources.das;


        }
        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.gamestatus = Gamestatus.Stopping;
            MessageBox.Show("Packman \nVersion 1.0.0 \nCreated: Rasul", "About Packman");
        }

    }
}
