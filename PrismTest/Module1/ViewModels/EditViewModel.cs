using System;
using System.Linq;
using System.ComponentModel;

using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

using Module1.Models;
using Module1.Services;

namespace Module1.ViewModels
{
    /// <summary>
    /// ViewModel for the Edit view. Demonstrates Prism's support
    /// for controlling navigation via the IConfirmNavigationRequest
    /// interface and the use of interaction requests.
    /// </summary>
    public class EditViewModel : NotificationObject, IConfirmNavigationRequest
    {
        private readonly IDataService _dataService;

        public EditViewModel( IDataService dataService )
        {
            _dataService = dataService;

            // Initialize the Navigation Interaction Request .
            navigationInteractionRequest = new InteractionRequest<Confirmation>();
        }

        public DataItem CurrentItem { get; private set; }

        private bool _confirmNavigation;
        public bool ConfirmNavigation
        {
            get { return _confirmNavigation; }
            set { _confirmNavigation = value; base.RaisePropertyChanged<bool>( () => ConfirmNavigation ); }
        }

        private readonly InteractionRequest<Confirmation> navigationInteractionRequest;

        public IInteractionRequest NavigationInteractionRequest
        {
            get { return this.navigationInteractionRequest; }
        }

        #region IConfirmNavigationRequest Members
        public bool IsNavigationTarget( NavigationContext navigationContext )
        {
            // Called to see if this view can handle the navigation request. If it can, this view is activated.

            // Check the ID of the currently displayed item against the ID navigation parameter.
            string id = navigationContext.Parameters["ID"];
            return CurrentItem == null ? false : CurrentItem.Id.Equals( id );
        }

        public void OnNavigatedFrom( NavigationContext navigationContext )
        {
            // Called when this view is deactivated as a result of navigation to another view.
        }

        public void OnNavigatedTo( NavigationContext navigationContext )
        {
            // Called to initialize this view during navigation.

            // The ID of the item to be displayed is passed as a navigation parameter.
            string id = navigationContext.Parameters["ID"];
            if ( !string.IsNullOrEmpty( id ) )
            {
                // Retrieve the specified item using the data service.
                CurrentItem = _dataService.GetModel().FirstOrDefault( item => item.Id == id );
                base.RaisePropertyChanged( "CurrentItem" );
            }
        }

        public void ConfirmNavigationRequest( NavigationContext navigationContext, Action<bool> continuationCallback )
        {
            // Called during a navigation request to confirm or cancel navigation.
            if ( !ConfirmNavigation )
            {
                // No need to confirm navigation with the user so proceed with the navigation request.
                continuationCallback( true );
            }
            else
            {
                // Prompt the user to confirm navigation using the interaction request.
                this.navigationInteractionRequest.Raise(
                    // The viewmodel for the content of the popup window.
                    new Confirmation { Content = "Proceed with navigation?", Title = "Confirm Navigation" },
                    // The callback method - Called when the user has finished with the interaction request.
                    c => { continuationCallback( c.Confirmed ); } );
            }
        }
        #endregion
    }
}
