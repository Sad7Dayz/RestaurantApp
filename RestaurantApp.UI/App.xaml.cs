using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows;

namespace RestaurantApp.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Mutex? mutex;

        public App()
        {
            string applicationName = Process.GetCurrentProcess().ProcessName;
            Duplicate_execution(applicationName);
        }

        /// <summary>
        /// 중복실행방지
        /// </summary>
        /// <param name="mutexName"></param>
        private void Duplicate_execution(string mutexName)
        {
            try
            {
                mutex = new Mutex(false, mutexName);
            }
            catch (Exception ex)
            {
                Application.Current.Shutdown();
            }
            if (mutex.WaitOne(0, false))
            {
                InitializeComponent();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}
