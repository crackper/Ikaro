using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using Ikaros.Modules.Almacen.Views;

namespace Ikaros.Modules.Almacen.ViewModels
{
    public class ProductosViewModel
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public ProductosViewModel(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;

            ViewName = "Productos";
            ImageUri = "\\Images\\product32x32.png";

            CloseCommand = new DelegateCommand(Close);
            SelectTabCommand = new DelegateCommand(SelectTab);
        }

        public String ViewName { get; set; }
        public String ImageUri { get; set; }

        public ICommand CloseCommand { get; set; }
        public ICommand SelectTabCommand { get; set; }

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

        public void SelectTab()
        {
            ViewName = "Seleeeeeee";
        }
    }
}
