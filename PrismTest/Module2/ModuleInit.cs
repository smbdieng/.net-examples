using System;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

using Common;
using Module2.Views;
using Module2.Services;

namespace Module2
{
    public class ModuleInit : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public ModuleInit( IUnityContainer container, IRegionManager regionManager )
        {
            _container = container;
            _regionManager = regionManager;
        }

        #region IModule Members

        public void Initialize()
        {
            // Register the DataService concrete type with the container.
            // The DataService's lifetime is controlled by the container so
            // a single instance is created and shared across the application.
            // Change this to swap in another data service implementation.
            _container.RegisterType<IDataService, DataService>( new ContainerControlledLifetimeManager() );

            // Use View Discovery to automatically display the CatalogView when the BottomLeft region is displayed.
            this._regionManager.RegisterViewWithRegion( RegionNames.BottomLeftRegion, () => this._container.Resolve<CatalogView>() );
        }

        #endregion
    }
}
