using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Regions;
using Fantasia.AlmacenModule.Views;

namespace Fantasia.AlmacenModule
{
    public class AlmacenModule:IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public AlmacenModule(IRegionManager regionManager,IUnityContainer container)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterType<ProductosView>();

            _regionManager.RegisterViewWithRegion("MainRegion",typeof(ProductosView));
        }
    }
}
