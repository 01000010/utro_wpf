using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace utro_wpf.core
{
    /// <summary>
    /// A view model for each basket item in the basket list
    /// </summary>
    public class BasketListItemViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The item's name
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// The item's description
        /// </summary>
        public string ItemDescription { get; set; }

        /// <summary>
        /// Is the current item the selected one?
        /// </summary>
        public bool IsSelected { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand SelectCommand { get; set; }

        #endregion

        #region Constructor

        public BasketListItemViewModel()
        {
            // SelectCommand = new RelayParameterizedCommand(async (parameter) => await SelectCommand(parameter));
            SelectCommand = new RelayCommand(() => Select());
        }

        #endregion

        #region Commands

        public void Select()
        {
            IsSelected ^= true;
        }

        #endregion
    }
}
