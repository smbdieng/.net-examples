using System;
using System.ComponentModel;
using System.Windows.Data;

using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;

using Common;
using Module1.Models;
using Module1.Services;

namespace Module1.ViewModels
{
    /// <summary>
    /// ViewModel for the Master view. Demonstrates Prism's support
    /// for commands, collection views, inter-module communication
    /// and navigation.
    /// </summary>
    public class MasterViewModel : NotificationObject
    {
        private readonly IDataService     _dataService;
        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager   _regionManager;
        private readonly DataItems        _model;

        public MasterViewModel( IDataService dataService, IEventAggregator eventAggregator, IRegionManager regionManager )
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;

            // Get the data model from the data service.
            _model = dataService.GetModel();

            // Initialize the CollectionView for the underlying model.
            DataItemsCV = new ListCollectionView( _model );
            // Track the current selection.
            DataItemsCV.CurrentChanged += new EventHandler( SelectedItemChanged );

            // Initialize the commands.
            NavigateToViewCommand = new DelegateCommand<string>( NavigateToView );
            SyncViewCommand = new DelegateCommand<string>( SyncView );
        }

        #region DataItems CollectionView

        public ICollectionView DataItemsCV { get; private set; }

        private void SelectedItemChanged( object sender, EventArgs e )
        {
            // Publish the DataItemSelected event when the current selection changes.
            DataItem item = DataItemsCV.CurrentItem as DataItem;
            if ( item != null )
            {
                _eventAggregator.GetEvent<DataItemSelectedEvent>().Publish( item.Id );
            }
        }
        #endregion

        #region NavigateToEditView & NavigateToDetailsView Commands

        public DelegateCommand<string> NavigateToViewCommand { get; private set; }
        public DelegateCommand<string> SyncViewCommand { get; private set; }

        private void NavigateToView( string id )
        {
            // Navigate to the EditView, passing the item ID as a navigation parameter.
            // A new EditView instance is created for each item. If an EditView instance
            // for a particular item already exists, it is activated.
            UriQuery parameters = new UriQuery();
            parameters.Add( "ID", id );
            _regionManager.RequestNavigate( RegionNames.MainRegion,
                                            new Uri( "EditView" + parameters.ToString(), UriKind.Relative ),
                                            NavigationCompleted );
        }

        private void SyncView( string id )
        {
            // Navigate to the DetailsView, passing the item ID as a navigation parameter.
            // Only one DetailView instance is created. This instance is activated and
            // updated to display the details of the specified item.
            UriQuery parameters = new UriQuery();
            parameters.Add( "ID", id );
            _regionManager.RequestNavigate( RegionNames.MainRegion,
                                            new Uri( "DetailsView" + parameters.ToString(), UriKind.Relative ),
                                            NavigationCompleted );
        }

        private void NavigationCompleted( NavigationResult navigation )
        {
            // Called when navigation is complete.
            if ( navigation.Result == true )
            {
            }
        }
        #endregion
    }
}
