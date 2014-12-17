using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace GamesWpf
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
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
