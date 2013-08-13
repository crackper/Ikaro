using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importamos
using System.Collections.ObjectModel;
using System.ComponentModel;
using Ikaros.Infrastructure.MVVM;
using Microsoft.Practices.Prism.Events;
using Ikaros.Infrastructure.Toolbar;

namespace Ikaros.Modules.Toolbar.ViewModels
{
    public class ToolbarViewModel:ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IToolbarService _toolbarService;

        public ToolbarViewModel(IToolbarService toolbarService, IEventAggregator eventAggregator)
        {
            _toolbarService = toolbarService;
            _eventAggregator = eventAggregator;

            toolbarItems = new ObservableCollection<ToolbarItem>();

            foreach (var item in _toolbarService.GetToolbarItems())
            {
                toolbarItems.Add(new ToolbarItemViewModel(_eventAggregator) { 
                    Nombre = item.Nombre,
                    ViewName= item.ViewName,
                    Icon = item.Icon
                });
            }
        }

        private ObservableCollection<ToolbarItem> toolbarItems;
        public ObservableCollection<ToolbarItem> ToolbarItems
        {
            get { return toolbarItems; }
            set 
            {
                if (toolbarItems !=null)
                {
                    toolbarItems = value;
                    RaisePropertyChanged("ToolbarItems");
                }
            }
        }

    }
}
