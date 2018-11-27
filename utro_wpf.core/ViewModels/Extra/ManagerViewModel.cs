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
        #region Public Properties

        #region Common Properties

        /// <summary>
        /// The code of the new item
        /// </summary>
        public TextEntryViewModel Code { get; set; }

        /// <summary>
        /// Name of the new item
        /// </summary>
        public TextEntryViewModel Name { get; set; }

        /// <summary>
        /// The width of the new item
        /// </summary>
        public TextEntryViewModel Width { get; set; }

        /// <summary>
        /// The height of the new item
        /// </summary>
        public TextEntryViewModel Height { get; set; }

        /// <summary>
        /// The price of the new item
        /// </summary>
        public TextEntryViewModel Price { get; set; }

        // The picture will get handled a little different

        #endregion

        #region Product Properties

        /// <summary>
        /// Additional information of the new product item
        /// </summary>
        public TextEntryViewModel Commentary { get; set; }

        #endregion

        #region Fabric Properties

        /// <summary>
        /// The color of the new fabric item
        /// </summary>
        public TextEntryViewModel Color { get; set; }

        /// <summary>
        /// The drawing of the new frabric item
        /// </summary>
        public TextEntryViewModel Drawing { get; set; }

        /// <summary>
        /// The material composition of the new fabric item
        /// </summary>
        public TextEntryViewModel Composition { get; set; }

        #endregion

        #region Fittings Properties

        /// <summary>
        /// The type of the new fittings item
        /// </summary>
        public TextEntryViewModel Type { get; set; }

        /// <summary>
        /// The weight of the new fittings item
        /// </summary>
        public TextEntryViewModel Weight { get; set; }

        #endregion

        #endregion

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

            // Delete this once the real data starts comming up
            Code = new TextEntryViewModel { Label = "Код", OriginalText = "ПР-0001" };
            Name = new TextEntryViewModel { Label = "Наименование", OriginalText = "Наим. пример" };
            Width = new TextEntryViewModel { Label = "Ширина", OriginalText = "1234" };
            Height = new TextEntryViewModel { Label = "Длина", OriginalText = "1234" };
            Commentary = new TextEntryViewModel { Label = "Комментарий", OriginalText = "Пример пример пример пример" };
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