using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utro_wpf
{
    /// <summary>
    /// The design model for <see cref="BasketListItemViewModel"/>... to preview what we do in design.
    /// </summary>
    public class BasketListItemDesignModel : BasketListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static BasketListItemDesignModel Instance => new BasketListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasketListItemDesignModel()
        {
            ItemName = "EXAMPLE NAME";
            ItemDescription = "Example description for the item.";
        }

        #endregion
    }
}
