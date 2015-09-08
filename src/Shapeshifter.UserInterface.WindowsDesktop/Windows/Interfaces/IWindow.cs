﻿using System;
using System.Windows.Interop;

namespace Shapeshifter.UserInterface.WindowsDesktop.Windows.Interfaces
{
    public interface IWindow
    {
        event EventHandler SourceInitialized;

        HwndSource HandleSource { get; }

        void Show();
    }
}