using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikaros.Infrastructure.Toolbar
{
    public class ToolbarItem
    {
        public string Nombre { get; set; }
        public string ViewName { get; set; }
        public string Icon { get; set; }

        public string CreateArg()
        {
            return Nombre.Replace(' ', '_') + "_" + ViewName.Replace(' ', '_');
        }
    }
}
