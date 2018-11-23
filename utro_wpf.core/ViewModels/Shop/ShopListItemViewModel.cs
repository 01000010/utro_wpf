using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utro_wpf.core
{
    /// <summary>
    /// A view model for each basket item in the basket list
    /// </summary>
    public class ShopListItemViewModel : BaseViewModel
    {
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
    }
}
