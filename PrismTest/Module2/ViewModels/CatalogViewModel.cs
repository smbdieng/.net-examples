using System.Linq;
using System.ComponentModel;

using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Events;

using Common;
using Module2.Models;
using Module2.Services;

namespace Module2.ViewModels
{
    /// <summary>
    /// ViewModel for the Catalog view. Demonstrates Prism's support for
    /// loosely-coupled events for communication between modules and components.
    /// </summary>
    public class CatalogViewModel : NotificationObject
    {
        private readonly IDataService     _dataService;
        private readonly IEventAggregator _eventAggregator;

        public CatalogViewModel( IDataService dataService, IEventAggregator eventAggregator )
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;

            // Subscribe to the DataItemSelected event.
            _eventAggregator.GetEvent<DataItemSelectedEvent>().Subscribe( DataItemSelected, true );
        }

        private void DataItemSelected( string id )
        {
            if ( !string.IsNullOrEmpty( id ) )
            {
                CurrentItem = _dataService.GetModel().FirstOrDefault( item => item.Id == id );
                base.RaisePropertyChanged( "CurrentItem" );
            }
        }

        public DataItem CurrentItem { get; private set; }
    }
}
