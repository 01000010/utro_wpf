using PropertyChanged;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace utro_wpf
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #region Command Helpers

        /// <summary>
        /// Runs a command if the updating flag is not set.
        /// If the flag is true (the function is already running) then the action is not run.
        /// If the flag is false (the function is not running) then the action is run.
        /// Once the action if finished if it was run, then the flag is reset.
        /// </summary>
        /// <param name="updatingFlag">The boolean flag</param>
        /// <param name="action">The action to run if the command is not already running</param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            // Check the flag
            if (updatingFlag.GetPropertyValue()) return;
            // If we are running set the flag
            updatingFlag.SetPropertyValue(true);

            try
            {
                await action();
            }
            finally
            {
                // Set the property back to false
                updatingFlag.SetPropertyValue(false);
            }
        }

        #endregion
    }
}