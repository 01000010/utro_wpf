using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace utro_wpf.core
{
    /// <summary>
    /// The view model for a longin screen
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {

        #region Commands

        /// <summary>
        /// The command to close the settings
        /// </summary>
        public ICommand CloseSettingsCommand { get; set; }

        /// <summary>
        /// The command to open the settings
        /// </summary>
        public ICommand OpenSettingsCommand { get; set; }

        /// <summary>
        /// The command to exit from the account
        /// </summary>
        public ICommand ExitAccountCommand { get; set; }

        /// <summary>
        /// The command to redirect to the manager page
        /// </summary>
        public ICommand GoToManagerCommand { get; set; }

        /// <summary>
        /// The command to redirect to the admin page
        /// </summary>
        public ICommand GoToAdminCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Defualt constructor for the class
        /// </summary>
        /// <param name="window"></param>
        public SettingsViewModel()
        {
            CloseSettingsCommand = new RelayCommand(CloseSettings);
            OpenSettingsCommand = new RelayCommand(OpenSettings);
            ExitAccountCommand = new RelayCommand(ExitAccount);
            GoToManagerCommand = new RelayCommand(GoManager);
            GoToAdminCommand = new RelayCommand(GoAdmin);
        }

        #endregion

        #region Commands methods
        
        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public void CloseSettings()
        {
            IoC.AppVM.SettingsMenuVisible = false;
        }

        /// <summary>
        /// Command to open the settings window
        /// </summary>
        public void OpenSettings()
        {
            IoC.AppVM.SettingsMenuVisible = true;
        }

        public void ExitAccount()
        {
            IoC.AppVM.GoToPage(ApplicationPage.Login);
            IoC.AppVM.SettingsMenuVisible = false;
            // Add here the logic to close the session.
        }

        public void GoManager()
        {
            IoC.AppVM.ManagerAddVisible = true;
        }

        public void GoAdmin()
        {
            IoC.AppVM.AdministratorControlVisible = true;
        }

        #endregion
    }
}