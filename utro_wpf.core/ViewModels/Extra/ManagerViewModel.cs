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
    public class ManagerViewModel : BaseViewModel
    {

        #region Commands

        /// <summary>
        /// The command to close the manager add
        /// </summary>
        public ICommand CloseManagerCommand { get; set; }

        /// <summary>
        /// The command to open the manager add
        /// </summary>
        public ICommand OpenManagerCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Defualt constructor for the class
        /// </summary>
        /// <param name="window"></param>
        public ManagerViewModel()
        {
            CloseManagerCommand = new RelayCommand(CloseManager);
            OpenManagerCommand = new RelayCommand(OpenManager);
        }

        #endregion

        #region Commands methods
        
        public void CloseManager()
        {
            IoC.AppVM.ManagerAddVisible = false;
        }

        public void OpenManager()
        {
            IoC.AppVM.ManagerAddVisible = true;
        }

        #endregion
    }
}