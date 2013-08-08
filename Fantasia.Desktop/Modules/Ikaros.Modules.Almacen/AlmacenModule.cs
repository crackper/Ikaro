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
using Ikaros.Modules.Almacen.Views;
using Ikaros.Modules.Almacen.ViewModels;

namespace Ikaros.Modules.Almacen
{
    public class AlmacenModule:IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private readonly INavigationService _navigationService;

        public AlmacenModule(INavigationService navigationService, IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _container = container;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
        }

        public void Initialize()
        {
            _container.RegisterType<ProductosView>("ProductosView", new ContainerControlledLifetimeManager());
            _container.RegisterType<ProductosViewModel>();
            
            
            _navigationService.RegisterNavigationPoint(
                new NavigationPoint() { 
                    Name = "Almacen",
                    Category = "Administración",
                    Icon = "\\Images\\administracion.png"
                });

            _eventAggregator.GetEvent<NavigateEvent>().Subscribe(Navigate, true);
        }

        private void Navigate(NavigationPoint point)
        {
            var contentRegion = _regionManager.Regions["MainRegion"];

            if (point.Name == "Almacen" && point.Category == "Administración")
            {             
                var existView = contentRegion.Views.Where(v => v.GetType() == typeof(AlmacenView_Administracion)).SingleOrDefault();

                if (existView != null)
                {
                   contentRegion.Activate(existView);
                }
                else
                {
                    var view = _container.Resolve<AlmacenView_Administracion>();
                    contentRegion.Add(view);
                    contentRegion.Activate(view);
                }
            }
        }
    }
}
