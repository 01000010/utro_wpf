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

        public ICommand OpenSettingsCommand { get; set; }

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
        }

        #endregion

        #region Commands
        
        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public void CloseSettings()
        {
            IoC.AppVM.SettingsMenuVisible = false;
        }

        public void OpenSettings()
        {
            IoC.AppVM.SettingsMenuVisible = true;
        }

        #endregion
    }
}