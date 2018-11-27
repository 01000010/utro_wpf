using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utro_wpf.core;

namespace utro_wpf
{
    /// <summary>
    /// Locates the view model from the IoC
    /// </summary>
    public class ViewModelLocator
    {
        #region Properties

        /// <summary>
        /// The singleton instance of the locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        #endregion
        
        /// <summary>
        /// The application view model
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => IoC.AppVM;

        /// <summary>
        /// The view model for the settings
        /// </summary>
        public static SettingsViewModel SettingsViewModel => IoC.AppSettings;

        /// <summary>
        /// The manager for the application
        /// </summary>
        public static ManagerViewModel ManagerViewModel => IoC.AppManager;

        /// <summary>
        /// The administrator control for the application
        /// </summary>
        public static AdministratorViewModel AdministratorViewModel => IoC.AppAdmin;

        /// <summary>
        /// The payment control for the application
        /// </summary>
        public static PaymentViewModel PaymentViewModel => IoC.AppPay;
    }
}
