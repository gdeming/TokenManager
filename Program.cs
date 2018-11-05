using System;
using System.Threading;
using System.Windows.Forms;

namespace TokenManager
{
    internal static class Program
    {
        private const string MutexName = "TokenManagerMutex";
        private const string MutexId = "Global\\{" + MutexName + "}";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            using (Mutex mutex = new Mutex(false, MutexId))
            {
                try
                {
                    if (!mutex.WaitOne(0))
                    {
                        return;
                    }
                }
                catch (AbandonedMutexException)
                {
                    // Harmless exception - previous instance exited without releasing the mutex
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                using (ApplicationContext = new TokenManagerApplicationContext())
                {
                    Application.Run(ApplicationContext);
                }
            }
        }

        public static TokenManagerApplicationContext ApplicationContext { get; private set; }
    }
}
