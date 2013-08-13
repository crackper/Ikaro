using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using Ikaros.Modules.Almacen.Views;
using Ikaros.Infrastructure.Toolbar;
using Ikaros.Modules.Toolbar.Views;
using Ikaros.Modules.Toolbar.ViewModels;

namespace Ikaros.Modules.Almacen.ViewModels
{
    public class ProductosViewModel
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;
        private IToolbarService _toolbarService;
        private readonly IEventAggregator _eventAggregator;

        public ProductosViewModel(IUnityContainer container, IRegionManager regionManager, IToolbarService toolbarService,IEventAggregator eventAggregator)
        {
            _container = container;
            _regionManager = regionManager;
            _toolbarService = toolbarService;
            _eventAggregator = eventAggregator;

            ViewName = "Productos";
            ImageUri = "\\Images\\product32x32.png";

            CloseCommand = new DelegateCommand(Close);
            SelectViewCommand = new DelegateCommand(SelectView);

            _toolbarService.RegistrarToolbarItem(new ToolbarItem() { 
                Nombre = "Guardar",
                ViewName = ViewName,
                Icon = ImageUri
            });

            _eventAggregator.GetEvent<ToolbarEvent>().Subscribe(Item, true);


            var view = _container.Resolve<ToolbarView>();
            var viewModel = _container.Resolve<ToolbarViewModel>();

            view.DataContext = viewModel;

            _regionManager.Regions["ToolbarRegion"].Add(view);
            _regionManager.Regions["ToolbarRegion"].Activate(view);  
        }

        private void Item(ToolbarItem item)
        {
            System.Windows.MessageBox.Show("Guardar");
        }

        public String ViewName { get; set; }
        public String ImageUri { get; set; }

        public ICommand CloseCommand { get; set; }
        public ICommand SelectViewCommand { get; set; }

        private void Close()
        {

            var region = _regionManager.Regions["MainRegion"];

            var view = region.Views.Where(v => v.GetType() == typeof(ProductosView)).Single();
            if (view != null)
            {
                region.Deactivate(view);
                region.Remove(view);
            }
        }

        public void SelectView()
        {
            System.Windows.MessageBox.Show("Seleccionaste la vista");
            _regionManager.RequestNavigate("ToolbarRegion", "ToolbarView");
        }
    }
}
