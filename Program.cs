using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Packman
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] arg)
        {
            MainFormController mc;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            switch(arg.Length)
            {
                case 0: mc = new MainFormController(); break;
                case 1: mc = new MainFormController(int.Parse(arg[0])); break;
                case 2: mc = new MainFormController(int.Parse(arg[0]), int.Parse(arg[1])); break;
                case 3: mc = new MainFormController(int.Parse(arg[0]), int.Parse(arg[1]), int.Parse(arg[2])); break;
                case 4: mc = new MainFormController(int.Parse(arg[0]), int.Parse(arg[1]), int.Parse(arg[2]), int.Parse(arg[3])); break;
                default: mc = new MainFormController(); break;
            }

            Application.Run(mc);
        }
    }
}
