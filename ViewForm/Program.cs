using LibraryContracts.BusinessLogicsContracts;
using LibraryContracts.StorageContracts;
using LibraryBusinessLogic.BusinessLogics;
using Unity;
using Unity.Lifetime;
using Database.Implements;

namespace ViewForm
{
    internal static class Program
    {
        private static IUnityContainer container = null;
        public static IUnityContainer Container { get { if (container == null) { container = BuildUnityContainer(); } return container; } }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();

            currentContainer.RegisterType<IBookStorage, BookStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAuthorStorage, AuthorStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IBookLogic, BookLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAuthorLogic, AuthorLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}