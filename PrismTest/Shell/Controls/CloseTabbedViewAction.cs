///////////////////////////////////////////////////////////////////////////////
// Copyright (C) 2011 David Hill. All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Interactivity;

using Microsoft.Practices.Prism.Regions;

namespace Shell.Controls
{
    /// <summary>
    /// A Blend trigger action to remove a view from a tab control region.
    /// </summary>
    public class CloseTabbedViewAction : TriggerAction<FrameworkElement>
    {
        protected override void Invoke( object parameter )
        {
            RoutedEventArgs args = parameter as RoutedEventArgs;
            if ( args == null ) return;

            // Find the parent tab item that contains the view to remove.
            TabItem tabItem = FindVisualParent<TabItem>( args.OriginalSource as DependencyObject );

            // Find the parent tab control that represents the region.
            TabControl tabControl = FindVisualParent<TabControl>( tabItem );

            if ( tabControl != null && tabItem != null )
            {
                // Get the view.
                object view = tabItem.Content;

                // Get the region associated with the tab control.
                IRegion region = RegionManager.GetObservableRegion( tabControl ).Value;
                if ( region != null )
                {
                    NavigationContext context = new NavigationContext( region.NavigationService, null );

                    // See if the view (or its view model) supports the INavigationAware interface.
                    // If so, call the OnNavigatedFrom method.
                    NotifyIfImplements<INavigationAware>( view, i => i.OnNavigatedFrom( context ) );

                    // See if the view (or its view model) supports the IConfirmNavigation interface.
                    // If so, call the ConfirmNavigationRequest method. If not, just remove the view from the region. 
                    if ( !NotifyIfImplements<IConfirmNavigationRequest>( view,
                        i => i.ConfirmNavigationRequest( context,
                        canNavigate => { if ( canNavigate ) if ( region != null ) region.Remove( view ); } ) ) )
                    {
                        // Remove the view.
                        region.Remove( view );
                    }
                }
            }
        }

        private T FindVisualParent<T>( DependencyObject node ) where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent( node );
            if ( parent == null || parent is T ) return (T)parent;

            // Recurse up the visual tree.
            return FindVisualParent<T>( parent );
        }

        private T Implementor<T>( object content ) where T : class
        {
            T impl = content as T;
            if ( impl == null )
            {
                FrameworkElement element = content as FrameworkElement;
                if ( element != null ) impl = element.DataContext as T;
            }
            return impl;
        }

        private bool NotifyIfImplements<T>( object content, Action<T> action ) where T : class
        {
            bool notified = false;

            // Get the implementor of the specified interface - either the view or the view model.
            T target = Implementor<T>( content );
            if ( target != null )
            {
                action( target );
                notified = true;
            }
            return notified;
        }
    }
}
