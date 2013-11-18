using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importamos
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Commands;
using System.Windows.Input;
using Ikaros.Infrastructure.Navigation;
using Ikaros.Infrastructure.MVVM;
using Ikaros.Infrastructure.Administration;
using Ikaros.Modules.Almacen.Views;
using System.Windows.Threading;
using System.Windows.Controls;
using Ikaro.Service;

namespace Ikaros.Modules.Almacen.ViewModels
{
    public class AlmacenAdministracionViewModel:AdministrationViewModel
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;
        private IProductoService _productoService;
        

        public AlmacenAdministracionViewModel(IUnityContainer container, IRegionManager regionManager,IProductoService productoService)
        {
            _container = container;
            _regionManager = regionManager;

            ViewName = "Almacen .::. Administracion";
            ImageUri = "\\Images\\almacen24x24.png";

            CloseCommand = new DelegateCommand(Close);
            SelectViewCommand = new DelegateCommand(SelectView);

            Actions.Add(new AdministrationActionViewModel()
            {
                Action = (p) => {
                    IsBusy = true;

                    Dispatcher.CurrentDispatcher.BeginInvoke((Action)delegate 
                        {
                           var _view = _container.Resolve<ProductosView>();
                            _view.DataContext = new ProductosViewModel(container, regionManager,productoService);//_container.Resolve<ProductosViewModel>(); //

                            AddViewtoMainRegion(_view);        
                           
                            IsBusy = false;
                        },DispatcherPriority.Background);
                },
                Category = "Mantenimientos",
                Title = "Productos",
                Icon = "\\Images\\product32x32.png"
            });

            Actions.Add(new AdministrationActionViewModel()
            {
                Action = (p) =>
                {
                    IsBusy = true;

                    Dispatcher.CurrentDispatcher.BeginInvoke((Action)delegate
                    {
                        var _view = _container.Resolve<CategoriasView>();
                        _view.DataContext = new CategoriasViewModel(container, regionManager);

                        AddViewtoMainRegion(_view);

                        IsBusy = false;
                    }, DispatcherPriority.Background);
                },
                Category = "Mantenimientos",
                Title = "Categorias",
                Icon = "\\Images\\category32x32.png"
            });
        }

        public String ViewName { get; set; }
        public String ImageUri { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand SelectViewCommand { get; set; }

        private void Close()
        {
            var region = _regionManager.Regions["MainRegion"];
            var view = region.Views.Where(v => v.GetType() == typeof(AlmacenView_Administracion)).Single();
            
            if (view != null)
            {
                region.Deactivate(view);
                region.Remove(view);
            }
        }

        public void SelectView()
        {
            System.Windows.MessageBox.Show("Seleccionaste la vista");
        }

        private void AddViewtoMainRegion(UserControl view)
        {
            var region = _regionManager.Regions["MainRegion"];

            var viewExiste = region.Views.Where(v => v.GetType() == view.GetType()).SingleOrDefault();

            if (viewExiste != null)
            {
               region.Activate(viewExiste);
            }
            else
            {
                region.Add(view);
                region.Activate(view);
            }
        }
    }
}
