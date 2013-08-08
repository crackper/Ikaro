using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importamos
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using Ikaros.Infrastructure.Navigation;
using Ikaros.Modules.Navigation.Views;


namespace Ikaros.Modules.Navigation
{
    public class NavigationModule:IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private readonly INavigationService _navigationService;

        public NavigationModule(INavigationService navigationService, IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _container = container;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
        }

        public void Initialize()
        {
           // _container.RegisterType<NavigationView>();

            var view = _container.Resolve<NavigationView>();
            //
            _regionManager.Regions["NavigationRegion"].Add(view);
            _regionManager.Regions["NavigationRegion"].Activate(view);    
        }
    }
}
