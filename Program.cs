using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jamals_Yellow_Pages
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
         public static Test Test;
        [STAThread]

        
        static void Main()
        {
            //Application.Run(new Splash());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Start();

            Test = new Test();
            Application.Run(Test);
            //Application.Run(new Form1());
            //Run();
        }
        public static void Start()   
        {
            Application.Run(new Splash());
        }
        
    }
}
