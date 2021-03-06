﻿namespace Shapeshifter.WindowsDesktop.Controls.Window.ViewModels.Interfaces
{
    using System.ComponentModel;
    using System.Windows.Input;

    using Infrastructure.Dependencies.Interfaces;

    public interface ISettingsViewModel: INotifyPropertyChanged, ISingleInstance
    {
        bool StartWithWindows { get; set; }

		bool IsQuietModeEnabled { get; set; }

        int PasteDurationBeforeUserInterfaceShowsInMilliseconds { get; set; }

        string HotkeyString { get; }

        void OnReceiveKeyDown(Key key);
    }
}