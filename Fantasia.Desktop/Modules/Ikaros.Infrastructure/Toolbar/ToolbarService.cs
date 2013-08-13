using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikaros.Infrastructure.Toolbar
{
    public class ToolbarService:IToolbarService
    {
        readonly List<ToolbarItem> _toolbarItems;

        public ToolbarService()
        {
            _toolbarItems = new List<ToolbarItem>();
        }

        public void RegistrarToolbarItem(ToolbarItem item)
        {
            _toolbarItems.Add(item);
        }

        public ToolbarItem[] GetToolbarItems()
        {
           return _toolbarItems.ToArray();
        }

        public ToolbarItem GetToolbarItemFromArg(string arg)
        {
            return _toolbarItems.SingleOrDefault(p=>arg == p.CreateArg());
        }
    }
}
