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

        public static SettingsViewModel SettingsViewModel => IoC.AppSettings;
    }
}
