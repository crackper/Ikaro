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
using Ikaros.Infrastructure.Toolbar;
using Ikaros.Modules.Toolbar.Views;

namespace Ikaros.Modules.Toolbar
{
    public class ToolbarModule:IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private readonly IToolbarService _toolbarService;

        public ToolbarModule(IToolbarService toolbarService, IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _container = container;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _toolbarService = toolbarService;
        }

        public void Initialize()
        {
            var view = _container.Resolve<ToolbarView>();
            //
            //_regionManager.Regions["ToolbarRegion"].Add(view);
            //_regionManager.Regions["ToolbarRegion"].Activate(view);  

           // _regionManager.RegisterViewWithRegion("ToolbarRegion", typeof(ToolbarView));
        }
    }
}
