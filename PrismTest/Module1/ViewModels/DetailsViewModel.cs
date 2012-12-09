using System.Linq;
using System.ComponentModel;

using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Regions;

using Module1.Models;
using Module1.Services;

namespace Module1.ViewModels
{
    /// <summary>
    /// ViewModel for the Details view. Demonstrates Prism's support
    /// for controlling navigation via the INavigationAware
    /// interface.
    /// </summary>
    public class DetailsViewModel : NotificationObject, INavigationAware
    {
        private readonly IDataService _dataService;

        public DetailsViewModel( IDataService dataService )
        {
            _dataService = dataService;
        }

        public DataItem CurrentItem { get; private set; }

        #region INavigationAware Members
        public bool IsNavigationTarget( NavigationContext navigationContext )
        {
            // Called to see if this view can handle the navigation request. If it can, this view is activated.

            // This view is always the navigation target so return true.
            return true;
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
        #endregion
    }
}
