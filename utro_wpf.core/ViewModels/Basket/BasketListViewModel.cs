using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utro_wpf.core
{
    /// <summary>
    /// A view model for the list of items
    /// </summary>
    public class BasketListViewModel : BaseViewModel
    {
        /// <summary>
        /// The item's name
        /// </summary>
        public List<BasketListItemViewModel> Items { get; set; }
    }
}
