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

        /// <summary>
        /// The kernel to add the bindings to
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// The view model for the application
        /// </summary>
        public static ApplicationViewModel AppVM => Get<ApplicationViewModel>();

        /// <summary>
        /// The view model for the settings menu
        /// </summary>
        public static SettingsViewModel AppSettings => Get<SettingsViewModel>();

        /// <summary>
        /// The view model for the application manger
        /// </summary>
        public static ManagerViewModel AppManager => Get<ManagerViewModel>();

        /// <summary>
        /// The view model for the administrator
        /// </summary>
        public static AdministratorViewModel AppAdmin => Get<AdministratorViewModel>();

        /// <summary>
        /// The view model for payments
        /// </summary>
        public static PaymentViewModel AppPay => Get<PaymentViewModel>();

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
            // Bind to an instance of the manager
            Kernel.Bind<ManagerViewModel>().ToConstant(new ManagerViewModel());
            // Bind to an instance of the administrator
            Kernel.Bind<AdministratorViewModel>().ToConstant(new AdministratorViewModel());
            // Bind to an instance of the payment model
            Kernel.Bind<PaymentViewModel>().ToConstant(new PaymentViewModel());
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
