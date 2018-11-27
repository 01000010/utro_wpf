using System.Windows.Input;

namespace utro_wpf.core
{
    /// <summary>
    /// The design-time data for a <see cref="ManagerViewModel"/>
    /// </summary>
    public class ManagerDesignModel : ManagerViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ManagerDesignModel Instance => new ManagerDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ManagerDesignModel()
        {
            // Let's use a product item as an example
            Code = new TextEntryViewModel { Label = "Код", OriginalText = "ПР-0001" };
            Name = new TextEntryViewModel { Label = "Наименование", OriginalText = "Наим. пример" };
            Width = new TextEntryViewModel { Label = "Ширина", OriginalText = "1234" };
            Height = new TextEntryViewModel { Label = "Длина", OriginalText = "1234" };
            Commentary = new TextEntryViewModel { Label = "Комментарий", OriginalText = "Пример пример пример пример" };
        }

        #endregion
    }
}