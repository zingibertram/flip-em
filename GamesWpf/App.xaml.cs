using System;
using System.IO;
using System.Windows;

namespace GamesWpf
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            base.OnStartup(e);
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            using (var writer = new StreamWriter(Path.Combine(dir, "errors.log")))
            {
                writer.Write(e.ExceptionObject.ToString());
            }
        }
    }
}
