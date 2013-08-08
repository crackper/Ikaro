using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using Ikaros.Infrastructure.Navigation;

namespace Ikaros.Desktop
{
    public class Bootstrapper:UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeModules()
        {
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();

            base.InitializeModules();
        }

        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = this.ModuleCatalog as ModuleCatalog;

           // moduleCatalog.AddModule(typeof(AlmacenModule.AlmacenModule));
            moduleCatalog.AddModule(typeof(Ikaros.Modules.Almacen.AlmacenModule));
            moduleCatalog.AddModule(typeof(Ikaros.Modules.Navigation.NavigationModule));           

            base.ConfigureModuleCatalog();
        }

        protected override void ConfigureContainer()
        {
            RegisterTypeIfMissing(typeof(INavigationService), typeof(NavigationService), true);

            base.ConfigureContainer();
        }
    }
}
