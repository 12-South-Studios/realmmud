using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using System.Threading;
using log4net;
using Ninject;
using Ninject.Modules;
using Realm.Admin.DAL;
using Realm.DAL;
using Realm.Edit.Editor;
using Realm.Library.Common.Logging;

namespace Realm.Edit
{
    static class Program
    {
        public static MainForm MainForm { get; private set; }
        public static readonly ILogWrapper Log = new LogWrapper(LogManager.GetLogger(typeof(Program)), LogLevel.Error);
        private static String RealmConnectionString { get; set; }
        private static String AdminConnectionString { get; set; }
        public static IKernel NinjectKernel { get; private set; }

        [STAThread]
        static int Main()
        {
            Application.ThreadException += ApplicationThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Log.InfoFormat("{0} starting...", Application.ProductName);

            try
            {
                RealmConnectionString = ConfigurationManager.ConnectionStrings["RealmDbContext"].ConnectionString;
                AdminConnectionString = ConfigurationManager.ConnectionStrings["AdminDbContext"].ConnectionString;

                NinjectKernel = new StandardKernel(new List<INinjectModule>
                    {
                        new MainModule(),
                        new RealmDbContextModule(),
                        new RealmAdminDbContextModule()
                    }.ToArray());
                
                MainForm = new MainForm();

                BuilderRegistrationModule.RegisterBuilders();

                Application.Run(MainForm);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.ToString());
            }

            Application.ThreadException -= ApplicationThreadException;
            AppDomain.CurrentDomain.UnhandledException -= CurrentDomainUnhandledException;
            return 0;
        }

        private static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Log.Error(e.Exception);
        }

        private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Error(e.ExceptionObject);
        }
    }
}
