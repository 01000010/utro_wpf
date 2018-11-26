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
    public class PaymentViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The card number
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// The cardholder name
        /// </summary>
        public string CardName { get; set; }

        /// <summary>
        /// Valid thru
        /// </summary>
        public string Validity { get; set; }

        /// <summary>
        /// A flag to check if the register command is running
        /// </summary>
        public bool IsPaymentRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand PayupCommand { get; set; }
        
        #endregion

        #region Constructor

        /// <summary>
        /// Defualt constructor for the class
        /// </summary>
        /// <param name="window"></param>
        public PaymentViewModel()
        {
            PayupCommand = new RelayParameterizedCommand(async (parameter) => await Register(parameter));
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
            await RunCommand(() => IsPaymentRunning, async () => 
            {
                await Task.Delay(1000); // Symulate a log in
                string cardNumber = CardNumber;
                string cardName = CardName;
                string validity = Validity;
                string cvv = (parameter as IHavePassword).SecurePassword.Unsecure(); // Do never do this for fuck sake!!! Even more so here!!!
                // If succesuful, go to store
                IoC.AppVM.GoToPage(ApplicationPage.Shop);
            });
        }

        #endregion
    }
}