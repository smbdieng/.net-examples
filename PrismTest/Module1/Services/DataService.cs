using System;

using Module1.Models;

namespace Module1.Services
{
    /// <summary>
    /// Dummy data service class. Provides a dummy data model.
    /// Replace with your real data model and/or data service proxy.
    /// </summary>
    public class DataService : IDataService
    {
        private DataItems model;

        public DataItems GetModel()
        {
            if ( model == null )
            {
                model = new DataItems();

                // Dummy Data.
                model.Add( new DataItem() { Id = "1", Name = "Item 1", Description = "Description 1" } );
                model.Add( new DataItem() { Id = "2", Name = "Item 2", Description = "Description 2" } );
                model.Add( new DataItem() { Id = "3", Name = "Item 3", Description = "Description 3" } );
                model.Add( new DataItem() { Id = "4", Name = "Item 4", Description = "Description 4" } );
            }

            return model;
        }
    }
}
