using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitcoin_Transaction_Log
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{ZbpkxDXVxPepGCzoDXcfCwIkCTZ9Cq9Q5Qt1mXDw}");
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true)) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
                mutex.ReleaseMutex();
            }
        }
    }
}
