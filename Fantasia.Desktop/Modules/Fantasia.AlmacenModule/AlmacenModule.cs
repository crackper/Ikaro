using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Events;
using Ikaros.AlmacenModule.Views;
using Ikaros.Infrastructure.Navigation;

namespace Ikaros.AlmacenModule
{
    [Module(ModuleName = "AlmacenModule")]
    public class AlmacenModule:IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private readonly INavigationService _navigationService;
        private readonly EventAggregator _eventAggregator;

        public AlmacenModule(INavigationService navigationService, IRegionManager regionManager, IUnityContainer container, EventAggregator eventAggregator)
        {
            _container = container;
            _regionManager = regionManager;
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
        }

        public void Initialize()
        {
            //_container.RegisterType<ProductosView>("ProductosView", new ContainerControlledLifetimeManager());
            _navigationService.RegisterNavigationPoint(
                new NavigationPoint()
                {
                    Name = "Almacen",
                    Category = "Administracion",
                    ShowInJumpList = true,
                    Icon = "\\Images\\contents.png"
                });

            _eventAggregator.GetEvent<NavigateEvent>().Subscribe(Navigate, true);
        }

        public void Navigate(NavigationPoint point)
        {
            var contentRegion = _regionManager.Regions["MainRegion"];

            if (point.Name == "Almacen" && point.Category == "Administracion")
            {
               var existView = contentRegion.Views.Where(v => v.GetType() == typeof(ProductosView)).SingleOrDefault();


                if (existView != null)
                {
                    contentRegion.Activate(existView);
                }
                else
                {
                    var view = _container.Resolve<ProductosView>();
                    contentRegion.Add(view);
                    contentRegion.Activate(view);
                }
                
            }
        }
    }
}
