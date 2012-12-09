using System;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

using Common;
using Module1.Views;
using Module1.Services;

namespace Module1
{
    public class ModuleInit : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager  _regionManager;

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

            // Use View Discovery to automatically display the MasterView when the TopLeft region is displayed.
            _regionManager.RegisterViewWithRegion( RegionNames.TopLeftRegion, () => _container.Resolve<MasterView>() );

            // Register the view types with the container so that it can create them
            // during navigation. Note that the container will attempt to create the
            // view as a named object so the views have to be registered as such.
            _container.RegisterType<Object, EditView>( "EditView" );
            _container.RegisterType<Object, DetailsView>( "DetailsView" );
        }

        #endregion
    }
}
