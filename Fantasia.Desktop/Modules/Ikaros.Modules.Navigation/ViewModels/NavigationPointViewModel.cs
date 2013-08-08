using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importamos
using System.Windows.Input;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Commands;
using Ikaros.Infrastructure.Navigation;

namespace Ikaros.Modules.Navigation.ViewModels
{
    public class NavigationPointViewModel : NavigationPoint
    {
        IEventAggregator _eventAggregator;

        public NavigationPointViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        private ICommand navigateCommand;
        public ICommand NavigateCommand
        {
            get
            {
                if (navigateCommand == null)
                {
                    navigateCommand = new DelegateCommand<NavigationPoint>(Navigate);
                }
                return navigateCommand;
            }
        }

        void Navigate(NavigationPoint point)
        {
            Console.WriteLine("Publicar: " + point.Name + " [" + point.Category + "]");
            _eventAggregator.GetEvent<NavigateEvent>().Publish(point);
        }
    }
}
