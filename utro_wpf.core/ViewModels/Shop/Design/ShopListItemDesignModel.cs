using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utro_wpf.core
{
    /// <summary>
    /// The design model for <see cref="ShopListItemViewModel"/>... to preview what we do in design.
    /// </summary>
    public class ShopListItemDesignModel : ShopListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ShopListItemDesignModel Instance => new ShopListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ShopListItemDesignModel()
        {
            ItemName = "EXAMPLE NAME";
            ItemDescription = "Example description for the item.";
        }

        #endregion
    }
}
