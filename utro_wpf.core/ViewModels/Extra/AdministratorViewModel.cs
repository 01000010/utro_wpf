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
    public class AdministratorViewModel : BaseViewModel
    {

        #region Commands

        /// <summary>
        /// The command to close the manager add
        /// </summary>
        public ICommand CloseAdministratorCommand { get; set; }

        /// <summary>
        /// The command to open the manager add
        /// </summary>
        public ICommand OpenAdministratorCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Defualt constructor for the class
        /// </summary>
        /// <param name="window"></param>
        public AdministratorViewModel()
        {
            CloseAdministratorCommand = new RelayCommand(CloseAdministrator);
            OpenAdministratorCommand = new RelayCommand(OpenAdministrator);
        }

        #endregion

        #region Commands methods
        
        public void CloseAdministrator()
        {
            IoC.AppVM.AdministratorControlVisible = false;
        }

        public void OpenAdministrator()
        {
            IoC.AppVM.AdministratorControlVisible = true;
        }

        #endregion
    }
}