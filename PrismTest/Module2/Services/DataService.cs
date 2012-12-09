using System;

using Module2.Models;

namespace Module2.Services
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
                model.Add( new DataItem() { Id = "1", CatalogRef = "#31245-1111", SKU = "923-25-3412", InStock = false } );
                model.Add( new DataItem() { Id = "2", CatalogRef = "#89324-9314", SKU = "943-55-2212", InStock = true } );
                model.Add( new DataItem() { Id = "3", CatalogRef = "#11262-7312", SKU = "623-26-3892", InStock = false } );
                model.Add( new DataItem() { Id = "4", CatalogRef = "#38257-2214", SKU = "823-21-2412", InStock = true } );
            }

            return model;
        }
    }
}
