using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importamos
using System.Windows.Input;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Commands;
using Ikaros.Infrastructure.Toolbar;

namespace Ikaros.Modules.Toolbar.ViewModels
{
    public class ToolbarItemViewModel:ToolbarItem
    {
        IEventAggregator _eventAggregator;

        public ToolbarItemViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        private ICommand itemCommand;

        public ICommand ItemCommand
        {
            get 
            {
                if (itemCommand == null)
                {
                    itemCommand= new DelegateCommand<ToolbarItem>(Item);
                }
                return itemCommand; 
            }
        }

        void Item(ToolbarItem item)
        {
            Console.WriteLine("Publicar: " + item.Nombre + "[" + item.ViewName + "]");
            _eventAggregator.GetEvent<ToolbarEvent>().Publish(item);
        }
    }
}
