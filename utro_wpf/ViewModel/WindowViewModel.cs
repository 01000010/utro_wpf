﻿using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace utro_wpf
{
    /// <summary>
    /// The view model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Memebers

        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The margin around the window
        /// </summary>
        private int mOuterMarginSize = 10;
        
        /// <summary>
        /// The roundness of the windows edges
        /// </summary>
        private int mWindowRadius = 12;

        #endregion

        #region Public Properties

        /// <summary>
        /// The smallest width the window can be
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 600.0;

        /// <summary>
        /// The smallest height the windwo can be
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 600.0;

        /// <summary>
        /// The size of the border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// The new padding for the window's contents
        /// </summary>
        public Thickness InnerBodyPadding { get { return new Thickness(ResizeBorder); } }

        /// <summary>
        /// The new resized border of the window taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// The window's outer margin, for allowing to drop a shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        public Thickness OuterMarginThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// The radius of the window's edges
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }

        /// <summary>
        /// The new corner radius of the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The new corner radius for the hide mask
        /// </summary>
        public CornerRadius ContainerCornerRadius { get { return new CornerRadius(WindowRadius + 4); } }
        
        /// <summary>
        /// The height of the title bar (the top bar of the window)
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to show the system menu for window control
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Defualt constructor for the class
        /// </summary>
        /// <param name="window"></param>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            // Listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>
            {
                // Fire off event for all properties that are affected by a resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            // Initialize the commands
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            // TODO
            // Fix window resize 
            // Gotta fix the bug about the minimum size
            // WindowResizer resizer = new WindowResizer(mWindow);
        }

        #endregion

        #region Helpers
        
        /// <summary>
        /// Gets the current mouse postion on the screen
        /// </summary>
        /// <returns> A point with the current mouse position </returns>
        private Point GetMousePosition()
        {
            Point position = Mouse.GetPosition(mWindow);
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }

        #endregion
    }
}
