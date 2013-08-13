using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikaros.Infrastructure.Toolbar
{
    public interface IToolbarService
    {
        void RegistrarToolbarItem(ToolbarItem item);
        ToolbarItem[] GetToolbarItems();
        ToolbarItem GetToolbarItemFromArg(string arg);
    }
}
