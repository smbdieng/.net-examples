using System;
using System.Windows;
using System.Windows.Interactivity;

using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

namespace Module1
{
    /// <summary>
    /// A simple Blend trigger action to display a message box so that
    /// the user can confirm or reject navigation.
    /// </summary>
    class ConfirmNavigationAction : TriggerAction<FrameworkElement>
    {
        protected override void Invoke( object parameter )
        {
            InteractionRequestedEventArgs args = parameter as InteractionRequestedEventArgs;
            if ( args == null ) return;

            MessageBoxResult result = MessageBox.Show( args.Context.Content.ToString(), args.Context.Title, MessageBoxButton.YesNo );
            if ( result == MessageBoxResult.Yes )
            {
                Confirmation c = args.Context as Confirmation;
                c.Confirmed = true;
            }

            args.Callback();
        }
    }
}
