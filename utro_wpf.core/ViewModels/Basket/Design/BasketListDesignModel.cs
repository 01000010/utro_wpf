using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utro_wpf.core
{
    /// <summary>
    /// The design model for <see cref="BasketListViewModel"/>... to preview what we do in design.
    /// </summary>
    public class BasketListDesignModel : BasketListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static BasketListDesignModel Instance => new BasketListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasketListDesignModel()
        {
            Items = new List<BasketListItemViewModel>
            {
                new BasketListItemViewModel
                {
                    ItemName = "Example name #1",
                    ItemDescription = "Some item's descripton #1"
                },
                new BasketListItemViewModel
                {
                    ItemName = "Example name #2",
                    ItemDescription = "Some item's descripton #2"
                },
                new BasketListItemViewModel
                {
                    ItemName = "Example name #3",
                    ItemDescription = "Some item's descripton #3",
                    IsSelected = true
                },
                new BasketListItemViewModel
                {
                    ItemName = "Example name #4",
                    ItemDescription = "Some item's descripton #4"
                },
                new BasketListItemViewModel
                {
                    ItemName = "Example name #5",
                    ItemDescription = "Some item's descripton #5"
                },
                new BasketListItemViewModel
                {
                    ItemName = "Example name #6",
                    ItemDescription = "Some item's descripton #6"
                },
                new BasketListItemViewModel
                {
                    ItemName = "Example name #7",
                    ItemDescription = "Some item's descripton #7"
                }
            };
        }

        #endregion
    }
}
