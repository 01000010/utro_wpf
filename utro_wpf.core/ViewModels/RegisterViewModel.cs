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
    public class RegisterViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Email of the user
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// A flag to check if the register command is running
        /// </summary>
        public bool RegisterIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        /// <summary>
        /// The command to go to the register page
        /// </summary>
        public ICommand GoLoginCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Defualt constructor for the class
        /// </summary>
        /// <param name="window"></param>
        public RegisterViewModel()
        {
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await Register(parameter));
            GoLoginCommand = new RelayCommand(async () => await GoLogin());
        }

        #endregion

        #region Commands

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view model for the user password</param>
        /// <returns></returns>
        public async Task Register(object parameter)
        {
            await RunCommand(() => RegisterIsRunning, async () => 
            {
                await Task.Delay(1000); // Symulate a log in
                string user = User;
                string password = (parameter as IHavePassword).SecurePassword.Unsecure(); // Do never do this for fuck sake!!!
                // If succesuful, go to store
                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Shop);
            });
        }
        
        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public async Task GoLogin()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);
            await Task.Delay(1);
        }

        #endregion
    }
}