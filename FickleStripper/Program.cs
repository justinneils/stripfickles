using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace FickleStripper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // load all plugins into the current assembly.  potentially a security risk...
            foreach (var file in Directory.GetFiles("Plugins", "*.dll"))
            {
                AppDomain.CurrentDomain.Load(Assembly.LoadFrom(file).GetName());
            }

            Control.CheckForIllegalCrossThreadCalls = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
