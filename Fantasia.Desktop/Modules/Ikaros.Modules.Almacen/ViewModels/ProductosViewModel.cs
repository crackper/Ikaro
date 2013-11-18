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
using System.Windows;
using System.Collections.ObjectModel;
using Ikaro.Core.Domain;
using Ikaro.Service;

namespace Ikaros.Modules.Almacen.ViewModels
{
    public class ProductosViewModel:NotificationObject
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;
        private IProductoService _productoService;
        private ObservableCollection<Producto> _productos;
        private string _criterioBusqueda = "";        

        public ProductosViewModel(IUnityContainer container, IRegionManager regionManager,IProductoService productoService )
        {
            _container = container;
            _regionManager = regionManager;
            _productoService = productoService;

            ViewName = "Productos";
            ImageUri = "\\Images\\product32x32.png";

            BuscarProductos();

            CloseCommand = new DelegateCommand(Close);
            SelectViewCommand = new DelegateCommand(SelectView);
            BuscarCommand = new DelegateCommand(BuscarProductos);
        }

        public String ViewName { get; set; }
        public String ImageUri { get; set; }

        public ICommand CloseCommand { get; set; }
        public ICommand SelectViewCommand { get; set; }
        public ICommand BuscarCommand { get; set; }

        public ObservableCollection<Producto> Productos
        {
            get { return _productos; }
            set { _productos = value; }
        }

        public string CriterioBusqueda
        {
            get { return _criterioBusqueda; }
            set { _criterioBusqueda = value; }
        }

        void BuscarProductos() 
        {
            _productos = new ObservableCollection<Producto>(_productoService.GetProductoByCriterio(CriterioBusqueda));
            this.RaisePropertyChanged(()=>Productos);
        }

        private void Close()
        {

            var result = MessageBox.Show("Desea Cerrar la Vista de Productos", "Ikaros", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var region = _regionManager.Regions["MainRegion"];

                var view = region.Views.Where(v => v.GetType() == typeof(ProductosView)).Single();
                if (view != null)
                {
                    region.Deactivate(view);
                    region.Remove(view);
                }
            }            
        }

        public void SelectView()
        {
            MessageBox.Show("Seleccionaste la vista");
        }
    }
}
