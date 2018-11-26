using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utro_wpf.core
{
    /// <summary>
    /// The IoC container for our application.
    /// IoC standers for inverse of chili. :9
    /// </summary>
    public static class IoC
    {
        #region Public Properties

        public static IKernel Kernel { get; private set; } = new StandardKernel();

        public static ApplicationViewModel AppVM => Get<ApplicationViewModel>();

        public static SettingsViewModel AppSettings => Get<SettingsViewModel>();

        #endregion

        #region Construction

        /// <summary>
        /// Sets up the IoC container.
        /// NOTE: Call it as soon as the application starts
        /// </summary>
        public static void Setup()
        {
            // Bind the requiered view models
            BindViewModels();
        }

        /// <summary>
        /// Binds all singleton view models
        /// </summary>
        private static void BindViewModels()
        {
            // Bind to an instance of ApplicationViewModel
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
            // Bind to an instance of the Settings
            Kernel.Bind<SettingsViewModel>().ToConstant(new SettingsViewModel());
        }

        #endregion

        #region Helper

        /// <summary>
        /// Gets a service of the IoC of the specified type
        /// </summary>
        /// <typeparam name="T">Type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        #endregion
    }
}
