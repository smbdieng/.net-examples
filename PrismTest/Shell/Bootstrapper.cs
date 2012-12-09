﻿using System;
using System.Windows;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;

using Shell.Views;

namespace Shell
{
    public partial class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            // Create the module catalog from a XAML file.
            return Microsoft.Practices.Prism.Modularity.ModuleCatalog.CreateFromXaml(
                        new Uri( "/Shell;component/ModuleCatalog.xaml", UriKind.Relative ) );
        }

        protected override DependencyObject CreateShell()
        {
            // Use the container to create an instance of the shell.
            ShellView view = Container.TryResolve<ShellView>();

            // Display the shell's root visual.
            view.Show();

            return view;
        }
    }
}

