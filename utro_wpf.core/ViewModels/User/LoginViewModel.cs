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
    public class LoginViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Email of the user
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// A flag to check if the loging command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The command to go to the register page
        /// </summary>
        public ICommand GoRegisterCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Defualt constructor for the class
        /// </summary>
        /// <param name="window"></param>
        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
            GoRegisterCommand = new RelayCommand(async () => await GoRegister());
        }

        #endregion

        #region Commands

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view model for the user password</param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {
            await RunCommand(() => LoginIsRunning, async () => 
            {
                await Task.Delay(1000); // Symulate a log in
                string user = User;
                string password = (parameter as IHavePassword).SecurePassword.Unsecure(); // Do never do this for fuck sake!!!
                // If succesuful, go to store
                IoC.AppVM.GoToPage(ApplicationPage.Shop);
            });
        }
        
        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public async Task GoRegister()
        {
            IoC.AppVM.GoToPage(ApplicationPage.Register);
            await Task.Delay(1);
        }
        #endregion
    }
}