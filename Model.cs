using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Packman
{
    public delegate void STREEP();
    public class Model
    {
        public event STREEP statusstreep;
        int fieldsize;
        int amounttank;
        int amountapple;
        int speedgame;
        int collectedapple; // Сбор яблок

        public Gamestatus gamestatus= new Gamestatus();
        
        static Random r;
        public View view;
        List<Tank> tank;
        Wall wall;
        List<Apple> apple;
        Packman packman;
        Projectile projectile;
        List<Firetank> firetank;

        public Model(int fieldsize, int amounttank,int  amountapple,int speedgame)
        {
            this.fieldsize = fieldsize;
            this.amounttank = amounttank;
            this.amountapple = amountapple;
            this.speedgame = speedgame;

            NewGame();
        } ///Конструктор

        public List<Tank> Tank { get => tank;  }
        public Wall Wall { get => wall; }
        public List<Apple> Apple { get => apple;  }
        public Packman Packman { get => packman; }
        public Projectile Projectile { get => projectile; }
        public List<Firetank> Firetank { get => firetank; }


        
        public void CreatTanks()
        {
            int x, y;

            while(Tank.Count < amounttank + 1)
            {
               if(tank.Count == 0)
               {
                  tank.Add(new Hunter(fieldsize, x = r.Next(7) * 40, x = r.Next(7) * 40));
               }
                x = r.Next(7) * 40;
                y = r.Next(7) * 40;

                bool flaq = true;
                foreach(Tank t in tank)
                    if(t.X == x && t.Y==y)
                    {
                        flaq = false;
                        break;
                    }
                if(flaq)
                    tank.Add(new Tank(fieldsize, x, y));             
            }
        } ///Создание вражеских танков
        public void CreatApple(int colectedapple)
        {
            int x, y;

            while(apple.Count <amountapple + colectedapple)
            {
                x = r.Next(7) * 40;
                y = r.Next(7) * 40;

                bool flaq = true;

                foreach(Apple a in apple)
                if(a.X == x && a.Y == y)
                {
                        flaq = false;
                        break;
                }
                if(flaq)
                    apple.Add(new Apple(x, y));
            }
        } ///Слздание яблок
        public void CreatApple()
        {
            CreatApple(0);
        }  ///Перегрузка
        public void Play()
        {
            while(gamestatus == Gamestatus.Playing)
            {
                Thread.Sleep(40);

                PlayAllObject();

                IfCallisionTanks();
                IfCallisionTanksOfPackman();
                IfPickApple();
                IfDesttroyTank();

                if (collectedapple > 4)
                {
                    gamestatus = Gamestatus.Winer;
                    statusstreep();
                    MessageBox.Show("Ура! Ура! Ура! Вы собрали все 5 яблок!", "Победитель Танки");
                    
                    statusstreep();
                }
            }
        }
        private void PlayAllObject()
        {      
                ((Hunter)tank[0]).Run(packman.X, packman.Y);

                for (int t = 1; t < tank.Count; t++)
                  tank[t].Run();

                packman.Run();

                projectile.Run();

                foreach (Firetank f in firetank)
                    f.Fire();
        } ///Запуск всех объектов
        private void IfDesttroyTank()
        {
            for (int i = 1; i < tank.Count; i++)
            {
                if ((projectile.X - tank[i].X) < 13 && (projectile.Y - tank[i].Y) < 13 &&
                    (projectile.X - tank[i].X) > 4 && (projectile.Y - tank[i].Y) > 4)
                {
                    firetank.Add(new Firetank(tank[i].X, tank[i].Y));
                    tank.RemoveAt(i);

                    projectile.DefaultSettings();
                }
            }
        } ///Уничтоженные танки и их анимации
        private void IfPickApple()
        {
            for (int i = 0; i < apple.Count; i++)
            {
                 if (Math.Abs(packman.X - apple[i].X) < 4 && Math.Abs(packman.Y - apple[i].Y) < 4)
                 {
                    apple[i] = new Apple(step += 30, 270);
                    CreatApple(++collectedapple);
                 }
            }
        } ///Сбор яблок
        private void IfCallisionTanksOfPackman()
        {
            for (int i = 0; i < tank.Count; i++)
                    if (
                        Math.Abs(tank[i].X - packman.X) <= 19 && (tank[i].Y == packman.Y)
                        ||
                        Math.Abs(tank[i].Y - packman.Y) <= 19 && (tank[i].X == packman.X)
                        ||
                        Math.Abs(tank[i].X - packman.X) <= 19 && (Math.Abs(tank[i].Y - packman.Y) <= 19))
                    {
                        gamestatus = Gamestatus.Looser;
                        statusstreep();
                    }
        } ///Столкновение пакмана с вражескими танками
        private void IfCallisionTanks()
        {
            for (int i = 0; i < tank.Count - 1; i++)
                 for (int k = i + 1; k < tank.Count; k++)
               if (
                   Math.Abs(tank[i].X - tank[k].X) <= 10 && (tank[i].Y == tank[k].Y)
                   ||
                   Math.Abs(tank[i].Y - tank[k].Y) <= 10 && (tank[i].X == tank[k].X)
                   ||
                   Math.Abs(tank[i].X - tank[k].X) <= 20 && (Math.Abs(tank[i].Y - tank[k].Y) <= 20))
               {
                   if(i == 0)
                        ((Hunter)tank[i]).TurnAround();
                   else
                        tank[i].TurnAround();
                   tank[k].TurnAround();
               }
        } ///Столкновение вражеских танков(поворот)

        int step;
        public void NewGame()
        {
            step = -30;

            gamestatus = Gamestatus.Stopping;
            collectedapple = 0;

            tank = new List<Tank>(fieldsize);
            wall = new Wall();
            apple = new List<Apple>();
            packman = new Packman(fieldsize);
            projectile = new Projectile();
            firetank = new List<Firetank>();
            r = new Random();

            CreatTanks();
            CreatApple();

        }

    }
}
