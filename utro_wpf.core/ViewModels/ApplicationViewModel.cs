using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utro_wpf.core
{
    /// <summary>
    /// The application state as view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        /// <summary>
        /// Whether the side menu should be shown
        /// </summary>
        public bool SideMenuVisible { get; private set; } = false;

        /// <summary>
        /// Wheter the settings menu should be visible
        /// </summary>
        public bool SettingsMenuVisible { get; set; } = false;

        /// <summary>
        /// Wether we should pop up the manager add page
        /// </summary>
        public bool ManagerAddVisible { get; set; } = false;

        /// <summary>
        /// Wether we should pop up the administrator control
        /// </summary>
        public bool AdministratorControlVisible { get; set; } = false;

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">The page to go to</param>
        public void GoToPage(ApplicationPage page)
        {
            // Go to the page
            CurrentPage = page;
            // Should we show the side menu?
            SideMenuVisible = page == ApplicationPage.Shop;
        }
    }
}
