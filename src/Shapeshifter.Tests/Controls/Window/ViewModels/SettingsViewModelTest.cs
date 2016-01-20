﻿namespace Shapeshifter.WindowsDesktop.Controls.Window.ViewModels
{
    using Autofac;

    using Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using NSubstitute;

    using Services.Interfaces;

    [TestClass]
    public class SettingsViewModelTest: TestBase
    {
        static string GetRunRegistryPath()
        {
            return @"Software\Microsoft\Windows\CurrentVersion\Run";
        }

        [TestMethod]
        public void StartWithWindowsIsTrueWhenRunKeyIsAdded()
        {
            var container = CreateContainer(
                c => {
                    c.RegisterFake<IRegistryManager>()
                        .GetValue(
                            GetRunRegistryPath(),
                            "Shapeshifter")
                        .Returns("somePath");
                });

            var settingsViewModel = container.Resolve<ISettingsViewModel>();
            Assert.IsTrue(settingsViewModel.StartWithWindows);
        }

        [TestMethod]
        public void StartWithWindowsIsFalseWhenRunKeyIsNotPresent()
        {
            var container = CreateContainer(
                c => {
                    c.RegisterFake<IRegistryManager>()
                        .GetValue(
                            GetRunRegistryPath(),
                            "Shapeshifter")
                        .Returns((string)null);
                });

            var settingsViewModel = container.Resolve<ISettingsViewModel>();
            Assert.IsTrue(settingsViewModel.StartWithWindows);
        }
    }
}